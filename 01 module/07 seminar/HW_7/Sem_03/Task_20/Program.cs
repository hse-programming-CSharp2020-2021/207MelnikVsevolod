using System;

namespace Task_20
{
    class Program
    {
        static int[] Gen(int n)
        {
            Random rnd = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; ++i)
                a[i] = rnd.Next(10, 100);
            return a;
        }

        static void Show(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write($"{a[i]} ");
            Console.WriteLine("");
        }

        static void ArrayItemDouble(ref int[] a, int x)
        {
            int n = a.Length;
            int[] b = new int[n];
            a.CopyTo(b, 0);
            int j = 0;
            for (int i = 0; i < n; ++i)
            {
                if (j >= b.Length)
                    Array.Resize(ref b, b.Length + 1);
                b[j++] = a[i];
                if (a[i] == x)
                {
                    if (j >= b.Length)
                        Array.Resize(ref b, b.Length + 1);
                    b[j++] = a[i];
                }
            }
            a = b;
        }

        static void Main(string[] args)
        {
            int n, y;
            if (!int.TryParse(Console.ReadLine(), out n) || !int.TryParse(Console.ReadLine(), out y) || n < 0)
                Console.WriteLine("Incorrect input");
            else
            {
                int[] a = Gen(n);
                Show(a);
                ArrayItemDouble(ref a, y);
                Show(a);
            }
        }
    }
}
