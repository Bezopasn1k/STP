namespace UnitTests
{
    using MyFraction;
    [TestClass]
    public class MyFractionTests
    {
        [TestMethod]
        public void Constructor_ValidArguments()
        {
            int numerator = 3;
            int denominator = 4;

            MyFraction fraction = new MyFraction(numerator, denominator);

            Assert.AreEqual(numerator, fraction.GetNumerator());
            Assert.AreEqual(denominator, fraction.GetDenominator());
        }

        [TestMethod]
        public void Constructor_InvalidDenominator()
        {
            int numerator = 2;
            int denominator = 0;

            Assert.ThrowsException<MyException>(() => new MyFraction(numerator, denominator));
        }

        [TestMethod]
        public void Constructor_StringRepresentation()
        {
            string fractionStr = "5/6";

            MyFraction fraction = new MyFraction(fractionStr);

            Assert.AreEqual(5, fraction.GetNumerator());
            Assert.AreEqual(6, fraction.GetDenominator());
        }

        [TestMethod]
        public void Operator_Addition()
        {
            MyFraction fraction1 = new MyFraction(1, 2);
            MyFraction fraction2 = new MyFraction(1, 3);

            MyFraction result = fraction1 + fraction2;

            Assert.AreEqual(5, result.GetNumerator());
            Assert.AreEqual(6, result.GetDenominator());
        }

        [TestMethod]
        public void Operator_Subtraction()
        {
            MyFraction fraction1 = new MyFraction(3, 4);
            MyFraction fraction2 = new MyFraction(1, 4);

            MyFraction result = fraction1 - fraction2;

            Assert.AreEqual(1, result.GetNumerator());
            Assert.AreEqual(2, result.GetDenominator());
        }

        [TestMethod]
        public void Operator_Multiplication()
        {
            MyFraction fraction1 = new MyFraction(2, 3);
            MyFraction fraction2 = new MyFraction(3, 4);

            MyFraction result = fraction1 * fraction2;

            Assert.AreEqual(1, result.GetNumerator());
            Assert.AreEqual(2, result.GetDenominator());
        }

        [TestMethod]
        public void Operator_Division()
        {
            MyFraction fraction1 = new MyFraction(2, 3);
            MyFraction fraction2 = new MyFraction(3, 4);

            MyFraction result = fraction1 / fraction2;

            Assert.AreEqual(8, result.GetNumerator());
            Assert.AreEqual(9, result.GetDenominator());
        }

        [TestMethod]
        public void Constructor_InvalidDenominator_Zero()
        {
            string fractionStr = "2/0";

            Assert.ThrowsException<MyException>(() => new MyFraction(fractionStr));
        }

        [TestMethod]
        public void Constructor_InvalidDenominator_AllZeroes()
        {
            string fractionStr = "3/0000";

            Assert.ThrowsException<MyException>(() => new MyFraction(fractionStr));
        }

        [TestMethod]
        public void Constructor_ValidFractionString()
        {
            string fractionStr = "5/7";

            MyFraction fraction = new MyFraction(fractionStr);

            Assert.AreEqual(5, fraction.GetNumerator());
            Assert.AreEqual(7, fraction.GetDenominator());
        }

        [TestMethod]
        public void Copy_ReturnsCopyOfFraction()
        {
            MyFraction originalFraction = new MyFraction(3, 5);

            MyFraction copyFraction = originalFraction.Copy();

            Assert.AreEqual(originalFraction.GetNumerator(), copyFraction.GetNumerator());
            Assert.AreEqual(originalFraction.GetDenominator(), copyFraction.GetDenominator());
        }

        [TestMethod]
        public void Squaring_ReturnsSquareOfFraction()
        {
            MyFraction fraction = new MyFraction(4, 9);

            MyFraction squaredFraction = fraction.Squaring();

            Assert.AreEqual(new MyFraction(16, 81), squaredFraction);
        }

        [TestMethod]
        public void Reverse_ReturnsReciprocalFraction()
        {
            MyFraction fraction = new MyFraction(3, 7);

            MyFraction reversedFraction = fraction.Reverse();

            Assert.AreEqual(new MyFraction(7, 3), reversedFraction);
        }

        [TestMethod]
        public void GetNumeratorStr_ReturnsNumeratorAsString()
        {
            MyFraction fraction = new MyFraction(5, 8);

            string numeratorStr = fraction.GetNumeratorStr();

            Assert.AreEqual("5", numeratorStr);
        }

        [TestMethod]
        public void GetDenominatorStr_ReturnsDenominatorAsString()
        {
            MyFraction fraction = new MyFraction(5, 8);

            string denominatorStr = fraction.GetDenominatorStr();

            Assert.AreEqual("8", denominatorStr);
        }

        [TestMethod]
        public void GetFracStr_ReturnsFractionAsString()
        {
            MyFraction fraction = new MyFraction(1, 4);

            string fracStr = fraction.GetFracStr();

            Assert.AreEqual("1/4", fracStr);
        }

        [TestMethod]
        public void PrintFraction_WritesFractionToConsole()
        {
            MyFraction fraction = new MyFraction(5, 7);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            fraction.PrintFraction();
            string expectedOutput = "Fraction: 5/7" + Environment.NewLine;
            string actualOutput = sw.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Equals_ReturnsTrueForEqualFractions()
        {
            MyFraction fraction1 = new MyFraction(3, 7);
            MyFraction fraction2 = new MyFraction(3, 7);

            bool result = fraction1.Equals(fraction2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_ReturnsFalseForDifferentFractions()
        {
            MyFraction fraction1 = new MyFraction(3, 7);
            MyFraction fraction2 = new MyFraction(4, 9);

            bool result = fraction1.Equals(fraction2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsSameHashCodeForEqualFractions()
        {
            MyFraction fraction1 = new MyFraction(3, 7);
            MyFraction fraction2 = new MyFraction(3, 7);

            int hashCode1 = fraction1.GetHashCode();
            int hashCode2 = fraction2.GetHashCode();

            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void GetHashCode_ReturnsDifferentHashCodeForDifferentFractions()
        {
            MyFraction fraction1 = new MyFraction(3, 7);
            MyFraction fraction2 = new MyFraction(4, 9);

            int hashCode1 = fraction1.GetHashCode();
            int hashCode2 = fraction2.GetHashCode();

            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void Equals_ReturnsFalseForDifferentTypes()
        {
            MyFraction fraction = new MyFraction(3, 7);
            object otherObject = new object();

            bool result = fraction.Equals(otherObject);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_OtherTypeObject_ReturnsFalse()
        {
            MyFraction fraction = new MyFraction(3, 5);
            object otherObject = null;

            bool result = fraction.Equals(otherObject);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualityOperator_EqualsFractions_ReturnsTrue()
        {
            MyFraction fraction1 = new MyFraction(3, 5);
            MyFraction fraction2 = new MyFraction(3, 5);

            bool result = fraction1 == fraction2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualityOperator_NotEqualFractions_ReturnsFalse()
        {
            MyFraction fraction1 = new MyFraction(2, 3);
            MyFraction fraction2 = new MyFraction(3, 4);

            bool result = fraction1 == fraction2;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InequalityOperator_EqualsFractions_ReturnsFalse()
        {
            MyFraction fraction1 = new MyFraction(3, 5);
            MyFraction fraction2 = new MyFraction(3, 5);

            bool result = fraction1 != fraction2;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InequalityOperator_NotEqualFractions_ReturnsTrue()
        {
            MyFraction fraction1 = new MyFraction(2, 3);
            MyFraction fraction2 = new MyFraction(3, 4);

            bool result = fraction1 != fraction2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LessThanOperator_LessThanFractions_ReturnsTrue()
        {
            MyFraction fraction1 = new MyFraction(2, 5);
            MyFraction fraction2 = new MyFraction(3, 5);

            bool result = fraction1 < fraction2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LessThanOperator_GreaterThanFractions_ReturnsFalse()
        {
            MyFraction fraction1 = new MyFraction(3, 5);
            MyFraction fraction2 = new MyFraction(2, 5);

            bool result = fraction1 < fraction2;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThanOrEqualOperator_LessThanFractions_ReturnsTrue()
        {
            MyFraction fraction1 = new MyFraction(2, 5);
            MyFraction fraction2 = new MyFraction(3, 5);

            bool result = fraction1 <= fraction2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LessThanOrEqualOperator_GreaterThanFractions_ReturnsFalse()
        {
            MyFraction fraction1 = new MyFraction(3, 5);
            MyFraction fraction2 = new MyFraction(2, 5);

            bool result = fraction1 <= fraction2;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GreaterThanOperator_GreaterThanFractions_ReturnsTrue()
        {
            MyFraction fraction1 = new MyFraction(3, 5);
            MyFraction fraction2 = new MyFraction(2, 5);

            bool result = fraction1 > fraction2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanOperator_LessThanFractions_ReturnsFalse()
        {
            MyFraction fraction1 = new MyFraction(2, 5);
            MyFraction fraction2 = new MyFraction(3, 5);

            bool result = fraction1 > fraction2;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GreaterThanOrEqualOperator_GreaterThanFractions_ReturnsTrue()
        {
            MyFraction fraction1 = new MyFraction(3, 5);
            MyFraction fraction2 = new MyFraction(2, 5);

            bool result = fraction1 >= fraction2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanOrEqualOperator_LessThanFractions_ReturnsFalse()
        {
            MyFraction fraction1 = new MyFraction(2, 5);
            MyFraction fraction2 = new MyFraction(3, 5);

            bool result = fraction1 >= fraction2;

            Assert.IsFalse(result);
        }
    }
}