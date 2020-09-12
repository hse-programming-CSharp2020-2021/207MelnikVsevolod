using System;

namespace Task2
{
    class Program
    {
        public static void Maximize(int p)
        {
            int[] a = new int[4];
            a[0] = p / 1000;
            a[1] = p % 1000 / 100;
            a[2] = p % 100 / 10;
            a[3] = p % 10;
            //сортировка цифр
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 3; ++j)
                    if (a[j] < a[j + 1])
                    {
                        int t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;
                    }

            Console.WriteLine("{0}{1}{2}{3}", a[0], a[1], a[2], a[3]);
        }

        static void Main(string[] args)
        {
            int p = 1000;
            while (p >= 1000 && p <= 9999 && int.TryParse(Console.ReadLine(), out p))
            {
                if (p >= 1000 && p <= 9999)
                    Maximize(p);
            }
        }
    }
}
