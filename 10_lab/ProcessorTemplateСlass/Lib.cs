using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorTemplateСlass
{
    public enum TOprtn { None, Add, Sub, Mul, Dvd }

    //тип для функций
    public enum TFunc { Rev, Sqr }

    public class TProc<T>
    {
        private T Lop_Res;    //левый операнд-результат
        private T Rop;        //правый операнд
        private TOprtn Operation; //текущая операция

        public TProc()
        {
            Lop_Res = default(T);
            Rop = default(T);
            Operation = TOprtn.None;
        }

        public void OprtnClear()
        {
            Lop_Res = default(T);
            Rop = default(T);
            Operation = TOprtn.None;
        }

        public void OprtnRun()
        {
            if (Operation == TOprtn.None)
            {
                return;
            }

            switch (Operation)
            {
                case TOprtn.Add:
                    Lop_Res = Add(Lop_Res, Rop);
                    break;
                case TOprtn.Sub:
                    Lop_Res = Subtract(Lop_Res, Rop);
                    break;
                case TOprtn.Mul:
                    Lop_Res = Multiply(Lop_Res, Rop);
                    break;
                case TOprtn.Dvd:
                    if (IsDivisionValid(Rop))
                    {
                        Lop_Res = Divide(Lop_Res, Rop);
                    }
                    else
                    {
                        Console.WriteLine("Делить на ноль нельзя");
                    }
                    break;
            }

            Operation = TOprtn.None;
        }

        public void FuncRun(TFunc Func)
        {
            if (Func == TFunc.Rev)
            {
                if (IsDivisionValid(Rop))
                {
                    Rop = Divide(default(T), Rop);
                }
                else
                {
                    Console.WriteLine("Делить на ноль нельзя");
                }
            }
            else if (Func == TFunc.Sqr)
            {
                Rop = Multiply(Rop, Rop);
            }
        }

        private bool IsDivisionValid(T value)
        {
            dynamic dynamicValue = value;
            return dynamicValue != 0;
        }

        public void Lop_Res_Set(T Operand)
        {
            Lop_Res = Operand;
        }

        public void Rop_Set(T Operand)
        {
            Rop = Operand;
        }

        public void ReSet()
        {
            Lop_Res = default(T);
            Rop = default(T);
            Operation = TOprtn.None;
        }

        public T ReadLop_Res()
        {
            return Lop_Res;
        }

        public void WriteLop_Res(T Operand)
        {
            Lop_Res = Operand;
        }

        public T ReadRop()
        {
            return Rop;
        }

        public void WriteRop(T Operand)
        {
            Rop = Operand;
        }

        public TOprtn ReadOperation()
        {
            return Operation;
        }

        public void WriteOperation(TOprtn Oprtn)
        {
            Operation = Oprtn;
        }

        private T Add(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x + y;
        }

        private T Subtract(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x - y;
        }

        private T Multiply(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x * y;
        }

        private T Divide(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;

            if (y == 0)
            {
                Console.WriteLine("Делить на ноль нельзя");
                return default(T);
            }

            return x / y;
        }
    }
}
