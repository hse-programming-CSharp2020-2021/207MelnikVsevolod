using System;
namespace Task2
{
    public class Square : Point
    {
        double side;

        public double Side
        {
            get { return side; }
            set { side = value; }
        }

        public Square(double x, double y, double side)
        {
            this.x = x;
            this.y = y;
            this.side = side;
        }

        override public void Display()
        {
            Console.WriteLine($"X: {x}, Y: {y}, Side: {side}");
        }

        public override double Area
        {
            get
            {
                return side * side;
            }
        }

        public override double Len
        {
            get
            {
                return 4 * side;
            }
        }
    }
}
