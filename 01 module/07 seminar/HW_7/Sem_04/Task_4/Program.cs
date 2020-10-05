using System;

namespace Task_4
{
    class Program
    {
        static int Det(int[,] a)
        {
            int d = int.MinValue;
            if (a.Length == 4)
            {
                d = a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];
            } else if (a.Length == 9)
            {
                d = (a[0, 0] * a[1, 1] * a[2, 2] + a[0, 1] * a[1, 2] * a[2, 0] + a[0, 2] * a[1, 0] * a[2, 1])
                  - (a[0, 0] * a[1, 2] * a[2, 1] + a[0, 1] * a[1, 0] * a[2, 2] + a[0, 2] * a[1, 1] * a[2, 0]);
            }
            return d;
        }

        static int[,] ReadMat(int n)
        {
            int[,] m = new int[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    m[i, j] = int.Parse(Console.ReadLine());
            return m;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] a = ReadMat(n);
            Console.WriteLine(Det(a));
        }
    }
}
