using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT_TMemory
{
    public enum MemoryState
    {
        Off,
        On
    }

    public class UMemory
    {
        private int data;

        public void Write(int value)
        {
            data = value;
        }

        public int Read()
        {
            return data;
        }
    }

    public class TMemory<T>
    {
        private T FNumber;
        private MemoryState FState;
        private UMemory memory = new UMemory();

        public TMemory()
        {
            FNumber = default(T);
            FState = MemoryState.Off;
        }

        public void Store(T E)
        {
            FNumber = E;
            FState = MemoryState.On;

            // Сохранить значение в пользовательской памяти
            if (E is int)
            {
                int intValue = (int)(object)E;
                memory.Write(intValue);
            }
        }

        public T Retrieve()
        {
            if (FState == MemoryState.On)
            {
                return FNumber;
            }
            throw new InvalidOperationException("Memory is turned off.");
        }

        public void Add(T E)
        {
            if (FState == MemoryState.On)
            {
                dynamic num1 = FNumber;
                dynamic num2 = E;
                FNumber = num1 + num2;
            }
            else
            {
                throw new InvalidOperationException("Memory is turned off.");
            }
        }

        public void Clear()
        {
            FNumber = default(T);
            FState = MemoryState.Off;

            // Очистить пользовательскую память
            memory.Write(0);
        }

        public string ReadMemoryState()
        {
            return FState.ToString();
        }

        public T ReadNumber()
        {
            return FNumber;
        }

        public int ReadMemoryValue()
        {
            return memory.Read();
        }
    }
}
