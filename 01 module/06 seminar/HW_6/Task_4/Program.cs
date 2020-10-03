using System;

namespace Task_4
{
    class Program
    {
        static int[] Gen(int a0)
        {
            int[] a = new int[1];
            a[0] = a0;
            for (int i = 0; a[i] != 1; ++i)
            {
                Array.Resize(ref a, a.Length + 1);
                a[i + 1] = a[i] % 2 == 0 ? a[i] / 2 : (3 * a[i] + 1);
            }
            return a;
        }

        static void Main(string[] args)
        {
            int a0 = int.Parse(Console.ReadLine());
            int[] x = new int[1];
            x = Gen(a0);
            for (int i = 0; i < x.Length; ++i)
                Console.WriteLine(x[i]);
        }
    }
}
