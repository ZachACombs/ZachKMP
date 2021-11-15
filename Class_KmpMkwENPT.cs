using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>An ENPT entry</summary>
    public class KmpMkwENPTEntry
    {
        private Vector3 Var_Position;
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

        private float Var_Scale;
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

        private ushort Var_PointSetting1;
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

        private byte Var_PointSetting2;
        ///<summary>Point setting 2</summary>
        public byte PointSetting2
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

        private byte Var_PointSetting3;
        ///<summary>Point setting 3</summary>
        public byte PointSetting3
        {
            set
            {
                Var_PointSetting3 = value;
            }
            get
            {
                return Var_PointSetting3;
            }
        }

        ///<summary>Creates an ENPT entry</summary>
        ///<param name="position">A 3D position vector of the enemy position.</param>
        ///<param name="scale">The size of the area, use a low value for narrow sections of the track and a big value for big sections.</param>
        ///<param name="pointSetting1">Point setting 1</param>
        ///<param name="pointSetting2">Point setting 2</param>
        ///<param name="pointSetting3">Point setting 3</param>
        public KmpMkwENPTEntry(Vector3 position, float scale, ushort pointSetting1, byte pointSetting2, byte pointSetting3)
        {
            Var_Position = position;
            Var_Scale = scale;
            Var_PointSetting1 = pointSetting1;
            Var_PointSetting2 = pointSetting2;
            Var_PointSetting3 = pointSetting3;
        }
    }

    ///<summary>An ENPT Section</summary>
    public class KmpMkwENPTSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwENPTEntry> Var_Entries;
        public KmpEntryList<KmpMkwENPTEntry> Entries
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
                KmpMkwENPTEntry entry = Var_Entries[n];
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Scale));
                rawData.AddRange(ByteConverter.GetBytes(entry.PointSetting1));
                rawData.Add(entry.PointSetting2);
                rawData.Add(entry.PointSetting3);
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwENPTSection() : base("ENPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwENPTEntry>();
        }
        public KmpMkwENPTSection(KmpMkwENPTEntry[] entries) : base("ENPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwENPTEntry>(entries);
        }
        public KmpMkwENPTSection(GenericKmpSection section) : base("ENPT")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwENPTEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x14; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwENPTEntry(
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
                    rawData[offset + 0x12],
                    rawData[offset + 0x13]
                    ));
            }
        }
    }
}
