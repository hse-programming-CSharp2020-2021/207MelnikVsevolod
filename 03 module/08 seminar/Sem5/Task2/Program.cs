using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < 10; ++i)
                numbers[i] = rnd.Next(1, 101);
            // Write.
            FileStream s = File.Create("Numbers");
            using (BinaryWriter bw = new BinaryWriter(s))
            {
                for (int i = 0; i < 10; ++i)
                    bw.Write(numbers[i]);
            }
            // Read.
            s = File.Open("Numbers", FileMode.Open);
            using (BinaryReader br = new BinaryReader(s))
            {
                for (int i = 0; i < 10; ++i)
                    numbers[i] = br.ReadInt32();
            }
            for (int i = 0; i < 10; ++i)
                Console.Write($"{numbers[i]} ");
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            int j = 0;
            for (int i = 0; i < 10; ++i)
                if (Math.Abs(n - numbers[i]) < Math.Abs(n - numbers[j]))
                    j = i;
            numbers[j] = n;
            for (int i = 0; i < 10; ++i)
                Console.Write($"{numbers[i]} ");
            s = File.Create("Numbers");
            using (BinaryWriter bw = new BinaryWriter(s))
            {
                for (int i = 0; i < 10; ++i)
                    bw.Write(numbers[i]);
            }
        }
    }
}
