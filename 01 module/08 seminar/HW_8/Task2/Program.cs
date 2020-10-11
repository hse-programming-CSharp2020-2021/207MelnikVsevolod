using System;
using System.IO;

namespace Task2
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

        static void WriteArray(string path, int[] arr)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < arr.Length; ++i)
                sw.Write($"{arr[i]} ");
        }

        static int GetLog(int n)
        {
            int l = 1;
            while (l * 2 < n)
                l = l * 2;
            return l;
        }

        static void Main(string[] args)
        {
            int[] a = ReadArray("input.txt");
            int[] l = new bool[a.Length];
            for (int i = 0; i < l.Length; ++i)
                l[i] = GetLog(a[i]);
            WriteArray("output.txt", l);
        }
    }
}
