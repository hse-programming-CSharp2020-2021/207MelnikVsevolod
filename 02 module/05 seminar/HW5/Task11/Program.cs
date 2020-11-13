using System;

namespace Task11
{
    class GeometricProgression
    {
        double _start;
        double _increment;

        public GeometricProgression()
        {
            _start = 0;
            _increment = 1;
        }

        public GeometricProgression(double start, double increment)
        {
            _start = start;
            _increment = increment;
        }

        public double this[int index]
        {
            get
            {
                return _start * Math.Pow(_increment, index - 1);
            }
        }

        public string GetInfo()
        {
            return $"Начальное значение: {_start:F3}, знаменатель: {_increment:F3}";
        }

        public double GetSum(int n)
        {
            return _start * (Math.Pow(_increment, n) - 1) / (_increment - 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            GeometricProgression g_p = new GeometricProgression(rnd.NextDouble() * 10, 5 - 5 * rnd.NextDouble());
            Console.WriteLine(g_p.GetInfo());
            int n = int.Parse(Console.ReadLine());
            GeometricProgression[] progressions = new GeometricProgression[n];
            for (int i = 0; i < n; ++i)
            {
                progressions[i] = new GeometricProgression(rnd.NextDouble() * 10, 5 - 5 * rnd.NextDouble());
                Console.WriteLine(progressions[i].GetInfo());
            }
            int step = rnd.Next(3, 16);
            Console.WriteLine($"{step}-ый элемент последовательности больше, чем в последовательности ({g_p.GetInfo()}):");
            for (int i = 0; i < n; ++i)
            {
                if (progressions[i][step] > g_p[step])
                    Console.WriteLine(progressions[i].GetInfo());
            }
        }
    }
}
