using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<Project> projects = new List<Project>();
        static int cursor = 0;


        /// <summary>
        /// Display error message.
        /// </summary>
        /// <param name="error"></param>
        static void Error(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }


        /// <summary>
        /// About program window.
        /// </summary>
        static void About()
        {
            NewWindow("О программе", new string[] { "'Q' - назад"});
            Console.WriteLine("тут должно быть о программе");

            Console.ReadKey();
        }


        /// <summary>
        /// Clear console and display header.
        /// </summary>
        /// <param name="name"> Name of the window </param>
        /// /// <param name="hints"> Hints for the user </param>
        static void NewWindow(string name, string[] hints)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"[ {name} ]");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Управление:");
            foreach (string line in hints)
                Console.WriteLine($" {line}");
            Console.WriteLine("");
            Console.ResetColor();
        }


        /// <summary>
        /// Setup console for correct ui drawing.
        /// </summary>
        static void SetupUI()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }


        /// <summary>
        /// Add new user with given by user name to the users list.
        /// </summary>
        static void AddUser()
        {
            Console.Write("dd - Введите имя нового пользователя: ");
            string name = Console.ReadLine();
            if (name != "")
                users.Add(new User(name));
        }


        /// <summary>
        /// Delete user.
        /// </summary>
        static void DeleteUser(int number)
        {
            if (number >= 0 && number < users.Count)
                users.RemoveAt(number);
        }


        /// <summary>
        /// List all users on the screen.
        /// </summary>
        static void ListUsers()
        {
            while (true)
            {
                NewWindow("Пользователи", new string[] { "'D' - удалить пользователя",
                    "'A' - добавить", "'Q' - назад" });
                if (cursor < 0 || cursor >= users.Count)
                    cursor = 0;
                for (int i = 0; i < users.Count; ++i)
                {
                    if (cursor == i)
                        Console.Write("■ ");
                    else
                        Console.Write("  ");
                    Console.WriteLine(users[i].Name);
                }

                // Read user input.
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor >= users.Count)
                        cursor = 0;
                }
                else if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = 0;
                }
                else if (key == ConsoleKey.D)
                    DeleteUser(cursor);
                else if (key == ConsoleKey.A)
                    AddUser();
                else if (key == ConsoleKey.Q)
                    break;
            }
        }


        /// <summary>
        /// Delete project.
        /// </summary>
        static void DeleteProject(int number)
        {
            if (number >= 0 && number < projects.Count)
                projects.RemoveAt(number);
        }


        /// <summary>
        /// Add new project with given by user name to the projects list.
        /// </summary>
        static void AddProject()
        {
            Console.Write("dd - Введите имя нового проекта: ");
            string name = Console.ReadLine();
            if (name != "")
                projects.Add(new Project(name));
        }


        /// <summary>
        /// Rename project.
        /// </summary>
        static void RenameProject(int number)
        {
            if (number >= 0 && number < projects.Count)
            {
                Console.Write("ename - Введите новое имя проекта: ");
                string name = Console.ReadLine();
                if (name != "")
                    projects[number].Name = name;
            }
        }


        /// <summary>
        /// List all projects on the screen.
        /// </summary>
        static void ListProjects()
        {
            while (true)
            {
                NewWindow("Проекты", new string[] { "'D' - удалить проект",
                    "'A' - добавить", "'R' - переименовать",
                    "'ENTER или ПРОБЕЛ' - выбрать проект", "'Q' - назад" });
                if (cursor < 0 || cursor >= projects.Count)
                    cursor = 0;
                for (int i = 0; i < projects.Count; ++i)
                {
                    if (cursor == i)
                        Console.Write("■ ");
                    else
                        Console.Write("  ");
                    Console.WriteLine($"{projects[i].Name} [{projects[i].TasksCount}]");
                }

                // Read user input.
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor >= projects.Count)
                        cursor = 0;
                }
                else if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = 0;
                }
                else if (key == ConsoleKey.D)
                    DeleteProject(cursor);
                else if (key == ConsoleKey.A)
                    AddProject();
                else if (key == ConsoleKey.R)
                    RenameProject(cursor);
                else if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                    ModProject(projects[cursor]);
                else if (key == ConsoleKey.Q)
                    break;
            }
        }


        /// <summary>
        /// Add new task.
        /// </summary>
        /// <param name="project"> Project of this task. </param>
        static void AddTask(Project project)
        {
            Console.WriteLine("Нет");
            Console.ReadKey();
        }


        /// <summary>
        /// Delete task.
        /// </summary>
        /// <param name="project"></param>
        /// <param name="number"></param>
        static void DeleteTask(Project project, int number)
        {
            if (number >= 0 && number < project.TasksCount)
                project.tasks.RemoveAt(number);
        }


        /// <summary>
        /// Display project's tasks and modify it.
        /// </summary>
        /// <param name="project"></param>
        static void ModProject(Project project)
        {
            while (true)
            {
                NewWindow($"Проект \"{project.Name}\"", new string[] { "'A' - добавить задачу", "'D' - удалить задачу", "'Q' - выйти"} );
                if (cursor < 0 || cursor >= project.TasksCount)
                    cursor = 0;
                for (int i = 0; i < project.TasksCount; ++i)
                {
                    if (cursor == i)
                        Console.Write("■ ");
                    else
                        Console.Write("  ");
                    Console.WriteLine($"{project.tasks[i].Name} {project.tasks[i].CreationTime}");
                }

                // Read user input.
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor >= project.TasksCount)
                        cursor = 0;
                }
                else if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = 0;
                }
                else if (key == ConsoleKey.A)
                    AddTask(project);
                else if (key == ConsoleKey.D)
                    DeleteTask(project, cursor);
                else if (key == ConsoleKey.Q)
                    break;
            }
        }


        /// <summary>
        /// Main menu.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetupUI();
            string[] buttons = new string[] { "Пользователи", "Проекты", "О программе" };

            while (true)
            {
                NewWindow("Управление проектами и задачами", new string[] { "'W или ВВЕРХ' - вверх",
                "'S или ВНИЗ' - вниз", "'ENTER или ПРОБЕЛ' - выбрать пункт меню", "'Q' - выйти"});

                if (cursor < 0 || cursor >= buttons.Length)
                    cursor = 0;
                for (int i = 0; i < buttons.Length; ++i)
                {
                    if (cursor == i)
                        Console.Write("■ ");
                    else
                        Console.Write("  ");
                    Console.WriteLine($"{buttons[i]}");
                }

                // Read user input.
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor >= buttons.Length)
                        cursor = 0;
                }
                else if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = 0;
                }
                else if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                {
                    if (cursor == 0)
                        ListUsers();
                    else if (cursor == 1)
                        ListProjects();
                    else
                        About();
                }
                else if (key == ConsoleKey.Q)
                    break;
            }
        }

    }
}
