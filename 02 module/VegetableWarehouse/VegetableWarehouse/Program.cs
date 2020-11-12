using System;

namespace VegetableWarehouse
{
    partial class Program
    {
        // Id for new container.
        static int new_id = 0;
        // Random for generating containers.
        static Random rnd = new Random(DateTime.Now.Millisecond);
        static bool was_visited_by_mafia = false;
        // Colors for vegetables
        static char[] vegetables = new char[5] { 'o', 'O', '@', '.', '*'};
        static ConsoleColor[] colors = new ConsoleColor[5] { ConsoleColor.DarkRed,
                                                      ConsoleColor.Blue,
                                                      ConsoleColor.Green,
                                                      ConsoleColor.DarkGreen,
                                                      ConsoleColor.DarkYellow};

        /// <summary>
        /// Warehouse of containers of boxes of vegetables.
        /// </summary>
        static Warehouse wh;

        /// <summary>
        /// Money in rubles.
        /// </summary>
        static double balance = 0;

        /// <summary>
        /// Read line from console.
        /// </summary>
        static string ReadLine()
        {
            string input;
            Console.ForegroundColor = ConsoleColor.Yellow;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }

        /// <summary>
        /// Ask user parameters of warehouse and create it.
        /// </summary>
        static void CreateWarehouse()
        {
            int max_cnt;
            double fee;
            string input;
            Console.WriteLine("Каким будет склад?");
            do
            {
                Console.WriteLine("Введите максимальное число контейнеров на складе:");
                Console.WriteLine("Целое положительное число.");
                input = ReadLine();
            } while (!int.TryParse(input, out max_cnt) || max_cnt <= 0);
            do
            {
                Console.WriteLine("Введите плату за хранение одного контейнера в рублях:");
                Console.WriteLine("Положительное вещественное число.");
                input = ReadLine();
            } while (!double.TryParse(input, out fee) || fee <= 0);
            wh = new Warehouse(max_cnt, fee);
            Console.Clear();
            Console.WriteLine("Вы успешно создали склад для овощей.");
        }

        /// <summary>
        /// Display info about warehouse.
        /// </summary>
        static void DisplayInfo()
        {
            string[] wh_info = wh.Info();
            for (int i = 0; i < wh_info.Length; ++i)
                Console.WriteLine(wh_info[i]);
        }

        /// <summary>
        /// Display current balance in rubles.
        /// </summary>
        static void DisplayBalance()
        {
            Console.Write("Баланс: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{balance:F2}₽");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Display error on the screen.
        /// </summary>
        static void Error(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Fill container with boxes.
        /// </summary>
        /// <param name="container"></param>
        static void FillContainer(Container container)
        {
            int cnt;
            string input;
            do
            {
                Console.Write("Количество ящиков в контейнере (положительное целое число): ");
                input = ReadLine();
            } while (!int.TryParse(input, out cnt) || cnt <= 0);
            for (int i = 0; i < cnt; ++i)
            {
                Console.WriteLine("");
                string id, s_mass, s_price;
                double mass, price;
                Console.Write("Наименование ящика: ");
                id = ReadLine();
                Console.Write("Масса ящика: ");
                s_mass = ReadLine();
                Console.Write("Цена за кг: ");
                s_price = ReadLine();
                if (!double.TryParse(s_mass, out mass) || !double.TryParse(s_price, out price))
                {
                    Error("Некорректный ввод. Масса и цена должны быть числами.");
                    --i;
                    continue;
                }
                Box new_box = new Box(id, mass, price);
                if (container.AddBox(new_box))
                    Console.WriteLine("Ящик успешно добавлен.");
                else
                    Error("Ящик не может быть добавлен, так как превышена максимальная допустимая масса.");
            }
        }

        /// <summary>
        /// Create new container and add to warehouse.
        /// </summary>
        static void AddContainer()
        {
            Container new_c = new Container(new_id++, rnd.NextDouble() * (950) + 50);
            Console.WriteLine($"Создан контейнер под номером {new_c.ID}");
            Console.WriteLine($"Максимальная допустимая масса: {new_c.MaxMass:F3}");
            FillContainer(new_c);
            if (wh.AddContainer(new_c))
            {
                balance += wh.Fee;
                Console.WriteLine("Контейнер успешно добавлен на склад");
                DisplayBalance();
            }
            else
                Console.WriteLine("Контейнер не был добавлен, так как его хранение не рентабельно.");
        }

        /// <summary>
        /// Delete container from warehouse.
        /// </summary>
        /// <param name="id"> Id of the container. </param>
        static void DeleteContainer(int id)
        {
            if (wh.DeleteContainer(id))
                Console.WriteLine($"Контейнер №{id} успешно удалён со склада.");
            else
                Error($"Контейнер {id} не найден.");
        }

        /// <summary>
        /// Draw random vegetable.
        /// </summary>
        static void Vegetable()
        {
            Console.ForegroundColor = colors[rnd.Next(5)];
            Console.Write(vegetables[rnd.Next(5)]);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Greet user.
        /// </summary>
        static void Greet()
        {
            Console.WriteLine("   __________________   ");
            Console.WriteLine("  /   ____________   \\ ");
            Console.WriteLine(" /   |Склад овощей|   \\");
                Console.Write(" |    ------------    |     ");
            for (int i = 0; i < 3; ++i)
                Vegetable();
            Console.WriteLine("   _   ");
                Console.Write(" |   |            |   |   |");
            for (int i = 0; i < 5; ++i)
                Vegetable();
            Console.WriteLine("||п\\  ");
            Console.WriteLine(" |   |            |   |   |_____||=_|  ");
            Console.WriteLine(" |   |            |   |    o----=-o-   ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("///////////////////////////////////////");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Добро пожаловать в систему учёта овощного склада.");
        }

        /// <summary>
        /// Display manual.
        /// </summary>
        static void Help()
        {
            Console.WriteLine("Команды: ");
            Console.WriteLine("  help - справка о командах.");
            Console.WriteLine("  add - добавить контейнер на склад.");
            Console.WriteLine("  delete <id> - удалить контейнер под номером <id>.");
            Console.WriteLine("  balance - вывести баланс счёта.");
            Console.WriteLine("  info - вывести информацию о складе и хранимых контейнерах.");
            Console.WriteLine("  load - загрузить данные о новом складе из файлов.");
            Console.WriteLine("  export - вывести информацию о складе и хранимых контейнерах в файл.");
            Console.WriteLine("  exit - выйти из программы.");
        }

        /// <summary>
        /// Pay mafia for protection.
        /// </summary>
        static void PayMafia()
        {
            Console.WriteLine("");
            if (!was_visited_by_mafia)
            {
                Console.WriteLine("Несколько членов мафии входят в ваш склад.");
                Console.WriteLine(" - Ты знаешь, что случилось с последним складом," +
                                  " владелец которого не платил за защиту?");
                Console.WriteLine("   Лучше не знать.");
                Console.WriteLine("   Ты платишь нам, и твои овощи будут в порядке. Ты меня понял?");
                ReadLine();
                Console.WriteLine(" - Не то чтобы у тебя был выбор. Приятно иметь с тобой дело.");
            }
            else
                Console.WriteLine("Мафия вернулась в ваш склад, чтобы забрать деньги за защиту.");
            if (balance >= wh.Fee * 2)
            {
                balance -= wh.Fee * 2;
                Console.WriteLine($"Вам пришлось заплатить {wh.Fee * 2} рублей.");
                DisplayBalance();
            }
            else
            {
                Console.WriteLine("Вы не смогли заплатить мафии, поэтому они " +
                    "заставили вас поместить их контейнер на склад со скидкой.");
                Container m_c = new Container(new_id++, 5);
                Box m_b = new Box("Овощи мафии", 1, wh.Fee * 5);
                m_c.AddBox(m_b);
                wh.AddContainer(m_c);
                balance -= wh.Fee / 2;
            }

            was_visited_by_mafia = true;
        }

        /// <summary>
        /// Parse and exetuce command.
        /// </summary>
        /// <param name="args"> Arguments of the command. </param>
        /// <param name="exit"> True if user want to exit. </param>
        static void ParseCommand(string[] args, out bool exit)
        {
            exit = false;
            switch (args[0])
            {
                case "help":
                    Help();
                    break;
                case "add":
                    AddContainer();
                    break;
                case "delete":
                    int id;
                    if (args.Length == 2 && int.TryParse(args[1], out id))
                        DeleteContainer(id);
                    else
                        Error("Неверный формат команды.");
                    break;
                case "balance":
                    DisplayBalance();
                    break;
                case "info":
                    DisplayInfo();
                    break;
                case "load":
                    LoadFromFiles();
                    break;
                case "export":
                    WriteInfoToFile();
                    break;
                case "exit":
                    exit = true;
                    break;
                default:
                    Error("Неверная команда.");
                    break;
            }
        }

        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            wh = new Warehouse();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Greet();
            Console.WriteLine("Хотите загрузить склад из файлов? Напишите yes, если да.");
            string answer = ReadLine();
            if (answer == "yes" || answer == "Yes" || answer == "y" || answer == "Y")
            {
                try
                {
                    LoadFromFiles();
                }
                catch (Exception ex)
                {
                    Error("Ошибка: " + ex.Message);
                }
            }
            else
                CreateWarehouse();
            Help();
            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");
                Console.Write(">>> ");
                string command = ReadLine();
                try
                {
                    ParseCommand(command.Split(), out exit);
                }
                catch (Exception ex)
                {
                    Error("Ошибка: " + ex.Message);
                }
                if (rnd.Next(5) == 0)
                    PayMafia();
            }
            Console.WriteLine("До свидания.");
        }
    }
}
