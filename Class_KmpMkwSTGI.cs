using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>A STGI entry</summary>
    public class KmpMkwSTGIEntry
    {
        ///<summary>Lap count. Always 03 in Nintendo tracks. This byte was used in early development and is no longer in use, but it is still set correctly for all race tracks (03) and tournaments with a different lap count. There is a <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">cheat code</see></b> which makes the game use this value as lap count in normal races.</summary>
        public byte LapCount
        {
            set
            {
                Var_LapCount = value;
            }
            get
            {
                return Var_LapCount;
            }
        }
        private byte Var_LapCount;

        ///<summary>0: Pole position is left.<br/>
        ///1: Pole position is right.</summary>
        public byte PolePosition
        {
            set
            {
                Var_PolePosition = value;
            }
            get
            {
                return Var_PolePosition;
            }
        }
        private byte Var_PolePosition;

        ///<summary>0: Normal distance.<br/>
        ///1: Drivers are closer together (in driving direction, narrow mode).</summary>
        public byte Distance
        {
            set
            {
                Var_Distance = value;
            }
            get
            {
                return Var_Distance;
            }
        }
        private byte Var_Distance;

        ///<summary>0x01 to enable <see href="https://youtu.be/YvkT4wJ40Ng">lens flare flashing</see>.</summary>
        public byte LensFlareFlashing
        {
            set
            {
                Var_LensFlareFlashing = value;
            }
            get
            {
                return Var_LensFlareFlashing;
            }
        }
        private byte Var_LensFlareFlashing;

        ///<summary>Padding for flare color.</summary>
        public byte FlareColorPadding
        {
            set
            {
                Var_FlareColorPadding = value;
            }
            get
            {
                return Var_FlareColorPadding;
            }
        }
        private byte Var_FlareColorPadding;

        ///<summary>Flare color. 0xE6E6E6 or 0xFFFFFF (for the color) and 0xXXXXXX32 or 0xXXXXXX4B (for the transparency) in Nintendo tracks. This is the lighting color that covers the screen by the <see href="http://szs.wiimm.de/cgi/mkw/object?query=0x3#res">lensFX</see> object.</summary>
        public Color FlareColor
        {
            set
            {
                Var_FlareColor = value;
            }
            get
            {
                return Var_FlareColor;
            }
        }
        private Color Var_FlareColor;

        ///<summary>Always 0 in Nintendo tracks. The last byte is used as the first byte of a floating point for the <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">speed modifier</see></b> cheat code.</summary>
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

        ///<summary>Always 0 in Nintendo tracks (padding). This byte is used as the second byte of a floating point for the <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">speed modifier</see></b> cheat code.</summary>
        public byte Padding
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
        private byte Var_Padding;

        ///<summary>Gets the speed factor for tracks that are meant to take advantage of the <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">speed modifier</see></b> cheat code.</summary>
        /// <returns>Speed factor value</returns>
        public float GetSpeedFactor()
        {
            return ByteConverter.ToSingle(new byte[] { (byte)(Unknown % 256), Var_Padding, 0, 0 });
        }
        ///<summary>Sets the speed factor for tracks that are meant to take advantage of the <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">speed modifier</see></b> cheat code.</summary>
        ///<param name="speedFactor">Value of speed factor</param>
        public void SetSpeedFactor(float speedFactor)
        {
            byte[] bytes = ByteConverter.GetBytes(speedFactor);
            Var_Unknown = (ushort)(((Var_Unknown / 256) * 256) + bytes[0]);
            Var_Padding = bytes[1];
        }

        ///<summary>Creates a STGI entry</summary>
        ///<param name="polePosition">0: Pole position is left.<br/>
        ///1: Pole position is right.</param>
        ///<param name="distance">0: Normal distance.<br/>
        ///1: Drivers are closer together (in driving direction, narrow mode).</param>
        ///<param name="lensFlareFlashing">0x01 to enable <see href="https://youtu.be/YvkT4wJ40Ng">lens flare flashing</see>.</param>
        ///<param name="flareColorPadding">Padding for flare color.</param>
        ///<param name="flareColor">Flare color. 0xE6E6E6 or 0xFFFFFF (for the color) and 0xXXXXXX32 or 0xXXXXXX4B (for the transparency) in Nintendo tracks. This is the lighting color that covers the screen by the <see href="http://szs.wiimm.de/cgi/mkw/object?query=0x3#res">lensFX</see> object.</param>
        public KmpMkwSTGIEntry(byte polePosition, byte distance,
                byte lensFlareFlashing, byte flareColorPadding, Color flareColor) : 
            this(3, polePosition, distance,
                lensFlareFlashing, flareColorPadding, flareColor,
                0, 0)
        {
        }
        ///<summary>Creates a STGI entry</summary>
        ///<param name="lapCount">Lap count. Always 03 in Nintendo tracks. This byte was used in early development and is no longer in use, but it is still set correctly for all race tracks (03) and tournaments with a different lap count. There is a <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">cheat code</see></b> which makes the game use this value as lap count in normal races.</param>
        ///<param name="polePosition">0: Pole position is left.<br/>
        ///1: Pole position is right.</param>
        ///<param name="distance">0: Normal distance.<br/>
        ///1: Drivers are closer together (in driving direction, narrow mode).</param>
        ///<param name="lensFlareFlashing">0x01 to enable <see href="https://youtu.be/YvkT4wJ40Ng">lens flare flashing</see>.</param>
        ///<param name="flareColorPadding">Padding for flare color.</param>
        ///<param name="flareColor">Flare color. 0xE6E6E6 or 0xFFFFFF (for the color) and 0xXXXXXX32 or 0xXXXXXX4B (for the transparency) in Nintendo tracks. This is the lighting color that covers the screen by the <see href="http://szs.wiimm.de/cgi/mkw/object?query=0x3#res">lensFX</see> object.</param>
        public KmpMkwSTGIEntry(byte lapCount, byte polePosition, byte distance,
                byte lensFlareFlashing, byte flareColorPadding, Color flareColor) :
            this(lapCount, polePosition, distance,
                lensFlareFlashing, flareColorPadding, flareColor,
                0, 0)
        {
        }
        ///<summary>Creates a STGI entry</summary>
        ///<param name="lapCount">Lap count. Always 03 in Nintendo tracks. This byte was used in early development and is no longer in use, but it is still set correctly for all race tracks (03) and tournaments with a different lap count. There is a <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">cheat code</see></b> which makes the game use this value as lap count in normal races.</param>
        ///<param name="polePosition">0: Pole position is left.<br/>
        ///1: Pole position is right.</param>
        ///<param name="distance">0: Normal distance.<br/>
        ///1: Drivers are closer together (in driving direction, narrow mode).</param>
        ///<param name="lensFlareFlashing">0x01 to enable <see href="https://youtu.be/YvkT4wJ40Ng">lens flare flashing</see>.</param>
        ///<param name="flareColorPadding">Padding for flare color.</param>
        ///<param name="flareColor">Flare color. 0xE6E6E6 or 0xFFFFFF (for the color) and 0xXXXXXX32 or 0xXXXXXX4B (for the transparency) in Nintendo tracks. This is the lighting color that covers the screen by the <see href="http://szs.wiimm.de/cgi/mkw/object?query=0x3#res">lensFX</see> object.</param>
        ///<param name="speedFactor">Speed factor for tracks that are meant to take advantage of the <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">speed modifier</see></b> cheat code.</param>
        public KmpMkwSTGIEntry(byte lapCount, byte polePosition, byte distance,
                byte lensFlareFlashing, byte flareColorPadding, Color flareColor,
                float speedFactor) :
            this(lapCount, polePosition, distance,
                lensFlareFlashing, flareColorPadding, flareColor,
                0, 0)
        {
            SetSpeedFactor(speedFactor);
        }
        ///<summary>Creates a STGI entry</summary>
        ///<param name="lapCount">Lap count. Always 03 in Nintendo tracks. This byte was used in early development and is no longer in use, but it is still set correctly for all race tracks (03) and tournaments with a different lap count. There is a <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">cheat code</see></b> which makes the game use this value as lap count in normal races.</param>
        ///<param name="polePosition">0: Pole position is left.<br/>
        ///1: Pole position is right.</param>
        ///<param name="distance">0: Normal distance.<br/>
        ///1: Drivers are closer together (in driving direction, narrow mode).</param>
        ///<param name="lensFlareFlashing">0x01 to enable <see href="https://youtu.be/YvkT4wJ40Ng">lens flare flashing</see>.</param>
        ///<param name="flareColorPadding">Padding for flare color.</param>
        ///<param name="flareColor">Flare color. 0xE6E6E6 or 0xFFFFFF (for the color) and 0xXXXXXX32 or 0xXXXXXX4B (for the transparency) in Nintendo tracks. This is the lighting color that covers the screen by the <see href="http://szs.wiimm.de/cgi/mkw/object?query=0x3#res">lensFX</see> object.</param>
        ///<param name="unknown">Always 0 in Nintendo tracks. The last byte is used as the first byte of a floating point for the <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">speed modifier</see></b> cheat code.</param>
        ///<param name="padding">Always 0 in Nintendo tracks (padding). This byte is used as the second byte of a floating point for the <b><see href="http://wiki.tockdom.com/wiki/Lap_%26_Speed_Modifier">speed modifier</see></b> cheat code.</param>
        public KmpMkwSTGIEntry(byte lapCount, byte polePosition, byte distance, 
            byte lensFlareFlashing, byte flareColorPadding, Color flareColor,
            ushort unknown, byte padding)
        {
            LapCount = lapCount;
            PolePosition = polePosition;
            Distance = distance;
            LensFlareFlashing = lensFlareFlashing;
            FlareColorPadding = flareColorPadding;
            FlareColor = flareColor;
            Unknown = unknown;
            Padding = padding;
        }
    }

    ///<summary>A STGI section</summary>
    public class KmpMkwSTGISection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwSTGIEntry> Var_Entries;
        public KmpEntryList<KmpMkwSTGIEntry> Entries
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
                KmpMkwSTGIEntry entry = Var_Entries[n];
                rawData.Add(entry.LapCount);
                rawData.Add(entry.PolePosition);
                rawData.Add(entry.Distance);
                rawData.Add(entry.LensFlareFlashing);
                rawData.Add(entry.FlareColorPadding);
                rawData.Add(entry.FlareColor.R);
                rawData.Add(entry.FlareColor.G);
                rawData.Add(entry.FlareColor.B);
                rawData.Add(entry.FlareColor.A);
                rawData.AddRange(ByteConverter.GetBytes(entry.Unknown));
                rawData.Add(entry.Padding);
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwSTGISection() : base("STGI")
        {
            Var_Entries = new KmpEntryList<KmpMkwSTGIEntry>();
        }
        public KmpMkwSTGISection(KmpMkwSTGIEntry[] entries) : base("STGI")
        {
            Var_Entries = new KmpEntryList<KmpMkwSTGIEntry>(entries);
        }
        public KmpMkwSTGISection(GenericKmpSection section) : base("STGI")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwSTGIEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            int entryLength = 0x0C; //Length of each entry
            if (rawData.Length < (entryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = entryLength * n;
                Var_Entries.Add(new KmpMkwSTGIEntry(
                    rawData[offset + 0x00],
                    rawData[offset + 0x01],
                    rawData[offset + 0x02],
                    rawData[offset + 0x03],
                    rawData[offset + 0x04],
                    new Color(
                        rawData[offset + 0x05],
                        rawData[offset + 0x06],
                        rawData[offset + 0x07],
                        rawData[offset + 0x08]),
                    ByteConverter.ToUInt16(new byte[] {
                        rawData[offset + 0x09],
                        rawData[offset + 0x0A] }),
                    rawData[offset + 0x0B]
                    ));
            }
        }
    }
}
