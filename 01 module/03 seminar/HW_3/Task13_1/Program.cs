using System;

namespace Task13_1
{
    class Program
    {
        public static void Find()
        {
            int s = 0;
            int x = 0;
            while (!(s >= 100 && s <= 999 && (s / 100) == (s % 100 / 10) && (s / 100) == (s % 10)))
            {
                x += 1;
                s += x;
            }
            Console.WriteLine(s);
            Console.WriteLine($"{x} слагаемых:");
            Console.WriteLine("1+2+3+...+{0}+{1}+{2} = {3}", x - 2, x - 1, x, s); // вывод последовательности
        }

        static void Main(string[] args)
        {
            Find();
        }
    }
}
