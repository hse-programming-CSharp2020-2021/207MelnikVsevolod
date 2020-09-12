using System;

namespace ASCIIDecoder
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string sa = Console.ReadLine();
            int a;
            if (int.TryParse(sa, out a))
                Console.WriteLine((char)a);
            else
                Console.WriteLine("Error");
        }
    }
}
