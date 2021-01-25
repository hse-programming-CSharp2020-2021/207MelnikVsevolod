using System;

namespace Task4
{
    class QuadraticTrinomial
    {
        // коэффициенты при степенях 2,1 и 0
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public QuadraticTrinomial(double a, double b, double c)
        {
            A = a; B = b; C = c;
        }
        // значение квадратного трёхчлена в точке x0
        public double ValueInX(double x0)
        {
            return A * x0 * x0 + B * x0 + C;
        }
        // метод возвращает частное от деления значения в точке x0
        // квадратного трёхчлена на значение в точке x0 квадратного
        // трёхчлена, переданного в качестве параметра
        public double Division(QuadraticTrinomial another, double x0)
        {
            double div = 1;
            // TODO: добавить реализацию
            if (another.ValueInX(x0) == 0)
                throw new DivideByZeroException();
            div = ValueInX(x0) / another.ValueInX(x0);
            return div;
        }
    }

    class Program
    {
        static void Divide(QuadraticTrinomial q1, QuadraticTrinomial q2, double x0)
        {
            try
            {
                Console.WriteLine(q1.Division(q2, x0));
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Деление на 0");
            }
        }

        static void Main(string[] args)
        {
            QuadraticTrinomial q1 = new QuadraticTrinomial(2, 3, 7);
            QuadraticTrinomial q2 = new QuadraticTrinomial(1, -5, 6);
            Divide(q1, q2, 1);
            Divide(q1, q2, -3);
            Divide(q1, q2, 3);
            Divide(q1, q2, 2);
            Divide(q1, q2, 7);
            Divide(q1, q2, 100);
            Divide(q1, q2, 0);
        }
    }
}
