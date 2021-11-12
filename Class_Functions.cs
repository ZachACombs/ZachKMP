using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    internal class Functions
    {
        public static Exception ValidateName(string name)
        {
            if (name.Length != 4)
                return new Exception("Value does not have exactly 4 characters");
            char[] c = name.ToCharArray();
            for (int n = 0; n < c.Length; n += 1)
            {
                if (c[n] > 255)
                    return new Exception("Value has non-ASCII character(s)");
            }
            return null;
        }
    }
    internal class ByteConverter
    {
        public static ushort ToUInt16(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt16(bytes, 0);
        }
        public static uint ToUInt32(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }
        public static short ToInt16(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToInt16(bytes, 0);
        }
        public static int ToInt32(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        public static float ToSingle(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }

        public static byte[] GetBytes(ushort value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }
        public static byte[] GetBytes(uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }
        public static byte[] GetBytes(short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }
        public static byte[] GetBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }
        public static byte[] GetBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }
    }
}
