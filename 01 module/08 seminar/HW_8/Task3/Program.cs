using System;
using System.IO; // Пространство имён System.IO -> File.
using System.Text; // Кодировка.

class Program
{
    static void WriteText(string filename, string[] lines, Encoding enc)
    {
        File.WriteAllLines(filename, lines, enc);
    }

    static void ReadWithoutDots(string filename, Encoding enc)
    {
        // читаем сформированный файл и обрабатываем предложения
        string[] messages = File.ReadAllLines(fileName, enc); // Массив сообщений из переписки.
        Console.WriteLine(Environment.NewLine + "Переписка после форматирования:");
        foreach (string item in messages)
            if (item[item.Length - 1] == '.')
                Console.WriteLine(item.Substring(0, item.Length - 1)); // Выводим сообщения из переписки без точек на экран.
            else
                Console.WriteLine(item);
    }

    static Random rand = new Random();
    static void Main()
    {
        // основные настрйки
        const string fileName = "dialog.txt";
        Encoding enc = Encoding.Unicode;
        const int linesCount = 6;   // кол-во предложений

        Console.WriteLine("Переписка до форматирования:");
        string[] lines = new string[linesCount];
        for (int i = 0; i < linesCount; i++)
        {
            string message = string.Empty; // предложение
            int length = rand.Next(20, 51); // Длина сообщения от 20 до 50 символов (51 - 50 включён в диапазон)
            for (int j = 0; j < length; j++)
            {
                message += (char)rand.Next('А', 'Я'); // Посимвольное добавление букв в сообщение. "Ё" нет в диапазоне от А до Я!
            }
            message += "." + Environment.NewLine; // Добавляем в сообщение точку и перенос на следующую строку.
            lines[i] = message;
        }
        WriteText(filename, lines, enc);

        ReadWithoutDots(filename, enc);
    }
}