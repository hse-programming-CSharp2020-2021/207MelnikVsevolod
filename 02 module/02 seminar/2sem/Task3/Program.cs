using System;

namespace Task3
{
    class Program
    {
        class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public Point() : this(0, 0) { }

            public Point(Point p)
            {
                X = p.X;
                Y = p.Y;
            }

            public double Ro
            {
                get
                {
                    return Math.Sqrt(X * X + Y * Y);
                }
            }

            public double Fi
            {
                get
                {
                    return Math.Atan2(Y, X);
                }
            }

            public string PointData
            {
                get
                {
                    string maket = "X = {0:F2}; Y = {1:F2}; Ro = {2:F2}, Fi = {3:F2} ";
                    return string.Format(maket, X, Y, Ro, Fi);
                }
            }
        }

        static void Main(string[] args)
        {
            Point a, b, c;
            a = new Point(3, 4);
            Console.WriteLine(a.PointData);
            b = new Point(0, 3);
            Console.WriteLine(b.PointData);
            c = new Point();
            double x = 0, y = 0;
            do
            {
                Console.Write("x = ");
                double.TryParse(Console.ReadLine(), out x);
                Console.Write("y = ");
                double.TryParse(Console.ReadLine(), out y);
                c.X = x;
                c.Y = y;
            } while (x == 0 && y == 0);
            Point[] points = new Point[3] { a, b, c };
            for (int i = 0; i < 3; ++i)
                for (int j = 1; j < 3; ++j)
                    if (points[j - 1].Ro > points[j].Ro)
                    {
                        Point t = points[j - 1];
                        points[j - 1] = points[j];
                        points[j] = t;
                    }
            for (int i = 0; i < 3; ++i)
                Console.WriteLine(points[i].PointData);
        }
    }
}
