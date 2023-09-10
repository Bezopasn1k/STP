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
            // Arrange
            int a = 48;
            int b = 18;

            // Act
            int result = Program.GCD(a, b);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void GCD_NegativeNumbers()
        {
            // Arrange
            int a = -36;
            int b = -48;

            // Act
            int result = Program.GCD(a, b);

            // Assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void GCD_OneZeroInput()
        {
            // Arrange
            int a = 0;
            int b = 42;

            // Act
            int result = Program.GCD(a, b);

            // Assert
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void GCD_BothZeroInput()
        {
            // Arrange
            int a = 0;
            int b = 0;

            // Act
            int result = Program.GCD(a, b);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}