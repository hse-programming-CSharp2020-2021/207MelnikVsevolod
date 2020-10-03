using System;

namespace Task_6
{
    class Program
    {
        static int[] Gen(int a0)
        {
            int[] a = new int[1];
            a[0] = a0;
            for (int i = 0; a[i] != 1; ++i)
            {
                Array.Resize(ref a, a.Length + 1);
                a[i + 1] = a[i] % 2 == 0 ? a[i] / 2 : (3 * a[i] + 1);
            }
            return a;
        }

        static void Show(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                Console.Write($"[{i}] = {a[i]} ");
                if (i % 5 == 4)
                    Console.WriteLine("");
            }
        }

        static int[] Compress(int[] a)
        {
            int[] b = new int[a.Length];
            int x = 0;
            for (int i = 0; i < a.Length - 1; ++i)
            {
                if ((a[i] + a[i + 1]) % 3 == 0)
                {
                    b[x++] = a[i] * a[i + 1];
                    ++i;
                }
                else
                    b[x++] = a[i];
            }
            if ((a[a.Length - 2] + a[a.Length - 1]) % 3 != 0)
                b[x++] = a[a.Length - 1];
            Array.Resize(ref b, x);
            return b;
        }

        static void Main(string[] args)
        {
            int a0 = int.Parse(Console.ReadLine());
            int[] x = new int[1];
            x = Gen(a0);
            int[] b = new int[1];
            b = Compress(x);
            Show(b);
        }
    }
}
