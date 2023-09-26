using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFraction
{
    public class MyException : Exception
    {
        public MyException(string s) : base(s) { }
    }
    public class MyFraction
    {
        private int m_Numerator;
        private int m_Denominator;

        public MyFraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new MyException($"Знаменатель равен 0");
            }
            m_Numerator = numerator;
            m_Denominator = denominator;
            int gcd = GCD(m_Numerator, m_Denominator);
            m_Numerator /= gcd;
            m_Denominator /= gcd;
        }

        public MyFraction(string fraction)
        {
            string[] words = fraction.Split('/');
            if (words[1][0] == '0' && words[1].Length == 1)
                {
                    throw new MyException($"Знаменатель равен 0");
                }
            else
            {
                bool flag = false;
                for (int i = 0; i < words[1].Length; i++)
                {
                    if (words[1][i] != '0')
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    throw new MyException($"Знаменатель равен 0");
                }
            }
            m_Numerator = Convert.ToInt32(words[0]);
            m_Denominator = Convert.ToInt32(words[1]);
            int gcd = GCD(m_Numerator, m_Denominator);
            m_Numerator /= gcd;
            m_Denominator /= gcd;
        }

        public MyFraction Copy()
        {
            MyFraction copy = new MyFraction(m_Numerator, m_Denominator);
            return copy;
        }

        public static MyFraction operator +(MyFraction a, MyFraction b)
        {
            a.GCD(a.m_Numerator, a.m_Denominator);
            b.GCD(b.m_Numerator, b.m_Denominator);
            MyFraction c = new MyFraction(a.m_Numerator * b.m_Denominator + b.m_Numerator * a.m_Denominator, a.m_Denominator * b.m_Denominator);
            c.GCD(c.m_Numerator, c.m_Denominator);
            return c;
        }

        public static MyFraction operator -(MyFraction a, MyFraction b)
        {
            a.GCD(a.m_Numerator, a.m_Denominator);
            b.GCD(b.m_Numerator, b.m_Denominator);
            MyFraction c = new MyFraction(a.m_Numerator * b.m_Denominator - b.m_Numerator * a.m_Denominator, a.m_Denominator * b.m_Denominator);
            c.GCD(c.m_Numerator, c.m_Denominator);
            return c;
        }

        public static MyFraction operator *(MyFraction a, MyFraction b)
        {
            a.GCD(a.m_Numerator, a.m_Denominator);
            b.GCD(b.m_Numerator, b.m_Denominator);
            MyFraction c = new MyFraction(a.m_Numerator * b.m_Numerator, a.m_Denominator * b.m_Denominator);
            c.GCD(c.m_Numerator, c.m_Denominator);
            return c;
        }

        public static MyFraction operator /(MyFraction a, MyFraction b)
        {
            a.GCD(a.m_Numerator, a.m_Denominator);
            b.GCD(b.m_Numerator, b.m_Denominator);
            MyFraction c = new MyFraction(a.m_Numerator * b.m_Denominator, a.m_Denominator * b.m_Numerator);
            c.GCD(c.m_Numerator, c.m_Denominator);
            return c;
        }

        public MyFraction Squaring()
        {
            MyFraction c = this * this;
            c.GCD(c.m_Numerator, c.m_Denominator);
            return c;
        }

        public MyFraction Reverse()
        {
            MyFraction c = new MyFraction(m_Denominator, m_Numerator);

            c.GCD(c.m_Numerator, c.m_Denominator);
            return c;
        }

        public static bool operator !=(MyFraction a, MyFraction b)
        {
            a.GCD(a.m_Numerator, a.m_Denominator); 
            b.GCD(b.m_Numerator, b.m_Denominator);
            return (a.m_Numerator != b.m_Numerator || a.m_Denominator != b.m_Denominator) ? true : false;
        }

        public static bool operator ==(MyFraction a, MyFraction b)
        {
            a.GCD(a.m_Numerator, a.m_Denominator);
            b.GCD(b.m_Numerator, b.m_Denominator);
            return (a.m_Numerator == b.m_Numerator && a.m_Denominator == b.m_Denominator) ? true : false;
        }

        public static bool operator <(MyFraction a, MyFraction b)
        {
            a.GCD(a.m_Numerator, a.m_Denominator);
            b.GCD(b.m_Numerator, b.m_Denominator);
            return (((float)a.m_Numerator / (float)a.m_Denominator) < ((float)b.m_Numerator / (float)b.m_Denominator)) ? true : false;
        }

        public static bool operator <=(MyFraction a, MyFraction b)
        {
            a.GCD(a.m_Numerator, a.m_Denominator);
            b.GCD(b.m_Numerator, b.m_Denominator);
            return (((float)a.m_Numerator / (float)a.m_Denominator) <= ((float)b.m_Numerator / (float)b.m_Denominator)) ? true : false;
        }

        public static bool operator >(MyFraction a, MyFraction b)
        {
            a.GCD(a.m_Numerator, a.m_Denominator);
            b.GCD(b.m_Numerator, b.m_Denominator);
            return (((float)a.m_Numerator / (float)a.m_Denominator) > ((float)b.m_Numerator / (float)b.m_Denominator)) ? true : false;
        }

        public static bool operator >=(MyFraction a, MyFraction b)
        {
            a.GCD(a.m_Numerator, a.m_Denominator);
            b.GCD(b.m_Numerator, b.m_Denominator);
            return (((float)a.m_Numerator / (float)a.m_Denominator) >= ((float)b.m_Numerator / (float)b.m_Denominator)) ? true : false;
        }

        public int GCD(int num1, int num2)
        {
            int Remainder;

            while (num2 != 0)
            {
                Remainder = num1 % num2;
                num1 = num2;
                num2 = Remainder;
            }

            return num1;
        }

        public int GetNumerator()
        {
            return m_Numerator;
        }

        public int GetDenominator()
        {
            return m_Denominator;
        }

        public string GetNumeratorStr()
        {
            return Convert.ToString(m_Numerator);
        }

        public string GetDenominatorStr()
        {
            return Convert.ToString(m_Denominator);
        }

        public string GetFracStr()
        {
            return Convert.ToString(m_Numerator + '/' + m_Denominator);
        }

        public void PrintFraction()
        {
            Console.WriteLine("Fraction: "+ m_Numerator + '/' + m_Denominator);
        }
    }
}
