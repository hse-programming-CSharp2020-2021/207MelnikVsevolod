using System;

namespace Task_16
{
    class Program
    {
        static int[] Gen(int n)
        {
            Random rnd = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; ++i)
                a[i] = rnd.Next(-10, 11);
            return a;
        }

        static void Show(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write($"{a[i]} ");
            Console.WriteLine("");
        }

        static int Min(int[] a)
        {
            int m = 0;
            for (int i = 0; i < a.Length; ++i)
                if (a[i] < a[m])
                    m = i;
            return m;
        }

        static int Max(int[] a)
        {
            int m = 0;
            for (int i = 0; i < a.Length; ++i)
                if (a[i] > a[m])
                    m = i;
            return m;
        }

        static void Main(string[] args)
        {
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                Console.WriteLine("Incorrect input");
            else
            {
                int[] a = Gen(n);
                Show(a);
                Console.WriteLine(Min(a));
                Console.WriteLine(Max(a) + Min(a));
            }
        }
    }
}
