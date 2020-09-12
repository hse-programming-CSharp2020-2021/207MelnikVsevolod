using System;

namespace Task6
{
    class Program
    {
        public static double Total(double k, double r, uint n)
        {
            double s = k;
            for (int i = 1; i <= n; ++i)
            {
                s = s * (100 + r) / 100;
                Console.WriteLine("{0}: {1:f3}", i, s);
            }
            return s;
        }

        static void Main(string[] args)
        {
            double k, r, s, temp;
            uint n;
            do Console.Write("Введите начальный капитал: ");
            while (!double.TryParse(Console.ReadLine(), out k) | k <= 0);
            do Console.Write("Введите годовуб процентную ставку: ");
            while (!double.TryParse(Console.ReadLine(), out r) | r <= 0);
            do Console.Write("Введите число лет: ");
            while (!uint.TryParse(Console.ReadLine(), out n) | n == 0);

            s = Total(k, r, n); //обращение к методу
            Console.WriteLine("Итоговая сумма: " + s);
        }
    }
}
