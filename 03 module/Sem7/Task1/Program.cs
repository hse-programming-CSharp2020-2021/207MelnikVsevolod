using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
                Console.WriteLine(line);
            Console.WriteLine();
        }

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            for (int i = 0; i < 10; ++i)
                numbers[i] = rnd.Next();

            File.AppendAllLines("file1.txt", Array.ConvertAll<int, string>(numbers, x => x.ToString()));
            ReadFile("file1.txt");

            string snumbers = "";
            foreach (int n in numbers)
                snumbers += n + Environment.NewLine;
            using (FileStream fs = new FileStream("file2.txt", FileMode.OpenOrCreate))
            {
                byte[] bytes = System.Text.Encoding.Default.GetBytes(snumbers);
                fs.Write(bytes);
            }
            ReadFile("file2.txt");

            using (StreamWriter sw = new StreamWriter("file3.txt"))
            {
                byte[] bytes = System.Text.Encoding.Default.GetBytes(snumbers);
                sw.Write(bytes);
            }
            ReadFile("file3.txt");

            using (BinaryWriter bw = new BinaryWriter(File.Open("file4.txt", FileMode.OpenOrCreate)))
            {
                byte[] bytes = System.Text.Encoding.Default.GetBytes(snumbers);
                bw.Write(bytes);
            }
            ReadFile("file4.txt");
        }
    }
}
