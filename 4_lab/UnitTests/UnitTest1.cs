namespace UnitTests
{
    using ConsoleApplicationMatrix;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MatrixClass_Addition()
        {
            int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
            MatrixClass a = new MatrixClass(matrix1, 2, 2);
            MatrixClass b = new MatrixClass(matrix2, 2, 2);
            MatrixClass result = a + b;

            int[,] expectedMatrix = { { 6, 8 }, { 10, 12 } };
            MatrixClass expected = new MatrixClass(expectedMatrix, 2, 2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MatrixClass_Subtraction()
        {
            int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
            MatrixClass a = new MatrixClass(matrix1, 2, 2);
            MatrixClass b = new MatrixClass(matrix2, 2, 2);
            MatrixClass result = a - b;

            int[,] expectedMatrix = { { -4, -4 }, { -4, -4 } };
            MatrixClass expected = new MatrixClass(expectedMatrix, 2, 2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MatrixClass_Multiplication()
        {
            int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
            MatrixClass a = new MatrixClass(matrix1, 2, 2);
            MatrixClass b = new MatrixClass(matrix2, 2, 2);
            MatrixClass result = a * b;

            int[,] expectedMatrix = { { 19, 22 }, { 43, 50 } };
            MatrixClass expected = new MatrixClass(expectedMatrix, 2, 2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MatrixClass_Transpose()
        {
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            MatrixClass a = new MatrixClass(matrix, 3, 3);
            MatrixClass result = a.Transp();

            int[,] expectedMatrix = { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } };
            MatrixClass expected = new MatrixClass(expectedMatrix, 3, 3);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void MatrixClass_Invalid_Size_I()
        {
            MatrixClass a = new MatrixClass(-1, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void MatrixClass_Invalid_Size_J()
        {
            MatrixClass a = new MatrixClass(3, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void MatrixClass_Invalid_Size_I_2()
        {
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            MatrixClass a = new MatrixClass(matrix, -3, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void MatrixClass_Invalid_Size_J_2()
        {
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            MatrixClass a = new MatrixClass(matrix, 3, -3);
        }

        [TestMethod]
        public void MatrixClass_Indexer_GetValue()
        {
            int[,] matrix = { { 1, 2 }, { 3, 4 } };
            MatrixClass a = new MatrixClass(matrix, 2, 2);

            int result = a[0, 0];
            int expected = 1;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MatrixClass_Indexer_SetValue()
        {
            int[,] matrix = { { 1, 2 }, { 3, 4 } };
            MatrixClass a = new MatrixClass(matrix, 2, 2);

            a[0, 0] = 5;

            int result = a[0, 0];
            int expected = 5;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void MatrixClass_Indexer_GetValue_OutOfBounds()
        {
            int[,] matrix = { { 1, 2 }, { 3, 4 } };
            MatrixClass a = new MatrixClass(matrix, 2, 2);

            int result = a[3, 3]; // Выход за границы матрицы, ожидаем исключение MyException
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void MatrixClass_Indexer_SetValue_OutOfBounds()
        {
            int[,] matrix = { { 1, 2 }, { 3, 4 } };
            MatrixClass a = new MatrixClass(matrix, 2, 2);

            a[3, 3] = 5; // Выход за границы матрицы при записи, ожидаем исключение MyException
        }
    }
}