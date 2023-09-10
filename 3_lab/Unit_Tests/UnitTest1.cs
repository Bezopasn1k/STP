namespace Unit_Tests
{
    using STP_ThirdLab;

    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void Main_Test()
        {
            Program.Main(null);
        }
    }

    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Order_SortedInput()
        {
            double x = 1.0;
            double y = 2.0;
            double z = 3.0;

            double[] result = Program.Order(x, y, z);

            CollectionAssert.AreEqual(new double[] { 3.0, 2.0, 1.0 }, result);
        }

        [TestMethod]
        public void Order_UnsortedInput()
        {
            double x = 3.0;
            double y = 1.0;
            double z = 2.0;

            double[] result = Program.Order(x, y, z);

            CollectionAssert.AreEqual(new double[] { 3.0, 2.0, 1.0 }, result);
        }

        [TestMethod]
        public void Order_SameInput()
        {
            double x = 2.0;
            double y = 2.0;
            double z = 2.0;

            double[] result = Program.Order(x, y, z);

            CollectionAssert.AreEqual(new double[] { 2.0, 2.0, 2.0 }, result);
        }
    }

    [TestClass]
    public class GCDTests
    {
        [TestMethod]
        public void GCD_PositiveNumbers()
        {
            int a = 48;
            int b = 18;

            int result = Program.GCD(a, b);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void GCD_NegativeNumbers()
        {
            int a = -36;
            int b = -48;

            int result = Program.GCD(a, b);

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void GCD_OneZeroInput()
        {
            int a = 0;
            int b = 42;

            int result = Program.GCD(a, b);

            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void GCD_BothZeroInput()
        {
            int a = 0;
            int b = 0;

            int result = Program.GCD(a, b);

            Assert.AreEqual(0, result);
        }
    }

    [TestClass]
    public class ConvertFromEvenTests
    {
        [TestMethod]
        public void ConvertFromEven_PositiveNumber()
        {
            int x = 12345;

            int result = Program.ConvertFromEven(x);

            Assert.AreEqual(24, result);
        }

        [TestMethod]
        public void ConvertFromEven_Zero()
        {
            int x = 0;

            int result = Program.ConvertFromEven(x);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ConvertFromEven_NegativeNumber()
        {
            int x = -13579;

            int result = Program.ConvertFromEven(x);

            Assert.AreEqual(37, result);
        }

        [TestMethod]
        public void ConvertFromEven_MixedNumber()
        {
            int x = 1234567890;

            int result = Program.ConvertFromEven(x);

            Assert.AreEqual(13579, result);
        }
    }

    [TestClass]
    public class MaxMatrixTopDiameterElTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxMatrixTopDiameterEl_EmptyArray()
        {
            double[,] matrix = new double[0, 0];
            double result = Program.MaxMatrixTopDiameterEl(matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxMatrixTopDiameterEl_NullMatrix()
        {
            double[,] matrix = null; ;
            double result = Program.MaxMatrixTopDiameterEl(matrix);
        }

        [TestMethod]
        public void MaxMatrixTopDiameterEl_ValidMatrix()
        {
            double[,] matrix = {
            { 1.0, 2.0, 3.0 },
            { 4.0, 5.0, 6.0 },
            { 7.0, 8.0, 9.0 }
            };

            double result = Program.MaxMatrixTopDiameterEl(matrix);
            Assert.AreEqual(3.0, result, 0.001);
        }
        [TestMethod]
        public void MaxMatrixTopDiameterEl_NegativeValidMatrix()
        {
            double[,] matrix = {
            { -1.0, -2.0, -3.0 },
            { -4.0, -5.0, -6.0 },
            { -7.0, -8.0, -9.0 }
            };

            double result = Program.MaxMatrixTopDiameterEl(matrix);
            Assert.AreEqual(-3.0, result, 0.001);
        }

        public void MaxMatrixTopDiameterEl_OnesMatrix()
        {
            double[,] matrix = {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
            };

            double result = Program.MaxMatrixTopDiameterEl(matrix);
            Assert.AreEqual(3.0, result, 0.001);
        }
    }
}