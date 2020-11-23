using System;
namespace Task2
{
    public class Point
    {
        protected double x, y;

        virtual public void Display()
        {
            Console.WriteLine($"X: {x}, Y: {y}");
        }

        virtual public double Area
        {
            get
            {
                return 0;
            }
        }

        virtual public double Len
        {
            get
            {
                return 0;
            }
        }
    }
}
