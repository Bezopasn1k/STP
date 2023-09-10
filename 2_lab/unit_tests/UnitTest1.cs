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
}