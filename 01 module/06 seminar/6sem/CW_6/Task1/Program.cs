using System;

namespace Task1
{
    class Program
    {
        static int[] IntToCharArray(int[] a)
        {
            int[] b = new int[a.Length];
            Array.Copy(a, b);
            int m = 0;
            for (int i = 0; i < a.Length; ++i)
                if (a[i] % 2 == 0)
                    b[m++] = a[i];
            if (m > 0)
                Array.Resize(b, m);
            return b;
        }

        static void Main(string[] args)
        {
            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
                Console.WriteLine("Incorrect input");
            char[] c = IntToCharArray(n);
            Array.ForEach(c, x => Console.WriteLine(x));
        }
    }
}
