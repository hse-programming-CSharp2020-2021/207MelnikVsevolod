using System;

namespace Task_05
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("5.0 / 3 = " + (5.0 / 3).ToString("F"));
            Console.WriteLine("5.0 / 3 = " + (5.0 / 3).ToString("F4"));
            Console.WriteLine("5.0 / 3 = " + (5.0 / 3).ToString("E"));
            Console.WriteLine("5.0 / 3 = " + (5.0 / 3).ToString("E5"));
            Console.WriteLine("5.0 / 3 = " + (5.0 / 3).ToString("G"));
            Console.WriteLine("5.0 / 3 = " + (5.0 / 3).ToString("G3"));
            Console.WriteLine("5.0 / 3e10 = " + (5.0 / 3e10).ToString("G3"));
            Console.WriteLine("5.0 / 3e-10 = " + (5.0 / 3e-10).ToString("G"));
            Console.WriteLine("5.0 / 3e20 = " + (5.0 / 3e20).ToString("G"));
            Console.WriteLine("Press enter to continue");

            char s1 = 'a';
            Console.WriteLine((char)(s1 + 1));
            Console.ReadKey();
        }
    }
}
