using System;
using System.IO;

namespace Project1
{
    class Program
    {
        static string[] ChangeText(string[] text)
        {
            int n, m;
            n = m = 0;
            string[] text2 = new string[text.Length + 1];
            for (int i = 0; i < text.Length; ++i)
            {
                for (int j = 0; j < text[i].Length; ++j)
                {
                    if (text[i][j] < 'A' || text[i][j] > 'Z')
                        text2[i] = text2[i] + text[i][j];
                    else
                        ++m;
                    if (text[i][j] >= '0' && text[i][j] <= '9')
                    {
                        text2[i] = text2[i] + text[i][j];
                        ++n;
                    }
                }
            }
            text2[text.Length] = $"Было удвоено {n} цифр и удалено {m} заглавных букв";
            return text2;
        }

        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("firstFile.txt");
            File.WriteAllLines("secondFile.txt", ChangeText(text));
        }
    }
}
