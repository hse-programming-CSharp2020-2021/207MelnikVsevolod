using System;

namespace Task7
{
    class Program
    {
        public static bool Solve(double a, double b, double c, out double x1, out double x2)
        {
            double d = b * b - 4 * a * c;
            x1 = x2 = 0;
            if (d < 0)
                return false;
            x1 = (-b + Math.Sqrt(d)) / (2 * a);
            x2 = (-b - Math.Sqrt(d)) / (2 * a);
            return true;
        }

        static void Main(string[] args)
        {
            double a, b, c, x1, x2;
            do Console.Write("Введите A: ");
            while (!double.TryParse(Console.ReadLine(), out a));
            do Console.Write("Введите B: ");
            while (!double.TryParse(Console.ReadLine(), out b));
            do Console.Write("Введите C: ");
            while (!double.TryParse(Console.ReadLine(), out c));
            if (Solve(a, b, c, out x1, out x2))
                Console.WriteLine("x = {0:f3}, {1:f3}", x1, x2);
            else
                Console.WriteLine("Нет корней");
        }
    }
}
