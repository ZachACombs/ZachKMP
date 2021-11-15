using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>A route point in a POTI section</summary>
    public class KmpMkwPOTIPoint
    {
        ///<summary>A 3D position vector of the route position.</summary>
        public Vector3 Position
        {
            set
            {
                Var_Position = value;
            }
            get
            {
                return Var_Position;
            }
        }
        private Vector3 Var_Position;

        ///<summary>Route point settings. If used for speed or time, the value is based of 1/60s.</summary>
        public ushort PointSettings
        {
            set
            {
                Var_PointSettings = value;
            }
            get
            {
                return Var_PointSettings;
            }
        }
        private ushort Var_PointSettings;

        ///<summary>Additional settings, depend on the object.</summary>
        public ushort AdditionalSettings
        {
            set
            {
                Var_AdditionalSettings = value;
            }
            get
            {
                return Var_AdditionalSettings;
            }
        }
        private ushort Var_AdditionalSettings;

        ///<summary>Creates a route point for the POTI section</summary>
        ///<param name="position">A 3D position vector of the route position.</param>
        ///<param name="pointSettings">Route point settings. If used for speed or time, the value is based of 1/60s.</param>
        ///<param name="additionalSettings">Additional settings, depend on the object.</param>
        public KmpMkwPOTIPoint(Vector3 position, ushort pointSettings, ushort additionalSettings)
        {
            Var_Position = position;
            Var_PointSettings = pointSettings;
            Var_AdditionalSettings = additionalSettings;
        }
    }

    ///<summary>A POTI Entry</summary>
    public class KmpMkwPOTIEntry
    {
        ///<summary>Points in route</summary>
        public KmpEntryList<KmpMkwPOTIPoint> Points
        {
            get
            {
                return Var_Points;
            }
        }
        private KmpEntryList<KmpMkwPOTIPoint> Var_Points;

        ///<summary>Route setting 1; 0 or 1 in Nintendo's tracks.
        ///    <list type="bullet">
        ///    <item><description>0: Object or camera goes directly from point to point with a hard direction change.</description></item>
        ///    <item><description>1: Enables a smooth motion. <b>The game will freeze if this setting is used on a route with two or less points.</b></description></item>
        ///    </list></summary>
        public byte RouteSetting1
        {
            set
            {
                Var_RouteSetting1 = value;
            }
            get
            {
                return Var_RouteSetting1;
            }
        }
        private byte Var_RouteSetting1;

        ///<summary>Route setting 2; 0 or 1 in Nintendo's tracks.
        ///    <list type="bullet">
        ///    <item><description>0: Use route cyclic(go to first point after leaving last point).</description></item>
        ///    <item><description>1: Use route forward, then backward, then forward and so on.</description></item>
        ///    </list></summary>
        public byte RouteSetting2
        {
            set
            {
                Var_RouteSetting2 = value;
            }
            get
            {
                return Var_RouteSetting2;
            }
        }
        private byte Var_RouteSetting2;

        ///<summary>Creates a POTI entry</summary>
        ///<param name="routeSetting1">Route setting 1; 0 or 1 in Nintendo's tracks.
        ///    <list type="bullet">
        ///    <item><description>0: Object or camera goes directly from point to point with a hard direction change.</description></item>
        ///    <item><description>1: Enables a smooth motion. <b>The game will freeze if this setting is used on a route with two or less points.</b></description></item>
        ///    </list></param>
        ///<param name="routeSetting2">Route setting 2; 0 or 1 in Nintendo's tracks.
        ///    <list type="bullet">
        ///    <item><description>0: Use route cyclic(go to first point after leaving last point).</description></item>
        ///    <item><description>1: Use route forward, then backward, then forward and so on.</description></item>
        ///    </list></param>
        public KmpMkwPOTIEntry(byte routeSetting1, byte routeSetting2)
        {
            Var_Points = new KmpEntryList<KmpMkwPOTIPoint>();
            Var_RouteSetting1 = routeSetting1;
            Var_RouteSetting2 = routeSetting2;
        }
        ///<summary>Creates a POTI entry</summary>
        ///<param name="points">Points in route</param>
        ///<param name="routeSetting1">Route setting 1; 0 or 1 in Nintendo's tracks.
        ///    <list type="bullet">
        ///    <item><description>0: Object or camera goes directly from point to point with a hard direction change.</description></item>
        ///    <item><description>1: Enables a smooth motion. <b>The game will freeze if this setting is used on a route with two or less points.</b></description></item>
        ///    </list></param>
        ///<param name="routeSetting2">Route setting 2; 0 or 1 in Nintendo's tracks.
        ///    <list type="bullet">
        ///    <item><description>0: Use route cyclic(go to first point after leaving last point).</description></item>
        ///    <item><description>1: Use route forward, then backward, then forward and so on.</description></item>
        ///    </list></param>
        public KmpMkwPOTIEntry(KmpMkwPOTIPoint[] points, byte routeSetting1, byte routeSetting2)
        {
            Var_Points = new KmpEntryList<KmpMkwPOTIPoint>(points);
            Var_RouteSetting1 = routeSetting1;
            Var_RouteSetting2 = routeSetting2;
        }
    }

    ///<summary>A POTI Section</summary>
    public class KmpMkwPOTISection : KmpSection
    {
        private KmpEntryList<KmpMkwPOTIEntry> Var_Entries;
        public KmpEntryList<KmpMkwPOTIEntry> Entries
        {
            get
            {
                return Var_Entries;
            }
        }
        public override ushort GetEntryCount()
        {
            return Var_Entries.Count;
        }

        private string Var_SectionName;
        public override string GetSectionName()
        {
            return Var_SectionName;
        }

        private ushort Var_AdditionalValue;
        public override ushort GetAdditionalValue()
        {
            ushort pointCount = 0;
            for (int n = 0; n < Var_Entries.Count; n += 1)
                pointCount += Var_Entries[n].Points.Count;
            return pointCount;
        }

        public GenericKmpSection ToGenericKmpSection()
        {
            List<byte> rawData = new List<byte>();
            for (int n = 0; n < Var_Entries.Count; n += 1)
            {
                KmpMkwPOTIEntry entry = Var_Entries[n];
                rawData.AddRange(ByteConverter.GetBytes(entry.Points.Count));
                rawData.Add(entry.RouteSetting1);
                rawData.Add(entry.RouteSetting2);
                for (int m = 0; m < entry.Points.Count; m += 1)
                {
                    KmpMkwPOTIPoint point = entry.Points[m];
                    rawData.AddRange(ByteConverter.GetBytes(point.Position.X));
                    rawData.AddRange(ByteConverter.GetBytes(point.Position.Y));
                    rawData.AddRange(ByteConverter.GetBytes(point.Position.Z));
                    rawData.AddRange(ByteConverter.GetBytes(point.PointSettings));
                    rawData.AddRange(ByteConverter.GetBytes(point.AdditionalSettings));
                }
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwPOTISection()
        {
            Var_SectionName = "POTI";
            Var_Entries = new KmpEntryList<KmpMkwPOTIEntry>();
        }
        public KmpMkwPOTISection(KmpMkwPOTIEntry[] entries)
        {
            Var_SectionName = "POTI";
            Var_Entries = new KmpEntryList<KmpMkwPOTIEntry>(entries);
        }
        public KmpMkwPOTISection(GenericKmpSection section)
        {
            Var_SectionName = "POTI";

            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwPOTIEntry>();

            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x04; //Length of each entry (Not including points)
            int pointLength = 0x10; //Length of each point
            int pos = 0;
            for (int n = 0; n < entryCount; n += 1)
            {
                if ((pos + entryLength) > rawData.Length)
                    throw new FormatException("Raw data ends before all entries are defined");
                ushort pointCount = ByteConverter.ToUInt16(new byte[] {
                    rawData[pos + 0x00],
                    rawData[pos + 0x01]
                    });
                byte routeSetting1 = rawData[pos + 0x02];
                byte routeSetting2 = rawData[pos + 0x03];
                pos += entryLength;
                if ((pos + (pointLength * pointCount)) > rawData.Length)
                    throw new FormatException("Raw data ends before all entries are defined");
                KmpMkwPOTIPoint[] points = new KmpMkwPOTIPoint[pointCount];
                for (int m = 0; m < pointCount; m += 1)
                {
                    points[m] = new KmpMkwPOTIPoint(
                        new Vector3(
                            ByteConverter.ToSingle(new byte[] {
                                rawData[pos + 0x00],
                                rawData[pos + 0x01],
                                rawData[pos + 0x02],
                                rawData[pos + 0x03] }),
                            ByteConverter.ToSingle(new byte[] {
                                rawData[pos + 0x04],
                                rawData[pos + 0x05],
                                rawData[pos + 0x06],
                                rawData[pos + 0x07] }),
                            ByteConverter.ToSingle(new byte[] {
                                rawData[pos + 0x08],
                                rawData[pos + 0x09],
                                rawData[pos + 0x0A],
                                rawData[pos + 0x0B] })
                            ),
                        ByteConverter.ToUInt16(new byte[] {
                            rawData[pos + 0x0C],
                            rawData[pos + 0x0D]
                            }),
                        ByteConverter.ToUInt16(new byte[] {
                            rawData[pos + 0x0E],
                            rawData[pos + 0x0F]
                            })
                        );
                    pos += pointLength;
                }
                Var_Entries.Add(new KmpMkwPOTIEntry(
                    points,
                    routeSetting1,
                    routeSetting2));
            }
        }
    }
}
