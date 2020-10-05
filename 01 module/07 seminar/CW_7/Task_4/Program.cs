using System;

namespace Task_4
{
    class Program
    {
        static int[] ReadArray(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; ++i)
                a[i] = int.Parse(Console.ReadLine());
            return a;
        }

        static int[] NegativeToEnd(int[] a)
        {
            int[] b = new int[a.Length];
            int x = 0;
            for (int i = 0; i < a.Length; ++i)
                if (a[i] >= 0)
                    b[x++] = a[i];
            for (int i = 0; i < a.Length; ++i)
                if (a[i] < 0)
                    b[x++] = a[i];
            return b;
        }

        static void Show(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write($"{a[i]} ");
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = ReadArray(n);
            a = NegativeToEnd(a);
            Show(a);
        }
    }
}
