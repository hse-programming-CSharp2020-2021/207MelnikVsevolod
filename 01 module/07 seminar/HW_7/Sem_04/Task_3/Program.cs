using System;

namespace Task_3
{
    class Program
    {
        static char[][] Gen1(int n)
        {
            char[][] a = new char[n][];
            for (int k = 0; k < n; ++k)
            {
                a[k] = new char[k + 1];
                for (int i = 0; i < k + 1; ++i)
                {
                    a[k][i] = '*';
                }
            }
            return a;
        }

        static char[][] Gen2(int n)
        {
            char[][] a = new char[n / 2 + 1][];
            for (int k = 0; k < n / 2 + 1; ++k)
            {
                a[k] = new char[n / 2 + k + 1];
                for (int i = 0; i < n / 2 + k + 1; ++i)
                {
                    a[k][i] = ' ';
                }
                for (int i = 0; i < k * 2 + 1; ++i)
                    a[k][n / 2 + k - i] = '*';
            }
            return a;
        }

        static void Show(char[][] a, int n)
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < a[i].Length; ++j)
                    if (a[i][j] != 0)
                        Console.Write(a[i][j]);
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] a = Gen2(n);
            Show(a, n / 2 + 1);
        }
    }
}
