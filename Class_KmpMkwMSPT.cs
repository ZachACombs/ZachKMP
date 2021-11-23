using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>A MSPT entry</summary>
    public class KmpMkwMSPTEntry
    {
        ///<summary>A 3D position vector of this point.</summary>
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

        ///<summary>A 3D angle vector of this point.</summary>
        public Vector3 Rotation
        {
            set
            {
                Var_Rotation = value;
            }
            get
            {
                return Var_Rotation;
            }
        }
        private Vector3 Var_Rotation;

        ///<summary>The ID of this entry. For all Nintendo tracks, the value is set to the index. The usage is unknown.</summary>
        public ushort PointId
        {
            set
            {
                Var_PointId = value;
            }
            get
            {
                return Var_PointId;
            }
        }
        private ushort Var_PointId;

        ///<summary><b>Unknown</b>.</summary>
        public ushort Unknown
        {
            set
            {
                Var_Unknown = value;
            }
            get
            {
                return Var_Unknown;
            }
        }
        private ushort Var_Unknown;

        ///<summary>Creates a MSPT entry</summary>
        ///<param name="position">A 3D position vector of this point.</param>
        ///<param name="rotation">A 3D angle vector of this point.</param>
        ///<param name="pointId">The ID of this entry. For all Nintendo tracks, the value is set to the index. The usage is unknown.</param>
        public KmpMkwMSPTEntry(Vector3 position, Vector3 rotation, ushort pointId) : this(position, rotation, pointId, 0xFFFF)
        {

        }
        ///<summary>Creates a MSPT entry</summary>
        ///<param name="position">A 3D position vector of this point.</param>
        ///<param name="rotation">A 3D angle vector of this point.</param>
        ///<param name="pointId">The ID of this entry. For all Nintendo tracks, the value is set to the index. The usage is unknown.</param>
        ///<param name="unknown"><b>Unknown</b>.</param>
        public KmpMkwMSPTEntry(Vector3 position, Vector3 rotation, ushort pointId, ushort unknown)
        {
            Position = position;
            Rotation = rotation;
            PointId = pointId;
            Unknown = unknown;
        }
    }

    ///<summary>A MSPT section</summary>
    public class KmpMkwMSPTSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwMSPTEntry> Var_Entries;
        public KmpEntryList<KmpMkwMSPTEntry> Entries
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
                KmpMkwMSPTEntry entry = Var_Entries[n];
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.PointId));
                rawData.AddRange(ByteConverter.GetBytes(entry.Unknown));
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwMSPTSection() : base("MSPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwMSPTEntry>();
        }
        public KmpMkwMSPTSection(KmpMkwMSPTEntry[] entries) : base("MSPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwMSPTEntry>(entries);
        }
        public KmpMkwMSPTSection(GenericKmpSection section) : base("MSPT")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwMSPTEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x1C; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwMSPTEntry(
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
                    new Vector3(
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x0C],
                            rawData[offset + 0x0D],
                            rawData[offset + 0x0E],
                            rawData[offset + 0x0F] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x10],
                            rawData[offset + 0x11],
                            rawData[offset + 0x12],
                            rawData[offset + 0x13] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x14],
                            rawData[offset + 0x15],
                            rawData[offset + 0x16],
                            rawData[offset + 0x17] })
                        ),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x18],
                        rawData[offset + 0x19] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x1A],
                        rawData[offset + 0x1B] })
                    ));
            }
        }
    }
}
