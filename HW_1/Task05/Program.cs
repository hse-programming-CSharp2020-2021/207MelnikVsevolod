using System;

namespace Task05
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter cathetus 1 ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter cathetus 2 ");
            double b = double.Parse(Console.ReadLine());
            double c = Math.Sqrt(a * a + b * b);
            Console.WriteLine("Hypotenuse = " + c);
        }
    }
}
