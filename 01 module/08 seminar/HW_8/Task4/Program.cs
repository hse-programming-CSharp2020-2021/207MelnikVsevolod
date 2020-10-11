using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static string scorePath = "../../../Score.csv";

        /// <summary>
        /// Метод считывания Integer с двумя границами 
        /// </summary>
        /// <param name="left"> Левая граница </param>
        /// <param name="right"> Правая граница </param>
        /// <returns> Считанное число </returns>
        static int ReadInt(int left, int right)
        {
            while (true)
            {
                try
                {
                    int n = int.Parse(Console.ReadLine());
                    if (n < left || n > right)
                        throw new ArgumentException();
                    return n;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод, повторите.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Нет такого пункта");
                }
            }
        }

        /// <summary>
        /// Метод вывода меню
        /// </summary>
        static void PrintMainMenu()
        {
            Console.WriteLine("Добро пожаловать в ваш личный словарь!!!\n Выберите номер пункта, что вы хотите сделать:\n" +
                "\t 1. Добавить новый словарь.\n" +
                "\t 2. Добавить новое слово и перевод.\n" +
                "\t 3. Найти перевод слова.\n" +
                "\t 4. Игра в карточки\n" +
                "\t Для выхода введите 0");
        }

        static void Main(string[] args)
        {
            while (true)
                Start();
        }

        /// <summary>
        /// Реализация общего процесса поведения программы
        /// </summary>
        static void Start()
        {
            PrintMainMenu();
            int n = ReadInt(0, 4);
            switch (n)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    AddNewLanguage();
                    break;
                case 2:
                    AddNewWord();
                    break;
                case 3:
                    FindTranslate();
                    break;
                case 4:
                    PlayCard();
                    break;
            }
        }

        /// <summary>
        /// Метод добавления нового словаря
        /// </summary>
        static void AddNewLanguage()
        {
            Console.Write("Введите название словаря: ");
            string dictName = Console.ReadLine() + ".txt";

            if (File.Exists(dictName))
            {
                try
                {
                    Console.WriteLine("Такой словарь уже существует");
                }
                catch (IOException)
                {
                    Console.WriteLine("Ошибка при создании словаря");
                }
            }
            else
            {
                // Вариант для пацанов (если юзать стримы)
                //FileStream f = File.Create(dictName);
                //f.Close();
                // Костыль под соусом 
                File.AppendAllText(dictName, "");
            }
        }

        /// <summary>
        /// Метод добавления нового слова в словарь
        /// </summary>
        static void AddNewWord()
        {
            // Ищем словарь
            string dictName;
            try
            {
                dictName = CheckIfExist();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.Write("Введите новое слово: ");
            string word = Console.ReadLine();
            Console.Write("Введите перевод: ");
            string translate = Console.ReadLine();

            try
            {
                File.AppendAllText(dictName, word + "-" + translate + "\n");
            }
            catch (IOException)
            {
                Console.WriteLine("Неудалось добавить новое слово");
            }
        }

        /// <summary>
        /// Метод поиска перевода слова
        /// </summary>
        static void FindTranslate()
        {
            // Ищем словарь
            string dictName;
            try
            {
                dictName = CheckIfExist();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.Write("Введите слово: ");
            string word = Console.ReadLine();
            string[] allWords = null;
            try
            {
                allWords = File.ReadAllLines(dictName);
            }
            catch (IOException)
            {
                Console.WriteLine("Неудалось считать слова");
            }

            // Ищем первое слово в словаре нужное нам
            foreach (string str in allWords)
            {
                if (str.Split('-').Length != 2)
                {
                    Console.WriteLine("Ошибка в записи " + str);
                    continue;
                }

                string dictWord = str.Split('-')[0];
                if (dictWord == word)
                {
                    Console.WriteLine("Перевод:" + str.Split('-')[1]);
                    return;
                }
            }

            Console.WriteLine("Слово отсутсвтует");
        }

        /// <summary>
        /// Метод игры в карточки
        /// </summary>
        static void PlayCard()
        {
            // Ищем словарь
            int newScore = 0;
            string dictName;
            try
            {
                dictName = CheckIfExist();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }


            Random rnd = new Random();
            string[] allWords = null;
            try
            {
                allWords = File.ReadAllLines(dictName);
            }
            catch (IOException)
            {
                Console.WriteLine("Неудалось считать слова");
            }

            Console.WriteLine("Вам будут выводиться слова на выбранном языке, а вам неодходимо написать перевод. \nДля выхода в меню \"Exit\"");

            int len = allWords.Length;
            while (true)
            {
                // Рандомно выбираем слово
                string pair = allWords[rnd.Next(len)];

                // При ошибки в записи выходим из игры
                if (pair.Split('-').Length != 2)
                {
                    Console.WriteLine("Ошибка в записи " + pair + "\nИсправьте");
                    return;
                }

                // Выводим карточку
                Console.WriteLine(pair.Split('-')[0]);
                string answer = Console.ReadLine();

                // При выходе записываем результат
                if (answer == "Exit")
                {
                    Console.Write("Введите ваше имя для сохранения результатов: ");
                    string name = Console.ReadLine();
                    try
                    {
                        File.AppendAllText(scorePath, name + ";" + newScore + ";" + System.DateTime.Now.ToString() + "\n");
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Неудалось записать результат");
                    }
                    return;
                }
                if (answer == pair.Split('-')[1])
                {
                    Console.WriteLine("Верно!");
                    ++newScore;
                }
                else
                    Console.WriteLine("Невеврно. Верный ответ: " + pair.Split('-')[1]);
            }
        }

        /// <summary>
        /// Вспомогательный метод для проверки на наличие словаря
        /// </summary>
        /// <returns></returns>
        static string CheckIfExist()
        {
            Console.Write("Введите название словаря: ");
            string dictName = Console.ReadLine() + ".txt";

            if (!File.Exists(dictName))
                throw new ArgumentException("Такого словаря не существует:(");

            return dictName;
        }
    }
}
