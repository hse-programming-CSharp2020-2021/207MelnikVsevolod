using System;

namespace Task_1
{
    class Program
    {
        static int[,] Gen1(int n)
        {
            int[,] a = new int[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    if (i == j)
                        a[i, j] = 0;
                    else if (i > j)
                        a[i, j] = -1;
                    else
                        a[i, j] = 1;
            return a;
        }

        static int[,] Gen2(int n)
        {
            int[,] a = new int[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    if (i == (n - j - 1))
                        a[i, j] = 0;
                    else if (i > (n - j - 1))
                        a[i, j] = 1;
                    else
                        a[i, j] = -1;
            return a;
        }

        static int[,] Gen3(int n)
        {
            int[,] a = new int[n, n];
            int i, j;
            i = 0;
            j = -1;
            int m = 1;
            while (m <= n * n)
            {
                while (j + 1 < n && a[i, j + 1] == 0)
                {
                    ++j;
                    a[i, j] = m++;
                }
                while (i + 1 < n && a[i + 1, j] == 0)
                {
                    ++i;
                    a[i, j] = m++;
                }
                while (j - 1 >= 0 && a[i, j - 1] == 0)
                {
                    --j;
                    a[i, j] = m++;
                }
                while (i - 1 >= 0 && a[i - 1, j] == 0)
                {
                    --i;
                    a[i, j] = m++;
                }
            }
            return a;
        }

        static void Show(int[,] a, int n)
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Console.Write($"{a[i, j]} ");
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            int[,] a = Gen3(n);
            Show(a, n);
        }
    }
}
