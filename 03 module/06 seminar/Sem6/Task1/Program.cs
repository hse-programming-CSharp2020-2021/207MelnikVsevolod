using System;

namespace Task1
{
    struct Coords
    {
        private double x, y;

        public Coords(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }

    class Circle
    {
        Coords center;
        double radius;

        Coords Center
        {
            get
            {
                return center;
            }

            set
            {
                center = value;
            }
        }

        double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentException("Radius can't be negative.");
                radius = value;
            }
        }

        public Circle(double x, double y, double r)
        {
            center = new Coords(x, y);
            Radius = r;
        }

        public override string ToString()
        {
            return $"Center: {center}, radius: {radius}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(4, 5, 7);
            Console.WriteLine(circle);
        }
    }
}
