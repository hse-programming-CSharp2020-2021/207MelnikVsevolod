using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Task4
{
    [Serializable] // атрибут сериализации public
    class Multiple
    {
        public readonly string name;
        public readonly int divisor;
        public readonly List<int> numbers;

        public override string ToString()
        {
            // название делителя // значение делителя
            // массив чисел, кратных divisor
            string mom = "Делитель: " + divisor + " - " + name + "\r\nКратные: "; foreach (int m in numbers)
                mom += m + " "; return mom;
        }

        public Multiple(int div, int[] ar)
        { // конструктор
            if (div <= 0 || div > 9)
                throw new Exception("Неверно выбран делитель!"); divisor = div;
            string[] names = new string[] { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            name = names[div];
            int[] temp = new int[ar.Length]; int numb = 0;
            for (int i = 0; i < ar.Length; i++)
                if (ar[i] % div == 0) temp[numb++] = ar[i]; numbers = new List<int>(temp);
            numbers.RemoveRange(numb, numbers.Count - numb); // Укоротили массив
        } // конструктор
    }

    class Program
    {
        static void Main(string[] args)
        {
            Multiple row; // ссылка на объект класса
            int size = 0; // размер генеральной совокупности
            do
                Console.Write("Введите размер генеральной совокупности: ");
            while (!int.TryParse(Console.ReadLine(), out size) | size < 1); Random gen = new Random(5);
            int[] data = new int[size]; // генеральная совокупность
            for (int i = 0; i < size; i++)
            {
                data[i] = gen.Next(0, 100);
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
            BinaryFormatter formBin = new BinaryFormatter();

            using (FileStream byteStream = new FileStream("bytes", FileMode.Create, FileAccess.ReadWrite))
            {
                do
                { // цикл для создания и записи в файл объектов
                    int div;
                    do
                    {
                        // цикл проверки делителя!
                        do Console.Write("Введите делитель: ");
                        while (!int.TryParse(Console.ReadLine(), out div)); try
                        {
                            row = new Multiple(div, data);
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Нужен делитель от 1 до 9!"); continue;
                        }
                    }
                    while (true);
                    // создан объект row, запишем его код в файл:
                    formBin.Serialize(byteStream, row);
                    byteStream.Flush();
                    Console.WriteLine("\nДля чтения файла - клавиша ESC");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                byteStream.Position = 0;
                while (true) // читать до конца файла
                    try
                    {
                        row = (Multiple)formBin.Deserialize(byteStream); Console.WriteLine(row.ToString());
                    }
                    catch (SerializationException)
                    {
                        break;
                    }
            }

        }
    }
}