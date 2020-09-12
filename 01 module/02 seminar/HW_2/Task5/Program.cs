using System;

namespace Task5
{
    class Program
    {
        public static void Solve(double a, double b, double c)
        {
            string ans = ((a < b + c) && (b < a + c) && (c < a + b)) ? "Yes" : "No";//неравенство треугольника
            Console.WriteLine(ans);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                double a, b, c;
                if (!double.TryParse(Console.ReadLine(), out a))
                    return;
                if (!double.TryParse(Console.ReadLine(), out b))
                    return;
                if (!double.TryParse(Console.ReadLine(), out c))
                    return;
                Solve(a, b, c);
            }
        }
    }
}
