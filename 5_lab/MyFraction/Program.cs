using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFraction;

namespace MyFraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyFraction n = new MyFraction("30/70");
            MyFraction c = new MyFraction(40, 80);
            n = n + c;
            n.PrintFraction();
            n = n - c;
            n.PrintFraction();
            n = n * c;
            n.PrintFraction();
            n = n / c;
            n.PrintFraction();
            n = n.squaring();
            n.PrintFraction();
        }
    }
}
