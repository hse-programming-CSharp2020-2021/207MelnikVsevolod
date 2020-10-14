using System;

namespace Array_test
{
    class Program
    {
        static int[] Generate(int n)
        {
            Random rand = new Random();
            int[] ar = new int[n];
            for (int i = 0; i < n; ++i)
                ar[i] = rand.Next(10, 51);
            return ar;
        }

        static void Write(int[] a, int n)
        {
            for (int i = 0; i < n; ++i)
                Console.WriteLine(a[i]);
        }

        static int App(int[] a, int[] b, int n, int m)
        {
            int j = 0;
            for (int i = 0; i < m; ++i)
            {
                if (b[i] % 2 == 0)
                    a[n + j++] = b[i];
            }
            return j;
        }

        static void Main(string[] args)
        {
            int n, m;
            if (!int.TryParse(Console.ReadLine(), out n) || !int.TryParse(Console.ReadLine(), out m))
                Console.WriteLine("Incorrect input");
            else
            {
                int[] a = Generate(n + m);
                int[] b = Generate(m);
                Write(a, n);
                Console.WriteLine("");
                Write(b, m);
                Console.WriteLine("");
                Write(a, n + App(a, b, n, m));
            }
        }
    }
}
