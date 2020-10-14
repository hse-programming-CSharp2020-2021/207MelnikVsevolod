using System;

namespace sem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double x, y, R;
            double.TryParse(Console.ReadLine(), out R);
            double.TryParse(Console.ReadLine(), out x);
            double.TryParse(Console.ReadLine(), out y);
            if (x * x + y * y <= R * R)
                Console.WriteLine("inside");
            else
                Console.WriteLine("outside");
        }
    }
}
