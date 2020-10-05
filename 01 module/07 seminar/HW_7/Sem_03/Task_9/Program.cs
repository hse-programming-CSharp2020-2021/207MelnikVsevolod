using System;

namespace Task_9
{
    class Program
    {
        static int[] Gen(int n)
        {
            Random rnd = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; ++i)
                a[i] = rnd.Next(-10, 11);
            return a;
        }

        static void Show(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write($"{a[i]} ");
            Console.WriteLine("");
        }

        static void ArrayHill(ref int[] a)
        {
            int n = a.Length;
            int[] b = new int[n];
            a.CopyTo(b, 0);
            Array.Sort(b);
            for (int i = 0; i < n; ++i)
                if (i % 2 == 0)
                    a[i / 2] = b[i];
                else
                    a[n - (i / 2) - 1] = b[i];
        }

        static void Main(string[] args)
        {
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 0)
                Console.WriteLine("Incorrect input");
            else
            {
                int[] a = Gen(n);
                Show(a);
                ArrayHill(ref a);
                Show(a);
            }
        }
    }
}
