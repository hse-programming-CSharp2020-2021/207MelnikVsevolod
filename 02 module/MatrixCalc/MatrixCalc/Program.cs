using System;
using System.IO;

// All operations are done with matrixed, stored in memory.
namespace MatrixCalc
{
    partial class Program
    {
        static string error_message = "";

        /// <summary>
        /// Matrixes, stored in memory by user.
        /// </summary>
        static Matrix[] memory = new Matrix[0];

        /// <summary>
        /// Write all operations or not.
        /// </summary>
        static bool write_all_ops = true;

        static Random rnd;
        static ConsoleColor default_color;

        /// <summary>
        /// Append matrix to memory.
        /// </summary>
        /// <param name="m"> Matrix. </param>
        static void StoreMatrix(Matrix m)
        {
            Array.Resize(ref memory, memory.Length + 1);
            memory[memory.Length - 1] = m;
        }

        /// <summary>
        /// Delete last matrix in the memory.
        /// </summary>
        static void DeleteLastMatrix()
        {
            if (memory.Length >= 1)
                Array.Resize(ref memory, memory.Length - 1);
        }

        /// <summary>
        /// Checks if matrix with that index exists in memory.
        /// </summary>
        /// <param name="index"> Index of the matrix in memory. </param>
        /// <returns></returns>
        static bool IsInMemory(int index)
        {
            return index >= 0 && index < memory.Length;
        }

        /// <summary>
        /// Draw operation with matrixes.
        /// </summary>
        /// <param name="str"> Array of strings. </param>
        /// <param name="force"> Draw it even if write_all_ops is false. </param>
        static void WriteOperation(string[] str, bool force = false)
        {
            if (write_all_ops || force)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                for (int i = 0; i < str.Length; ++i)
                    Console.WriteLine(str[i]);
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Print matrix.
        /// </summary>
        /// <param name="matrix_index"> Index of the matrix in memory. </param>
        /// <param name="error"> Error. </param>
        static void Print(int matrix_index, out bool error)
        {
            error = false;
            if (matrix_index < memory.Length && matrix_index >= 0)
                WriteOperation(FormatMatrix(memory[matrix_index]), true);
            else
            {
                error_message = "Матрицы с таким номером нет в памяти." + System.Environment.NewLine + $"Матриц в памяти: {memory.Length}.";
                error = true;
            }
        }

        /// <summary>
        /// Add ( and ) around matrix.
        /// Or | and | if we draw det of matrix.
        /// </summary>
        /// <param name="m"> Matrix. </param>
        /// <returns> Array of strings. </returns>
        static string[] FormatMatrix(Matrix m, bool is_det = false)
        {
            string[] str = m.Show();
            if (str.Length == 1)
            {
                if (is_det)
                    str[0] = "│ " + str[0] + "│";
                else
                    str[0] = "( " + str[0] + ")";
            }
            else
            {
                if (is_det)
                {
                    str[0] = "│ " + str[0] + "│";
                    str[str.Length - 1] = "│ " + str[str.Length - 1] + "│";
                }
                else
                {
                    str[0] = "╭ " + str[0] + "╮";
                    str[str.Length - 1] = "╰ " + str[str.Length - 1] + "╯";
                }
                for (int i = 1; i < str.Length - 1; ++i)
                    str[i] = "│ " + str[i] + "│";
            }
            return str;
        }

        /// <summary>
        /// Draw Morpheus with blue and red pills.
        /// </summary>
        static void DrawMorpheus()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("               _____               ");
            Console.WriteLine("             /       \\            ");
            Console.WriteLine("            |         |            ");
            Console.WriteLine("           (|-( )-( )-|)           ");
            Console.WriteLine("            |   /_\\   |    <- это типа Морфеус");
            Console.WriteLine("            \\   ___   /           ");
            Console.WriteLine("             \\   _   /            ");
            Console.WriteLine("        ________| |________        ");
            Console.WriteLine("       /         ^         \\       ");
            Console.WriteLine("      /     \\ | \\ / | /     \\      ");
            Console.WriteLine("     /    /  \\|  v  |/  \\    \\     ");
            Console.WriteLine("    /    /|   \\     /   |\\    \\     ");
            Console.Write("  --=");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("()");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("=  |    \\   /    |  =");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("()");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=--  ");
            Console.WriteLine("    ====  |     \\ /     |  ====    ");
            Console.WriteLine("          |             |          ");
        }

        /// <summary>
        /// Choose yes or not.
        /// </summary>
        /// <param name="msg"> Question to ask user. </param>
        /// <returns> User's answer. </returns>
        static bool Choose(string msg)
        {
            // Choose to write all operations or not.
            DrawMorpheus();
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Yes");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("No");
            Console.ForegroundColor = ConsoleColor.White;
            string answer = "";
            while (answer != "Yes" && answer != "No")
            {
                answer = Console.ReadLine();
                if (answer != "Yes" && answer != "No")
                    Console.WriteLine("Введите Yes или No");
            }
            Console.Clear();
            if (answer == "Yes")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Parse arguments and returns 2 indexes of matix in operation.
        /// </summary>
        /// <param name="args"> Arguments of the command. </param>
        /// <param name="m1"> Index 1. </param>
        /// <param name="m2"> Index 2. </param>
        /// <param name="error"> Error. </param>
        static void Parse2Indexes(string[] args, out int m1, out int m2, out bool error)
        {
            m1 = m2 = 0;
            error = false;
            if (args.Length >= 5 && int.TryParse(args[2], out m1) && int.TryParse(args[4], out m2))
            {
                if (!IsInMemory(m1) || !IsInMemory(m2))
                {
                    error = true;
                    error_message = "Матриц с такими индексами нет в памяти.";
                }
            }
            else
            {
                error = true;
                error_message = "Неверный формат команды.";
            }
        }

        /// <summary>
        /// Parse arguments and return 1 index of matrix in operation.
        /// </summary>
        /// <param name="args"> Arguments of the command. </param>
        /// <param name="m1"> Index of the matrix. </param>
        /// <param name="error"> Error. </param>
        static void Parse1Index(string[] args, out int m1, out bool error)
        {
            m1 = 0;
            error = false;
            if (args.Length >= 4 && int.TryParse(args[2], out m1))
            {
                if (!IsInMemory(m1))
                {
                    error = true;
                    error_message = "Матрицы с таким индексом нет в памяти.";
                }
            }
            else
            {
                error = true;
                error_message = "Неверный формат команды.";
            }
        }

        /// <summary>
        /// Execute command that requires calculating matrixes.
        /// </summary>
        /// <param name="args"> Arguments of the command. </param>
        /// <param name="error"> Error. </param>
        static void Calc(string[] args, out bool error)
        {
            error = false;
            // Index of the result matrix.
            int result_index = 0;
            // Create new matrix if needed.
            if (args[0] == "new")
            {
                StoreMatrix(new Matrix());
                result_index = memory.Length - 1;
            }
            else if (!int.TryParse(args[0], out result_index) || !IsInMemory(result_index))
            {
                error = true;
                error_message = $"Матрицы с индексом {args[0]} нет в памяти.";
                return;
            }
            int m1, m2;
            // Copy matrix if asked.
            if (args.Length == 3 && int.TryParse(args[2], out m1) && m1 >= 0 && m1 < memory.Length)
            {
                memory[result_index] = new Matrix(memory[m1]);
                Console.WriteLine("Матрица скопирована.");
            }
            else switch (args[3])
                {
                    case "+":
                        Parse2Indexes(args, out m1, out m2, out error);
                        if (!error)
                        {
                            Matrix res = Add(memory[m1], memory[m2], out error);
                            if (!error)
                            {
                                memory[result_index] = res;
                                Console.WriteLine($"Результат записан в память под номером {result_index}.");
                            }
                        }
                        break;
                    case "-":
                        Parse2Indexes(args, out m1, out m2, out error);
                        if (!error)
                        {
                            Matrix res = Sub(memory[m1], memory[m2], out error);
                            if (!error)
                            {
                                memory[result_index] = res;
                                Console.WriteLine($"Результат записан в память под номером {result_index}.");
                            }
                        }
                        break;
                    case "*":
                        Parse2Indexes(args, out m1, out m2, out error);
                        if (!error)
                        {
                            Matrix res = Mult(memory[m1], memory[m2], out error);
                            if (!error)
                            {
                                memory[result_index] = res;
                                Console.WriteLine($"Результат записан в память под номером {result_index}.");
                            }
                        }
                        break;
                    case "t":
                        Parse1Index(args, out m1, out error);
                        if (!error)
                        {
                            memory[result_index] = T(memory[m1]);
                            Console.WriteLine($"Результат записан в память под номером {result_index}.");
                        }
                        break;
                    case "*s":
                        Parse1Index(args, out m1, out error);
                        if (!error)
                        {
                            double s;
                            if (double.TryParse(args[4], out s))
                            {
                                memory[result_index] = Mult_s(memory[m1], s);
                                Console.WriteLine($"Результат записан в память под номером {result_index}.");
                            }
                            else
                            {
                                error = true;
                                error_message = "Введено не число.";
                            }
                        }
                        break;
                    default:
                        error = true;
                        error_message = "Неверная команда.";
                        break;
                }
            // New matrix is unused because of an error.
            if (args[0] == "new" && error)
                DeleteLastMatrix();
        }

        /// <summary>
        /// Execute command given by user.
        /// </summary>
        /// <param name="raw_command"> User's command (not parsed) </param>
        /// <param name="exit"> User wants to exit </param>
        static void DoCommand(string raw_command, out bool exit)
        {
            exit = false;
            if (raw_command == null)
                return;
            string[] args = raw_command.Split();
            if (args.Length == 0)
                return;
            string command = args[0];
            error_message = "Неверная команда.";
            bool error = false;
            int matrix_index;
            if (args.Length >= 3 && args[1] == "=")
            {
                Calc(args, out error);
            }
            else
            {
                switch (command)
                {
                    case "exit":
                        exit = true;
                        break;
                    case "help":
                        Help();
                        break;
                    case "show":
                        if (args.Length == 2 && int.TryParse(args[1], out matrix_index))
                        {
                            Print(matrix_index, out error);
                        }
                        else
                        {
                            error = true;
                            error_message = "Неверный формат команды.";
                        }
                        break;
                    case "solve":
                        if (args.Length == 2 && int.TryParse(args[1], out matrix_index) && IsInMemory(matrix_index))
                        {
                            if (memory[matrix_index].Columns < 2)
                            {
                                error = true;
                                error_message = "Неверный размер матрицы.";
                                break;
                            }
                            Solve(memory[matrix_index]);
                        }
                        else
                        {
                            error = true;
                            error_message = "Неверный формат команды.";
                        }
                        break;
                    case "det":
                        if (args.Length == 2 && int.TryParse(args[1], out matrix_index) && IsInMemory(matrix_index))
                        {
                            double det = Det(memory[matrix_index], out error);
                            if (!error)
                                Console.WriteLine(det);
                        }
                        else
                        {
                            error = true;
                            error_message = "Неверный формат команды.";
                        }
                        break;
                    case "trace":
                        if (args.Length == 2 && int.TryParse(args[1], out matrix_index) && IsInMemory(matrix_index))
                        {
                            double trace = Trace(memory[matrix_index], out error);
                            if (!error)
                                Console.WriteLine(trace);
                        }
                        else
                        {
                            error = true;
                            error_message = "Неверный формат команды.";
                        }
                        break;
                    case "read":
                        ReadMatrix(out error);
                        break;
                    case "file":
                        ReadFromFile(out error);
                        break;
                    case "rand":
                        RandomMatrix(out error);
                        break;
                    default:
                        error = true;
                        error_message = "Неверная команда.";
                        break;
                }
            }
            if (error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: " + error_message);
                Console.ForegroundColor = default_color;
            }
        }


        /// <summary>
        /// Write line with delay after each symbol.
        /// </summary>
        /// <param name="str"></param>
        static void WriteLineSlow(string str)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                Console.Write(str[i]);
                System.Threading.Thread.Sleep(120);
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Greeting.
        /// </summary>
        static void Greet()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteLineSlow("Wake up Neo...");
            System.Threading.Thread.Sleep(1000);
            WriteLineSlow("The Matrix has you...");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }

        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args"> Not used. </param>
        static void Main(string[] args)
        {
            rnd = new Random();
            Greet();
            string choose_msg = "Выводить все операции на экран?"
                              + System.Environment.NewLine
                              + "Рекомендуется при работе с небольшими матрицами.";
            if (Choose(choose_msg))
                write_all_ops = true;
            else
                write_all_ops = false;
            default_color = ConsoleColor.White;
            Console.OutputEncoding = new System.Text.UTF8Encoding();
            Console.ForegroundColor = default_color;
            Console.WriteLine("Введите help для справки.");

            bool exit = false;            
            while (!exit)
            {
                error_message = "";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(">>> ");
                string raw_command = Console.ReadLine();
                Console.ForegroundColor = default_color;
                try
                {
                    DoCommand(raw_command, out exit);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.ForegroundColor = default_color;
                }
            }
        }
    }
}
