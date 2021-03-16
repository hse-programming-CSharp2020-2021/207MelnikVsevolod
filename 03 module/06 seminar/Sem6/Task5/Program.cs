using System;
using System.Collections.Generic;

namespace Task5
{
    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double M { get; set; }

        public Point(double x, double y, double m)
        {
            X = x;
            Y = y;
            M = m;
        }

        public override string ToString()
        {
            return $"M: {M}, X: {X}, Y: {Y}";
        }
    }

    class SetOfPoints
    {
        List<Point> points = new List<Point>();
        double radius;

        public SetOfPoints(double r, List<Point> points)
        {
            this.radius = r;
            foreach (Point p in points)
            {
                if (r == Math.Sqrt(p.X * p.X + p.Y * p.Y))
                    this.points.Add(p);
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (Point p in points)
                str += p + Environment.NewLine;
            str += Environment.NewLine;
            return str;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Point> points = new List<Point>();
            for (int i = 0; i < n; ++i)
            {
                string[] input = Console.ReadLine().Split();
                points.Add(new Point(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2])));
            }
            while (true)
            {
                int r = int.Parse(Console.ReadLine());
                Console.WriteLine(new SetOfPoints(r, points));
            }
        }
    }
}
