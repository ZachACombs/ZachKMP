using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>An ITPT entry</summary>
    public class KmpMkwITPTEntry
    {
        ///<summary>A 3D position vector of the enemy position.</summary>
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

        ///<summary>The size of the area, use a low value for narrow sections of the track and a big value for big sections.</summary>
        public float Scale
        {
            set
            {
                Var_Scale = value;
            }
            get
            {
                return Var_Scale;
            }
        }
        private float Var_Scale;

        ///<summary>Point setting 1</summary>
        public ushort PointSetting1
        {
            set
            {
                Var_PointSetting1 = value;
            }
            get
            {
                return Var_PointSetting1;
            }
        }
        private ushort Var_PointSetting1;

        ///<summary>Point setting 2</summary>
        public ushort PointSetting2
        {
            set
            {
                Var_PointSetting2 = value;
            }
            get
            {
                return Var_PointSetting2;
            }
        }
        private ushort Var_PointSetting2;

        ///<summary>Creates an ENPT entry</summary>
        ///<param name="position">A 3D position vector of the enemy position.</param>
        ///<param name="scale">The size of the area, use a low value for narrow sections of the track and a big value for big sections.</param>
        ///<param name="pointSetting1">Point setting 1</param>
        ///<param name="pointSetting2">Point setting 2</param>
        public KmpMkwITPTEntry(Vector3 position, float scale, ushort pointSetting1, ushort pointSetting2)
        {
            Var_Position = position;
            Var_Scale = scale;
            Var_PointSetting1 = pointSetting1;
            Var_PointSetting2 = pointSetting2;
        }
    }

    ///<summary>An ITPT Section</summary>
    public class KmpMkwITPTSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwITPTEntry> Var_Entries;
        public KmpEntryList<KmpMkwITPTEntry> Entries
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

        public override GenericKmpSection ToGenericKmpSection()
        {
            List<byte> rawData = new List<byte>();
            for (int n = 0; n < Var_Entries.Count; n += 1)
            {
                KmpMkwITPTEntry entry = Var_Entries[n];
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Scale));
                rawData.AddRange(ByteConverter.GetBytes(entry.PointSetting1));
                rawData.AddRange(ByteConverter.GetBytes(entry.PointSetting2));
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwITPTSection() : base("ITPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwITPTEntry>();
        }
        public KmpMkwITPTSection(KmpMkwITPTEntry[] entries) : base("ITPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwITPTEntry>(entries);
        }
        public KmpMkwITPTSection(GenericKmpSection section) : base("ITPT")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwITPTEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x14; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwITPTEntry(
                    new Vector3(
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x00],
                            rawData[offset + 0x01],
                            rawData[offset + 0x02],
                            rawData[offset + 0x03] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x04],
                            rawData[offset + 0x05],
                            rawData[offset + 0x06],
                            rawData[offset + 0x07] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x08],
                            rawData[offset + 0x09],
                            rawData[offset + 0x0A],
                            rawData[offset + 0x0B] })
                        ),
                    ByteConverter.ToSingle(new byte[] {
                        rawData[offset + 0x0C],
                        rawData[offset + 0x0D],
                        rawData[offset + 0x0E],
                        rawData[offset + 0x0F] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x10],
                        rawData[offset + 0x11] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x12],
                        rawData[offset + 0x13] })
                    ));
            }
        }
    }
}
