using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("../../../Program.cs", FileMode.Open))
            {
                int number = 0;
                int pos = 0;
                while ((number = fs.ReadByte()) != -1)
                {
                    if (number >= '0' && number <= '9')
                        Console.WriteLine($"{pos}: {(char)number}");
                    pos++;
                }
            }
        }
    }
}
