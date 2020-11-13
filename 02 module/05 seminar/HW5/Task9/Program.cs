using System;
using System.Linq;

namespace Task9
{
    class LinearEquation
    {
        public double A
        {
            get; private set;
        }

        public double B
        {
            get; private set;
        }

        public double C
        {
            get; private set;
        }

        public double X
        {
            get
            {
                if (A == 0)
                    return int.MinValue;
                return (C - B) / A;
            }
        }

        public bool OneSolution
        {
            get
            {
                return A != 0;
            }
        }

        public bool HasSolutions
        {
            get
            {
                return A != 0 || B == C;
            }
        }

        public void Info()
        {
            Console.WriteLine($"{A}x + {B} = {C}");
            if (OneSolution)
                Console.WriteLine($"X = {X}");
            else if (HasSolutions)
                Console.WriteLine("X - любое число.");
            else
                Console.WriteLine("Нет решений.");
        }

        public LinearEquation()
        {
            A = B = C = 0;
        }

        public LinearEquation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = int.Parse(Console.ReadLine());
            LinearEquation[] eq = new LinearEquation[n];
            for (int i = 0; i < n; ++i)
                eq[i] = new LinearEquation(rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11));
            eq = eq.OrderBy(e => e.X).ToArray();
            for (int i = 0; i < n; ++i)
                eq[i].Info();
        }
    }
}
