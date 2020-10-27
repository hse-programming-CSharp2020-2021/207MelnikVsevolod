using System;

namespace Task3
{
    class Polygon
    {
        int edges;
        double radius;

        public Polygon(int e = 3, double r = 1)
        {
            edges = e;
            radius = r;
        }

        public double Perimeter
        {
            get
            {
                return 2 * edges * radius * Math.Tan(Math.PI / edges);
            }
        }

        public double Area
        {
            get
            {
                return Perimeter * radius / 2;
            }
        }

        public string PolygonData()
        {
            return string.Format("Правильный {0}-угольник радиуса {1}, периметр = {2:F3}, площадь = {3:F3}", edges, radius, Perimeter, Area);
        }
    }

    class Program
    {
        static void ListPolygons(Polygon[] p)
        {
            int min = 0, max = 0;
            for (int i = 0; i < p.Length; ++i)
            {
                if (p[i].Area > p[max].Area)
                    max = i;
                if (p[i].Area < p[min].Area)
                    min = i;
            }
            for (int i = 0; i < p.Length; ++i)
            {
                if (i == min)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (i == max)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(p[i].PolygonData());
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {
            int n = 3;
            double r = 1;

            Polygon[] p = new Polygon[0];
            while (n != 0 || r != 0)
            {
                if (!int.TryParse(Console.ReadLine(), out n) || !double.TryParse(Console.ReadLine(), out r))
                {
                    Console.WriteLine("Incorrect input");
                    break;
                }
                if (n == 0 && r == 0)
                    break;
                Polygon p1 = new Polygon(n, r);
                Array.Resize(ref p, p.Length + 1);
                p[p.Length - 1] = p1;
                ListPolygons(p);
            }
        }
    }
}
