using System;
using System.Text;

namespace Task1
{
    class Program
    {
        static string RemoveSpaces(string s)
        {
            StringBuilder t = new StringBuilder();
            t.AppendJoin(' ', s.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            return t.ToString();
        }

        static int CountWords(string s)
        {
            int cnt = 0;
            int letters = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != ' ')
                {
                    ++letters;
                }
                else
                {
                    if (letters >= 4)
                        ++cnt;
                    letters = 0;
                }
            }
            if (letters >= 4)
                ++cnt;
            return cnt;
        }

        static bool isGlas(char c)
        {
            return c == 'а' || c == 'э' || c == 'и' || c == 'о' || c == 'ы' || c == 'я' || c == 'е' || c == 'ё';
        }

        static int CountWords2(string s)
        {
            int cnt = 0;
            if (isGlas(s[0]))
                ++cnt;
            for (int i = 1; i < s.Length; ++i)
                if (s[i - 1] == ' ' && isGlas(s[i]))
                    ++cnt;
            return cnt;
        }

        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(RemoveSpaces(s));
            Console.WriteLine(CountWords(s));
            Console.WriteLine(CountWords2(s));
        }
    }
}
