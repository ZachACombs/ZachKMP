using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    public abstract class KmpCommonPathEntry
    {
        ///<summary>Index in points section of starting point</summary>
        public byte PointStart
        {
            set { Var_PointStart = value; }
            get { return Var_PointStart; }
        }
        private byte Var_PointStart;

        ///<summary>Number of points in group</summary>
        public byte PointLength
        {
            set { Var_PointLength = value; }
            get { return Var_PointLength; }
        }
        private byte Var_PointLength;
        
        ///<summary>Index of 1st previous point group</summary>
        public byte PrevGroup1 { set { Var_PrevGroup1 = value; } get { return Var_PrevGroup1; } }
        private byte Var_PrevGroup1;

        ///<summary>Index of 2nd previous point group</summary>
        public byte PrevGroup2 { set { Var_PrevGroup2 = value; } get { return Var_PrevGroup2; } }
        private byte Var_PrevGroup2;

        ///<summary>Index of 3rd previous point group</summary>
        public byte PrevGroup3 { set { Var_PrevGroup3 = value; } get { return Var_PrevGroup3; } }
        private byte Var_PrevGroup3;

        ///<summary>Index of 4th previous point group</summary>
        public byte PrevGroup4 { set { Var_PrevGroup4 = value; } get { return Var_PrevGroup4; } }
        private byte Var_PrevGroup4;

        ///<summary>Index of 5th previous point group</summary>
        public byte PrevGroup5 { set { Var_PrevGroup5 = value; } get { return Var_PrevGroup5; } }
        private byte Var_PrevGroup5;

        ///<summary>Index of 6th previous point group</summary>
        public byte PrevGroup6 { set { Var_PrevGroup6 = value; } get { return Var_PrevGroup6; } }
        private byte Var_PrevGroup6;

        ///<summary>Index of 1st next point group</summary>
        public byte NextGroup1 { set { Var_NextGroup1 = value; } get { return Var_NextGroup1; } }
        private byte Var_NextGroup1;

        ///<summary>Index of 2nd next point group</summary>
        public byte NextGroup2 { set { Var_NextGroup2 = value; } get { return Var_NextGroup2; } }
        private byte Var_NextGroup2;

        ///<summary>Index of 3rd next point group</summary>
        public byte NextGroup3 { set { Var_NextGroup3 = value; } get { return Var_NextGroup3; } }
        private byte Var_NextGroup3;

        ///<summary>Index of 4th next point group</summary>
        public byte NextGroup4 { set { Var_NextGroup4 = value; } get { return Var_NextGroup4; } }
        private byte Var_NextGroup4;

        ///<summary>Index of 5th next point group</summary>
        public byte NextGroup5 { set { Var_NextGroup5 = value; } get { return Var_NextGroup5; } }
        private byte Var_NextGroup5;

        ///<summary>Index of 6th next point group</summary>
        public byte NextGroup6 { set { Var_NextGroup6 = value; } get { return Var_NextGroup6; } }
        private byte Var_NextGroup6;

        protected ushort Var_ExtraValue;

        internal const int EntryLength = 0x10;
        internal byte[] ToRawData()
        {
            return new byte[]
            {
                Var_PointStart,
                Var_PointLength,
                Var_PrevGroup1,
                Var_PrevGroup2,
                Var_PrevGroup3,
                Var_PrevGroup4,
                Var_PrevGroup5,
                Var_PrevGroup6,
                Var_NextGroup1,
                Var_NextGroup2,
                Var_NextGroup3,
                Var_NextGroup4,
                Var_NextGroup5,
                Var_NextGroup6,
                (byte)(Var_ExtraValue / 256),
                (byte)(Var_ExtraValue % 256)
            };
        }
        
        protected KmpCommonPathEntry(byte pointStart, byte pointLength,
            byte prevGroup1, byte prevGroup2, byte prevGroup3, byte prevGroup4, byte prevGroup5, byte prevGroup6,
            byte nextGroup1, byte nextGroup2, byte nextGroup3, byte nextGroup4, byte nextGroup5, byte nextGroup6,
            ushort extravalue)
        {
            Var_PointStart = pointStart;
            Var_PointLength = pointLength;
            Var_PrevGroup1 = prevGroup1;
            Var_PrevGroup2 = prevGroup2;
            Var_PrevGroup3 = prevGroup3;
            Var_PrevGroup4 = prevGroup4;
            Var_PrevGroup5 = prevGroup5;
            Var_PrevGroup6 = prevGroup6;
            Var_NextGroup1 = nextGroup1;
            Var_NextGroup2 = nextGroup2;
            Var_NextGroup3 = nextGroup3;
            Var_NextGroup4 = nextGroup4;
            Var_NextGroup5 = nextGroup5;
            Var_NextGroup6 = nextGroup6;
            Var_ExtraValue = extravalue;
        }
        protected KmpCommonPathEntry(byte[] rawData)
        {
            if (rawData.Length < EntryLength)
                throw new ArgumentException(nameof(rawData), "Array is too small");

            Var_PointStart = rawData[0x00];
            Var_PointLength = rawData[0x01];
            Var_PrevGroup1 = rawData[0x02];
            Var_PrevGroup2 = rawData[0x03];
            Var_PrevGroup3 = rawData[0x04];
            Var_PrevGroup4 = rawData[0x05];
            Var_PrevGroup5 = rawData[0x06];
            Var_PrevGroup6 = rawData[0x07];
            Var_NextGroup1 = rawData[0x08];
            Var_NextGroup2 = rawData[0x09];
            Var_NextGroup3 = rawData[0x0A];
            Var_NextGroup4 = rawData[0x0B];
            Var_NextGroup5 = rawData[0x0C];
            Var_NextGroup6 = rawData[0x0D];
            Var_ExtraValue = (ushort)((rawData[0x0E] * 256) + rawData[0x0F]);
        }
    }
}
