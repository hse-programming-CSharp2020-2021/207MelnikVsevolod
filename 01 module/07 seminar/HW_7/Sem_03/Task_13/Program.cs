using System;

namespace Task_13
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

        static void Show(int[] a, int k=1)
        {
            for (int i = 0; i < a.Length; i += k)
                Console.Write($"{a[i]} ");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            int n;
            int k;
            if (!int.TryParse(Console.ReadLine(), out n) || !int.TryParse(Console.ReadLine(), out k) || n < 0 || k > n)
                Console.WriteLine("Incorrect input");
            else
            {
                int[] a = Gen(n);
                Show(a, 1);
                Show(a, k);
            }
        }
    }
}
