using System;

namespace Task_2
{
    class Program
    {
        static int[][] Gen(int n, out int k)
        {
            int[][] a = new int[n][];
            k = 0;
            while (n > 0)
            {
                a[k] = new int[k + 1];
                for (int i = 0; i < k + 1; ++i)
                {
                    a[k][i] = n--;
                }
                ++k;
            }
            Array.Resize(ref a, k);
            return a;
        }

        static void Show(int[][] a, int k)
        {
            for (int i = 0; i < k; ++i)
            {
                for (int j = 0; j <= i; ++j)
                    if (a[i][j] != 0)
                        Console.Write($"{a[i][j]} ");
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k;
            int[][] a = Gen(n, out k);
            Show(a, k);
        }
    }
}
