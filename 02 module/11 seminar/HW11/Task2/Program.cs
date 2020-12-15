using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] lines;
            if ((lines = StringSplit.ValidatedSplit(str, ';')) == null)
            {
                Console.WriteLine("Ошибка");
            }
            else
            {
                for (int i = 0; i < lines.Length; ++i)
                    Console.WriteLine(StringSplit.Abbrevation(lines[i]));
            }
        }
    }
}
