using System;

namespace Task6
{
    class Program
    {
        static int[] ReadArray()
        {
            string[] s_numbers = Console.ReadLine().Split(';');
            int[] numbers = new int[s_numbers.Length];
            for (int i = 0; i < s_numbers.Length; ++i)
                numbers[i] = int.Parse(s_numbers[i]);
            return numbers;
        }

        static void WriteArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
                Console.Write($"{arr[i]} ");
            Console.WriteLine("");
        }

        static double Average(int[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; ++i)
                sum += arr[i];
            return sum / arr.Length;
        }

        static void Main(string[] args)
        {
            int[] arr = ReadArray();
            WriteArray(arr);
            Console.WriteLine(Average(arr));
        }
    }
}
