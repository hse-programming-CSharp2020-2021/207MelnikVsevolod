using System;

namespace Sem1
{
    class Methods
    {
        public static int[] CreateArray(int x)
        {
            int[] a = new int[0];
            while (x > 0)
            {
                Array.Resize(ref a, a.Length + 1);
                a[a.Length - 1] = x % 10;
                x /= 10;
            }
            return a;
        }

        public static void WriteArray(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.WriteLine(a[i]);
        }
    }

    class Program
    {
        delegate int[] CreateArray(int x);
        delegate void WriteArray(int[] a);

        static void Main(string[] args)
        {
            CreateArray ca = Methods.CreateArray;
            WriteArray wa = Methods.WriteArray;
            int[] a = ca(52416);
            int[] arr = { 2, 4, 2, 6, 7, 2, 3, 43, 2, 6};
            wa(arr);
            Console.WriteLine(ca.Method + " " + ca.Target);
            Console.WriteLine(wa.Method + " " + wa.Target);
        }
    }
}
