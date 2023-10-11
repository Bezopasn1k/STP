namespace UnitTests
{
    using TPNumber;
    using static TPNumber.TPNumber;

    [TestClass]
    public class TPNumberTests
    {
        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основание СС не принадлежит интервалу [2;16].")]
        public void TestConstructorWithInvalidBaseBelow()
        {
            TPNumber number = new TPNumber(5.0, 1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основание СС не принадлежит интервалу [2;16].")]
        public void TestConstructorWithInvalidBaseHigher()
        {
            TPNumber number = new TPNumber(5.0, 17, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Точность не может быть меньше 0.")]
        public void TestConstructorWithInvalidPrecision()
        {
            TPNumber number = new TPNumber(3.0, 10, -1);
        }

        [TestMethod]
        public void TestConstructorWithValidParameters()
        {
            TPNumber number = new TPNumber(8.0, 10, 2);
            Assert.AreEqual(8.0, number.GetNumber(), 0.001);
            Assert.AreEqual(10, number.GetBNumber());
            Assert.AreEqual(2, number.GetCNumber());
        }


        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основание СС не принадлежит интервалу [2;16].")]
        public void TestStringConstructorWithInvalidBaseBelow()
        {
            TPNumber number = new TPNumber("5,0", "1", "2");
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основание СС не принадлежит интервалу [2;16].")]
        public void TestStringConstructorWithInvalidBaseHigher()
        {
            TPNumber number = new TPNumber("5,0", "17", "2");
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Точность не может быть меньше 0.")]
        public void TestStringConstructorWithInvalidPrecision()
        {
            TPNumber number = new TPNumber("3,0", "10", "-1");
        }

        [TestMethod]
        public void TestStringConstructorWithValidParameters()
        {
            TPNumber number = new TPNumber("8,0", "10", "2");
            Assert.AreEqual(8.0, number.GetNumber(), 0.001);
            Assert.AreEqual(10, number.GetBNumber());
            Assert.AreEqual(2, number.GetCNumber());
        }

        [TestMethod]
        public void TestTPNumberConstructorWithOther()
        {
            TPNumber original = new TPNumber(5.0, 10, 2);
            TPNumber copy = new TPNumber(original);

            Assert.AreEqual(original.GetNumber(), copy.GetNumber(), 0.001);
            Assert.AreEqual(original.GetBNumber(), copy.GetBNumber());
            Assert.AreEqual(original.GetCNumber(), copy.GetCNumber());
        }

        [TestMethod]
        public void TestCopyMethod()
        {
            TPNumber original = new TPNumber(8.0, 16, 3);
            TPNumber copy = original.Copy();

            Assert.AreEqual(original.GetNumber(), copy.GetNumber(), 0.001);
            Assert.AreEqual(original.GetBNumber(), copy.GetBNumber());
            Assert.AreEqual(original.GetCNumber(), copy.GetCNumber());
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основания чисел не совпадают.")]
        public void TestAdditionOperatorWithMismatchedBase()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 16, 2);
            TPNumber result = num1 + num2;
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Точности чисел не совпадают.")]
        public void TestAdditionOperatorWithMismatchedPrecision()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 10, 3);
            TPNumber result = num1 + num2;
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основания чисел не совпадают.")]
        public void TestMultiplicationOperatorWithMismatchedBase()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 16, 2);
            TPNumber result = num1 * num2;
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Точности чисел не совпадают.")]
        public void TestMultiplicationOperatorWithMismatchedPrecision()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 10, 3);
            TPNumber result = num1 * num2;
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основания чисел не совпадают.")]
        public void TestSubtractionOperatorWithMismatchedBase()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 16, 2);
            TPNumber result = num1 - num2;
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Точности чисел не совпадают.")]
        public void TestSubtractionOperatorWithMismatchedPrecision()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 10, 3);
            TPNumber result = num1 - num2;
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основания чисел не совпадают.")]
        public void TestDivisionOperatorWithMismatchedBase()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 16, 2);
            TPNumber result = num1 / num2;
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Точности чисел не совпадают.")]
        public void TestDivisionOperatorWithMismatchedPrecision()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 10, 3);
            TPNumber result = num1 / num2;
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Деление на ноль.")]
        public void TestDivisionOperatorWithZeroDivisor()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(0.0, 10, 2);
            TPNumber result = num1 / num2;
        }

        [TestMethod]
        public void TestAdditionOperator()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 10, 2);
            TPNumber result = num1 + num2;
            Assert.AreEqual(8.0, result.GetNumber(), 0.001);
            Assert.AreEqual(10, result.GetBNumber());
            Assert.AreEqual(2, result.GetCNumber());
        }

        [TestMethod]
        public void TestMultiplicationOperator()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 10, 2);
            TPNumber result = num1 * num2;
            Assert.AreEqual(15.0, result.GetNumber(), 0.001);
            Assert.AreEqual(10, result.GetBNumber());
            Assert.AreEqual(2, result.GetCNumber());
        }

        [TestMethod]
        public void TestSubtractionOperator()
        {
            TPNumber num1 = new TPNumber(5.0, 10, 2);
            TPNumber num2 = new TPNumber(3.0, 10, 2);
            TPNumber result = num1 - num2;
            Assert.AreEqual(2.0, result.GetNumber(), 0.001);
            Assert.AreEqual(10, result.GetBNumber());
            Assert.AreEqual(2, result.GetCNumber());
        }

        [TestMethod]
        public void TestDivisionOperator()
        {
            TPNumber num1 = new TPNumber(6.0, 10, 2);
            TPNumber num2 = new TPNumber(2.0, 10, 2);
            TPNumber result = num1 / num2;
            Assert.AreEqual(3.0, result.GetNumber(), 0.001);
            Assert.AreEqual(10, result.GetBNumber());
            Assert.AreEqual(2, result.GetCNumber());
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumber.TPNumberException), "Деление на ноль.")]
        public void TestInverseWithZeroNumber()
        {
            TPNumber num = new TPNumber(0, 10, 2);
            TPNumber inverse = num.Inverse();
        }

        [TestMethod]
        public void TestInverseWithNonZeroNumber()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            TPNumber inverse = num.Inverse();
            Assert.AreEqual(0.2, inverse.GetNumber(), 0.001);
            Assert.AreEqual(10, inverse.GetBNumber());
            Assert.AreEqual(2, inverse.GetCNumber());
        }

        [TestMethod]
        public void TestSquare()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            TPNumber square = num.Square();
            Assert.AreEqual(25.0, square.GetNumber(), 0.001);
            Assert.AreEqual(10, square.GetBNumber());
            Assert.AreEqual(2, square.GetCNumber());
        }

        [TestMethod]
        public void TestGetNumber()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            double value = num.GetNumber();
            Assert.AreEqual(5.0, value, 0.001);
        }

        [TestMethod]
        public void TestGetNString()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            string value = num.GetNString();
            Assert.AreEqual("5", value);
        }

        [TestMethod]
        public void TestGetBNumber()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            int value = num.GetBNumber();
            Assert.AreEqual(10, value);
        }

        [TestMethod]
        public void TestGetBString()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            string value = num.GetBString();
            Assert.AreEqual("10", value);
        }

        [TestMethod]
        public void TestGetCNumber()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            int value = num.GetCNumber();
            Assert.AreEqual(2, value);
        }

        [TestMethod]
        public void TestGetCString()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            string value = num.GetCString();
            Assert.AreEqual("2", value);
        }

        [TestMethod]
        public void TestSetBNumberValid()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            num.SetBNumber(8);
            Assert.AreEqual(8, num.GetBNumber());
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основание СС не принадлежит интервалу [2;16].")]
        public void TestSetBNumberInvalidBelow()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            num.SetBNumber(1);
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основание СС не принадлежит интервалу [2;16].")]
        public void TestSetBNumberInvalidHigher()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            num.SetBNumber(17);
        }

        [TestMethod]
        public void TestSetBStringValid()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            num.SetBString("8");
            Assert.AreEqual(8, num.GetBNumber());
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основание СС не принадлежит интервалу [2;16].")]
        public void TestSetBStringInvalidBelow()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            num.SetBString("1");
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Основание СС не принадлежит интервалу [2;16].")]
        public void TestSetBStringInvalidHigher()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            num.SetBString("17");
        }

        [TestMethod]
        public void TestSetCNumberValid()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            num.SetCNumber(3);
            Assert.AreEqual(3, num.GetCNumber());
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Точность не может быть меньше 0.")]
        public void TestSetCNumberInvalid()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            num.SetCNumber(-1);
        }

        [TestMethod]
        public void TestSetCStringValid()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            num.SetCString("3");
            Assert.AreEqual(3, num.GetCNumber());
        }

        [TestMethod]
        [ExpectedException(typeof(TPNumberException), "Точность не может быть меньше 0.")]
        public void TestSetCStringInvalid()
        {
            TPNumber num = new TPNumber(5.0, 10, 2);
            num.SetCString("-1");
        }
    }
}