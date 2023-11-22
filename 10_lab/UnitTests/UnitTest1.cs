using ProcessorTemplate—lass;

namespace UnitTests
{
    [TestClass]
    public class TProcTests
    {
        [TestMethod]
        public void TestDefaultValues()
        {
            TProc<int> processor = new TProc<int>();

            Assert.AreEqual(default(int), processor.ReadLop_Res());
            Assert.AreEqual(default(int), processor.ReadRop());
            Assert.AreEqual(TOprtn.None, processor.ReadOperation());
        }

        [TestMethod]
        public void TestLop_Res_Set()
        {
            TProc<int> processor = new TProc<int>();

            processor.Lop_Res_Set(5);

            Assert.AreEqual(5, processor.ReadLop_Res());
        }

        [TestMethod]
        public void TestRop_Set()
        {
            TProc<int> processor = new TProc<int>();

            processor.Rop_Set(3);

            Assert.AreEqual(3, processor.ReadRop());
        }

        [TestMethod]
        public void TestWriteOperation()
        {
            TProc<int> processor = new TProc<int>();

            processor.WriteOperation(TOprtn.Add);

            Assert.AreEqual(TOprtn.Add, processor.ReadOperation());
        }

        [TestMethod]
        public void TestAddOperation()
        {
            TProc<int> processor = new TProc<int>();

            processor.Lop_Res_Set(5);
            processor.Rop_Set(3);
            processor.WriteOperation(TOprtn.Add);
            processor.OprtnRun();

            Assert.AreEqual(8, processor.ReadLop_Res());
        }

        [TestMethod]
        public void TestSubtractOperation()
        {
            TProc<int> processor = new TProc<int>();

            processor.Lop_Res_Set(5);
            processor.Rop_Set(3);
            processor.WriteOperation(TOprtn.Sub);
            processor.OprtnRun();

            Assert.AreEqual(2, processor.ReadLop_Res());
        }

        [TestMethod]
        public void TestMultiplyOperation()
        {
            TProc<int> processor = new TProc<int>();

            processor.Lop_Res_Set(5);
            processor.Rop_Set(3);
            processor.WriteOperation(TOprtn.Mul);
            processor.OprtnRun();

            Assert.AreEqual(15, processor.ReadLop_Res());
        }

        [TestMethod]
        public void TestDivideOperation()
        {
            TProc<int> processor = new TProc<int>();

            processor.Lop_Res_Set(6);
            processor.Rop_Set(3);
            processor.WriteOperation(TOprtn.Dvd);
            processor.OprtnRun();

            Assert.AreEqual(2, processor.ReadLop_Res());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivideByZero()
        {
            TProc<int> processor = new TProc<int>();

            processor.Lop_Res_Set(6);
            processor.Rop_Set(0);
            processor.WriteOperation(TOprtn.Dvd);
            processor.OprtnRun();
        }

        [TestMethod]
        public void TestFuncRunReverse()
        {
            TProc<int> processor = new TProc<int>();

            processor.Rop_Set(5);
            processor.FuncRun(TFunc.Rev);

            Assert.AreEqual(0, processor.ReadRop());
        }

        [TestMethod]
        public void TestFuncRunSquare()
        {
            TProc<int> processor = new TProc<int>();

            processor.Rop_Set(3);
            processor.FuncRun(TFunc.Sqr);

            Assert.AreEqual(9, processor.ReadRop());
        }

        [TestMethod]
        public void TestOprtnClear()
        {
            TProc<int> processor = new TProc<int>();

            processor.Lop_Res_Set(5);
            processor.Rop_Set(3);
            processor.WriteOperation(TOprtn.Add);
            processor.OprtnClear();

            Assert.AreEqual(default(int), processor.ReadLop_Res());
            Assert.AreEqual(default(int), processor.ReadRop());
            Assert.AreEqual(TOprtn.None, processor.ReadOperation());
        }

        [TestMethod]
        public void TestOprtnRunWithNoneOperation()
        {
            TProc<int> processor = new TProc<int>();

            processor.Lop_Res_Set(5);
            processor.Rop_Set(3);
            processor.OprtnRun();

            Assert.AreEqual(5, processor.ReadLop_Res());
            Assert.AreEqual(3, processor.ReadRop());
            Assert.AreEqual(TOprtn.None, processor.ReadOperation());
        }

        [TestMethod]
        public void TestOprtnRunWithAddOperation()
        {
            TProc<int> processor = new TProc<int>();

            processor.Lop_Res_Set(5);
            processor.Rop_Set(3);
            processor.WriteOperation(TOprtn.Add);

            Console.WriteLine($"Before OprtnRun: Lop_Res: {processor.ReadLop_Res()}, Rop: {processor.ReadRop()}, Operation: {processor.ReadOperation()}");
            processor.OprtnRun();
            Console.WriteLine($"After OprtnRun: Lop_Res: {processor.ReadLop_Res()}, Rop: {processor.ReadRop()}, Operation: {processor.ReadOperation()}");

            Assert.AreEqual(8, processor.ReadLop_Res());
            Assert.AreEqual(3, processor.ReadRop());
            Assert.AreEqual(TOprtn.None, processor.ReadOperation());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestFuncRunReverseWithZeroRop()
        {
            TProc<int> processor = new TProc<int>();

            processor.Rop_Set(0);
            processor.FuncRun(TFunc.Rev);
        }

        [TestMethod]
        public void TestReSet()
        {
            TProc<int> processor = new TProc<int>();

            processor.Lop_Res_Set(5);
            processor.Rop_Set(3);
            processor.WriteOperation(TOprtn.Add);
            processor.ReSet();

            Assert.AreEqual(default(int), processor.ReadLop_Res());
            Assert.AreEqual(default(int), processor.ReadRop());
            Assert.AreEqual(TOprtn.None, processor.ReadOperation());
        }

        [TestMethod]
        public void TestWriteLop_Res()
        {
            TProc<int> processor = new TProc<int>();

            processor.WriteLop_Res(10);

            Assert.AreEqual(10, processor.ReadLop_Res());
        }

        [TestMethod]
        public void TestWriteRop()
        {
            TProc<int> processor = new TProc<int>();

            processor.WriteRop(7);

            Assert.AreEqual(7, processor.ReadRop());
        }
    }
}