using System;

namespace Task8
{
    class Point
    {
        public double X
        {
            get; set;
        }

        public double Y
        {
            get; set;
        }

        public double Dist(Point b)
        {
            return Math.Sqrt((X - b.X) * (X - b.X) + (Y - b.Y) * (Y - b.Y));
        }

        public Point()
        {
            X = Y = 0;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    class Triangle
    {
        Point A
        {
            get; set;
        }

        Point B
        {
            get; set;
        }

        Point C
        {
            get; set;
        }

        public Triangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();
        }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Triangle(double ax, double ay, double bx, double by, double cx, double cy)
        {
            A = new Point(ax, ay);
            B = new Point(bx, by);
            C = new Point(cx, cy);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Triangle[] tr = new Triangle(n);
            Random rnd = new Random();
            for (int i = 0; i < n; ++i)
            {
                tr[i] = new Triangle(rnd.Next(-10, 10), rnd.Next(-10, 10), rnd.Next(-10, 10), rnd.Next(-10, 10), rnd.Next(-10, 10), rnd.Next(-10, 10));
            }
            
        }
    }
}
