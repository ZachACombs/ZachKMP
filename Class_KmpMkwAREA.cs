using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>An AREA entry</summary>
    public class KmpMkwAREAEntry
    {
        ///<summary>Area shape: 0 = box; 1 = cylinder</summary>
        public byte AreaShape
        {
            set
            {
                Var_AreaShape = value;
            }
            get
            {
                return Var_AreaShape;
            }
        }
        private byte Var_AreaShape;

        ///<summary><see href="http://wiki.tockdom.com/wiki/AREA_type">Area type</see>: 0x00–0x0A</summary>
        public byte AreaType
        {
            set
            {
                Var_AreaType = value;
            }
            get
            {
                return Var_AreaType;
            }
        }
        private byte Var_AreaType;

        ///<summary>Index of CAME if type = 0x00, 0xFF else.</summary>
        public byte CAMEIndex
        {
            set
            {
                Var_CAMEIndex = value;
            }
            get
            {
                return Var_CAMEIndex;
            }
        }
        private byte Var_CAMEIndex;

        ///<summary>Priority value; a higher number means a higher priority to choose which area activates if multiple areas are intersected.</summary>
        public byte PriorityValue
        {
            set
            {
                Var_PriorityValue = value;
            }
            get
            {
                return Var_PriorityValue;
            }
        }
        private byte Var_PriorityValue;

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
        private Vector3 Var_Position;

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

        ///<summary>AREA setting 1. Used by AREA type 2, 3, 6, 8 and 9.</summary>
        public ushort Setting1
        {
            set
            {
                Var_Setting1 = value;
            }
            get
            {
                return Var_Setting1;
            }
        }
        private ushort Var_Setting1;

        ///<summary>AREA setting 2. Used by AREA type 6 and 3.</summary>
        public ushort Setting2
        {
            set
            {
                Var_Setting2 = value;
            }
            get
            {
                return Var_Setting2;
            }
        }
        private ushort Var_Setting2;

        ///<summary>Route ID used by AREA type 3.</summary>
        public byte RouteId
        {
            set
            {
                Var_RouteId = value;
            }
            get
            {
                return Var_RouteId;
            }
        }
        private byte Var_RouteId;

        ///<summary>Enemy point ID. This value is used by AREA type 4.</summary>
        public byte EnemyPointId
        {
            set
            {
                Var_EnemyPointId = value;
            }
            get
            {
                return Var_EnemyPointId;
            }
        }
        private byte Var_EnemyPointId;

        ///<summary>Padding? Always 0 in Nintendo tracks.</summary>
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

        ///<summary>Creates an AREA Entry</summary>
        /// <param name="areaShape">Area shape: 0 = box; 1 = cylinder</param>
        /// <param name="areaType"><see href="http://wiki.tockdom.com/wiki/AREA_type">Area type</see>: 0x00–0x0A</param>
        /// <param name="cameIndex">Index of CAME if type = 0x00, 0xFF else.</param>
        /// <param name="priorityValue">Priority value; a higher number means a higher priority to choose which area activates if multiple areas are intersected.</param>
        /// <param name="position">A 3D position vector of the start position.</param>
        /// <param name="rotation">A 3D rotation vector of the start position.</param>
        /// <param name="scale">A 3D scale vector of the object.</param>
        /// <param name="setting1">AREA setting 1. Used by AREA type 2, 3, 6, 8 and 9.</param>
        /// <param name="setting2">AREA setting 2. Used by AREA type 6 and 3.</param>
        /// <param name="routeId">Route ID used by AREA type 3.</param>
        /// <param name="enemyPointId">Enemy point ID. This value is used by AREA type 4.</param>
        public KmpMkwAREAEntry(byte areaShape, byte areaType, byte cameIndex, byte priorityValue, 
            Vector3 position, Vector3 rotation, Vector3 scale,
            ushort setting1, ushort setting2, byte routeId, byte enemyPointId)
        {
            AreaShape = areaShape;
            AreaType = areaType;
            CAMEIndex = cameIndex;
            PriorityValue = priorityValue;
            Position = position;
            Rotation = rotation;
            Scale = scale;
            Setting1 = setting1;
            Setting2 = setting2;
            RouteId = routeId;
            EnemyPointId = enemyPointId;
            Padding = 0;
        }

        ///<summary>Creates an AREA Entry</summary>
        /// <param name="areaShape">Area shape: 0 = box; 1 = cylinder</param>
        /// <param name="areaType"><see href="http://wiki.tockdom.com/wiki/AREA_type">Area type</see>: 0x00–0x0A</param>
        /// <param name="cameIndex">Index of CAME if type = 0x00, 0xFF else.</param>
        /// <param name="priorityValue">Priority value; a higher number means a higher priority to choose which area activates if multiple areas are intersected.</param>
        /// <param name="position">A 3D position vector of the start position.</param>
        /// <param name="rotation">A 3D rotation vector of the start position.</param>
        /// <param name="scale">A 3D scale vector of the object.</param>
        /// <param name="setting1">AREA setting 1. Used by AREA type 2, 3, 6, 8 and 9.</param>
        /// <param name="setting2">AREA setting 2. Used by AREA type 6 and 3.</param>
        /// <param name="routeId">Route ID used by AREA type 3.</param>
        /// <param name="enemyPointId">Enemy point ID. This value is used by AREA type 4.</param>
        /// <param name="padding">Padding? Always 0 in Nintendo tracks.</param>
        public KmpMkwAREAEntry(byte areaShape, byte areaType, byte cameIndex, byte priorityValue,
            Vector3 position, Vector3 rotation, Vector3 scale,
            ushort setting1, ushort setting2, byte routeId, byte enemyPointId, ushort padding)
        {
            AreaShape = areaShape;
            AreaType = areaType;
            CAMEIndex = cameIndex;
            PriorityValue = priorityValue;
            Position = position;
            Rotation = rotation;
            Scale = scale;
            Setting1 = setting1;
            Setting2 = setting2;
            RouteId = routeId;
            EnemyPointId = enemyPointId;
            Padding = padding;
        }
    }

    ///<summary>An AREA section</summary>
    public class KmpMkwAREASection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwAREAEntry> Var_Entries;
        public KmpEntryList<KmpMkwAREAEntry> Entries
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
                KmpMkwAREAEntry entry = Var_Entries[n];
                rawData.Add(entry.AreaShape);
                rawData.Add(entry.AreaType);
                rawData.Add(entry.CAMEIndex);
                rawData.Add(entry.PriorityValue);
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Scale.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Scale.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Scale.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Setting1));
                rawData.AddRange(ByteConverter.GetBytes(entry.Setting2));
                rawData.Add(entry.RouteId);
                rawData.Add(entry.EnemyPointId);
                rawData.AddRange(ByteConverter.GetBytes(entry.Padding));
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwAREASection() : base("AREA")
        {
            Var_Entries = new KmpEntryList<KmpMkwAREAEntry>();
        }
        public KmpMkwAREASection(KmpMkwAREAEntry[] entries) : base("AREA")
        {
            Var_Entries = new KmpEntryList<KmpMkwAREAEntry>(entries);
        }
        public KmpMkwAREASection(GenericKmpSection section) : base("AREA")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwAREAEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x30; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwAREAEntry(
                    rawData[offset + 0x00],
                    rawData[offset + 0x01],
                    rawData[offset + 0x02],
                    rawData[offset + 0x03],
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
                        rawData[offset + 0x29]
                        }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x2A],
                        rawData[offset + 0x2B]
                        }),
                    rawData[offset + 0x2C],
                    rawData[offset + 0x2D],
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x2E],
                        rawData[offset + 0x2F]
                        })
                    ));
            }
        }
    }
}
