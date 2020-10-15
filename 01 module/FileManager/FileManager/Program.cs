using System;
using System.IO;


//File manager main file. Parts of this class are located in ProgramUI.cs and ProgramText.cs.
//If id doesn't work, please, move everything to one file.
//For better experience use operation system's terminal (not integrated in IDE).
namespace FileManager
{
    partial class Program
    {
        //Error message for displaying to user.
        static string error_message = "";

        //Display help window.
        static void Help()
        {
            color = ConsoleColor.DarkCyan;
            string[] text = new string[19] { "help - показать справку по командам",
                                            "exit - выйти из программы",
                                            "disks - вывести список подключённых дисков",
                                            "disk_info - вывести информацию о текущем диске",
                                            "ls - просмотр файлов и папок текущей директории",
                                            "tree <x> - показать список файлов и папок в виде дерева с x уровнями",
                                            "cd <путь> - перейти в директорию <путь>",
                                            "mkdir <путь> - создать папку",
                                            "cp <откуда> <куда> - копировать файл",
                                            "mv <откуда> <куда> - переместить файл",
                                            "rm <путь> - удалить файл или папку",
                                            "open <путь> - вывести содержимое файла",
                                            "open <путь> -e - выбрать кодировку и вывести содержимое файла",
                                            "write <путь> - создать файл и записать в него текст",
                                            "write <путь> -e - выбрать кодировку и создать файл с текстом",
                                            "cnct <путь1> <путь2>... - конкатинировать и вывести файлы",
                                            "time - показать текущее время",
                                            "author - информация об авторе",
                                            "sign_up - войдите, чтобы получить ещё больше возможностей"};
            DrawWindow(text, "Справка по командам", false);
        }

        //Display list of disks.
        static void GetDisks(out bool error)
        {
            error = false;
            DriveInfo[] drives;
            try
            {
                drives = DriveInfo.GetDrives();
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
            string[] names = new string[drives.Length];
            for (int i = 0; i < drives.Length; ++i)
                names[i] = $"{i + 1}) " + drives[i].VolumeLabel;
            DrawWindow(names, "Диски", false);
        }

        //Display information about disk.
        static void DiskInfo(out bool error)
        {
            error = false;
            try
            {
                string dir = Directory.GetCurrentDirectory();
                DriveInfo drive_info = new DriveInfo(Directory.GetDirectoryRoot(dir));
                string is_ready = drive_info.IsReady ? "Да" : "Нет";
                string total_memory = (drive_info.TotalSize / (1024.0 * 1024)).ToString("F3");
                string memory_left = (drive_info.AvailableFreeSpace / (1024.0 * 1024)).ToString("F3");
                //Text of information about disk.
                string[] text = new string[6] {drive_info.VolumeLabel,
                                            "Тип: " + drive_info.DriveType,
                                            "Файловая система: " + drive_info.DriveFormat,
                                            "Размер: " + total_memory + " Mбайт",
                                            "Памяти свободно: " + memory_left + " Mбайт",
                                            "Готов к использованию: " + is_ready};
                DrawWindow(text, drive_info.Name, false);
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
        }

        //Append string to string array.
        static void Append(ref string[] text, string next_string)
        {
            Array.Resize(ref text, text.Length + 1);
            text[text.Length - 1] = next_string;
        }

        //Add subtree.
        //last_subtree needed for drawing branches of upper levels ot the tree.
        static void AddSubtree(ref string[] text, string[] subtree, bool last_subtree)
        {
            int n = text.Length;
            Array.Resize(ref text, text.Length + subtree.Length);
            for (int i = 0; i < subtree.Length; ++i)
                if (last_subtree)
                    text[i + n] = "   " + subtree[i];
                else
                    text[i + n] = "┃  " + subtree[i];
        }

        //Get dirs and files. Returns 2 arrays of strings - names of dirs and files.
        static void GetDirs(string cur_dir, ref bool is_short, out string[] dirs, out string[] files, out bool error)
        {
            error = false;
            dirs = new string[0];
            files = new string[0];
            try
            {
                dirs = Directory.GetDirectories(cur_dir);
                files = Directory.GetFiles(cur_dir);
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
            //Remove some dirs and files if list should be short.
            if (is_short)
            {
                if (dirs.Length + files.Length + 1 > 16)
                {
                    Array.Resize(ref dirs, Math.Min(7, dirs.Length));
                    Array.Resize(ref files, Math.Min(7, files.Length));
                }
                else
                {
                    //List is already short enough.
                    is_short = false;
                }
            }
        }

        //Get formated text of subtree.
        static string[] GetSubtree(string cur_dir, out bool error, bool is_short = false, int level = 1)
        {
            error = false;
            //Getting directories and files.
            string[] dirs = new string[0];
            string[] files = new string[0];
            GetDirs(cur_dir, ref is_short, out dirs, out files, out error);
            if (error)
                return new string[0];

            string[] text = new string[0];
            //Chars for drawing tree.
            string tree_char = "┣", last_char = "┗";
            //Adding directories to text for displaying in window.
            for (int i = 0; i < dirs.Length; ++i)
            {
                //Separating subdir name from path.
                string[] path_parts = dirs[i].Split(Path.DirectorySeparatorChar);
                //Format line.
                string line = "━ " + path_parts[path_parts.Length - 1];
                //Adding symbols so list looks like tree.
                if (i < dirs.Length - 1 || files.Length > 0 || is_short)
                    line = tree_char + line;
                else
                    line = last_char + line;
                Append(ref text, line);
                if (level > 1)
                    if (i < dirs.Length - 1 || files.Length > 0)
                        AddSubtree(ref text, GetSubtree(dirs[i], out error, is_short, level - 1), false);
                    else
                        AddSubtree(ref text, GetSubtree(dirs[i], out error, is_short, level - 1), true);
            }
            //Adding files to text for displaying in window.
            for (int i = 0; i < files.Length; ++i)
            {
                string[] path_parts = files[i].Split(Path.DirectorySeparatorChar);
                //Format line.
                string line = " " + path_parts[path_parts.Length - 1];
                //Adding symbols so list looks like tree.
                if (i < files.Length - 1 || is_short)
                    line = tree_char + line;
                else
                    line = last_char + line;
                Append(ref text, line);
            }
            //Indicating that there are more directories and files if it's true.
            if (is_short)
                Append(ref text, "...");
            return text;
        }

        //List directories and files in window.
        //If is_short = true, not all files and dirs showed.
        static void ListDir(out bool error, bool is_short = false)
        {
            string[] text = GetSubtree(Directory.GetCurrentDirectory(), out error, is_short);
            DrawWindow(text, "Текущая дириктория", false);
        }

        //Draw a tree with <levels> levels.
        static void Tree(out bool error, int levels)
        {
            string[] text = GetSubtree(Directory.GetCurrentDirectory(), out error, false, levels);
            DrawWindow(text, "Текущая дириктория", false);
        }

        //Change working directory.
        static void ChangeDir(string path, out bool error)
        {
            error = false;
            try
            {
                Directory.SetCurrentDirectory(path);
                ListDir(out error, true);
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
        }

        //Create directory.
        static void CreateDir(string path, out bool error)
        {
            error = false;
            try
            {
                Directory.CreateDirectory(path);
                ListDir(out error, true);
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
        }

        //Copy file.
        static void CopyFile(string from, string to, out bool error)
        {
            error = false;
            try
            {
                if (!File.Exists(from))
                {
                    Error("Такого файла не существует");
                }
                else if (File.Exists(to))
                {
                    Error("Такой файл уже существует");
                }
                else
                {
                    File.Copy(from, to);
                    ListDir(out error, true);
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
        }

        //Move file.
        static void MoveFile(string from, string to, out bool error)
        {
            error = false;
            try
            {
                if (!File.Exists(from))
                {
                    Error("Такого файла не существует");
                }
                else if (File.Exists(to))
                {
                    Error("Такой файл уже существует");
                }
                else
                {
                    File.Move(from, to);
                    ListDir(out error, true);
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
        }

        //Delete file or directory.
        static void DeleteFile(string path, out bool error)
        {
            error = false;
            try
            {
                if (!File.Exists(path) && !Directory.Exists(path))
                {
                    Error("Такого файла/папки не существует");
                }
                else if (File.Exists(path))
                {
                    File.Delete(path);
                    ListDir(out error, true);
                }
                else
                {
                    Directory.Delete(path);
                    ListDir(out error, true);
                }
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
        }

        //Display wrong command error.
        static void WrongInput()
        {
            color = ConsoleColor.Red;
            string[] text = new string[2] { "Введите корректную команду",
                "Введите help, чтобы узнать, какие команды можно использовать" };
            DrawWindow(text, " Команда не распознана");
        }

        //Displays error.
        static void Error(string error_msg = "Произошла ошибка")
        {
            color = ConsoleColor.Red;
            if (error_message.Length + 5 > Console.WindowWidth)
                error_message = error_message.Substring(0, Console.WindowWidth - 7) + "...";
            string[] text = new string[2] { error_msg, error_message };
            DrawWindow(text, "Ошибка");
        }

        //Display current date and time.
        static void Time()
        {
            string[] text = new string[2] { DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                                            DateTime.Now.ToString("HH:mm:ss")};
            DrawWindow(text, "Текущее время");
        }

        static void Author()
        {
            color = ConsoleColor.Red;
            for (int i = 15; i >= 0; --i)
            {
                Console.Clear();
                DrawWindow(new string[3] { "Разанонимизация запрещена", "правилами", $"вы будете ОТЧИСЛЕНЫ через: {i}" }, "!!!!!!!!!");
                System.Threading.Thread.Sleep(1000);
            }
            Console.Clear();
            DrawWindow(new string[2] { "Ошибка доступа к LMS.", "Отчисление отменено." }, "!!!!!!!!!");
        }

        static void SignUp()
        {
            DrawWindow(new string[1] { "Введите ФИО" }, "Регистрация");
            Console.ReadLine();
            Author();
        }

        //Main method. Reading commands and executing them.
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;
            DrawWindow(new string[2] { "Добро пожаловать.",
                                        "Введите help для справки." },
                                        "File manager for terminal");
            while (!exit)
            {
                bool error = false;
                error_message = "";
                //Read user's command.
                //Input.
                string raw_str = Console.ReadLine();
                //Arguments of the command (including it's name).
                string[] command_args = raw_str.Split();
                string command = command_args[0];
                //Arguments without command name in one string.
                string args2 = "";
                if (raw_str.Length > command.Length + 1)
                    args2 = raw_str.Substring(command.Length + 1);
                Console.Clear();
                color = ConsoleColor.Yellow;
                switch (command)
                {
                    case "help":
                        Help();
                        break;
                    case "exit":
                        exit = true;
                        break;
                    case "disks":
                        GetDisks(out error);
                        break;
                    case "disk_info":
                        DiskInfo(out error);
                        break;
                    case "ls":
                        ListDir(out error);
                        break;
                    case "time":
                        Time();
                        break;
                    case "author":
                        Author();
                        break;
                    case "sign_up":
                        SignUp();
                        break;
                    case "cd":
                        if (command_args.Length >= 2)
                        {
                            ChangeDir(args2, out error);
                            break;
                        } else
                        {
                            goto default;
                        }
                    case "mkdir":
                        if (command_args.Length >= 2)
                        {
                            CreateDir(args2, out error);
                            break;
                        }
                        else
                        {
                            goto default;
                        }
                    case "cp":
                        if (command_args.Length >= 3)
                        {
                            CopyFile(command_args[1], command_args[2], out error);
                            break;
                        }
                        else
                        {
                            goto default;
                        }
                    case "mv":
                        if (command_args.Length >= 3)
                        {
                            MoveFile(command_args[1], command_args[2], out error);
                            break;
                        }
                        else
                        {
                            goto default;
                        }
                    case "rm":
                        if (command_args.Length >= 2)
                        {
                            DeleteFile(args2, out error);
                            break;
                        }
                        else
                        {
                            goto default;
                        }
                    case "open":
                        if (command_args.Length >= 3 && command_args[2] == "-e")
                        {
                            OpenFile(command_args[1], out error, true);
                            break;
                        }
                        else
                        {
                            OpenFile(args2, out error);
                            break;
                        }
                    case "write":
                        if (command_args.Length >= 3 && command_args[2] == "-e")
                        {
                            CreateFile(command_args[1], out error, true);
                            break;
                        }
                        else
                        {
                            CreateFile(args2, out error);
                            break;
                        }
                    case "cnct":
                        if (command_args.Length >= 2)
                        {
                            Concatenate(command_args, out error);
                            break;
                        }
                        else
                        {
                            goto default;
                        }
                    case "tree":
                        int levels = 0;
                        if (command_args.Length >= 2 && int.TryParse(command_args[1], out levels))
                        {
                            Tree(out error, levels);
                            break;
                        } else
                        {
                            goto default;
                        }
                    default:
                        WrongInput();
                        break;
                }
                //If error occured in one of the methods.
                if (error)
                {
                    Console.Clear();
                    Error();
                }
            }
            DrawWindow(new string[6] { "", "", "", "",
                    "До свидания!",
                    DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") }, "Выход" );
        }
    }
}
