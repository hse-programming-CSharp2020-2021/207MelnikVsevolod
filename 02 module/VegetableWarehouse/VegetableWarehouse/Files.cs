using System;
using System.IO;

namespace VegetableWarehouse
{
    partial class Program
    {
        /// <summary>
        /// Read data about warehouse from file and create it.
        /// </summary>
        /// <param name="path"> Path to file. </param>
        /// <returns> True if reading was succesfull. </returns>
        static bool CreateWarehouseFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2)
                return false;
            int max_cnt;
            double fee;
            if (int.TryParse(lines[0], out max_cnt) && double.TryParse(lines[1], out fee))
            {
                wh = new Warehouse(max_cnt, fee);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Read data about container and fill it with boxes.
        /// </summary>
        /// <param name="container"> Container. </param>
        /// <param name="data"> Strings with data about container. </param>
        /// <param name="data_ind"> Index of current line in data. </param>
        /// <returns> True if data was correct. </returns>
        static bool FillContainerFromFile(Container container, string[] data, ref int data_ind)
        {
            if (data_ind >= data.Length)
                return false;
            string[] args = data[data_ind++].Split();
            int cnt;
            if (args.Length <= 0 || !int.TryParse(args[0], out cnt))
                return false;
            // Check if there are enough boxes.
            if (args.Length < cnt * 3 + 1)
                return false;
            for (int i = 0; i < cnt; ++i)
            {
                string id = args[i * 3 + 1];
                double mass, price;
                if (!double.TryParse(args[i*3+2], out mass) || !double.TryParse(args[i*3+3], out price))
                {
                    Error($"Ожидались числа на строке {data_ind} в описании контейнера.");
                    return false;
                }
                Box new_box = new Box(id, mass, price);
                if (!container.AddBox(new_box))
                    Error($"Ящик {id} не может быть добавлен, так как превышена" +
                          $" максимальная допустимая масса.");
            }
            return true;
        }

        /// <summary>
        /// Read files and add (or delete) containers.
        /// </summary>
        /// <param name="commands_path"> Path to file with commands. </param>
        /// <param name="data_path"> Path to file with data about containers. </param>
        /// <returns> True if operation was succesfull. </returns>
        static bool AddContainersFromFile(string commands_path, string data_path)
        {
            string[] commands = File.ReadAllLines(commands_path);
            string[] data = File.ReadAllLines(data_path);
            // Index of the current line in data.
            int data_ind = 0;
            for (int i = 0; i < commands.Length; ++i)
            {
                string[] cmd_args = commands[i].Split();
                if (cmd_args[0] == "delete")
                {
                    int id;
                    if (!int.TryParse(cmd_args[1], out id))
                        return false;
                    if (!wh.DeleteContainer(id))
                        Error($"Контейнер {id} не найден.");
                }
                else if (cmd_args[0] == "add")
                {
                    Container new_c = new Container(new_id++, rnd.NextDouble() * (950) + 50);
                    if (!FillContainerFromFile(new_c, data, ref data_ind))
                        return false;
                    if (wh.AddContainer(new_c))
                        balance += wh.Fee;
                    else
                        Console.WriteLine($"Контейнер {new_id-1} не был добавлен," +
                                          $" так как его хранение не рентабельно.");
                }
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Display manual for working with files.
        /// Explain files format.
        /// </summary>
        static void FilesManual()
        {
            Console.WriteLine("Описание склада состоит из 3 файлов:");
            Console.WriteLine("1) Описание склада.");
            Console.WriteLine("2) Описание команд.");
            Console.WriteLine("3) Описание контейнеров.");
            Console.WriteLine("");
            Console.WriteLine("Описание склада - 2 строки:" +
                " целое число - максимальное количество контейнеров и" +
                " вещественное число - плата за хранение одного контейнера.");
            Console.WriteLine("Описание команд - add - добавить контейнер," +
                " delete <id> - удалить контейнер под номером <id>");
            Console.WriteLine("Описание контейнеров - каждая строка - описание одного контейнера.");
            Console.WriteLine("Описание контейнера - количество ящиков и информация о ящиках");
            Console.WriteLine("Каждый ящик - наименование ящика, масса и цена за кг.");
            Console.WriteLine("Все данные в строке разделяются пробелами.");
            Console.WriteLine("");
        }

        /// <summary>
        /// Load warehouse from files.
        /// </summary>
        static void LoadFromFiles()
        {
            FilesManual();
            Console.Write("Введите путь до файла с описанием склада: ");
            string wh_path = ReadLine();
            Console.Write("Введите путь до файла с описанием команд: ");
            string cmd_path = ReadLine();
            Console.Write("Введите путь до файла с описанием контейнеров: ");
            string data_path = ReadLine();
            if (!File.Exists(wh_path))
            {
                Error("Файл с описанием склада не найден.");
                return;
            }
            if (!File.Exists(cmd_path))
            {
                Error("Файл с описанием команд не найден.");
                return;
            }
            if (!File.Exists(data_path))
            {
                Error("Файл с описанием контейнеров не найден.");
                return;
            }
            if (!CreateWarehouseFromFile(wh_path) || !AddContainersFromFile(cmd_path, data_path))
                Error("Неверный формат файлов.");
            else
            {
                Console.Clear();
                Console.WriteLine("Склад успешно загружен.");
            }
        }

        /// <summary>
        /// Write info about warehouse to file.
        /// </summary>
        static void WriteInfoToFile()
        {
            Console.WriteLine("Введите путь до файла, в который вы хотите записать отчёт.");
            string path = ReadLine();
            string[] wh_info = wh.Info();
            File.WriteAllLines(path, wh_info);
            Console.WriteLine("Отчёт успешно записан в файл.");
        }
    }
}
