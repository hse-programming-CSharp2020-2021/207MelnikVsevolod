using System;

namespace Task_8_2
{
    class Program
    {
        static double[] Normilize(double[] arr, int n)
        {
            double m = arr[0];
            for (int i = 0; i < n; ++i)
                if (arr[i] > m)
                    m = arr[i];
            for (int i = 0; i < n; ++i)
                arr[i] /= m;
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
            double[] arr = new double[n];
            for (int i = 0; i < n; ++i)
                arr[i] = double.Parse(Console.ReadLine());
            arr = Normilize(arr, n);
            Write(arr, n);
        }
    }
}
