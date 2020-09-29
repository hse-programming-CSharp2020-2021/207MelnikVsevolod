using System;

namespace Task_8_3
{
    class Program
    {
        static void Write(double[] arr, int n)
        {
            for (int i = 0; i < n; ++i)
                Console.WriteLine(arr[i].ToString("F3"));
        }

        static void Main(string[] args)
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);
            double[] arr = new double[n];
            for (int i = 0; i < n; ++i)
                arr[i] = double.Parse(Console.ReadLine());
            Write(arr, n);
        }
    }
}
