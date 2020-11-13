using System;

namespace Task10
{
    class Circle
    {
        public double X
        {
            get; private set;
        }

        public double Y
        {
            get; private set;
        }

        public double R
        {
            get; private set;
        }

        public bool Intersect(Circle c)
        {
            double dist = Math.Sqrt((X - c.X) * (X - c.X) + (Y - c.Y) * (Y - c.Y));
            return dist < R + c.R;
        }

        public void Info()
        {
            Console.WriteLine($"Центр = ({X}, {Y}), радиус = {R}");
        }

        public Circle()
        {
            X = Y = R = 1;
        }

        public Circle(double x, double y, double r)
        {
            X = x;
            Y = y;
            R = r;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = int.Parse(Console.ReadLine());
            Circle[] circles = new Circle[n];
            for (int i = 0; i < n; ++i)
                circles[i] = new Circle(rnd.Next(1, 16), rnd.Next(1, 16), rnd.Next(1, 16));
            Circle circle = new Circle(rnd.Next(1, 16), rnd.Next(1, 16), rnd.Next(1, 16));
            for (int i = 0; i < n; ++i)
                circles[i].Info();
            Console.Write("Пересекаются с кругом: ");
            circle.Info();
            for (int i = 0; i < n; ++i)
                if (circle.Intersect(circles[i]))
                    circles[i].Info();
        }
    }
}
