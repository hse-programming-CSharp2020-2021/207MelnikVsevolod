using System;

namespace Task14_4
{
    class Program
    {
        public static int NumOnFloor(int x) // номер на этаже
        {
            return x % 100;
        }

        static void Main(string[] args)
        {
            int a, b, c;
            if (!int.TryParse(Console.ReadLine(), out a) || !int.TryParse(Console.ReadLine(), out b) || !int.TryParse(Console.ReadLine(), out c)
                || a < 100 || a > 999 || b < 100 || b > 999 || c < 100 || c > 999)
                Console.WriteLine("Error");
            else
            {
                if (NumOnFloor(a) < NumOnFloor(b) && NumOnFloor(a) < NumOnFloor(c))
                    Console.WriteLine(a);
                else if (NumOnFloor(b) < NumOnFloor(c) && NumOnFloor(b) < NumOnFloor(c))
                    Console.WriteLine(b);
                else
                    Console.WriteLine(c);
            }
        }
    }
}
