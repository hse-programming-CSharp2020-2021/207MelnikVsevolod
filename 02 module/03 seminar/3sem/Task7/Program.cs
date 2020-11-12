using System;

namespace Task7
{
    class Sin
    {
        public double Xmin
        {
            get; set;
        }

        public double Xmax
        {
            get; set;
        }

        public Sin(double min, double max)
        {
            Xmin = min;
            Xmax = max;
        }

        public double this[double x]
        {
            get
            {
                if (x < Xmin || x > Xmax)
                    return 0;
                return Math.Sin(x);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Sin s = new Sin(0, Math.PI);
            Console.WriteLine(s[-1]);
            Console.WriteLine(s[Math.PI / 2]);
            Console.WriteLine(s[5]);
        }
    }
}
