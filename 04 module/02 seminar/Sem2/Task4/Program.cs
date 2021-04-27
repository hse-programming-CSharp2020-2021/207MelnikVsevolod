using System;
using System.IO;
using System.Threading;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Task4
{
    [DataContract]
    [Serializable]
    public class ConsoleSymbolStruct
    {
        [DataMember]
        public char symb;
        [DataMember]
        public int x, y;

        public char Symb { get { return symb; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }

        public ConsoleSymbolStruct()
        {
            symb = 'a';
            x = y = 0;
        }

        public ConsoleSymbolStruct(char c, int a, int b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentException("x or y < 0");
            symb = c;
            x = a;
            y = b;
        }
    }

    [DataContract]
    [Serializable]
    public class ColoredConsoleSymbol : ConsoleSymbolStruct
    {
        [DataMember]
        public ConsoleColor color;

        public ColoredConsoleSymbol() : base()
        {
            color = ConsoleColor.White;
        }

        public ColoredConsoleSymbol(char c, int a, int b, ConsoleColor cl) : base(c, a, b)
        {
            color = cl;
        }
    }

    class Program
    {
        static Random rnd = new Random();

        static void PrintChars(ConsoleSymbolStruct[] arr)
        {
            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Yellow };
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] is ColoredConsoleSymbol)
                    Console.ForegroundColor = (arr[i] as ColoredConsoleSymbol).color;
                else
                    Console.ForegroundColor = colors[rnd.Next(0, colors.Length)];
                Console.SetCursorPosition(arr[i].X, arr[i].Y);
                Console.Write(arr[i].Symb);
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Yellow };
            ConsoleSymbolStruct[] arr = new ConsoleSymbolStruct[10];
            for (int i = 0; i < arr.Length; ++i)
                arr[i] = new ColoredConsoleSymbol((char)rnd.Next('a', 'z'), rnd.Next(1, 15), rnd.Next(1, 15), colors[rnd.Next(0, colors.Length)]);

            PrintChars(arr);

            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Binary: ");
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream s = File.OpenWrite("bin"))
            {
                bf.Serialize(s, arr);
            }
            using (Stream s = File.OpenRead("bin"))
            {
                ConsoleSymbolStruct[] arr2 = (ConsoleSymbolStruct[])bf.Deserialize(s);
                PrintChars(arr2);
            }

            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Xml: ");
            XmlSerializer xs = new XmlSerializer(typeof(ConsoleSymbolStruct[]), new Type[] { typeof(ColoredConsoleSymbol) });
            using (Stream s = File.OpenWrite("xml"))
            {
                xs.Serialize(s, arr);
            }
            using (Stream s = File.OpenRead("xml"))
            {
                ConsoleSymbolStruct[] arr3 = (ConsoleSymbolStruct[])xs.Deserialize(s);
                PrintChars(arr3);
            }

            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Json: ");
            File.WriteAllText("json", JsonSerializer.Serialize(arr, typeof(ConsoleSymbolStruct[])));
            using (StreamReader sr = new StreamReader(File.OpenRead("json")))
            {
                ConsoleSymbolStruct[] arr4 = (ConsoleSymbolStruct[])JsonSerializer.Deserialize<ConsoleSymbolStruct[]>(sr.ReadLine());
                PrintChars(arr4);
            }

            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("DataContract: ");
            DataContractSerializer ds = new DataContractSerializer(typeof(ConsoleSymbolStruct[]), new Type[] { typeof(ColoredConsoleSymbol) } );
            using (Stream s = File.OpenWrite("data"))
            {
                ds.WriteObject(s, arr);
            }
            using (Stream s = File.OpenRead("data"))
            {
                ConsoleSymbolStruct[] arr5 = (ConsoleSymbolStruct[])ds.ReadObject(s);
                PrintChars(arr5);
            }

        }
    }
}
