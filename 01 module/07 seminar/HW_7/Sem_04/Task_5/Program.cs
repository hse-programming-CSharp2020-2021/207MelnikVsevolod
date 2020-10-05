using System;

namespace Task_5
{
    class Program
    {
        static int[,] Gen(int n)
        {
            Random rand = new Random();
            int[,] a = new int[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    a[i, j] = rand.Next(0, 26);
            return a;
        }

        static void Show(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                for (int j = 0; j < a.GetLength(1); ++j)
                    Console.Write($"{a[i, j]} ");
                Console.WriteLine("");
            }
        }

        static void Write1(int[,] a, int n)
        {
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    if (j < i && i < n - j - 1)
                        Console.WriteLine(a[i, j]);
        }

        static void Write2(int[,] a, int n)
        {
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    if (j <= i && i >= n - j - 1)
                        Console.WriteLine(a[i, j]);
        }

        static void Write3(int[,] a, int n)
        {
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    if (j < i && i > n - j - 1 || j > i && i < n - j - 1)
                        Console.WriteLine(a[i, j]);
        }

        static void Write4(int[,] a, int n)
        {
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    if (j < i && i > n - j - 1 && j >= n / 2 || j > i && i < n - j - 1 && j < n / 2)
                        Console.WriteLine(a[i, j]);
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] a = Gen(n);
            Show(a);
            Write4(a, n);
        }
    }
}
