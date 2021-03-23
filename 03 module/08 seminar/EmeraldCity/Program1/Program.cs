using System;
using System.IO;
using StreetLib;

namespace Program1
{
    class Program
    {
        static Random rnd = new Random();

        static bool ReadStreets(int N, out Street[] streetsArray)
        {
            streetsArray = new Street[N];
            string[] lines = File.ReadAllLines("data.txt");
            int cnt = 0;
            for (int i = 0; i < Math.Min(N, lines.Length); ++i)
            {
                if (lines[i] == "")
                    break;
                string[] args = lines[i].Split();
                if (args.Length < 1)
                    return false;
                streetsArray[cnt++] = new Street(args[0]);
                int[] numbers = new int[args.Length - 1];
                for (int j = 1; j < args.Length; ++j)
                    if (!int.TryParse(args[j], out numbers[j - 1]))
                        return false;
                streetsArray[cnt - 1].Houses = numbers;
            }
            if (cnt < N)
                Array.Resize(ref streetsArray, cnt);
            return true;
        }

        static void GenStreets(int N, out Street[] streetsArray)
        {
            streetsArray = new Street[N];
            for (int i = 0; i < N; ++i)
            {
                int n = rnd.Next(1, 11);
                int nameLength = rnd.Next(4, 7);
                string name = "";
                for (int j = 0; j < nameLength; ++j)
                    name += (char)(rnd.Next('a', 'z' + 1));
                streetsArray[i] = new Street(name);
                int[] numbers = new int[n];
                for (int j = 0; j < n; ++j)
                    numbers[j] = rnd.Next(1, 101);
                streetsArray[i].Houses = numbers;
            }
        }

        static void StoreStreets(Street[] streetsArray)
        {
            using (StreamWriter sw = new StreamWriter(File.OpenWrite("out.txt")))
            {
                for (int i = 0; i < streetsArray.Length; ++i)
                {
                    Console.WriteLine(streetsArray[i]);
                    sw.WriteLine(streetsArray[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.Write("N: ");
            } while (!int.TryParse(Console.ReadLine(), out N) || N <= 0);
            Street[] streetsArray;
            if (!ReadStreets(N, out streetsArray))
                GenStreets(N, out streetsArray);
            StoreStreets(streetsArray);
        }
    }
}
