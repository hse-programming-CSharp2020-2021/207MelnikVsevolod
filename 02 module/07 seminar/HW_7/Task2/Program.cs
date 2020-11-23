using System;

namespace Task2
{
    class Program
    {
        static Random rnd = new Random();

        static Point[] FigArray()
        {
            int circle_cnt = rnd.Next(11);
            int square_cnt = rnd.Next(11);
            Point[] arr = new Point[circle_cnt + square_cnt];
            for (int i = 0; i < circle_cnt; ++i)
                arr[i] = new Circle(rnd.Next(10, 101), rnd.Next(10, 101), rnd.Next(10, 101));
            for (int i = circle_cnt; i < circle_cnt + square_cnt; ++i)
                arr[i] = new Square(rnd.Next(10, 101), rnd.Next(10, 101), rnd.Next(10, 101));
            return arr;
        }

        static void Main(string[] args)
        {
            Point p = new Point();
            p.Display();
            Console.WriteLine("p.Area for Point = " + p.Area);
            p = new Circle(1, 2, 6);
            p.Display();
            Console.WriteLine("p.Area for Circle = " + p.Area);
            p = new Square(3, 5, 8);
            p.Display();
            Console.WriteLine("p.Area for Square = " + p.Area);
            Point[] arr = FigArray();
            int circle_cnt = 0, square_cnt = 0;
            for (int i = 0; i < arr.Length; ++i)
                if (arr[i] is Circle)
                    circle_cnt++;
                else
                    square_cnt++;
            Console.WriteLine("Circles: " + circle_cnt);
            Console.WriteLine("Squares: " + square_cnt);
            double area = 0, len = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                area += p.Area;
                len += p.Len;
            }
            area /= arr.Length;
            len /= arr.Length;
            Console.WriteLine("Area: " + area);
            Console.WriteLine("Len: " + len);
            Array.Sort(arr, (x, y) => x.Area.CompareTo(y.Area));
        }
    }
}
