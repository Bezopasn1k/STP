namespace unit_tests
{
    using STP_SecondLab;

    [TestClass]
    public class MinFromTwoTests
    {
        [TestMethod]
        public void MinFromTwo_FirstIsSmaller()
        {
            double result = Program.MinFromTwo(2.5, 5.7);
            Assert.AreEqual(2.5, result, 0.001); // Проверка, что первое число меньше
        }

        [TestMethod]
        public void MinFromTwo_SecondIsSmaller()
        {
            double result = Program.MinFromTwo(8.9, 3.4);
            Assert.AreEqual(3.4, result, 0.001); // Проверка, что второе число меньше
        }

        [TestMethod]
        public void MinFromTwo_BothAreEqual()
        {
            double result = Program.MinFromTwo(6.0, 6.0);
            Assert.AreEqual(6.0, result, 0.001); // Проверка, что оба числа равны
        }

        [TestMethod]
        public void MinFromTwo_BothAreNegative()
        {
            double result = Program.MinFromTwo(-5.3, -2.0);
            Assert.AreEqual(-5.3, result, 0.001); // Проверка, что функция работает с отрицательными числами
        }

        [TestMethod]
        public void MinFromTwo_OneIsNegative()
        {
            double result = Program.MinFromTwo(5.3, -2.0);
            Assert.AreEqual(-2.0, result, 0.001); // Проверка, что функция работает с отрицательными числами
        }
    }

    [TestClass]
    public class MaxMatrixElTests
    {
        [TestMethod]
        public void MaxMatrixEl_ValidMatrix()
        {
            double[,] matrix = { { 1.0, 2.0, 3.0 }, { 4.0, 5.0, 6.0 }, { 7.0, 8.0, 9.0 } };
            double result = Program.MaxMatrixEl(matrix);
            Assert.AreEqual(9.0, result, 0.001); // Проверка нахождения максимального значения
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindMaxElement_EmptyArray()
        {
            double[,] matrix = new double[0, 0];
            double result = Program.MaxMatrixEl(matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxMatrixEl_NullMatrix()
        {
            double[,] matrix = null; ;
            double result = Program.MaxMatrixEl(matrix);
        }
    }
}