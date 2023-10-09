using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyComplexNumber
{
    public class ComplexNumber
    {
        public double m_Real;
        public double m_Imaginary;

        public ComplexNumber(double real, double imaginary)
        {
            m_Real = real;
            m_Imaginary = imaginary;
        }

        public ComplexNumber(string complexNumber)
        {
            string[] words = { "" };
            string[] words_imaginary = { "" };
            if (complexNumber.Contains("+"))
            {
                words = complexNumber.Split('+');
                words_imaginary = words[1].Split('*');
            }
 
            if (complexNumber.Contains("-"))
            {
                words = complexNumber.Split('-');
                words_imaginary = words[1].Split('*');

            }

            m_Real = Convert.ToDouble(words[0]);
            m_Imaginary = Convert.ToDouble(words_imaginary[0]);
        }

        public ComplexNumber Copy()
        {
            return new ComplexNumber(m_Real, m_Imaginary);
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.m_Real + b.m_Real, a.m_Imaginary + b.m_Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.m_Real - b.m_Real, a.m_Imaginary - b.m_Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.m_Real * b.m_Real - a.m_Imaginary * b.m_Imaginary, a.m_Real * b.m_Imaginary + a.m_Real * a.m_Imaginary);
        }

        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber((a.m_Real * a.m_Imaginary + b.m_Real * b.m_Imaginary) / (Math.Pow(a.m_Imaginary, 2) + Math.Pow(b.m_Imaginary, 2)),
                (b.m_Real * a.m_Imaginary - a.m_Real * b.m_Imaginary) / (Math.Pow(a.m_Imaginary, 2) + Math.Pow(b.m_Imaginary, 2)));
        }

        public ComplexNumber Squaring()
        {
            return new ComplexNumber((m_Real * m_Real - m_Imaginary * m_Imaginary), (m_Real * m_Imaginary + m_Real * m_Imaginary));
        }

        public ComplexNumber Reverse()
        {
            return new ComplexNumber((m_Real / (Math.Pow(m_Real, 2) + Math.Pow(m_Imaginary, 2))), -(m_Imaginary / (Math.Pow(m_Real, 2) + Math.Pow(m_Imaginary, 2))));
        }

       
        public ComplexNumber Negative()
        {
            return new ComplexNumber(-m_Real, -m_Imaginary);
        }

        public ComplexNumber Abs()
        {
            return new ComplexNumber(Math.Sqrt(m_Real * m_Real), Math.Sqrt(m_Imaginary * m_Imaginary));
        }

        public double AngleRadian()
        {
            if (m_Real > 0) {
                return Math.Atan(m_Imaginary / m_Real);
            } else if (m_Real == 0 && m_Imaginary > 0)
            {
                return Math.PI / 2;
            } else if (m_Real == 0 && m_Imaginary < 0)
            {
                return -Math.PI / 2;
            } else if (m_Real < 0)
            {
                return Math.Atan(m_Imaginary / m_Real) + Math.PI;
            }

            return 0;
        }

        public double AngleDegree()
        {
            if (m_Real > 0)
            {
                return (AngleRadian() * 180) / Math.PI;
            }

            return 0;
        }

        public ComplexNumber Degree(int  degree) // какая-то пупа с лупой (очень вероятно, что криво работает)
        {
            ComplexNumber res = Abs();
            for (int i = 0; i < degree; i++)
            {
                res *= res;
            }
            ComplexNumber res_2 = new ComplexNumber(Math.Cos(AngleRadian() * degree), Math.Sin(AngleRadian() * degree));
            res = res * res_2;
            return res;
        }

        public ComplexNumber Sqrt(int degree, int i) // какая-то пупа с лупой
        {
            ComplexNumber res = Abs();
            for (int j = 0; j < degree; j++)
            {
                res *= res;
            }
            ComplexNumber res_2 = new ComplexNumber(Math.Cos(AngleRadian() * degree), Math.Sin(AngleRadian() * degree));
            res = res * res_2;
            return res;
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return (a.m_Real != b.m_Real || a.m_Imaginary != b.m_Imaginary) ? true : false;
        }

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return (a.m_Real == b.m_Real && a.m_Imaginary == b.m_Imaginary) ? true : false;
        }

        public double GetRe()
        {
            return m_Real;
        }

        public double GetIm()
        {
            return m_Imaginary;
        }

        public string GetReStr()
        {
            return Convert.ToString(m_Real);
        }

        public string GetImStr()
        {
            return Convert.ToString(m_Imaginary);
        }

        public string GetComplex()
        {
            if (m_Imaginary > 0)
            {
                return $"{m_Real}+i*{m_Imaginary}";
            } else
            {
                return $"{m_Real}-i*{m_Imaginary}";
            }
        }
    }
}
