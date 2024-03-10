using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace rgz
{
    public class TFrac
    {
        private long numerator;
        private long denominator;

        public long Numerator
        {
            set
            {
                numerator = value;
            }
            get
            {
                return numerator;
            }
        }

        public long Denominator
        {
            set
            {
                denominator = value;
            }
            get
            {
                return denominator;
            }
        }

        static void Swap<T>(ref T var_1, ref T var_2)
        {
            T temp;
            temp = var_1;
            var_1 = var_2;
            var_2 = temp;
        }

        public static long GCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b > 0)
            {
                a %= b;
                Swap(ref a, ref b);
            }
            return a;
        }

        public TFrac()
        {
            numerator = 0;
            denominator = 1;
        }

        public TFrac(long a, long b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }

            long gcdRes = GCD(a, b);
            numerator = a / gcdRes;
            denominator = b / gcdRes;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        public TFrac(string frac)
        {
            Regex FracRegex = new Regex(@"^-?(\d+)/(\d+)$");
            Regex NumberRegex = new Regex(@"^-?\d+/?$");
            if (FracRegex.IsMatch(frac))
            {
                List<string> FracSplited = frac.Split('/').ToList();
                numerator = Convert.ToInt64(FracSplited[0]);
                denominator = Convert.ToInt64(FracSplited[1]);
                if (denominator == 0)
                {
                    numerator = 0;
                    denominator = 1;
                    return;
                }
                long gcd = GCD(numerator, denominator);
                if (gcd > 1)
                {
                    numerator /= gcd;
                    denominator /= gcd;
                }
                return;
            }
            else if (NumberRegex.IsMatch(frac))
            {
                if (long.TryParse(frac, out long NewNumber))
                    numerator = NewNumber;
                else
                    numerator = 0;
                denominator = 1;
                return;
            }
            else
            {
                numerator = 0;
                denominator = 1;
                return;
            }
        }

        public TFrac Copy()
        {
            return (TFrac)this.MemberwiseClone();
        }

        public void SetString(string str)
        {
            TFrac TempFrac = new TFrac(str);
            numerator = TempFrac.numerator;
            denominator = TempFrac.denominator;
        }

        public TFrac Add(TFrac a)
        {
            return new TFrac(numerator * a.denominator + denominator * a.numerator, denominator * a.denominator);
        }

        public TFrac Mul(TFrac b)
        {
            return new TFrac(numerator * b.numerator, denominator * b.denominator);
        }

        public TFrac Sub(TFrac b)
        {
            return new TFrac(numerator * b.denominator - denominator * b.numerator, denominator * b.denominator);
        }

        public TFrac Div(TFrac b)
        {
            return new TFrac(numerator * b.denominator, denominator * b.numerator);
        }

        public TFrac Square()
        {
            return new TFrac(numerator * numerator, denominator * denominator);
        }

        public TFrac Reverse()
        { 
            return new TFrac(denominator, numerator); 
        }

        public TFrac Minus()
        {
            return new TFrac(-numerator, denominator);
        }

        public bool Equal(TFrac b)
        {
            return numerator == b.numerator && denominator == b.denominator;
        }

        public static bool operator >(TFrac a, TFrac b)
        {
            return (Convert.ToDouble(a.numerator) / Convert.ToDouble(a.denominator)) > (Convert.ToDouble(b.numerator) / Convert.ToDouble(b.denominator));
        }

        public static bool operator <(TFrac a, TFrac b)
        {
            return (Convert.ToDouble(a.numerator) / Convert.ToDouble(a.denominator)) < (Convert.ToDouble(b.numerator) / Convert.ToDouble(b.denominator));
        }

        public static implicit operator string(TFrac v)
        {
            throw new NotImplementedException();
        }

        public long getNumeratorNum()
        {
            return numerator;
        }

        public long getDenominatorNum()
        {
            return denominator;
        }

        public string getNumeratorString()
        {
            return numerator.ToString();
        }

        public string getDenominatorString()
        {
            return denominator.ToString();
        }

        public override string ToString()
        {
            return getNumeratorString() + "/" + getDenominatorString();
        }
    }
}
