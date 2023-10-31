using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT_TMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            TMemory<int> intMemory = new TMemory<int>();
            Console.WriteLine("Memory State: " + intMemory.ReadMemoryState());

            intMemory.Store(42);
            Console.WriteLine("Memory State: " + intMemory.ReadMemoryState());
            int number = intMemory.Retrieve();
            Console.WriteLine("Retrieved Number: " + number);

            intMemory.Add(10);
            number = intMemory.Retrieve();
            Console.WriteLine("Retrieved Number after Adding: " + number);


            intMemory.Clear();
            Console.WriteLine("Memory State after Clear: " + intMemory.ReadMemoryState());

            TMemory<string> stringMemory = new TMemory<string>();
            Console.WriteLine("Memory State: " + stringMemory.ReadMemoryState());

            stringMemory.Store("Hello, World!");
            Console.WriteLine("Memory State: " + stringMemory.ReadMemoryState());

            string text = stringMemory.Retrieve();
            Console.WriteLine("Retrieved Text: " + text);
        }
    }
}
