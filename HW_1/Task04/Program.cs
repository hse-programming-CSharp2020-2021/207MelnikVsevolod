using System;

namespace Task04
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter U");
            double u = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter R");
            double r = double.Parse(Console.ReadLine());
            double i = u / r;
            double p = u * u / r;
            Console.WriteLine("I = " + i);
            Console.WriteLine("P = " + p);
        }
    }
}
