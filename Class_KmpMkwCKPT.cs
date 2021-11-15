using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>A CKPT entry</summary>
    public class KmpMkwCKPTEntry
    {
        ///<summary>A 2D position vector (X and Z coordinate) of the left point of the check point line.</summary>
        public Vector2 LeftPoint
        {
            set
            {
                Var_LeftPoint = value;
            }
            get
            {
                return Var_LeftPoint;
            }
        }
        private Vector2 Var_LeftPoint;

        ///<summary>A 2D position vector (X and Z coordinate) of the right point of the check point line.</summary>
        public Vector2 RightPoint
        {
            set
            {
                Var_RightPoint = value;
            }
            get
            {
                return Var_RightPoint;
            }
        }
        private Vector2 Var_RightPoint;

        ///<summary>A zero based index link into the JGPT section to respawn players once they have entered this checkpoint.</summary>
        public byte RespawnIndex
        {
            set
            {
                Var_RespawnIndex = value;
            }
            get
            {
                return Var_RespawnIndex;
            }
        }
        private byte Var_RespawnIndex;

        ///<summary>Checkpoint type<br/>
        ///0x00: Lap Count Trigger<br/>
        ///0x01 - 0xFE: Key checkpoint<br/>
        ///0xFF: Normal Checkpoint
        ///</summary>
        public byte CheckpointType
        {
            set
            {
                Var_CheckpointType = value;
            }
            get
            {
                return Var_CheckpointType;
            }
        }
        private byte Var_CheckpointType;

        ///<summary>Previous check point in this group's sequence; 0xFF for the first point of the group.</summary>
        public byte PreviousCheckpoint
        {
            set
            {
                Var_PreviousCheckpoint = value;
            }
            get
            {
                return Var_PreviousCheckpoint;
            }
        }
        private byte Var_PreviousCheckpoint;

        ///<summary>Next check point in this group's sequence; 0xFF for the last point of the group.</summary>
        public byte NextCheckpoint
        {
            set
            {
                Var_NextCheckpoint = value;
            }
            get
            {
                return Var_NextCheckpoint;
            }
        }
        private byte Var_NextCheckpoint;

        public KmpMkwCKPTEntry(Vector2 leftPoint, Vector2 rightPoint, byte respawnIndex, byte checkpointType, byte prevCheckpoint, byte nextCheckpoint)
        {
            Var_LeftPoint = leftPoint;
            Var_RightPoint = rightPoint;
            Var_RespawnIndex = respawnIndex;
            Var_CheckpointType = checkpointType;
            Var_PreviousCheckpoint = prevCheckpoint;
            Var_NextCheckpoint = nextCheckpoint;
        }
    }

    ///<summary>A CKPT section</summary>
    public class KmpMkwCKPTSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwCKPTEntry> Var_Entries;
        public KmpEntryList<KmpMkwCKPTEntry> Entries
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
                KmpMkwCKPTEntry entry = Var_Entries[n];
                rawData.AddRange(ByteConverter.GetBytes(entry.LeftPoint.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.LeftPoint.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.RightPoint.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.RightPoint.Y));
                rawData.Add(entry.RespawnIndex);
                rawData.Add(entry.CheckpointType);
                rawData.Add(entry.PreviousCheckpoint);
                rawData.Add(entry.NextCheckpoint);
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwCKPTSection() : base("CKPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwCKPTEntry>();
        }
        public KmpMkwCKPTSection(KmpMkwCKPTEntry[] entries) : base("CKPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwCKPTEntry>(entries);
        }
        public KmpMkwCKPTSection(GenericKmpSection section) : base("CKPT")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwCKPTEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x14; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwCKPTEntry(
                    new Vector2(
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x00],
                            rawData[offset + 0x01],
                            rawData[offset + 0x02],
                            rawData[offset + 0x03] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x04],
                            rawData[offset + 0x05],
                            rawData[offset + 0x06],
                            rawData[offset + 0x07] })
                        ),
                    new Vector2(
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x08],
                            rawData[offset + 0x09],
                            rawData[offset + 0x0A],
                            rawData[offset + 0x0B] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x0C],
                            rawData[offset + 0x0D],
                            rawData[offset + 0x0E],
                            rawData[offset + 0x0F] })
                        ),
                    rawData[offset + 0x10],
                    rawData[offset + 0x11],
                    rawData[offset + 0x12],
                    rawData[offset + 0x13]
                    ));
            }
        }
    }
}
