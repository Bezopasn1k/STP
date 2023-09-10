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
            // Arrange
            double x = 1.0;
            double y = 2.0;
            double z = 3.0;

            // Act
            double[] result = Program.Order(x, y, z);

            // Assert
            CollectionAssert.AreEqual(new double[] { 3.0, 2.0, 1.0 }, result);
        }

        [TestMethod]
        public void Order_UnsortedInput()
        {
            // Arrange
            double x = 3.0;
            double y = 1.0;
            double z = 2.0;

            // Act
            double[] result = Program.Order(x, y, z);

            // Assert
            CollectionAssert.AreEqual(new double[] { 3.0, 2.0, 1.0 }, result);
        }

        [TestMethod]
        public void Order_SameInput()
        {
            // Arrange
            double x = 2.0;
            double y = 2.0;
            double z = 2.0;

            // Act
            double[] result = Program.Order(x, y, z);

            // Assert
            CollectionAssert.AreEqual(new double[] { 2.0, 2.0, 2.0 }, result);
        }
    }
}