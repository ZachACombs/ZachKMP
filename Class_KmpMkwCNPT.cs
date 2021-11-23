using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>A CNPT entry</summary>
    public class KmpMkwCNPTEntry
    {
        ///<summary>A 3D destination of the cannon. This point defines <b>a destination tangent or border of a ball around the cannon</b>, which is the landing zone. (Think of a 2D circle with a cannon in the middle.)</summary>
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

        ///<summary>A 3D angle vector of the direction to release players from the cannon in. The second value (Y-rotation from cannon start point) is the most important value because it declares the <b>shooting direction</b>. The players fly in the entered direction until they reach the defined tangent.<br/>
        ///If the X value is >0.0 and ≤100.0, it is possible that a driver turns right or left if landing. See <see href="https://youtu.be/bMd117MYqik#t=36s">this video</see> as an example.</summary>
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

        ///<summary>The <b>ID</b> of this cannon position. For all Nintendo tracks, the value is set to the index. This value seems to be irrelevant. <b>For the <see href="http://wiki.tockdom.com/wiki/KCL_flag">KCL flag</see>, the zero-based index is important</b>.</summary>
        public ushort CannonId
        {
            set
            {
                Var_CannonId = value;
            }
            get
            {
                return Var_CannonId;
            }
        }
        private ushort Var_CannonId;

        ///<summary><b>Shoot effect</b>: 0 (same as -1 or 0xFFFF) is straight, 1 is curved, 2 is curved and slow. See <see href="http://wiki.tockdom.com/wiki/Cannon#Cannon_Properties">Cannon Properties</see> for details.</summary>
        public short ShootEffect
        {
            set
            {
                Var_ShootEffect = value;
            }
            get
            {
                return Var_ShootEffect;
            }
        }
        private short Var_ShootEffect;

        ///<summary>Creates a CNPT entry</summary>
        ///<param name="position">A 3D destination of the cannon. This point defines <b>a destination tangent or border of a ball around the cannon</b>, which is the landing zone. (Think of a 2D circle with a cannon in the middle.)</param>
        ///<param name="rotation">A 3D angle vector of the direction to release players from the cannon in. The second value (Y-rotation from cannon start point) is the most important value because it declares the <b>shooting direction</b>. The players fly in the entered direction until they reach the defined tangent.<br/>
        ///If the X value is >0.0 and ≤100.0, it is possible that a driver turns right or left if landing. See <see href="https://youtu.be/bMd117MYqik#t=36s">this video</see> as an example.</param>
        ///<param name="cannonId">The <b>ID</b> of this cannon position. For all Nintendo tracks, the value is set to the index. This value seems to be irrelevant. <b>For the <see href="http://wiki.tockdom.com/wiki/KCL_flag">KCL flag</see>, the zero-based index is important</b>.</param>
        ///<param name="shootEffect"><b>Shoot effect</b>: 0 (same as -1 or 0xFFFF) is straight, 1 is curved, 2 is curved and slow. See <see href="http://wiki.tockdom.com/wiki/Cannon#Cannon_Properties">Cannon Properties</see> for details.</param>
        public KmpMkwCNPTEntry(Vector3 position, Vector3 rotation, ushort cannonId, short shootEffect)
        {
            Position = position;
            Rotation = rotation;
            CannonId = cannonId;
            ShootEffect = shootEffect;
        }
    }

    ///<summary>A CNPT section</summary>
    public class KmpMkwCNPTSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwCNPTEntry> Var_Entries;
        public KmpEntryList<KmpMkwCNPTEntry> Entries
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
                KmpMkwCNPTEntry entry = Var_Entries[n];
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.CannonId));
                rawData.AddRange(ByteConverter.GetBytes(entry.ShootEffect));
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwCNPTSection() : base("CNPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwCNPTEntry>();
        }
        public KmpMkwCNPTSection(KmpMkwCNPTEntry[] entries) : base("CNPT")
        {
            Var_Entries = new KmpEntryList<KmpMkwCNPTEntry>(entries);
        }
        public KmpMkwCNPTSection(GenericKmpSection section) : base("CNPT")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwCNPTEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x1C; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwCNPTEntry(
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
