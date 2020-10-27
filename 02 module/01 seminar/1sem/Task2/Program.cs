using System;

namespace Task5
{
    class Program
    {
        static void WriteArray(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write($"{a[i]} ");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            int n = 10;
            int[][] a = new int[n][];
            for (int i = 0; i < n; ++i)
                a[i] = new int[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    a[i][j] = (i + j) % n + 1;
            }
            for (int i = 0; i < n; ++i)
                WriteArray(a[i]);
        }
    }
}
