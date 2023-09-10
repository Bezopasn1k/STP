using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace STP_FirstLabTests
{
    using STP_FirstLab;
    [TestClass]
    public class FirstLabMethodsTests
    {
        [TestMethod]
        public void TestsProductOddElements_IncArr10LenExpect3840()
        {
            // arrange
            double[] items = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // act
            double result = FirstLabMethods.ProductOddElements(items);

            // assert
            Assert.AreEqual(3840, result);
        }

        [TestMethod]
        public void CyclicRightShift_Shift0OrArrLen()
        {
            // arrange
            double[] items = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // act
            double[] result = FirstLabMethods.CyclicRightShift(items, 0);

            // assert
            for (int i = 0; i  < items.Length; i++)
            {
                Assert.AreEqual(items[i], result[i]);
            }   
        }

        [TestMethod]
        public void CyclicRightShift_ShiftMoreThenArrLen()
        {
            // arrange
            double[] items = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] expectedRes = new double[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // act
            double[] result = FirstLabMethods.CyclicRightShift(items, 11);

            // assert
            for (int i = 0; i < items.Length; i++)
            {
                Assert.AreEqual(expectedRes[i], result[i]);
            }
        }

        [TestMethod]
        public void FromFractionToInt_InvalidRadixForFractionExpectMinus1()
        {
            // arrange
            int radix = 2;
            string fraction = "424.56";

            // act
            int result = FirstLabMethods.FromFractionToInt(radix, fraction);

            // assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void FromFractionToInt_FractionWithDotExpect424()
        {
            // arrange
            int radix = 8;
            string fraction = "424.56";

            // act
            int result = FirstLabMethods.FromFractionToInt(radix, fraction);

            // assert
            Assert.AreEqual(424, result);
        }

        [TestMethod]
        public void FromFractionToInt_FractionWithCommaExpect9403()
        {
            // arrange
            int radix = 10;
            string fraction = "9403,5656";

            // act
            int result = FirstLabMethods.FromFractionToInt(radix, fraction);

            // assert
            Assert.AreEqual(9403, result);
        }
    }
}

