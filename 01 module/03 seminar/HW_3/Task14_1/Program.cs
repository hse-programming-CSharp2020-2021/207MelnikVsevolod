using System;

namespace Task14_1
{
    class Program
    {
        public static bool Check(double x, double y)
        {
            if (x * x + y * y > 2 * 2)
                return false; // дальше от центра чем радиус
            if (x < 0 || (y > x))
                return false; // не тот угол
            return true;
        }

        static void Main(string[] args)
        {
            double x, y;
            if (!double.TryParse(Console.ReadLine(), out x) || !double.TryParse(Console.ReadLine(), out y))
                Console.WriteLine("Error");
            else if (Check(x, y))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
