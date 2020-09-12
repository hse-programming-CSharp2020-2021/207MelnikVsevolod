using System;

namespace Task1
{
    class Program
    {
        public static void Calc(int x)
        {
            Console.WriteLine(x * (x * (x * (12 * x + 9) - 3) + 2) - 4); //выражение упрощено для меньшего количества знаков умножения
        }

        static void Main(string[] args)
        {
            int x;
            while (int.TryParse(Console.ReadLine(), out x))
                Calc(x);
        }
    }
}
