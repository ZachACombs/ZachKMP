using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>A JGPT entry</summary>
    public class KmpMkwJGPTEntry
    {
        ///<summary>A <b>3D position vector</b> of the respawn position.</summary>
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

        ///<summary>A 3D <b>rotation vector</b> to define the direction for the players.</summary>
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

        ///<summary>The ID of this respawn position. For all Nintendo tracks, the value is set to the index. The usage is unknown and links of the CKPT section points to the index and are not related to this ID (tested by <see href="http://wiki.tockdom.com/wiki/Wiimm">Wiimm</see>).</summary>
        public ushort RespawnId
        {
            set
            {
                Var_RespawnId = value;
            }
            get
            {
                return Var_RespawnId;
            }
        }
        private ushort Var_RespawnId;

        ///<summary>Range. The value divided by 100 and modulo 100 have separate unknown meanings. The divided value can be any number from zero to eight. In Mario Kart Wii, the value is -1 (0xffff) or the remainder is always 99.</summary>
        public short Range
        {
            set
            {
                Var_Range = value;
            }
            get
            {
                return Var_Range;
            }
        }
        private short Var_Range;

        ///<summary>Creates a GOBJ entry</summary>
        ///<param name="position">A <b>3D position vector</b> of the respawn position.</param>
        ///<param name="rotation">A 3D <b>rotation vector</b> to define the direction for the players.</param>
        ///<param name="respawnId">The ID of this respawn position. For all Nintendo tracks, the value is set to the index. The usage is unknown and links of the CKPT section points to the index and are not related to this ID (tested by <see href="http://wiki.tockdom.com/wiki/Wiimm">Wiimm</see>).</param>
        ///<param name="range">Range. The value divided by 100 and modulo 100 have separate unknown meanings. The divided value can be any number from zero to eight. In Mario Kart Wii, the value is -1 (0xffff) or the remainder is always 99.</param>
        public KmpMkwJGPTEntry(Vector3 position, Vector3 rotation, ushort respawnId, short range)
        {
            Position = position;
            Rotation = rotation;
            RespawnId = respawnId;
            Range = range;
        }
    }

    ///<summary>A JGPT section</summary>
    public class KmpMkwJGPTSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwJGPTEntry> Var_Entries;
        public KmpEntryList<KmpMkwJGPTEntry> Entries
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
                KmpMkwJGPTEntry entry = Var_Entries[n];
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.RespawnId));
                rawData.AddRange(ByteConverter.GetBytes(entry.Range));
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwJGPTSection() : base("JGPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwJGPTEntry>();
        }
        public KmpMkwJGPTSection(KmpMkwJGPTEntry[] entries) : base("JGPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwJGPTEntry>(entries);
        }
        public KmpMkwJGPTSection(GenericKmpSection section) : base("JGPT")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwJGPTEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x1C; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwJGPTEntry(
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
                    ByteConverter.ToInt16(new byte[] {
                        rawData[offset + 0x1A],
                        rawData[offset + 0x1B] })
                    ));
            }
        }
    }
}
