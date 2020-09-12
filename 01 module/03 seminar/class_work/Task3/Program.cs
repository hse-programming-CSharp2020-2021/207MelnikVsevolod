using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double A, delta;
                if (!double.TryParse(Console.ReadLine(), out A))
                    return;
                if (!double.TryParse(Console.ReadLine(), out delta))
                    return;
                if (delta <= 0.0 || delta > A)
                    return;
                double s = 0, x = 0;
                while (x + delta <= A)
                {
                    s += delta * (x * x + (x + delta) * (x + delta)) / 2;
                    x += delta; // шаг интегрирования
                }
                Console.WriteLine(s);
            }
        }
    }
}
