using System;

namespace Task4
{
    class Rectangle : IComparable
    {
        public double A { get; set; }
        public double B { get; set; }

        public double S { get { return A * B; } }

        public int CompareTo(object obj)
        {
            if (obj is Rectangle)
            {
                Rectangle r = obj as Rectangle;
                return S.CompareTo(r.S);

            }
            return 0;
        }

        public override string ToString()
        {
            return $"[{A:F3}, {B:F3}]";
        }
    }

    class Block3D : Rectangle, IComparable
    {
        public double C { get; set; }

        public Block3D()
        {
            A = B = C = 0;
        }

        public Block3D(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override string ToString()
        {
            return $"[{A:F3}, {B:F3}, {C:F3}]";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Block3D[] blocks = new Block3D[10];
            for (int i = 0; i < 10; ++i)
            {
                blocks[i] = new Block3D(rnd.NextDouble() * 10, rnd.NextDouble() * 10, rnd.NextDouble() * 10);
            }
            for (int i = 0; i < 10; ++i)
                Console.WriteLine(blocks[i].ToString());
            Console.WriteLine();
            Console.WriteLine("Sorted array:");
            Array.Sort(blocks);
            for (int i = 0; i < 10; ++i)
                Console.WriteLine(blocks[i].ToString());
        }
    }
}
