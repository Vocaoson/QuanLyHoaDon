using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    static class MyExtension
    {
        public static long toLong(this object x)
        {
            return long.Parse(x.ToString());
        }
    }
}
