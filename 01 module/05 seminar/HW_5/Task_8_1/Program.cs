using System;

namespace Task_8_1
{
    class Program
    {
        static double[] Gen(int n)
        {
            double[] arr = new double[n];
            for (int i = 0; i < n; ++i)
                arr[i] = ((i * (i + 1.0) / 2) % n);
            return arr;
        }

        static void Write(double[] arr, int n)
        {
            for (int i = 0; i < n; ++i)
                Console.WriteLine(arr[i]);
        }

        static void Main(string[] args)
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);
            double[] arr = Gen(n);
            Write(arr, n);
        }
    }
}
