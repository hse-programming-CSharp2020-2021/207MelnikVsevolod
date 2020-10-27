using System;

namespace Task3
{
    class Program
    {
        static void WriteArray(char[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write($"{a[i]} ");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            char[][][] a = new char[3][][];
            a[0] = new char[3][];
            a[0][0] = new char[2] { 'a', 'b' };
            a[0][1] = new char[3] { 'c', 'd', 'e' };
            a[0][2] = new char[4] { 'f', 'g', 'h', 'i' };

            a[1] = new char[2][];
            a[1][0] = new char[2] { 'j', 'k' };
            a[1][1] = new char[3] { 'l', 'm', 'n' };

            a[2] = new char[1][];
            a[2][0] = new char[4] { 'o', 'p', 'q', 'r' };

            for (int i = 0; i < a.Length; ++i)
                for (int j = 0; j < a[i].Length; ++j)
                    WriteArray(a[i][j]);
        }
    }
}
