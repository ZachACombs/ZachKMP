using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    class Functions
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
}
