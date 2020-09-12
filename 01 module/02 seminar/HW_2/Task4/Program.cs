using System;

namespace Task4
{
    class Program
    {
        public static void Reverse(int p)
        {
            int[] a = new int[4];
            a[0] = p / 1000;
            a[1] = p % 1000 / 100;
            a[2] = p % 100 / 10;
            a[3] = p % 10;
            //печать в обратном порядке
            Console.WriteLine("{0}{1}{2}{3}", a[3], a[2], a[1], a[0]);
        }

        static void Main(string[] args)
        {
            int p = 1000;
            while (p >= 1000 && p <= 9999 && int.TryParse(Console.ReadLine(), out p))
            {
                if (p >= 1000 && p <= 9999)
                    Reverse(p);
            }
        }
    }
}
