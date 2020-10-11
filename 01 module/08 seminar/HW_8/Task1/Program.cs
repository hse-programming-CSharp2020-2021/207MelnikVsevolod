using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static int[] ReadArray(string path)
        {
            StreamReader sr = new StreamReader(path);
            string[] s_numbers = sr.ReadLine().Split();
            int[] numbers = new int[s_numbers.Length];
            for (int i = 0; i < s_numbers.Length; ++i)
                numbers[i] = int.Parse(s_numbers[i]);
            return numbers;
        }

        static void WriteArray(string path, bool[] arr)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < arr.Length; ++i)
                sw.Write($"{arr[i]} ");
        }

        static void Main(string[] args)
        {
            int[] a = ReadArray("input.txt");
            bool[] l = new bool[a.Length];
            for (int i = 0; i < l.Length; ++i)
                if (a[i] > 0)
                    l[i] = true;
            WriteArray("output.txt", l);
        }
    }
}
