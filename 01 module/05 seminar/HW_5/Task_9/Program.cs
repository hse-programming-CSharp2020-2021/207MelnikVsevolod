using System;

namespace Task_9
{
    class Program
    {
        static void Write(double[] arr, int n)
        {
            for (int i = 0; i < n; ++i)
                Console.WriteLine(arr[i].ToString("F3"));
        }

        static double[] ReplaceMax(double[] arr, int n, double x)
        {
            double m = arr[0];
            for (int i = 0; i < n; ++i)
                if (arr[i] > m)
                    m = arr[i];
            for (int i = 0; i < n; ++i)
                if (arr[i] == m)
                    arr[i] = x;
            return arr;
        }

        static void Main(string[] args)
        {
            int len = 5;
            double[] arr = new double[5] { 1, 5, 2, 4, 5 };
            double x = double.Parse(Console.ReadLine());
            arr = ReplaceMax(arr, len, x);
            Write(arr, len);
        }
    }
}
