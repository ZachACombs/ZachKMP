using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>A CAME Entry</summary>
    public class KmpMkwCAMEEntry
    {
        ///<summary><see href="http://wiki.tockdom.com/wiki/Camera#CAME_Types">Camera type</see></summary>
        public byte CameraType
        {
            set
            {
                Var_CameraType = value;
            }
            get
            {
                return Var_CameraType;
            }
        }
        private byte Var_CameraType;

        ///<summary><b>Next camera</b> entry index. Value 0xFF means: no next camera.</summary>
        public byte NextCameraIndex
        {
            set
            {
                Var_NextCameraIndex = value;
            }
            get
            {
                return Var_NextCameraIndex;
            }
        }
        private byte Var_NextCameraIndex;

        ///<summary>Camshake. <b>Exact meanings unknown</b>.</summary>
        public byte Camshake
        {
            set
            {
                Var_Camshake = value;
            }
            get
            {
                return Var_Camshake;
            }
        }
        private byte Var_Camshake;

        ///<summary>Index in POTI section of route used by camera. The value 0xFF means "no route".</summary>
        public byte RouteIndex
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
        private byte Var_RouteIndex;

        ///<summary><b>Velocity of the camera point</b> in units per 100/60 sec (=distance/1.67 sec).</summary>
        public ushort CameraPointVelocity
        {
            set
            {
                Var_CameraPointVelocity = value;
            }
            get
            {
                return Var_CameraPointVelocity;
            }
        }
        private ushort Var_CameraPointVelocity;

        ///<summary><b>Velocity of zooming</b> in units per 100/60 sec (=units/1.67 sec) (tested with <see href="http://wiki.tockdom.com/wiki/Camera#CAME_Types">camera type 5</see>).</summary>
        public ushort ZoomVelocity
        {
            set
            {
                Var_ZoomVelocity = value;
            }
            get
            {
                return Var_ZoomVelocity;
            }
        }
        private ushort Var_ZoomVelocity;

        ///<summary><b>Velocity of the view point</b> in distance per 100/60 sec (=distance/1.67 sec) (tested with <see href="http://wiki.tockdom.com/wiki/Camera#CAME_Types">camera type 5</see>).</summary>
        public ushort ViewPointVelocity
        {
            set
            {
                Var_ViewPointVelocity = value;
            }
            get
            {
                return Var_ViewPointVelocity;
            }
        }
        private ushort Var_ViewPointVelocity;

        ///<summary>Start flag. <b>Exact meanings unknown</b>.</summary>
        public byte StartFlag
        {
            set
            {
                Var_StartFlag = value;
            }
            get
            {
                return Var_StartFlag;
            }
        }
        private byte Var_StartFlag;

        ///<summary>Movie flag. <b>Exact meanings unknown</b>.</summary>
        public byte MovieFlag
        {
            set
            {
                Var_MovieFlag = value;
            }
            get
            {
                return Var_MovieFlag;
            }
        }
        private byte Var_MovieFlag;

        ///<summary>A 3D <b>position</b> vector of the camera.</summary>
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

        ///<summary>A <b>rotation</b> 3D vector. Almost always 0,0,0.</summary>
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

        ///<summary><b>Zoom start</b>: The angle of view (field of view). Angles >180 create curious effects.</summary>
        public float ZoomStart
        {
            set
            {
                Var_ZoomStart = value;
            }
            get
            {
                return Var_ZoomStart;
            }
        }
        private float Var_ZoomStart;

        ///<summary><b>Zoom end</b>. The camera changes the zoom to this value.</summary>
        public float ZoomEnd
        {
            set
            {
                Var_ZoomEnd = value;
            }
            get
            {
                return Var_ZoomEnd;
            }
        }
        private float Var_ZoomEnd;

        ///<summary>Start vector of the <b>view point</b> (<see href="http://wiki.tockdom.com/wiki/Camera#CAME_Types">camera type 5</see>) or the relative camera <b>position</b> (<see href="http://wiki.tockdom.com/wiki/Camera#CAME_Types">camera type 3</see>).</summary>
        public Vector3 ViewPointStart
        {
            set
            {
                Var_ViewPointStart = value;
            }
            get
            {
                return Var_ViewPointStart;
            }
        }
        private Vector3 Var_ViewPointStart;

        ///<summary>(Destination) vector of the <b>view point</b>.</summary>
        public Vector3 ViewPointEnd
        {
            set
            {
                Var_ViewPointEnd = value;
            }
            get
            {
                return Var_ViewPointEnd;
            }
        }
        private Vector3 Var_ViewPointEnd;

        ///<summary>The time how long this Camera is active. (in units of <see href="http://wiki.tockdom.com/wiki/Time_Modes">1/60 seconds</see>).</summary>
        public float Time
        {
            set
            {
                Var_Time = value;
            }
            get
            {
                return Var_Time;
            }
        }
        private float Var_Time;

        ///<summary>Creates a CAME entry</summary>
        ///<param name="cameraType"><see href="http://wiki.tockdom.com/wiki/Camera#CAME_Types">Camera type</see></param>
        ///<param name="nextCameraIndex"><b>Next camera</b> entry index. Value 0xFF means: no next camera.</param>
        ///<param name="camshake">Camshake. <b>Exact meanings unknown</b>.</param>
        ///<param name="routeIndex">Index in POTI section of route used by camera. The value 0xFF means "no route".</param>
        ///<param name="cameraPointVelocity"><b>Velocity of the camera point</b> in units per 100/60 sec (=distance/1.67 sec).</param>
        ///<param name="zoomVelocity"><b>Velocity of zooming</b> in units per 100/60 sec (=units/1.67 sec) (tested with <see href="http://wiki.tockdom.com/wiki/Camera#CAME_Types">camera type 5</see>).</param>
        ///<param name="viewPointVelocity"><b>Velocity of the view point</b> in distance per 100/60 sec (=distance/1.67 sec) (tested with <see href="http://wiki.tockdom.com/wiki/Camera#CAME_Types">camera type 5</see>).</param>
        ///<param name="startFlag">Start flag. <b>Exact meanings unknown</b>.</param>
        ///<param name="movieFlag">Movie flag. <b>Exact meanings unknown</b>.</param>
        ///<param name="position">A 3D <b>position</b> vector of the camera.</param>
        ///<param name="rotation">A <b>rotation</b> 3D vector. Almost always 0,0,0.</param>
        ///<param name="zoomStart"><b>Zoom start</b>: The angle of view (field of view). Angles >180 create curious effects.</param>
        ///<param name="zoomEnd"><b>Zoom end</b>. The camera changes the zoom to this value.</param>
        ///<param name="viewPointStart">Start vector of the <b>view point</b> (<see href="http://wiki.tockdom.com/wiki/Camera#CAME_Types">camera type 5</see>) or the relative camera <b>position</b> (<see href="http://wiki.tockdom.com/wiki/Camera#CAME_Types">camera type 3</see>).</param>
        ///<param name="viewPointEnd">(Destination) vector of the <b>view point</b>.</param>
        ///<param name="time">The time how long this Camera is active. (in units of <see href="http://wiki.tockdom.com/wiki/Time_Modes">1/60 seconds</see>).</param>
        public KmpMkwCAMEEntry(byte cameraType, byte nextCameraIndex, byte camshake, byte routeIndex, 
            ushort cameraPointVelocity, ushort zoomVelocity, ushort viewPointVelocity,
            byte startFlag, byte movieFlag,
            Vector3 position, Vector3 rotation,
            float zoomStart, float zoomEnd,
            Vector3 viewPointStart, Vector3 viewPointEnd,
            float time
            )
        {
            CameraType = cameraType;
            NextCameraIndex = nextCameraIndex;
            Camshake = camshake;
            RouteIndex = routeIndex;
            CameraPointVelocity = cameraPointVelocity;
            ZoomVelocity = zoomVelocity;
            ViewPointVelocity = viewPointVelocity;
            StartFlag = startFlag;
            MovieFlag = movieFlag;
            Position = position;
            Rotation = rotation;
            ZoomStart = zoomStart;
            ZoomEnd = zoomEnd;
            ViewPointStart = viewPointStart;
            ViewPointEnd = viewPointEnd;
            Time = time;
        }
    }

    public class KmpMkwCAMESection : KmpSection
    {
        private KmpEntryList<KmpMkwCAMEEntry> Var_Entries;
        public KmpEntryList<KmpMkwCAMEEntry> Entries
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

        ///<summary>First camera to use in the opening pan around the track.</summary>
        public byte OpeningCamera { set { Var_OpeningCamera = value; } get { return Var_OpeningCamera; } }
        ///<summary>First camera used in track selection menu videos of the track (<b>ignored in vanilla Mario Kart Wii</b>).</summary>
        public byte MenuCamera { set { Var_MenuCamera = value; } get { return Var_MenuCamera; } }
        private byte Var_OpeningCamera;
        private byte Var_MenuCamera;
        public override ushort GetAdditionalValue()
        {
            return (ushort)((Var_OpeningCamera * 256) + Var_MenuCamera);
        }

        public GenericKmpSection ToGenericKmpSection()
        {
            List<byte> rawData = new List<byte>();
            for (int n = 0; n < Var_Entries.Count; n += 1)
            {
                KmpMkwCAMEEntry entry = Var_Entries[n];
                rawData.Add(entry.CameraType);
                rawData.Add(entry.NextCameraIndex);
                rawData.Add(entry.Camshake);
                rawData.Add(entry.RouteIndex);
                rawData.AddRange(ByteConverter.GetBytes(entry.CameraPointVelocity));
                rawData.AddRange(ByteConverter.GetBytes(entry.ZoomVelocity));
                rawData.AddRange(ByteConverter.GetBytes(entry.ViewPointVelocity));
                rawData.Add(entry.StartFlag);
                rawData.Add(entry.MovieFlag);
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Position.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.Rotation.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.ZoomStart));
                rawData.AddRange(ByteConverter.GetBytes(entry.ZoomEnd));
                rawData.AddRange(ByteConverter.GetBytes(entry.ViewPointStart.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.ViewPointStart.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.ViewPointStart.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.ViewPointEnd.X));
                rawData.AddRange(ByteConverter.GetBytes(entry.ViewPointEnd.Y));
                rawData.AddRange(ByteConverter.GetBytes(entry.ViewPointEnd.Z));
                rawData.AddRange(ByteConverter.GetBytes(entry.Time));

            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwCAMESection()
        {
            Var_SectionName = "CAME";
            Var_Entries = new KmpEntryList<KmpMkwCAMEEntry>();
        }
        public KmpMkwCAMESection(KmpMkwCAMEEntry[] entries)
        {
            Var_SectionName = "CAME";
            Var_Entries = new KmpEntryList<KmpMkwCAMEEntry>(entries);
        }
        public KmpMkwCAMESection(GenericKmpSection section)
        {
            Var_SectionName = "CAME";

            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwCAMEEntry>();
            
            ushort additionalValue = section.GetAdditionalValue();
            OpeningCamera = (byte)(additionalValue / 256);
            MenuCamera = (byte)(additionalValue % 256);
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x48; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwCAMEEntry(
                    rawData[offset + 0x00],
                    rawData[offset + 0x01],
                    rawData[offset + 0x02],
                    rawData[offset + 0x03],
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x04],
                        rawData[offset + 0x05] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x06],
                        rawData[offset + 0x07] }),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x08],
                        rawData[offset + 0x09] }),
                    rawData[offset + 0x0A],
                    rawData[offset + 0x0B],
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
                    new Vector3(
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x18],
                            rawData[offset + 0x19],
                            rawData[offset + 0x1A],
                            rawData[offset + 0x1B] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x1C],
                            rawData[offset + 0x1D],
                            rawData[offset + 0x1E],
                            rawData[offset + 0x1F] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x20],
                            rawData[offset + 0x21],
                            rawData[offset + 0x22],
                            rawData[offset + 0x23] })
                        ),
                    ByteConverter.ToSingle(new byte[] {
                        rawData[offset + 0x24],
                        rawData[offset + 0x25],
                        rawData[offset + 0x26],
                        rawData[offset + 0x27] }),
                    ByteConverter.ToSingle(new byte[] {
                        rawData[offset + 0x28],
                        rawData[offset + 0x29],
                        rawData[offset + 0x2A],
                        rawData[offset + 0x2B] }),
                    new Vector3(
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x2C],
                            rawData[offset + 0x2D],
                            rawData[offset + 0x2E],
                            rawData[offset + 0x2F] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x30],
                            rawData[offset + 0x31],
                            rawData[offset + 0x32],
                            rawData[offset + 0x33] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x34],
                            rawData[offset + 0x35],
                            rawData[offset + 0x36],
                            rawData[offset + 0x37] })
                        ),
                    new Vector3(
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x38],
                            rawData[offset + 0x39],
                            rawData[offset + 0x3A],
                            rawData[offset + 0x3B] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x3C],
                            rawData[offset + 0x3D],
                            rawData[offset + 0x3E],
                            rawData[offset + 0x3F] }),
                        ByteConverter.ToSingle(new byte[] {
                            rawData[offset + 0x40],
                            rawData[offset + 0x41],
                            rawData[offset + 0x42],
                            rawData[offset + 0x43] })
                        ),
                    ByteConverter.ToSingle(new byte[] {
                        rawData[offset + 0x44],
                        rawData[offset + 0x45],
                        rawData[offset + 0x46],
                        rawData[offset + 0x47] })
                    ));
            }
        }
    }
}
