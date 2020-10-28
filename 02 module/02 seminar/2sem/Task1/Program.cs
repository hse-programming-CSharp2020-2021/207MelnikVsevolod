using System;

namespace Task1
{

    class Circle
    {
        private double _r;

        public double R
        {
            get
            {
                return _r;
            }
            set
            {
                if (_r <= 0)
                    throw new ArgumentException("Negative value");
                _r = value;
            }
        }

        public double S
        {
            get
            {
                return Math.PI * _r * _r;
            }
        }

        public double L
        {
            get
            {
                return Math.PI * 2 * _r;
            }
        }

        public Circle()
        {
            _r = 1;
        }

        public Circle(double radius)
        {
            _r = radius;
        }

        public override string ToString()
        {
            return $"Circle: radius = {_r}, square = {S}, length = {L}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double rmin = double.Parse(Console.ReadLine());
            double rmax = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            Random rnd = new Random();

            Circle[] circles = new Circle[n];
            int m = 0;

            for (int i = 0; i < n; ++i)
            {
                circles[i] = new Circle(rnd.NextDouble() * (rmax - rmin) + rmin);
                if (circles[i].S > circles[m].S)
                    m = i;
                Console.WriteLine(circles[i].ToString());
            }

            Console.WriteLine("Круг с наибольшей площадью: " + circles[m].ToString());
        }
    }
}