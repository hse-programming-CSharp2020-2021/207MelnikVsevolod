using System;
using System.IO;

namespace MatrixCalc
{
    partial class Program
    {
        /// <summary>
        /// Displays manual for the user.
        /// </summary>
        static void Help()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("СПРАВКА");
            Console.ForegroundColor = default_color;

            Console.WriteLine("  Все операции производятся над матрицами, сохранёнными в памяти программы.");
            Console.WriteLine("  Матрицы в памяти храняться под номерами, начинающимися с 0.");
            Console.WriteLine("  <матрица> - номер матрицы в памяти или new для создания новой.");
            Console.WriteLine("  Пример: new = add 5 8 - сложить 5-ю и 8-ю матрицы и записать результат в новую матрицу.");
            Console.WriteLine("  Пример: 2 = mult 0 3 - умножить 0-ю и 3-ю матрицы и записать результат во 2-ю матрицу.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("КОМАНДЫ:");
            Console.ForegroundColor = default_color;

            Console.WriteLine("  help - показать справку.");
            Console.WriteLine("  exit - выйти из программы.");
            Console.WriteLine("  show <матрица> - вывести матрицу на экран. Числа выводятся с точностью до 1 знака после запятой.");
            Console.WriteLine("  solve <матрица> - решить СЛАУ, записанную с помошью расширенной матрицы (A|b), где b - вектор решений.");
            Console.WriteLine("  det <матрица> - найти определитель квадратной матрицы.");
            Console.WriteLine("  trace <матрица> - найти след квадратной матрицы.");
            Console.WriteLine("  read - ввести матрицу с клавиатуры и записать в память.");
            Console.WriteLine("  file - загрузить матрицу из файла в память.");
            Console.WriteLine("  rand - создать случайную матрицу и записать в память.");

            Console.WriteLine("  <матрица> = <матрица> + <матрица> - сложить матрицы и записать результат в память.");
            Console.WriteLine("  <матрица> = <матрица> - <матрица> - вычесть матрицы и записать результат в память.");
            Console.WriteLine("  <матрица> = <матрица> * <матрица> - умножить матрицы и записать результат в память.");
            Console.WriteLine("  <матрица> = <матрица> t - транспонировать матрицу и записать результат в память.");
            Console.WriteLine("  <матрица> = <матрица> *s <число> - умножить матрицу на скаляр и записать результат в память.");
            Console.WriteLine("");

            Console.ForegroundColor = default_color;
        }
    }
}