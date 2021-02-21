using System;

namespace Task1
{
    interface ICalculate
    {
        double Perform(double x);
    }

    class Add : ICalculate
    {
        double number;

        public Add(double n)
        {
            number = n;
        }

        double ICalculate.Perform(double x)
        {
            return x + number;
        }
    }

    class Multiply : ICalculate
    {
        double number;

        public Multiply(double n)
        {
            number = n;
        }

        double ICalculate.Perform(double x)
        {
            return x * number;
        }
    }

    class Program
    {
        static double Calculate(double x, Add a, Multiply m)
        {
            return (m as ICalculate).Perform((a as ICalculate).Perform(x));
        }

        static void Main(string[] args)
        {
            Add a = new Add(5);
            Multiply m = new Multiply(3);
            Console.WriteLine(Calculate(2, a, m));
        }
    }
}
