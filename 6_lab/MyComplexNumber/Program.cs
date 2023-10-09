using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyComplexNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber n = new ComplexNumber("1+1*i");
            ComplexNumber m = new ComplexNumber("2534,6457564-423,3453464*i");
            double degree = n.AngleDegree();
            Console.WriteLine(degree);
        }
    }
}
