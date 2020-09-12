using System;

namespace Task04
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double u, r;
            Console.WriteLine("Enter U");
            if (!double.TryParse(Console.ReadLine(), out u))
            {
                Console.WriteLine("Error");
            }
            Console.WriteLine("Enter R");
            if (!double.TryParse(Console.ReadLine(), out r))
            {
                Console.WriteLine("Error");
            }
            double i = u / r;
            double p = u * u / r;
            Console.WriteLine("I = " + i);
            Console.WriteLine("P = " + p);
        }
    }
}
