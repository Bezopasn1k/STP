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
            n = n.Squaring();
            n.PrintFraction();
        }
    }
}
