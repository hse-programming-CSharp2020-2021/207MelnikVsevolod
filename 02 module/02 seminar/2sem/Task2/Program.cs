using System;

namespace Task2
{
    class LatinChar
    {
        char _char;

        public LatinChar()
        {
            _char = 'a';
        }

        public LatinChar(char c)
        {
            if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                _char = c;
            else
                throw new TypeInitializationException("LatinChar", new Exception("Invalid char"));
        }

        public char Char
        {
            get
            {
                return _char;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LatinChar lc = new LatinChar();
            char minChar, maxChar;
            minChar = (char)Console.Read();
            maxChar = (char)Console.Read();
            for (char i = minChar; i <= maxChar; ++i)
            {
                lc = new LatinChar(i);
                Console.WriteLine(lc.Char);
            }
        }
    }
}
