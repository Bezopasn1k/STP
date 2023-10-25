namespace UnitTests
{
    using ComplexNumberEditor;
    using MyComplexNumber;
    [TestClass]
    public class TEditorTests
    {
        [TestMethod]
        public void TestIsZeroWithZeroRealAndImaginaryParts()
        {
            ComplexNumber num = new ComplexNumber(0.0, 0.0);
            TEditor editor = new TEditor(num);
            Assert.IsTrue(editor.IsZero());
        }

        [TestMethod]
        public void TestIsZeroWithNonZeroRealAndZeroImaginaryPart()
        {
            ComplexNumber num = new ComplexNumber(5.0, 0.0);
            TEditor editor = new TEditor(num);
            Assert.IsFalse(editor.IsZero());
        }

        [TestMethod]
        public void TestIsZeroWithZeroRealAndNonZeroImaginaryPart()
        {
            ComplexNumber num = new ComplexNumber(0.0, 3.0);
            TEditor editor = new TEditor(num);
            Assert.IsFalse(editor.IsZero());
        }

        [TestMethod]
        public void TestIsZeroWithNonZeroRealAndImaginaryParts()
        {
            ComplexNumber num = new ComplexNumber(2.5, -4.0);
            TEditor editor = new TEditor(num);
            Assert.IsFalse(editor.IsZero());
        }

        [TestMethod]
        public void TestIsZeroWithNonZeroRealAndImaginaryPartsWithPositiveImSign()
        {
            ComplexNumber num = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(num);
            Assert.IsFalse(editor.IsZero());
        }

        [TestMethod]
        public void TestIsZeroWithNonZeroRealAndImaginaryPartsWithNegativeImSign()
        {
            ComplexNumber num = new ComplexNumber(3.0, -4.0);
            TEditor editor = new TEditor(num);
            Assert.IsFalse(editor.IsZero());
        }

        [TestMethod]
        public void TestAddSign_RealPartPositiveToNegative()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.AddSign();

            Assert.AreEqual("-3 + i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddSign_RealPartNegativeToPositive()
        {
            ComplexNumber complexNumber = new ComplexNumber(-3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.AddSign();

            Assert.AreEqual("3 + i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddSign_ImaginaryPartPositiveToNegative()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.ChangeEditingZone();

            editor.AddSign();

            Assert.AreEqual("3 - i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddSign_ImaginaryPartNegativeToPositive()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, -4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.ChangeEditingZone();

            editor.AddSign();

            Assert.AreEqual("3 - i*-4", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddDigit_RealPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.AddDigit(5);

            Assert.AreEqual("35 + i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddDigit_ImaginaryPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.ChangeEditingZone();

            editor.AddDigit(7);

            Assert.AreEqual("3 + i*47", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddDigit_NegativeRealPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(-3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.AddDigit(2);

            Assert.AreEqual("-32 + i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddZero_RealPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.AddZero();

            Assert.AreEqual("30 + i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddZero_ImaginaryPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.ChangeEditingZone();

            editor.AddZero();

            Assert.AreEqual("3 + i*40", editor.GetFullString());
        }

        [TestMethod]
        public void TestPop_RealPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(30.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.Pop();

            Assert.AreEqual("3 + i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestPop_ImaginaryPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 40.0);
            TEditor editor = new TEditor(complexNumber);

            editor.ChangeEditingZone();

            editor.Pop();

            Assert.AreEqual("3 + i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestPop_NegativeRealPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(-3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.Pop();

            Assert.AreEqual("-3 + i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestClear()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.Clear();

            Assert.AreEqual("0 + i*0", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddSeparator_RealPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.AddSeparator();

            Assert.AreEqual("3. + i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddSeparator_ImaginaryPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.ChangeEditingZone();

            editor.AddSeparator();

            Assert.AreEqual("3 + i*4.", editor.GetFullString());
        }

        [TestMethod]
        public void TestAddSeparator_NegativeRealPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(-3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.AddSeparator();

            Assert.AreEqual("-3. + i*4", editor.GetFullString());
        }

        [TestMethod]
        public void TestIsEditingRealPart_RealPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            bool isEditingRealPart = editor.IsEditingRealPart();

            Assert.IsTrue(isEditingRealPart);
        }

        [TestMethod]
        public void TestIsEditingRealPart_ImaginaryPartEditing()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            editor.ChangeEditingZone();

            bool isEditingRealPart = editor.IsEditingRealPart();

            Assert.IsFalse(isEditingRealPart);
        }

        [TestMethod]
        public void TestGetRl()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            string realPart = editor.GetRl();

            Assert.AreEqual("3", realPart);
        }

        [TestMethod]
        public void TestGetIm()
        {
            ComplexNumber complexNumber = new ComplexNumber(3.0, 4.0);
            TEditor editor = new TEditor(complexNumber);

            string imaginaryPart = editor.GetIm();

            Assert.AreEqual("4", imaginaryPart);
        }
    }
}