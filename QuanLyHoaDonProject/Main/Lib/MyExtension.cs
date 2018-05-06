using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    static class MyExtension
    {
        public static decimal toDecimal(this double x)
        {
            return decimal.Parse(x.ToString());
        }
        public static long toLong(this object x)
        {
            return long.Parse(x.ToString());
        }
        public static double toDouble(this object x)
        {
            return double.Parse(x.ToString());
        }
        public static double toDoubleS(this string x)
        {
            return double.Parse(x);
        }
        public static int toInt(this object x)
        {
            return int.Parse(x.ToString());
        }
        public static DateTime toDateTime(this object x)
        {
            return DateTime.Parse(x.ToString());
        }
    }
}
