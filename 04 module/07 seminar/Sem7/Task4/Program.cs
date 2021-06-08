using System;
using System.Threading;

namespace Task4
{
    class Program
    {
        static void Print()
        {
            for (int k = 0; k < 5; k++)
            {
                Thread.Sleep(150);
                Console.Write("2");
            }
        }
        public static void Main()
        {
            Thread tr = new Thread(Print);
            tr.Start();
            for (int k = 0; k < 5; k++)
            {
                Thread.Sleep(200);
                Console.Write("1");
            }
        }
    }
}
