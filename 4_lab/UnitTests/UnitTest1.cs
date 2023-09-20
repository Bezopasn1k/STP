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
        public void MatrixClass_Indexer_GetValue_OutOfBounds_I()
        {
            int[,] matrix = { { 1, 2 }, { 3, 4 } };
            MatrixClass a = new MatrixClass(matrix, 2, 2);

            int result = a[3, 1]; // Выход за границы матрицы, ожидаем исключение MyException
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void MatrixClass_Indexer_GetValue_OutOfBounds_J()
        {
            int[,] matrix = { { 1, 2 }, { 3, 4 } };
            MatrixClass a = new MatrixClass(matrix, 2, 2);

            int result = a[1, 3]; // Выход за границы матрицы, ожидаем исключение MyException
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void MatrixClass_Indexer_SetValue_OutOfBounds_I()
        {
            int[,] matrix = { { 1, 2 }, { 3, 4 } };
            MatrixClass a = new MatrixClass(matrix, 2, 2);

            a[3, 1] = 5; // Выход за границы матрицы при записи, ожидаем исключение MyException
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void MatrixClass_Indexer_SetValue_OutOfBounds_J()
        {
            int[,] matrix = { { 1, 2 }, { 3, 4 } };
            MatrixClass a = new MatrixClass(matrix, 2, 2);

            a[1, 3] = 5; // Выход за границы матрицы при записи, ожидаем исключение MyException
        }

        [TestMethod]
        public void MatrixClass_Addition_Operator_ResultIsNull()
        {
            int[,] matrixA = { { 1, 2 } };
            int[,] matrixB = { { 5, 6, 7 }, { 8, 9, 10 } };
            MatrixClass a = new MatrixClass(matrixA, 1, 2);
            MatrixClass b = new MatrixClass(matrixB, 2, 3);

            MatrixClass result = a + b;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void MatrixClass_Subtraction_Operator_ResultIsNull()
        {
            int[,] matrixA = { { 1, 2 } };
            int[,] matrixB = { { 5, 6, 7 }, { 8, 9, 10 } };
            MatrixClass a = new MatrixClass(matrixA, 1, 2);
            MatrixClass b = new MatrixClass(matrixB, 2, 3);

            MatrixClass result = a - b;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void MatrixClass_Multiplication_Operator_ResultIsNull()
        {
            int[,] matrixA = { { 1, 2, 3, 4 } };
            int[,] matrixB = { { 5, 6, 7 }, { 8, 9, 10 } };
            MatrixClass a = new MatrixClass(matrixA, 1, 4);
            MatrixClass b = new MatrixClass(matrixB, 2, 3);

            MatrixClass result = a * b;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void MatrixClass_Equals_ReturnsTrueForEqualMatrices()
        {
            int[,] matrixData1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrixData2 = { { 1, 2 }, { 3, 4 } };
            MatrixClass matrix1 = new MatrixClass(matrixData1, 2, 2);
            MatrixClass matrix2 = new MatrixClass(matrixData2, 2, 2);

            bool result = matrix1.Equals(matrix2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MatrixClass_Equals_ReturnsFalseForDifferentMatrices()
        {
            int[,] matrixData1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrixData2 = { { 5, 6 }, { 7, 8 } };
            MatrixClass matrix1 = new MatrixClass(matrixData1, 2, 2);
            MatrixClass matrix2 = new MatrixClass(matrixData2, 2, 2);

            bool result = matrix1.Equals(matrix2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MatrixClass_GetI_ReturnsNumberOfRows()
        {
            int[,] matrixData = { { 1, 2, 3 }, { 4, 5, 6 } };
            MatrixClass matrix = new MatrixClass(matrixData, 2, 3);

            int rows = matrix.GetI();

            Assert.AreEqual(2, rows);
        }

        [TestMethod]
        public void MatrixClass_GetJ_ReturnsNumberOfColumns()
        {
            int[,] matrixData = { { 1, 2, 3 }, { 4, 5, 6 } };
            MatrixClass matrix = new MatrixClass(matrixData, 2, 3);

            int columns = matrix.GetJ();

            Assert.AreEqual(3, columns);
        }

        [TestMethod]
        public void MatrixClass_ToString_ReturnsMatrixAsString()
        {
            int[,] matrixData = { { 1, 2 }, { 3, 4 } };
            MatrixClass matrix = new MatrixClass(matrixData, 2, 2);

            string result = matrix.ToString();

            Assert.AreEqual("{{1,2} {3,4}}", result);
        }

        [TestMethod]
        public void MatrixClass_Min_ReturnsMinimumValue()
        {
            int[,] matrixData = { { 5, 2, 9 }, { 3, 7, 1 } };
            MatrixClass matrix = new MatrixClass(matrixData, 2, 3);

            int min = matrix.Min();

            Assert.AreEqual(1, min);
        }

        [TestMethod]
        public void MatrixClass_NotEqualOperator_ReturnsTrueForDifferentMatrices()
        {
            int[,] matrixData1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrixData2 = { { 5, 6 }, { 7, 8 } };
            MatrixClass matrix1 = new MatrixClass(matrixData1, 2, 2);
            MatrixClass matrix2 = new MatrixClass(matrixData2, 2, 2);

            bool result = matrix1 != matrix2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MatrixClass_NotEqualOperator_ReturnsFalseForEqualMatrices()
        {
            int[,] matrixData1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrixData2 = { { 1, 2 }, { 3, 4 } };
            MatrixClass matrix1 = new MatrixClass(matrixData1, 2, 2);
            MatrixClass matrix2 = new MatrixClass(matrixData2, 2, 2);

            bool result = matrix1 != matrix2;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MatrixClass_Show_PrintsMatrixToConsole()
        {
            int[,] matrixData = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            MatrixClass matrix = new MatrixClass(matrixData, 3, 3);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                matrix.Show();

                string expectedOutput = "\t1\t2\t3" + Environment.NewLine +
                                        "\t4\t5\t6" + Environment.NewLine +
                                        "\t7\t8\t9" + Environment.NewLine + Environment.NewLine;
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

    }
}