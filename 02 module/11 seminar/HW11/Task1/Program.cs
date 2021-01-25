using System;

namespace Task1
{
    class UserString
    {
        string str;
        static Random gen = new Random();

        public UserString(int k, char minChar, char maxChar)
        {
            if (k < 0)
                throw new Exception("Аргумент метода должен быть положительным!"); // minChar, minChar - границы диапазона символов
            if (maxChar < minChar)
            {
                char c = minChar; minChar = maxChar; maxChar = c;
            }
            // пустая строка, останется пустой, если символов 0
            string line = String.Empty;
            for (int i = 0; i < k; i++)
                line += (char)gen.Next(minChar, maxChar + 1);
            str = line;
        }

        public string MoveOff(string s2)
        {
            string res = str;
            int index;
            for (int i = 0; i < s2.Length; i++)
                while ((index = res.IndexOf(s2[i])) >= 0) res = res.Remove(index, 1);
            return res;
        } // end of MoveOff()

        public override string ToString()
        {
            return str;
        }
    }

    class Program
    {
        static int GetIntValue(string comment)
        {
            int intVal;
            do Console.Write(comment);
            while (!int.TryParse(Console.ReadLine(), out intVal));
            return intVal;
        }

        static void Main(string[] args)
        {
            int k = GetIntValue("Количество символов ");
            char a = (char)Console.Read();
            char b = (char)Console.Read();
            Console.ReadLine();
            UserString us = new UserString(k, a, b);
            Console.WriteLine(us);
            string s2 = Console.ReadLine();
            Console.WriteLine(us.MoveOff(s2));
        }
    }
}
