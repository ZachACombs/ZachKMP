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

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 Zero = new Vector2(0f, 0f);
        public static Vector2 One = new Vector2(1f, 1f);
    }
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 Zero = new Vector3(0f, 0f, 0f);
        public static Vector3 One = new Vector3(1f, 1f, 1f);
    }
}
