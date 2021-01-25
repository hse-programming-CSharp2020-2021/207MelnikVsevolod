using System;
using System.IO;

namespace Task3
{
    class Program
    {

        /// <summary>
        /// Вычисляет количество открывающихся и закрывающихся скобок в строке
        /// </summary>
        /// <param name="tmp">строка символов</param>
        /// <param name="openBrackets">количество открывающихся скобок</param>
        /// <param name="closedBrackets">количество закрывающихся скобок</param>
        private static void BracketsCount(string tmp, ref int openBrackets, ref int closedBrackets)
        {
            bool isInString = false;
            for (int i = 0; i < tmp.Length; i++)
            {
                // статистика по строчным латинским символам
                if (tmp[i] >= 'a' && tmp[i] <= 'z')
                    stat[tmp[i] - 'a']++;
                if ((tmp[i] == '\"' || tmp[i] == '\'') && (i == 0 || tmp[i - 1] != '\\'))
                    isInString = !isInString;
                if (tmp[i] == '{' && !isInString)
                    openBrackets++;
                if (tmp[i] == '}' && !isInString)
                    closedBrackets++;
            }
        }

        /// <summary>
        /// метод формирует строку со статистикой по строчным латинским,
        /// символам, содержащимся в тексте файла
        /// </summary>
        /// <returns>возвращает строку с представлением статистики</returns>
        public static string StatToString()
        {
            string output = string.Empty;
            for (int i = 0; i < stat.Length; i++)
            {
                output += (char)('a' + i) + " - " + stat[i] + " ";
            }
            return output;
        }

        static int[] stat = new int[26]; // статистика по лат. буквам

        static void Main(string[] args)
        {
            string tmp;
            int openBrackets = 0; // количество {
            int closedBrackets = 0; // количество }

            int total = 0; // общее количество символов файла
            var In = Console.In; // Запоминаем стандартный входной поток
                                 // Создаем файл и текстовый входной поток:
            var Out = Console.Out;
            StreamReader stream_in = new StreamReader(@"../../../Program.cs");
            StreamWriter stream_out = new StreamWriter("output.txt");
            // Настраиваем стандартный входной поток на чтение из файла:
            Console.SetIn(stream_in);
            Console.SetOut(stream_out);

            while (true) { // цикл бесконечен
                tmp = stream_in.ReadLine();
                if (tmp == null) break; // условие прерывание цикла
                total += tmp.Length;
                // подсчёт количества фигурных скобок
                BracketsCount(tmp, ref openBrackets, ref closedBrackets); Console.WriteLine(tmp.Trim());
                Console.WriteLine(tmp);
            }
            // восстанавливаем состояние потока
            stream_in.Close(); Console.SetIn(In);
            // обрабатываем данные по скобкам
            tmp = "Баланс скобок не соблюдён";
            if (openBrackets == closedBrackets)
                tmp = "Баланс скобок соблюдён, количество блоков " + closedBrackets;
            Console.WriteLine(StatToString());
            Console.WriteLine(tmp);
            stream_out.Close();
            Console.SetOut(Out);
            Console.WriteLine("Для завершения работы нажмите любую клавишу."); Console.ReadKey();
        }

    }
}