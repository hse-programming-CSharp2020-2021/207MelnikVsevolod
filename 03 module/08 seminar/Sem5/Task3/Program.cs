﻿using System;
using System.IO;

namespace Task3
{
    class Program
    {
        public static int Main(string[] args)
        {
            // Attempt to open output file.
            using (var writer = new StreamWriter("File"))
            {
                Console.SetOut(writer);
                Random rnd = new Random();
                for (int i = 0; i < 100; ++i)
                    Console.WriteLine(rnd.NextDouble() * 900 + 100);
            }
            StreamWriter w = new StreamWriter(Console.OpenStandardOutput());
            Console.SetOut(w);
            using (var reader = new StreamReader("File"))
            {
                Console.SetIn(reader);
                double[] numbers = new double[100];
                for (int i = 0; i < 100; ++i)
                {
                    string line = Console.ReadLine();
                    numbers[i] = double.Parse(line);
                }
                double sum = 0;
                for (int i = 0; i < 100; ++i)
                    sum += numbers[i];
                Console.WriteLine(sum / 100);
            }

            StreamReader s = new StreamReader(Console.OpenStandardInput());
            Console.SetIn(s);
            return 0;
        }
    }
}
