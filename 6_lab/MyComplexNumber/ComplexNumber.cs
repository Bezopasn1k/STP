using System;
using System.Globalization;
using System.Text.RegularExpressions;

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
            // Используем регулярное выражение для разбора строки
            Match match = Regex.Match(complexNumber, @"^([-+]?\d+(\.\d+)?)([-+]?\d+(\.\d+)?)i$");

            if (match.Success)
            {
                // Значение вещественной части
                m_Real = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);

                // Значение мнимой части
                m_Imaginary = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            }
            else
            {
                // Разбор без мнимой части
                Match matchWithoutImaginary = Regex.Match(complexNumber, @"^([-+]?\d+(\.\d+)?)i$");
                if (matchWithoutImaginary.Success)
                {
                    m_Real = 0.0; // Устанавливаем вещественную часть в ноль
                    m_Imaginary = double.Parse(matchWithoutImaginary.Groups[1].Value, CultureInfo.InvariantCulture);
                }
                else
                {
                    // Разбор без вещественной части
                    Match matchWithoutReal = Regex.Match(complexNumber, @"^([-+]?\d+(\.\d+)?)$");
                    if (matchWithoutReal.Success)
                    {
                        m_Real = double.Parse(matchWithoutReal.Groups[1].Value, CultureInfo.InvariantCulture);
                        m_Imaginary = 0.0; // Устанавливаем мнимую часть в ноль
                    }
                    else
                    {
                        // Обработка неверного формата
                        throw new FormatException("Неверный формат комплексного числа");
                    }
                }
            }
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
            return new ComplexNumber(a.m_Real * b.m_Real - a.m_Imaginary * b.m_Imaginary, a.m_Real * b.m_Imaginary + a.m_Imaginary * b.m_Real);
        }

        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            double denominator = b.m_Real * b.m_Real + b.m_Imaginary * b.m_Imaginary;
            double realPart = (a.m_Real * b.m_Real + a.m_Imaginary * b.m_Imaginary) / denominator;
            double imaginaryPart = (a.m_Imaginary * b.m_Real - a.m_Real * b.m_Imaginary) / denominator;
            return new ComplexNumber(realPart, imaginaryPart);
        }


        public ComplexNumber Squaring()
        {
            double realPart = m_Real * m_Real - m_Imaginary * m_Imaginary;
            double imaginaryPart = 2 * m_Real * m_Imaginary;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        public ComplexNumber Reverse()
        {
            double denominator = m_Real * m_Real + m_Imaginary * m_Imaginary;
            double realPart = m_Real / denominator;
            double imaginaryPart = -m_Imaginary / denominator;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        public ComplexNumber Degree(int degree)
        {
            double magnitude = Math.Pow(Math.Sqrt(m_Real * m_Real + m_Imaginary * m_Imaginary), degree);
            double angle = AngleRadian() * degree;
            double realPart = magnitude * Math.Cos(angle);
            double imaginaryPart = magnitude * Math.Sin(angle);
            return new ComplexNumber(realPart, imaginaryPart);
        }

        public ComplexNumber Negative()
        {
            return new ComplexNumber(-m_Real, -m_Imaginary);
        }

        public ComplexNumber Abs()
        {
            return new ComplexNumber(Math.Sqrt(m_Real * m_Real + m_Imaginary * m_Imaginary), 0.0);
        }

        public double AngleRadian()
        {
            if (m_Real > 0)
            {
                return Math.Atan(m_Imaginary / m_Real);
            }
            else if (m_Real == 0 && m_Imaginary > 0)
            {
                return Math.PI / 2;
            }
            else if (m_Real == 0 && m_Imaginary < 0)
            {
                return -Math.PI / 2;
            }
            else if (m_Real < 0)
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
            string sign = m_Imaginary < 0 ? "-" : "+";
            return $"{m_Real}{sign}i*{Math.Abs(m_Imaginary)}";
        }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ComplexNumber otherFraction = (ComplexNumber)obj;
            return m_Real == otherFraction.m_Real && m_Imaginary == otherFraction.m_Imaginary;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(m_Real, m_Imaginary).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ComplexNumber otherFraction = (ComplexNumber)obj;
            return m_Real == otherFraction.m_Real && m_Imaginary == otherFraction.m_Imaginary;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(m_Real, m_Imaginary).GetHashCode();
        }
    }
}
