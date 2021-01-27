using System;

namespace Task2
{
    class Program
    {
        delegate string ConvertRule(string s);

        class Converter
        {
            public string Convert(string str, ConvertRule cr)
            {
                return cr(str);
            }

            public static string RemoveDigits(string str)
            {
                string ans = "";

                for (int i = 0; i < str.Length; ++i)
                    if (str[i] < '0' || str[i] > '9')
                        ans += str[i];
                return ans;
            }

            public static string RemoveSpaces(string str)
            {
                string ans = "";

                for (int i = 0; i < str.Length; ++i)
                    if (str[i] != ' ')
                        ans += str[i];
                return ans;
            }
        }


        static void Main(string[] args)
        {
            Converter c = new Converter();
            string s = "qwe qwe rqw23 243 2 2 ";
            ConvertRule c2 = Converter.RemoveDigits;
            c2 += Converter.RemoveSpaces;
            string[] tests = { "qwerty", "41 rww", "rkkfwkef 2", "134n u34 2 " };
            Array.ForEach(tests, (s) => Console.WriteLine(c.Convert(s, Converter.RemoveDigits)));
            Console.WriteLine();
            Array.ForEach(tests, (s) => Console.WriteLine(c.Convert(s, Converter.RemoveSpaces)));
            Console.WriteLine();
            Array.ForEach(tests, (s) => Console.WriteLine(c.Convert(s, c2)));
        }
    }
}
