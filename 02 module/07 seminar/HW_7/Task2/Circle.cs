using System;
namespace Task2
{
    public class Circle : Point
    {
        double rad;

        public double Rad
        {
            get { return rad; }
            set { rad = value; }
        }

        public Circle(double x, double y, double r)
        {
            this.x = x;
            this.y = y;
            this.rad = r;
        }

        override public void Display()
        {
            Console.WriteLine($"X: {x}, Y: {y}, R: {rad}");
        }

        public override double Area
        {
            get
            {
                return Math.PI * rad * rad;
            }
        }

        public override double Len
        {
            get
            {
                return 2 * Math.PI * rad;
            }
        }
    }
}
