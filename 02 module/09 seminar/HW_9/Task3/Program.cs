using System;

namespace Task3
{
    abstract public class MyString
    {
        protected String str;
        protected static Random rnd = new Random();

        /// <summary>
        /// Свойство, возвращающее информацию о палиндромности /// </summary>
        public bool IsPalindrome
        {
            get
            {
                if (str.Length > 0)
                {
                    char[] tmp = str.ToCharArray(); Array.Reverse(tmp);
                    string tmpString = new string(tmp);
                    if (str.CompareTo(tmpString) == 0) return true;
                }
                return false;
            }
        }

        abstract public bool Validate();
        abstract public int CountLetter(char letter);

        public override string ToString()
        {
            return str;
        }
    }


    public class RusString : MyString
    {
        public RusString(char start, char finish, int n)
        {
            // проверяем количество символов строки и допустимые границы
            if (n <= 0 || start < 'а' || finish > 'я')
                throw new ArgumentOutOfRangeException();
            char[] letters = new char[n];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = (char)rnd.Next(start, finish + 1);
            }
            str = new String(letters);
            if (!Validate())
                throw new TypeInitializationException("LatString", new ArgumentOutOfRangeException());
        }

        /// <summary>
        /// метод подсчитывает количество вхождений символа в строку
        /// </summary>
        /// <param name="letter">буква, которая ищется в строке</param> /// <returns></returns>
        override public int CountLetter(char letter)
        {
            if (letter < 'а' || letter > 'я') return 0; int start = 0, result = -1, res;
            do
            {
                res = str.IndexOf(letter, start);
                start = res + 1;
                result++;
            } while (res >= 0); return result;
        }

        override public bool Validate()
        {
            for (int i = 0; i < str.Length; ++i)
                if (str[i] < 'а' || str[i] > 'я') return false;
            return true;
        }
    }

    public class LatString : MyString
    {
        public LatString(char start, char finish, int n)
        {
            // проверяем количество символов строки и допустимые границы
            if (n <= 0 || start < 'a' || finish > 'z')
                throw new ArgumentOutOfRangeException();
            char[] letters = new char[n];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = (char)rnd.Next(start, finish + 1);
            }
            str = new String(letters);
            if (!Validate())
                throw new TypeInitializationException("LatString", new ArgumentOutOfRangeException());
        }

        /// <summary>
        /// метод подсчитывает количество вхождений символа в строку
        /// </summary>
        /// <param name="letter">буква, которая ищется в строке</param> /// <returns></returns>
        override public int CountLetter(char letter)
        {
            if (letter < 'a' || letter > 'z') return 0; int start = 0, result = -1, res;
            do
            {
                res = str.IndexOf(letter, start);
                start = res + 1;
                result++;
            } while (res >= 0); return result;
        }

        override public bool Validate()
        {
            for (int i = 0; i < str.Length; ++i)
                if (str[i] < 'a' || str[i] > 'z') return false;
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char start = 'к', finish = 'ю';
            char start2 = 'a', finish2 = 'z';
            do
            {
                MyString testString = new RusString(start, finish, 10);
                Console.WriteLine(testString);
                Console.WriteLine(testString.CountLetter('о'));
                // тестируем неверные входные данные
                try
                {
                    testString = new RusString(start, finish, -11);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Состояние объекта не изменено");// если объект не сформирован
                }
                Console.WriteLine(testString);
                Console.WriteLine(testString.CountLetter('о'));

                MyString testString2 = new LatString(start2, finish2, 10);
                Console.WriteLine(testString2);
                Console.WriteLine(testString2.CountLetter('a'));
                // тестируем неверные входные данные
                try
                {
                    testString2 = new LatString(start, finish, -11);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Состояние объекта не изменено");// если объект не сформирован
                }
                Console.WriteLine(testString2);
                Console.WriteLine(testString2.CountLetter('a'));
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
