using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFraction;

namespace ProcessorTemplateСlass
{
    class Program
    {
        static void Main(string[] args)
        {
            TProc<int> processor = new TProc<int>();
            processor.Lop_Res_Set(2);
            processor.WriteOperation(TOprtn.Add);
            processor.WriteRop(3);
            processor.OprtnRun();
            Console.WriteLine("Результат: " + processor.ReadLop_Res());


            TProc<MyFraction.MyFraction> processor2 = new TProc<MyFraction.MyFraction>();
            processor2.Lop_Res_Set(new MyFraction.MyFraction(2, 1));
            processor2.WriteOperation(TOprtn.Add);
            processor2.WriteRop(new MyFraction.MyFraction(3, 1));
            processor2.OprtnRun();
            Console.WriteLine("Результат: " + processor2.ReadLop_Res().ToString());
        }
    }
}
