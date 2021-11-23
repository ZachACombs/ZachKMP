using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    public struct Vector2
    {
        public float X;
        public float Y;

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(
                a.X + b.X,
                a.Y + b.Y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(
                a.X - b.X,
                a.Y - b.Y);
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(
                a.X * b.X,
                a.Y * b.Y);
        }
        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(
                a.X / b.X,
                a.Y / b.Y);
        }

        public static Vector2 Zero = new Vector2(0f, 0f);
        public static Vector2 One = new Vector2(1f, 1f);
    }
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.X + b.X,
                a.Y + b.Y,
                a.Z + b.Z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.X - b.X,
                a.Y - b.Y,
                a.Z - b.Z);
        }
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.X * b.X,
                a.Y * b.Y,
                a.Z * b.Z);
        }
        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.X / b.X,
                a.Y / b.Y,
                a.Z / b.Z);
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 Zero = new Vector3(0f, 0f, 0f);
        public static Vector3 One = new Vector3(1f, 1f, 1f);
    }
    
    public struct Color
    {
        private const byte Con_Opaque = 0xFF;

        ///<summary>Red value</summary>
        public byte R;
        ///<summary>Green value</summary>
        public byte G;
        ///<summary>Blue value</summary>
        public byte B;
        ///<summary>Alpha value</summary>
        public byte A;

        ///<summary>Defines a color</summary>
        ///<param name="rgb">RGB value</param>
        public Color(int rgb) : this (
            (byte)((rgb >> 16) % 256), 
            (byte)((rgb >> 8) % 256), 
            (byte)(rgb % 256))
        {
        }
        ///<summary>Defines a color</summary>
        ///<param name="rgba">RGBA value</param>
        public Color(uint rgba) : this(
            (byte)((rgba >> 24) % 256),
            (byte)((rgba >> 16) % 256),
            (byte)((rgba >> 8) % 256),
            (byte)(rgba % 256))
        {
        }
        ///<summary>Defines a color</summary>
        ///<param name="r">Red value</param>
        ///<param name="g">Green value</param>
        ///<param name="b">Blue value</param>
        public Color(byte r, byte g, byte b) : this (r, g, b, Con_Opaque)
        {
        }
        ///<summary>Defines a color</summary>
        ///<param name="r">Red value</param>
        ///<param name="g">Green value</param>
        ///<param name="b">Blue value</param>
        ///<param name="a">Alpha value</param>
        public Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
