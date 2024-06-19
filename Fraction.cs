using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Fraction
    {
        public long First { get; set; }
        public ushort Second { get; set; }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            double a1 = f1.First + (f1.Second / Math.Pow(10, f1.Second.ToString().Length));
            double a2 = f2.First + (f2.Second / Math.Pow(10, f1.Second.ToString().Length));
            double res = Math.Round(a1 + a2, 3);
            return new Fraction() { First = (long)Math.Floor(res), Second = ushort.Parse(res.ToString().Split(",")[1]) };
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            double a1 = f1.First + (f1.Second / Math.Pow(10, f1.Second.ToString().Length));
            double a2 = f2.First + (f2.Second / Math.Pow(10, f1.Second.ToString().Length));
            double res = Math.Round(a1 - a2,3);
            return new Fraction() { First = (long)Math.Floor(res), Second = ushort.Parse(res.ToString().Split(",")[1]) };
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            double a1 = f1.First + (f1.Second / Math.Pow(10, f1.Second.ToString().Length));
            double a2 = f2.First + (f2.Second / Math.Pow(10, f1.Second.ToString().Length));
            double res = Math.Round(a1 * a2, 3);
            return new Fraction() { First = (long)Math.Floor(res), Second = ushort.Parse(res.ToString().Split(",")[1]) };
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            double a1 = f1.First + (f1.Second / Math.Pow(10, f1.Second.ToString().Length));
            double a2 = f2.First + (f2.Second / Math.Pow(10, f1.Second.ToString().Length));
            double res = Math.Round(a1 / a2, 3);
            return new Fraction() { First = (long)Math.Floor(res), Second = ushort.Parse(res.ToString().Split(",")[1]) };
        }
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            if (f1.First == f2.First && f1.Second == f2.Second) 
                return true;
            else return false;
        }
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            if (f1.First != f2.First || f1.Second != f2.Second) 
                return true;
            else return false;
        }

        public override string? ToString()
        {
            return First+","+Second;
        }
    }
}
