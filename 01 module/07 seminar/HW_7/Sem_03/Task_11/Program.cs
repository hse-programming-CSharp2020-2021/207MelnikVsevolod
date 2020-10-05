using System;

namespace Task_11
{
    class Program
    {
        static int[] Gen(int n)
        {
            int[] a = new int[n];
            a[0] = 0;
            a[1] = 1;
            for (int i = 2; i < n; ++i)
                a[i] = 34 * a[i - 1] - a[i - 2] + 2;
            return a;
        }

        static void Show(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write($"{a[i]} ");
            Console.WriteLine("");
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
            }
        }
    }
}
