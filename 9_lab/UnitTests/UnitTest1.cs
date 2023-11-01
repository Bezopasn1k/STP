using ADT_TMemory;

namespace UnitTests
{
    [TestClass]
    public class TMemoryTests
    {
        [TestMethod]
        public void TestDefaultStateIsOff()
        {
            TMemory<int> memory = new TMemory<int>();

            string memoryState = memory.ReadMemoryState();

            Assert.AreEqual(MemoryState.Off.ToString(), memoryState);
        }

        [TestMethod]
        public void TestStoreAndRetrieve()
        {
            TMemory<int> memory = new TMemory<int>();

            memory.Store(42);
            int retrievedValue = memory.Retrieve();

            Assert.AreEqual(42, retrievedValue);
        }

        [TestMethod]
        public void TestAdd()
        {
            TMemory<int> memory = new TMemory<int>();

            memory.Store(10);
            memory.Add(5);
            int result = memory.Retrieve();

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void TestClear()
        {
            TMemory<int> memory = new TMemory<int>();

            memory.Store(10);
            memory.Clear();
            string memoryState = memory.ReadMemoryState();

            Assert.AreEqual(MemoryState.Off.ToString(), memoryState);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Memory is turned off.")]
        public void TestRetrieveWhenMemoryIsOff()
        {
            TMemory<int> memory = new TMemory<int>();

            int retrievedValue = memory.Retrieve();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Memory is turned off.")]
        public void TestAddWhenMemoryIsOff()
        {
            TMemory<int> memory = new TMemory<int>();

            memory.Add(5);
        }

        [TestMethod]
        public void TestReadNumber()
        {
            TMemory<int> memory = new TMemory<int>();

            memory.Store(20);
            int result = memory.ReadNumber();

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestReadMemoryValue()
        {
            TMemory<int> memory = new TMemory<int>();

            memory.Store(7);
            int memoryValue = memory.ReadMemoryValue();

            Assert.AreEqual(7, memoryValue);
        }
    }
}