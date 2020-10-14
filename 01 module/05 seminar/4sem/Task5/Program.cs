using System;

namespace Task5
{
    class Program
    {
        static double Sum(int n)
        {
            double sum = 0;
            for (int k = 1; k <= n; ++k)
                sum += (k + 0.3) / (3 * k * k + 5);
            return sum;
        }

        static void Main(string[] args)
        {
            int k;
            if (!int.TryParse(Console.ReadLine(), out k))
                Console.WriteLine("Incorrect input");
            else
            {
                for (int n = 1; n <= k; ++n)
                    Console.WriteLine(n.ToString() + " " + Sum(n).ToString("F3"));
            }
        }
    }
}
