using System;

namespace Task05
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("Enter cathetus 1 ");
            if (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Error");
            }
            Console.WriteLine("Enter cathetus 2 ");
            if (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Error");
            }
            c = Math.Sqrt(a * a + b * b);
            Console.WriteLine("Hypotenuse = " + c);
        }
    }
}
