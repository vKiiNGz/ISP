using System;
using System.Collections.Generic;
using System.Text;

namespace LR_7
{

    class Frac
    {
        public int numer { get; set; }
        public int decom { get; set; }

        static int GCD(int a, int b)
        {
            int x;
            if (a < b)
            {
                x = a;
                a = b;
                b = x;
            }
            while (b > 0)
            {
                a %= b;
                x = a;
                a = b;
                b = x;
            }
            return a;
        }

        static int LCM(int a, int b)
        {
            return (a * b / GCD(a, b));
        }

        public Frac(int x, int y)
        {
            numer = x;
            decom = y;
        }

        public static Frac operator +(Frac a, Frac b)
        {
            int x;
            x = LCM(a.decom, b.decom);
            return new Frac (x / a.decom * a.numer + x / b.decom * b.numer, x);
        }

        public static Frac operator -(Frac a, Frac b)
        {
            int x;
            x = LCM(a.decom, b.decom);
            return new Frac(x / a.decom * a.numer - x / b.decom * b.numer, x);
        }

        public static Frac operator /(Frac a, Frac b)
        {
            return new Frac(a.numer * b.decom, b.numer * a.decom);
        }

        public static Frac operator *(Frac a, Frac b)
        {
            return new Frac(a.numer * b.numer, b.decom * a.decom);
        }

        public static bool operator ==(Frac a, Frac b)
        {
            int x;
            x = LCM(a.decom, b.decom);
            return (x / a.decom * a.numer == x / b.decom * b.numer);
        }

        public static bool operator !=(Frac a, Frac b)
        {
            int x;
            x = LCM(a.decom, b.decom);
            return (x / a.decom * a.numer != x / b.decom * b.numer);
        }

        public static bool operator <(Frac a, Frac b)
        {
            int x;
            x = LCM(a.decom, b.decom);
            return (x / a.decom * a.numer < x / b.decom * b.numer);
        }

        public static bool operator >(Frac a, Frac b)
        {
            int x;
            x = LCM(a.decom, b.decom);
            return (x / a.decom * a.numer > x / b.decom * b.numer);
        }

        public static implicit operator short(Frac n)
        {
            return (short)(n.numer / n.decom);
        }

        public static implicit operator int(Frac n)
        {
            return (int)(n.numer / n.decom);
        }

        public static implicit operator long(Frac n)
        {
            return (long)(n.numer / n.decom);
        }

        public static implicit operator float(Frac n)
        {
            return (float)((float)n.numer / n.decom);
        }

        public static implicit operator double(Frac n)
        {
            return (double)((double)n.numer / n.decom);
        }
        public override string ToString() => numer.ToString() + "/" + decom.ToString();

        public string ToString(string format) => format == "." ? ((double)numer / decom).ToString() : "";
        public void Reduce()
        {
            int gcd = GCD(Math.Abs(numer), decom);
            numer /= gcd;
            decom /= gcd;
        }
    }
}
