using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

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
            Console.ReadLine();
        }


        /// <summary>
        /// About program window.
        /// </summary>
        static void About()
        {
            NewWindow("О программе", new string[] { "'Q' - назад"});
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("Реализован весь функционал (включая дополнительный)");
            Console.WriteLine("Список исполнителей не отображается в списке задач" +
                " чтобы не загромождать интерфейс, вместо этого он в окне задачи");

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
        /// Let user choose one of the options.
        /// </summary>
        /// <param name="options"> Options to choose. </param>
        /// <returns> Number of the chosen option. </returns>
        static int ChooseWindow(string caption, string[] options)
        {
            while (true)
            {
                NewWindow(caption, new string[] { "'ENTER/ПРОБЕЛ' - выбрать" });
                if (cursor < 0 || cursor >= options.Length)
                    cursor = 0;
                for (int i = 0; i < options.Length; ++i)
                {
                    if (cursor == i)
                        Console.Write("■ ");
                    else
                        Console.Write("  ");
                    Console.WriteLine(options[i]);
                }

                // Read user input.
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor >= options.Length)
                        cursor = 0;
                }
                else if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = 0;
                }
                else if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                    return cursor;
            }
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
                SaveUsers();
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
                else if ((key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                    && cursor < projects.Count)
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
            Console.Write("dd - Введите имя новой задачи: ");
            string name = Console.ReadLine();
            if (name == "")
                return;
            int option = ChooseWindow("Выберите тип задачи", new string[]
                { "Epic", "Story", "Task", "Bug" });
            Task newTask;
            if (option == 0)
                newTask = new Epic(name, DateTime.Now);
            else if (option == 1)
                newTask = new Story(name, DateTime.Now);
            else if (option == 2)
                newTask = new Task(name, DateTime.Now);
            else
                newTask = new Bug(name, DateTime.Now);
            project.tasks.Add(newTask);
            project.tasks = project.tasks.OrderBy((Task t) => t.ToString()).ToList();
        }


        /// <summary>
        /// Add new subtask.
        /// </summary>
        /// <param name="task"></param>
        static void AddSubtask(Epic task)
        {
            Console.Write("dd - Введите имя новой задачи: ");
            string name = Console.ReadLine();
            if (name == "")
                return;
            int option = ChooseWindow("Выберите тип задачи", new string[]
                { "Story", "Task", "Bug" });
            Task newTask;
            if (option == 0)
                newTask = new Story(name, DateTime.Now);
            else if (option == 1)
                newTask = new Task(name, DateTime.Now);
            else
                newTask = new Bug(name, DateTime.Now);
            task.subTasks.Add(newTask);
            task.subTasks = task.subTasks.OrderBy((Task t) => t.ToString()).ToList();
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
        /// Delete subtask.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="number"></param>
        static void DeleteSubtask(Epic task, int number)
        {
            if (number >= 0 && number < task.subTasks.Count)
                task.subTasks.RemoveAt(number);
        }


        /// <summary>
        /// Display project's tasks and modify it.
        /// </summary>
        /// <param name="project"></param>
        static void ModProject(Project project)
        {
            while (true)
            {
                NewWindow($"Проект \"{project.Name}\"", new string[] {
                    "'A' - добавить задачу", "'D' - удалить задачу",
                    "'Q' - выйти", "'ENTER или ПРОБЕЛ' - выбрать"} );
                if (cursor < 0 || cursor >= project.TasksCount)
                    cursor = 0;
                for (int i = 0; i < project.TasksCount; ++i)
                {
                    if (cursor == i)
                        Console.Write("■ ");
                    else
                        Console.Write("  ");
                    Console.WriteLine(project.tasks[i]);
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
                else if ((key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                    && cursor < project.tasks.Count)
                {
                    if (project.tasks[cursor] is Epic)
                        ModEpic(project.tasks[cursor] as Epic);
                    else
                        ModTask(project.tasks[cursor]);
                }
                else if (key == ConsoleKey.Q)
                    break;
            }
        }


        /// <summary>
        /// Ask user what user to assing.
        /// </summary>
        /// <param name="task"> Task. </param>
        static void AssignUser(Task task)
        {
            string[] names = new string[users.Count];
            for (int i = 0; i < users.Count; ++i)
                names[i] = users[i].Name;
            int number = ChooseWindow("Выберите исполнителя", names);
            if (number < users.Count)
                (task as IAssignable).Assign(users[number]);
        }


        /// <summary>
        /// Delete user from task.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="number"></param>
        static void UnassignUser(Task task, int number)
        {
            if (number < 0 || number >= (task as IAssignable).Users.Count)
                return;
            (task as IAssignable).Remove((task as IAssignable).Users[number]);
        }


        /// <summary>
        /// Change status of the task.
        /// </summary>
        /// <param name="task"> Task. </param>
        static void ChangeStatus(Task task)
        {
            int number = ChooseWindow("Выберите статус", new string[] { "Закрыта", "В работе", "Открыта"} );
            if (number == 0)
                task.Status = Task.StatusType.Closed;
            else if (number == 1)
                task.Status = Task.StatusType.InProgress;
            else
                task.Status = Task.StatusType.Opened;
        }


        /// <summary>
        /// Display task's info and modify it.
        /// </summary>
        /// <param name="task"></param>
        static void ModTask(Task task)
        {
            while (true)
            {
                NewWindow($"Задача \"{task.Name}\"", new string[] {
                    "'A' - добавить исполнителя",
                    "'D' - удалить исполнителя",
                    "'E' - изменить статус", "'Q' - выйти" });
                Console.WriteLine(task);
                Console.WriteLine("Исполнители:");
                List<User> taskUsers = (task as IAssignable).Users;
                if (cursor < 0 || cursor >= taskUsers.Count)
                    cursor = 0;
                for (int i = 0; i < taskUsers.Count; ++i)
                {
                    if (cursor == i)
                        Console.Write("■ ");
                    else
                        Console.Write("  ");
                    Console.WriteLine(taskUsers[i].Name);
                }

                // Read user input.
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor >= taskUsers.Count)
                        cursor = 0;
                }
                else if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = 0;
                }
                else if (key == ConsoleKey.A)
                    AssignUser(task);
                else if (key == ConsoleKey.D)
                    UnassignUser(task, cursor);
                else if (key == ConsoleKey.E)
                    ChangeStatus(task);
                else if (key == ConsoleKey.Q)
                    break;
            }
        }


        /// <summary>
        /// Mod epic task.
        /// </summary>
        /// <param name="project"></param>
        static void ModEpic(Epic task)
        {
            while (true)
            {
                NewWindow($"Задача \"{task.Name}\"", new string[] {
                    "'A' - добавить подзадачу", "'D' - удалить подзадачу",
                    "'Q' - выйти", "'ENTER или ПРОБЕЛ' - выбрать"});
                if (cursor < 0 || cursor >= task.subTasks.Count)
                    cursor = 0;
                for (int i = 0; i < task.subTasks.Count; ++i)
                {
                    if (cursor == i)
                        Console.Write("■ ");
                    else
                        Console.Write("  ");
                    Console.WriteLine(task.subTasks[i]);
                }

                // Read user input.
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor >= task.subTasks.Count)
                        cursor = 0;
                }
                else if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = 0;
                }
                else if (key == ConsoleKey.A)
                    AddSubtask(task);
                else if (key == ConsoleKey.D)
                    DeleteSubtask(task, cursor);
                else if ((key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                    && cursor < task.subTasks.Count)
                    ModTask(task.subTasks[cursor]);
                else if (key == ConsoleKey.Q)
                    break;
            }
        }


        /// <summary>
        /// Save users to file.
        /// </summary>
        static void SaveUsers()
        {
            try
            {
                string[] usersNames = new string[users.Count];
                for (int i = 0; i < users.Count; ++i)
                    usersNames[i] = users[i].Name;
                File.WriteAllLines("users.pr", usersNames);
            }
            catch (Exception)
            {
                Error("Ошибка сохранения");
            }
        }


        /// <summary>
        /// Load users from file.
        /// </summary>
        static void LoadUsers()
        {
            try
            {
                string[] usersNames = File.ReadAllLines("users.pr");
                users = new List<User>();
                for (int i = 0; i < usersNames.Length; ++i)
                    users.Add(new User(usersNames[i]));
            }
            catch (Exception)
            {
                // Do nothin.
            }
        }


        /// <summary>
        /// Save all projects to file.
        /// </summary>
        static void SaveProjects()
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Project));
                string[] files = Directory.GetFiles("SavedProjects");
                foreach (string file in files)
                    File.Delete(file);
                for (int i = 0; i < projects.Count; ++i)
                {
                    Project project = projects[i];
                    using (FileStream fs = new FileStream($"SavedProjects{Path.DirectorySeparatorChar}project{i}.xml", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, project);
                    }
                }
            }
            catch (Exception e)
            {
                Error("Ошибка сохранения проектов. " + e.Message);
            }
        }


        /// <summary>
        /// Load all projects from file.
        /// </summary>
        static void LoadProjects()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Project));
            string[] files = Directory.GetFiles("SavedProjects");
            projects = new List<Project>();
            foreach (string file in files)
            {
                try
                {
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        Project newProject = (Project)formatter.Deserialize(fs);

                        projects.Add(newProject);
                    }
                }
                catch (Exception e)
                {
                    Error(e.Message);
                }
            }
        }


        /// <summary>
        /// Prepare for exiting the application.
        /// </summary>
        static void PrepareForExit(object sender, EventArgs e)
        {
            SaveProjects();
            SaveUsers();
            Console.WriteLine("До свидания!");
        }


        /// <summary>
        /// Main menu.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetupUI();
            AppDomain.CurrentDomain.ProcessExit += PrepareForExit;
            LoadUsers();
            LoadProjects();
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
