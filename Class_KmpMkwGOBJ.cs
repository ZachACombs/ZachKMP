using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>A GOBJ entry</summary>
    public class KmpMkwGOBJEntry
    {
        ///<summary>Object ID to identify object.<br/>
        ///Bits 12 and 13 (mask 0x3000) are used as special feature by the Extended presence flags.
        ///</summary>
        public ushort ObjectId
        {
            set
            {
                Var_ObjectId = value;
            }
            get
            {
                return Var_ObjectId;
            }
        }
        private ushort Var_ObjectId;

        ///<summary>Padding. This member is part of the Extended presence flags. So make sure the value is zero if this object don't use the extension.</summary>
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
        private ushort Var_Padding;

        ///<summary>A 3D position vector of the object.</summary>
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

        ///<summary>A 3D rotation vector of the object.</summary>
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

        ///<summary>A 3D scale vector of the object.</summary>
        public Vector3 Scale
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
        private Vector3 Var_Scale;

        ///<summary>Index in POTI section of route used by object</summary>
        public ushort RouteIndex
        {
            set
            {
                Var_RouteIndex = value;
            }
            get
            {
                return Var_RouteIndex;
            }
        }
        private ushort Var_RouteIndex;

        ///<summary>Setting 1 for object</summary>
        public ushort Setting1 { set { Var_Setting1 = value; } get { return Var_Setting1; } }
        private ushort Var_Setting1;

        ///<summary>Setting 2 for object</summary>
        public ushort Setting2 { set { Var_Setting2 = value; } get { return Var_Setting2; } }
        private ushort Var_Setting2;

        ///<summary>Setting 3 for object</summary>
        public ushort Setting3 { set { Var_Setting3 = value; } get { return Var_Setting3; } }
        private ushort Var_Setting3;

        ///<summary>Setting 4 for object</summary>
        public ushort Setting4 { set { Var_Setting4 = value; } get { return Var_Setting4; } }
        private ushort Var_Setting4;

        ///<summary>Setting 5 for object</summary>
        public ushort Setting5 { set { Var_Setting5 = value; } get { return Var_Setting5; } }
        private ushort Var_Setting5;

        ///<summary>Setting 6 for object</summary>
        public ushort Setting6 { set { Var_Setting6 = value; } get { return Var_Setting6; } }
        private ushort Var_Setting6;

        ///<summary>Setting 7 for object</summary>
        public ushort Setting7 { set { Var_Setting7 = value; } get { return Var_Setting7; } }
        private ushort Var_Setting7;

        ///<summary>Setting 8 for object</summary>
        public ushort Setting8 { set { Var_Setting8 = value; } get { return Var_Setting8; } }
        private ushort Var_Setting8;

        ///<summary>Presence flags. Nintendo defines bits 0–5 (mask 0x3f). The other bits (6–15, mask 0xffc0) will be used by the Extended presence flags. So make sure these bits are cleared if this object don't use the extension.</summary>
        public ushort PresenceFlags
        {
            set
            {
                Var_PresenceFlags = value;
            }
            get
            {
                return Var_PresenceFlags;
            }
        }
        private ushort Var_PresenceFlags;

        ///<summary>Creates a GOBJ entry</summary>
        ///<param name="objectId">Object ID to identify object.<br/>
        ///Bits 12 and 13 (mask 0x3000) are used as special feature by the Extended presence flags.</param>
        ///<param name="padding">Padding. This member is part of the Extended presence flags. So make sure the value is zero if this object don't use the extension.</param>
        ///<param name="position">A 3D position vector of the object.</param>
        ///<param name="rotation">A 3D rotation vector of the object.</param>
        ///<param name="scale">A 3D scale vector of the object.</param>
        ///<param name="routeIndex">Index in POTI section of route used by object</param>
        ///<param name="setting1">Setting 1 for object</param>
        ///<param name="setting2">Setting 2 for object</param>
        ///<param name="setting3">Setting 3 for object</param>
        ///<param name="setting4">Setting 4 for object</param>
        ///<param name="setting5">Setting 5 for object</param>
        ///<param name="setting6">Setting 6 for object</param>
        ///<param name="setting7">Setting 7 for object</param>
        ///<param name="setting8">Setting 8 for object</param>
        ///<param name="presenceFlags">Presence flags. Nintendo defines bits 0–5 (mask 0x3f). The other bits (6–15, mask 0xffc0) will be used by the Extended presence flags. So make sure these bits are cleared if this object don't use the extension.</param>
        public KmpMkwGOBJEntry(ushort objectId, ushort padding, 
            Vector3 position, Vector3 rotation, Vector3 scale, ushort routeIndex,
            ushort setting1, ushort setting2, ushort setting3, ushort setting4,
            ushort setting5, ushort setting6, ushort setting7, ushort setting8,
            ushort presenceFlags)
        {
            Var_ObjectId = objectId;
            Var_Padding = padding;
            Var_Position = position;
            Var_Rotation = rotation;
            Var_Scale = scale;
            Var_RouteIndex = routeIndex;
            Var_Setting1 = setting1;
            Var_Setting2 = setting2;
            Var_Setting3 = setting3;
            Var_Setting4 = setting4;
            Var_Setting5 = setting5;
            Var_Setting6 = setting6;
            Var_Setting7 = setting7;
            Var_Setting8 = setting8;
            Var_PresenceFlags = presenceFlags;
        }
    }

    ///<summary>A GOBJ section</summary>
    public class KmpMkwGOBJSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwGOBJEntry> Var_Entries;
        public KmpEntryList<KmpMkwGOBJEntry> Entries
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
                KmpMkwGOBJEntry entry = Var_Entries[n];
                rawData.AddRange(ByteConverter.GetBytes(entry.ObjectId));
                rawData.AddRange(ByteConverter.GetBytes(entry.Padding));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Scale.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Scale.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Scale.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.RouteIndex));
                rawData.AddRange(ByteConverter.GetBytes(entry.Setting1));
                rawData.AddRange(ByteConverter.GetBytes(entry.Setting2));
                rawData.AddRange(ByteConverter.GetBytes(entry.Setting3));
                rawData.AddRange(ByteConverter.GetBytes(entry.Setting4));
                rawData.AddRange(ByteConverter.GetBytes(entry.Setting5));
                rawData.AddRange(ByteConverter.GetBytes(entry.Setting6));
                rawData.AddRange(ByteConverter.GetBytes(entry.Setting7));
                rawData.AddRange(ByteConverter.GetBytes(entry.Setting8));
                rawData.AddRange(ByteConverter.GetBytes(entry.PresenceFlags));
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwGOBJSection() : base("GOBJ")
        {
            Var_Entries = new KmpEntryList<KmpMkwGOBJEntry>();
        }
        public KmpMkwGOBJSection(KmpMkwGOBJEntry[] entries) : base("GOBJ")
        {
            Var_Entries = new KmpEntryList<KmpMkwGOBJEntry>(entries);
        }
        public KmpMkwGOBJSection(GenericKmpSection section) : base("GOBJ")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwGOBJEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x3C; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwGOBJEntry(
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x00],
                        rawData[offset + 0x01] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x02],
                        rawData[offset + 0x03] }),
                    new Vector3(
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x04],
                            rawData[offset + 0x05],
                            rawData[offset + 0x06],
                            rawData[offset + 0x07] }),
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
                    new Vector3(
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x10],
                            rawData[offset + 0x11],
                            rawData[offset + 0x12],
                            rawData[offset + 0x13] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x14],
                            rawData[offset + 0x15],
                            rawData[offset + 0x16],
                            rawData[offset + 0x17] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x18],
                            rawData[offset + 0x19],
                            rawData[offset + 0x1A],
                            rawData[offset + 0x1B] })
                        ),
                    new Vector3(
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x1C],
                            rawData[offset + 0x1D],
                            rawData[offset + 0x1E],
                            rawData[offset + 0x1F] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x20],
                            rawData[offset + 0x21],
                            rawData[offset + 0x22],
                            rawData[offset + 0x23] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x24],
                            rawData[offset + 0x25],
                            rawData[offset + 0x26],
                            rawData[offset + 0x27] })
                        ),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x28],
                        rawData[offset + 0x29] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x2A],
                        rawData[offset + 0x2B] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x2C],
                        rawData[offset + 0x2D] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x2E],
                        rawData[offset + 0x2F] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x30],
                        rawData[offset + 0x31] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x32],
                        rawData[offset + 0x33] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x34],
                        rawData[offset + 0x35] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x36],
                        rawData[offset + 0x37] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x38],
                        rawData[offset + 0x39] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x3A],
                        rawData[offset + 0x3B] })
                    ));
            }
        }
    }
}
