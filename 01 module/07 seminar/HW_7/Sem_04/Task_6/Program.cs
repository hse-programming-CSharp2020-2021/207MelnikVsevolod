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
            }
            else if (a.Length == 9)
            {
                d = (a[0, 0] * a[1, 1] * a[2, 2] + a[0, 1] * a[1, 2] * a[2, 0] + a[0, 2] * a[1, 0] * a[2, 1])
                  - (a[0, 0] * a[1, 2] * a[2, 1] + a[0, 1] * a[1, 0] * a[2, 2] + a[0, 2] * a[1, 1] * a[2, 0]);
            }
            return d;
        }

        static int[,] Gen()
        {
            Random rand = new Random();
            int[,] a = new int[3, 6];
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 6; ++j)
                    a[i, j] = rand.Next(0, 21);
            return a;
        }

        static int[] GetDets(int[,] m)
        {
            if (m.GetLength(0) != 3 || m.GetLength(1) != 6)
                return new int[2] { int.MinValue, int.MinValue };
            int[,] a = new int[3, 3];
            int[,] b = new int[3, 3];
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    a[i, j] = m[i, j];
            for (int i = 0; i < 3; ++i)
                for (int j = 3; j < 6; ++j)
                    b[i, j - 3] = m[i, j];
            int[] r = new int[2];
            r[0] = Det(a);
            r[1] = Det(b);
            return r;
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

        static void Main(string[] args)
        {
            int[,] a = Gen();
            int[] b = GetDets(a);
            Show(a);
            Console.WriteLine(b[0]);
            Console.WriteLine(b[1]);
        }
    }
}
