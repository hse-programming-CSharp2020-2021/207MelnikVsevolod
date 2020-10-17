using System;
using System.IO;


//Work with text in files.
namespace FileManager
{
    partial class Program
    {
        //Ask user to choose encoding.
        static System.Text.Encoding ChooseEncoding()
        {
            bool user_cant_choose = true;
            System.Text.Encoding enc = System.Text.Encoding.UTF8;
            while (user_cant_choose)
            {
                DrawWindow(new string[4] { "Выберите кодировку:", "UTF8", "Unicode", "ASCII" }, "Кодировка");
                string users_enc = Console.ReadLine();
                user_cant_choose = false;
                if (users_enc == "UTF8")
                    enc = System.Text.Encoding.UTF8;
                else if (users_enc == "Unicode")
                    enc = System.Text.Encoding.Unicode;
                else if (users_enc == "ASCII")
                    enc = System.Text.Encoding.ASCII;
                else
                    user_cant_choose = true;
            }
            return enc;
        }

        //Open file. If choose_enc = true, then ask user what encoding to choose.
        static void OpenFile(string path, out bool error, bool choose_enc = false, System.Text.Encoding enc = null)
        {
            error = false;
            if (enc == null)
                enc = System.Text.Encoding.UTF8;
            if (choose_enc)
                enc = ChooseEncoding();
            try
            {
                Console.Clear();
                string[] text = File.ReadAllLines(path, enc);
                int max_width = 0;
                //Count max length of the line for correct drawing.
                for (int i = 0; i < text.Length; ++i)
                    if (text[i].Length > max_width)
                        max_width = text[i].Length;
                color = ConsoleColor.Green;
                DrawWindow(text, path, false, max_width + 4);
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
        }

        //Write file. If choose_enc = true, then ask user what encoding to choose.
        static void CreateFile(string path, out bool error, bool choose_enc = false)
        {
            error = false;
            if (File.Exists(path))
            {
                Error("Файл уже существует");
                return;
            }
            System.Text.Encoding enc = System.Text.Encoding.UTF8;
            if (choose_enc)
            {
                enc = ChooseEncoding();
                Console.InputEncoding = enc;
            }
            try
            {
                File.WriteAllText(path, "");
                Console.Clear();
                color = ConsoleColor.Magenta;
                //Terminal size for drawing frame.
                int width = Math.Max(50, Console.WindowWidth);
                DrawLine(width, true, $" [ {path} ] ");
                DrawLine(width, false, $" [ Наберите :q чтобы сохранить и выйти ] ");
                //User's text.
                string[] text = new string[0];
                string line = "";
                do
                {
                    //Draw frame.
                    DrawChar('┃');
                    DrawChar(' ');
                    line = Console.ReadLine();
                    if (line != ":q")
                    {
                        //Add to text.
                        Array.Resize(ref text, text.Length + 1);
                        text[text.Length - 1] = line;
                    }
                } while (line != ":q");
                File.WriteAllLines(path, text, enc);
                OpenFile(path, out error, false, enc);
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
        }

        static void Concatenate(string[] args, out bool error)
        {
            error = false;
            try
            {
                Console.Clear();
                int max_width = 0;
                string[] all_text = new string[0];
                //Iterator for all_text.
                int j = 0;
                for (int k = 2; k < args.Length; ++k)
                {
                    //Text from one file.
                    string[] text = File.ReadAllLines(args[k]);
                    Array.Resize(ref all_text, all_text.Length + text.Length);
                    //Count max length of the line for correct drawing.
                    for (int i = 0; i < text.Length; ++i)
                    {
                        all_text[j++] = text[i];
                        if (text[i].Length > max_width)
                            max_width = text[i].Length;
                    }
                }
                //Write concatenated text in file.
                File.WriteAllLines(args[1], all_text);
                //Show result.
                OpenFile(args[1], out error);
            }
            catch (Exception ex)
            {
                error_message = ex.Message;
                error = true;
                return;
            }
        }
    }
}