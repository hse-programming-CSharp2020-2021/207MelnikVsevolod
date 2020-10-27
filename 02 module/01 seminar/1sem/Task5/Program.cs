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
            int[][] pascal;
            int n = int.Parse(Console.ReadLine());
            pascal = new int[n][];
            for (int i = 0; i < n; ++i)
                pascal[i] = new int[i + 1];
            pascal[0][0] = 1;
            pascal[1][0] = pascal[1][1] = 1;
            for (int i = 2; i < n; ++i)
            {
                pascal[i][0] = pascal[i][i] = 1;
                for (int j = 1; j < i; ++j)
                    pascal[i][j] = pascal[i - 1][j - 1] + pascal[i - 1][j];
            }

            for (int i = 0; i < n; ++i)
                WriteArray(pascal[i]);
        }
    }
}
