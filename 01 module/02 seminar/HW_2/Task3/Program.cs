using System;

namespace Task3
{
    class Program
    {
        public static void Solve(double a, double b, double c)
        {
            double d = b * b - 4 * a * c; //дискриминант
            string ans = (d < 0.0) ? string.Format("{0:f3} + {1:f3}i, {0:f3} - {1:f3}", -b / (2 * a), Math.Sqrt(Math.Abs(d)) / (2 * a)) :
                ((d == 0.0) ? string.Format("{0:f3}", -b / (2 * a)) :
                string.Format("{0:f3}, {1:f3}", (-b + Math.Sqrt(d)) / (2 * a), (-b - Math.Sqrt(d)) / (2 * a)));
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
