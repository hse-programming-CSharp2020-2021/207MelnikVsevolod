using System;

namespace Task13_2
{
    class Program
    {
        public static uint Reverse(uint n)
        {
            uint x = 0;
            while (n > 0)
            {
                x = x * 10 + n % 10; //добавление цифр с конца
                n = n / 10; //отбрасование последней цифры
            }
            return x;
        }

        static void Main(string[] args)
        {
            uint n;
            if (uint.TryParse(Console.ReadLine(), out n))
                Console.WriteLine(Reverse(n));
            else
                Console.WriteLine("Error");
        }
    }
}
