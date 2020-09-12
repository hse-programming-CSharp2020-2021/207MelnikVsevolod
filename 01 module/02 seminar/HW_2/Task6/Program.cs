using System;

namespace Task6
{
    class Program
    {
        public static void Solve(double s, int p)
        {
            Console.WriteLine((s * p / 100.0).ToString("C")); //в формате валют
        }

        static void Main(string[] args)
        {
            while (true)
            {
                double s;
                int p;
                if (!double.TryParse(Console.ReadLine(), out s))
                    return;
                if (!int.TryParse(Console.ReadLine(), out p))
                    return;
                Solve(s, p);
            }
        }
    }
}
