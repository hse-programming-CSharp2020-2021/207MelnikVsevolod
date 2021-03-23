using System;
using System.Collections.Generic;
using System.IO;
using StreetLib;

namespace Program2
{
    class Program
    {
        static Street[] ReadStreets()
        {
            List<Street> streets = new List<Street>();
            string[] lines = File.ReadAllLines("../../../../Program1/bin/Debug/netcoreapp3.1/out.txt");
            for (int i = 0; i < lines.Length; ++i)
            {
                if (lines[i] == "")
                    break;
                string[] args = lines[i].Split();
                streets.Add(new Street(args[0]));
                int[] numbers = new int[args.Length - 1];
                for (int j = 1; j < args.Length; ++j)
                    int.TryParse(args[j], out numbers[j - 1]);
                streets[streets.Count - 1].Houses = numbers;
            }
            return streets.ToArray();
        }

        static void Main(string[] args)
        {
            Street[] streetsArray;
            streetsArray = ReadStreets();
            Console.WriteLine("Волшебные улицы:");
            for (int i = 0; i < streetsArray.Length; ++i)
            {
                if (~streetsArray[i] % 2 == 1 && +streetsArray[i])
                    Console.WriteLine(streetsArray[i]);
            }
        }
    }
}
