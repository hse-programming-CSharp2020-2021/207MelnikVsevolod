using System;

namespace Task_3
{
    class Program
    {
        static int[] Gen(int n, int a, int d)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; ++i)
                arr[i] = a + i * d;
            return arr;
        }

        static void Write(int[] arr, int n)
        {
            for (int i = 0; i < n; ++i)
                Console.WriteLine(arr[i]);
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a, d;
            a = int.Parse(Console.ReadLine());
            d = int.Parse(Console.ReadLine());
            int[] arr = Gen(n, a, d);
            Write(arr, n);
        }
    }
}
