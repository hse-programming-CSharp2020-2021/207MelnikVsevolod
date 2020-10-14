using System;

namespace project1
{
    class Program
    {
        static bool Shift(ref char ch)
        {
            if (ch >= 'A' && ch <= 'Z')
                ch = (char)((ch - 'A' + 4) % ('Z' - 'A' + 1) + 'A');
            else if (ch >= 'a' && ch <= 'z')
                ch = (char)((ch - 'a' + 4) % ('z' - 'a' + 1) + 'a');
            else
                return false;
            return true;
        }

        static void Main(string[] args)
        {
            char c;
            c = (char)Console.Read();
            if (Shift(ref c))
                Console.WriteLine(c);
            else
                Console.WriteLine("Incorrect input");
        }
    }
}
