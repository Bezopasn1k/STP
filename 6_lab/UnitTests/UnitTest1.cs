using MyComplexNumber;

namespace UnitTests
{
    [TestClass]
    public class ComplexNumberTests
    {
        [TestMethod]
        public void TestComplexNumberConstructorWithRealAndImaginary()
        {
            ComplexNumber complex = new ComplexNumber(3.0, 4.0);
            Assert.AreEqual(3.0, complex.m_Real);
            Assert.AreEqual(4.0, complex.m_Imaginary);
        }

        [TestMethod]
        public void TestComplexNumberConstructorWithStringPositive()
        {
            ComplexNumber complex = new ComplexNumber("3.0+4.0i");
            Assert.AreEqual(3.0, complex.m_Real);
            Assert.AreEqual(4.0, complex.m_Imaginary);
        }

        [TestMethod]
        public void TestComplexNumberConstructorWithStringNegative()
        {
            ComplexNumber complex = new ComplexNumber("3.0-4.0i");
            Assert.AreEqual(3.0, complex.m_Real);
            Assert.AreEqual(-4.0, complex.m_Imaginary);
        }

        [TestMethod]
        public void TestComplexNumberConstructorWithStringNoImaginary()
        {
            ComplexNumber complex = new ComplexNumber("3.0");
            Assert.AreEqual(3.0, complex.m_Real);
            Assert.AreEqual(0.0, complex.m_Imaginary);
        }

        [TestMethod]
        public void TestComplexNumberConstructorWithStringNoReal()
        {
            ComplexNumber complex = new ComplexNumber("-4.0i");
            Assert.AreEqual(0.0, complex.m_Real);
            Assert.AreEqual(-4.0, complex.m_Imaginary);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestComplexNumberConstructorWithStringInvalidInput()
        {
            ComplexNumber complex = new ComplexNumber("3.0/4.0i");
        }

        [TestMethod]
        public void TestComplexNumberAddition()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            ComplexNumber b = new ComplexNumber(1.0, 2.0);
            ComplexNumber result = a + b;
            Assert.AreEqual(4.0, result.m_Real);
            Assert.AreEqual(6.0, result.m_Imaginary);
        }

        [TestMethod]
        public void TestComplexNumberSubtraction()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            ComplexNumber b = new ComplexNumber(1.0, 2.0);
            ComplexNumber result = a - b;
            Assert.AreEqual(2.0, result.m_Real);
            Assert.AreEqual(2.0, result.m_Imaginary);
        }

        [TestMethod]
        public void TestComplexNumberMultiplication()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            ComplexNumber b = new ComplexNumber(1.0, 2.0);
            ComplexNumber result = a * b;
            Assert.AreEqual(-5.0, result.m_Real);
            Assert.AreEqual(10.0, result.m_Imaginary);
        }

        [TestMethod]
        public void TestComplexNumberDivision()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            ComplexNumber b = new ComplexNumber(1.0, 2.0);
            ComplexNumber result = a / b;
            Assert.AreEqual(2.2, result.m_Real);
            Assert.AreEqual(-0.4, result.m_Imaginary);
        }

        [TestMethod]
        public void TestComplexNumberCopy()
        {
            ComplexNumber original = new ComplexNumber(3.0, 4.0);
            ComplexNumber copy = original.Copy();
            Assert.AreEqual(original.m_Real, copy.m_Real);
            Assert.AreEqual(original.m_Imaginary, copy.m_Imaginary);
        }

        [TestMethod]
        public void TestComplexNumberSquaring()
        {
            ComplexNumber complex = new ComplexNumber(3.0, 4.0);
            ComplexNumber squared = complex.Squaring();
            Assert.AreEqual(-7.0, squared.m_Real, 1e-10);
            Assert.AreEqual(24.0, squared.m_Imaginary, 1e-10);
        }

        [TestMethod]
        public void TestComplexNumberReverse()
        {
            ComplexNumber complex = new ComplexNumber(3.0, 4.0);
            ComplexNumber reversed = complex.Reverse();
            Assert.AreEqual(0.12, reversed.m_Real, 1e-10);
            Assert.AreEqual(-0.16, reversed.m_Imaginary, 1e-10);
        }

        [TestMethod]
        public void TestComplexNumberDegree()
        {
            ComplexNumber complex = new ComplexNumber(3.0, 4.0);
            ComplexNumber degree2 = complex.Degree(2);
            Assert.AreEqual(-7.0, degree2.m_Real, 1e-10);
            Assert.AreEqual(24.0, degree2.m_Imaginary, 1e-10);

            ComplexNumber degree3 = complex.Degree(3);
            Assert.AreEqual(-117.0, degree3.m_Real, 1e-10);
            Assert.AreEqual(44.0, degree3.m_Imaginary, 1e-10);
        }

        [TestMethod]
        public void TestComplexNumberNegative()
        {
            ComplexNumber complex = new ComplexNumber(3.0, 4.0);
            ComplexNumber negativeComplex = complex.Negative();
            Assert.AreEqual(-3.0, negativeComplex.m_Real);
            Assert.AreEqual(-4.0, negativeComplex.m_Imaginary);
        }

        [TestMethod]
        public void TestComplexNumberAbs()
        {
            ComplexNumber complex = new ComplexNumber(3.0, 4.0);
            ComplexNumber absComplex = complex.Abs();
            Assert.AreEqual(5.0, absComplex.m_Real);
            Assert.AreEqual(0.0, absComplex.m_Imaginary);
        }

        [TestMethod]
        public void TestAngleRadian()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            Assert.AreEqual(Math.Atan(4.0 / 3.0), a.AngleRadian(), 1e-6);

            ComplexNumber b = new ComplexNumber(0.0, 4.0);
            Assert.AreEqual(Math.PI / 2, b.AngleRadian(), 1e-6);

            ComplexNumber c = new ComplexNumber(0.0, -4.0);
            Assert.AreEqual(-Math.PI / 2, c.AngleRadian(), 1e-6);

            ComplexNumber d = new ComplexNumber(-3.0, 4.0);
            Assert.AreEqual(Math.Atan(d.m_Imaginary / d.m_Real) + Math.PI, d.AngleRadian(), 1e-6);

            ComplexNumber e = new ComplexNumber(0.0, 0.0);
            Assert.AreEqual(0, e.AngleRadian(), 1e-6);
        }

        [TestMethod]
        public void TestAngleDegree()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            Assert.AreEqual((Math.Atan(4.0 / 3.0) * 180) / Math.PI, a.AngleDegree(), 1e-6);

            ComplexNumber b = new ComplexNumber(-3.0, 4.0);
            Assert.AreEqual(0, b.AngleDegree(), 1e-6);

            ComplexNumber c = new ComplexNumber(0.0, 4.0);
            Assert.AreEqual(0, c.AngleDegree(), 1e-6);
        }

        [TestMethod]
        public void TestComplexNumberInequalityOperator()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            ComplexNumber b = new ComplexNumber(3.0, 4.0);
            ComplexNumber c = new ComplexNumber(5.0, 6.0);

            Assert.IsFalse(a != b);
            Assert.IsTrue(a != c);
        }

        [TestMethod]
        public void TestComplexNumberEqualityOperator()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            ComplexNumber b = new ComplexNumber(3.0, 4.0);
            ComplexNumber c = new ComplexNumber(5.0, 6.0);

            Assert.IsTrue(a == b);
            Assert.IsFalse(a == c);
        }

        [TestMethod]
        public void TestGetRe()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            Assert.AreEqual(3.0, a.GetRe());

            ComplexNumber b = new ComplexNumber(-2.5, 0.0);
            Assert.AreEqual(-2.5, b.GetRe());
        }

        [TestMethod]
        public void TestGetIm()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            Assert.AreEqual(4.0, a.GetIm());

            ComplexNumber b = new ComplexNumber(0.0, -2.5);
            Assert.AreEqual(-2.5, b.GetIm());
        }

        [TestMethod]
        public void TestGetReStr()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            Assert.AreEqual("3", a.GetReStr());

            ComplexNumber b = new ComplexNumber(-2.5, 0.0);
            Assert.AreEqual("-2,5", b.GetReStr());
        }

        [TestMethod]
        public void TestGetImStr()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            Assert.AreEqual("4", a.GetImStr());

            ComplexNumber b = new ComplexNumber(0.0, -2.5);
            Assert.AreEqual("-2,5", b.GetImStr());
        }

        [TestMethod]
        public void TestGetComplex()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            Assert.AreEqual("3+i*4", a.GetComplex());

            ComplexNumber b = new ComplexNumber(-2.5, -2.5);
            Assert.AreEqual("-2,5-i*2,5", b.GetComplex());
        }

        [TestMethod]
        public void TestEquals()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            ComplexNumber b = new ComplexNumber(3.0, 4.0);
            ComplexNumber c = new ComplexNumber(3.1, 4.0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));
        }

        [TestMethod]
        public void TestEqualsWithNull()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            Assert.IsFalse(a.Equals(null));
        }


        [TestMethod]
        public void TestGetHashCode()
        {
            ComplexNumber a = new ComplexNumber(3.0, 4.0);
            ComplexNumber b = new ComplexNumber(3.0, 4.0);
            ComplexNumber c = new ComplexNumber(3.1, 4.0);

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
            Assert.AreNotEqual(a.GetHashCode(), c.GetHashCode());
        }
    }
}