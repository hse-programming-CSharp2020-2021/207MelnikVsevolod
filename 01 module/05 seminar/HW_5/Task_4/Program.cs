using System;

namespace Task_4
{
    class Program
    {
        static int[] Gen(int n)
        {
            int[] arr = new int[n];
            arr[0] = 1;
            arr[1] = 1;
            for (int i = 2; i < n; ++i)
                arr[i] = arr[i - 1] + arr[i - 2];
            return arr;
        }

        static void Write(int[] arr, int n)
        {
            for (int i = n - 1; i >= 0; --i)
                Console.WriteLine(arr[i]);
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Gen(n);
            Write(arr, n);
        }
    }
}
