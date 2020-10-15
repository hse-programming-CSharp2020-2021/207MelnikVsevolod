using System;
using System.IO;


//Interface of the app.
namespace FileManager
{
    partial class Program
    {

        static ConsoleColor color = ConsoleColor.White;

        //Draws char, in different color if colored=true.
        static void DrawChar(char c, bool colored = true)
        {
            if (colored)
                Console.ForegroundColor = color;
            Console.Write(c);
            Console.ResetColor();
        }

        //Draws line with text in center
        static void DrawLine(int width, bool is_upper, string text = "")
        {
            char ch1 = '┣', ch2 = '┛';
            if (is_upper)
            {
                ch1 = '┏';
                ch2 = '┓';
            }
            DrawChar(ch1);
            for (int i = 1; i < width / 2 - text.Length / 2; ++i)
                DrawChar('━');
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            for (int i = width / 2 - text.Length / 2 + text.Length; i < width - 1; ++i)
                DrawChar('━');
            DrawChar(ch2);
            Console.WriteLine("");
        }

        //Writes line in window
        static void WriteLine(int width, string text, bool center)
        {
            DrawChar('┃');
            if (center)
            {
                for (int i = 1; i < width / 2 - text.Length / 2; ++i)
                    Console.Write(' ');
                Console.Write(text);
                for (int i = width / 2 - text.Length / 2 + text.Length; i < width - 1; ++i)
                    Console.Write(' ');
            }
            else
            {
                Console.Write(" " + text);
                for (int i = text.Length + 2; i < width - 1; ++i)
                    Console.Write(' ');
            }
            DrawChar('┃');
            Console.WriteLine("");
        }

        //This method draws window with given text in terminal.
        static void DrawWindow(string[] text, string window_name, bool center = true, int min_width = 50)
        {
            //Terminal sizes for drawing frame.
            int width = Math.Max(min_width, Console.WindowWidth - 1);
            int height = Math.Max(text.Length + 4, Math.Max(20, Console.WindowHeight - 1));
            DrawLine(width, true, $" [ {window_name} ] ");
            WriteLine(width, "", center);
            //WriteText
            for (int i = 0; i < text.Length; ++i)
                WriteLine(width, text[i], center);
            //WriteBlankLines;
            for (int i = text.Length + 2; i < height - 2; ++i)
                WriteLine(width, "", center);
            //Get current dirictory and display it.
            string dir = "???";
            try
            {
                dir = Directory.GetCurrentDirectory();
                //Path is too long for that window size.
                if (dir.Length > width - 25)
                    dir = "..." + dir.Substring(dir.Length - width + 28);
            }
            catch
            {
                dir = "???";
            }
            DrawLine(width, false, $" [ {dir} ] ");
            //Command line.
            DrawChar('╿');
            Console.Write(" $ ");
        }

    }
}