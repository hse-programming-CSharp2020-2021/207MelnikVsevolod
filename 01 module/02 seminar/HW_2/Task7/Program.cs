using System;

namespace Task7
{
    class Program
    {
        public static void Func1(double s, out double _int, out double dr)
        {
            _int = (int)s;
            dr = s - _int;
            //целая и дробная часть
        }

        public static void Func2(double s, out double s1, out double s2)
        {
            s1 = s * s;
            s2 = Math.Sqrt(Math.Abs(s));
            //квадрат и корень
        }

        static void Main(string[] args)
        {
            while (true)
            {
                double s;
                if (!double.TryParse(Console.ReadLine(), out s))
                    return;
                double i, d, s1, s2;
                Func1(s, out i, out d);
                Func2(s, out s1, out s2);
                Console.WriteLine("{0} = {1} + {2}", s, i, d);
                if (s >= 0.0)
                    Console.WriteLine("Sqr({0}) = {1}, Sqrt({0}) = {2}", s, s1, s2);
                else
                    Console.WriteLine("Sqr({0}) = {1}, Sqrt({0}) = {2:f3}i", s, s1, s2);
            }
        }
    }
}
