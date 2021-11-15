using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>A KTPT entry</summary>
    public class KmpMkwKTPTEntry
    {
        private Vector3 Var_Position;
        ///<summary>A 3D position vector of the start position.</summary>
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

        private Vector3 Var_Rotation;
        ///<summary>A 3D rotation vector of the start position.</summary>
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

        private short Var_PlayerIndex;
        ///<summary>The player index.<br/>
        ///For races, the first entry is used to define a start area, independent of its value (usually set to -1=0xffff).<br/>
        ///In battle courses, the value determines which players start here.Values 0 to 5 are for the red team and values 6 to 11 are for the blue team.The order of the entries is irrelevant.
        ///</summary>
        public short PlayerIndex
        {
            set
            {
                Var_PlayerIndex = value;
            }
            get
            {
                return Var_PlayerIndex;
            }
        }

        private ushort Var_Padding;
        ///<summary>Padding (probably doesn't need to be set)</summary>
        public ushort Padding
        {
            set
            {
                Var_Padding = value;
            }
            get
            {
                return Var_Padding;
            }
        }

        ///<summary>Creates a KTPT entry</summary>
        ///<param name="position">A 3D position vector of the start position.</param>
        ///<param name="rotation">A 3D rotation vector of the start position.</param>
        ///<param name="playerIndex">The player index.</param>
        public KmpMkwKTPTEntry(Vector3 position, Vector3 rotation, short playerIndex)
        {
            Position = position;
            Rotation = rotation;
            PlayerIndex = playerIndex;
            Padding = 0;
        }
    }

    ///<summary>A KTPT section</summary>
    public class KmpMkwKTPTSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwKTPTEntry> Var_Entries;
        public KmpEntryList<KmpMkwKTPTEntry> Entries
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
                KmpMkwKTPTEntry entry = Var_Entries[n];
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.PlayerIndex));
                rawData.AddRange(ByteConverter.GetBytes(entry.Padding));
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwKTPTSection() : base("KTPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwKTPTEntry>();
        }
        public KmpMkwKTPTSection(KmpMkwKTPTEntry[] entries) : base("KTPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwKTPTEntry>(entries);
        }
        public KmpMkwKTPTSection(GenericKmpSection section) : base("KTPT")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwKTPTEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x1C; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwKTPTEntry(
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
                    ByteConverter.ToInt16(new byte[] {
                        rawData[offset + 0x18],
                        rawData[offset + 0x19]
                        })
                    ));
            }
        }
    }
}
