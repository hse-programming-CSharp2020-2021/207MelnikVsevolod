using System;

namespace sem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int a, b;
            bool ba = int.TryParse(Console.ReadLine(), out a);
            bool bb = int.TryParse(Console.ReadLine(), out b);
            if (!ba || !bb)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine(a + b);
            }
        }
    }
}
