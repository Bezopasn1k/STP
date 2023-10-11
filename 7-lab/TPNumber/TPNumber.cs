using System;

namespace TPNumber
{
    public class TPNumber
    {
        public int b = 0;
        public int c = 0;
        public double n = 0;

        public class TPNumberException : Exception
        {
            public TPNumberException(string s) : base(s) { }
        }

        public TPNumber(double number, int base_, int precision)
        {
            if (base_ < 2 || base_ > 16)
            {
                throw new TPNumberException("Основание СС не принадлежит интервалу [2;16].");
            }
            if (precision < 0)
            {
                throw new TPNumberException("Точность не может быть меньше 0.");
            }
            n = number;
            b = base_;
            c = precision;
        }

        public TPNumber(string number, string base_, string precision)
        {
            double value = Convert.ToDouble(number);
            int baseValue = Convert.ToInt32(base_);
            int precisionValue = Convert.ToInt32(precision);
            if (baseValue < 2 || baseValue > 16)
            {
                throw new TPNumberException("Основание СС не принадлежит интервалу [2;16].");
            }
            if (precisionValue < 0)
            {
                throw new TPNumberException("Точность не может быть меньше 0.");
            }
            n = value;
            b = baseValue;
            c = precisionValue;
        }


        public TPNumber(TPNumber other)
        {
            n = other.n;
            b = other.b;
            c = other.c;
        }

        public TPNumber Copy()
        {
            return new TPNumber(n, b, c);
        }

        public static TPNumber operator +(TPNumber other_1, TPNumber other_2)
        {
            if (other_1.b != other_2.b)
            {
                throw new TPNumberException("Основания чисел не совпадают.");
            }
            if (other_1.c != other_2.c)
            {
                throw new TPNumberException("Точности чисел не совпадают.");
            }
            double sum = other_1.n + other_2.n;
            return new TPNumber(sum, other_1.b, other_1.c);
        }

        public static TPNumber operator *(TPNumber other_1, TPNumber other_2)
        {
            if (other_1.b != other_2.b)
            {
                throw new TPNumberException("Основания чисел не совпадают.");
            }
            if (other_1.c != other_2.c)
            {
                throw new TPNumberException("Точности чисел не совпадают.");
            }
            double mul = other_1.n * other_2.n;
            return new TPNumber(mul, other_1.b, other_1.c);
        }

        public static TPNumber operator -(TPNumber other_1, TPNumber other_2)
        {
            if (other_1.b != other_2.b)
            {
                throw new TPNumberException("Основания чисел не совпадают.");
            }
            if (other_1.c != other_2.c)
            {
                throw new TPNumberException("Точности чисел не совпадают.");
            }
            double diff = other_1.n - other_2.n;
            return new TPNumber(diff, other_1.b, other_1.c);
        }

        public static TPNumber operator /(TPNumber other_1, TPNumber other_2)
        {
            if (other_1.b != other_2.b)
            {
                throw new TPNumberException("Основания чисел не совпадают.");
            }
            if (other_1.c != other_2.c)
            {
                throw new TPNumberException("Точности чисел не совпадают.");
            }
            if (other_2.n == 0)
            {
                throw new TPNumberException("Деление на ноль.");
            }
            double quotient = other_1.n / other_2.n;
            return new TPNumber(quotient, other_1.b, other_1.c);
        }

        public TPNumber Inverse()
        {
            if (n == 0)
            {
                throw new TPNumberException("Деление на ноль");
            }
            double inv = 1.0 / n;
            return new TPNumber(inv, b, c);
        }

        public TPNumber Square()
        {
            double square = n * n;
            return new TPNumber(square, b, c);
        }

        public double GetNumber()
        {
            return n;
        }

        public string GetNString()
        {
            string nString = Convert.ToString(n);
            return nString;
        }

        public int GetBNumber()
        {
            return b;
        }

        public string GetBString()
        {
            string bString = Convert.ToString(b);
            return bString;
        }

        public int GetCNumber()
        {
            return c;
        }

        public string GetCString()
        {
            string cString = Convert.ToString(c);
            return cString;
        }

        public void SetBNumber(int newB)
        {
            if (newB >= 2 && newB <= 16)
            {
                b = newB;
            }
            else
            {
                throw new TPNumberException("Основание СС не принадлежит интервалу [2;16].");
            }
        }

        public void SetBString(string newB)
        {
            int newBaseValue = Convert.ToInt32(newB);
            if (newBaseValue >= 2 && newBaseValue <= 16)
            {
                b = newBaseValue;
            }
            else
            {
                throw new TPNumberException("Основание СС не принадлежит интервалу [2;16].");
            }
        }

        public void SetCNumber(int newC)
        {
            if (newC >= 0)
            {
                c = newC;
            }
            else
            {
                throw new TPNumberException("Точность не может быть меньше 0.");
            }
        }

        public void SetCString(string newC)
        {
            int newPrecisionValue = Convert.ToInt32(newC);
            if (newPrecisionValue >= 0)
            {
                c = newPrecisionValue;
            }
            else
            {
                throw new TPNumberException("Точность не может быть меньше 0.");
            }
        }
    }
}