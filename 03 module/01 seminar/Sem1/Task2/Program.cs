using System;

namespace Task2
{
    class Program
    {
        delegate int Cast(double x);

        static void Main(string[] args)
        {
            Cast c1 = delegate (double x)
            {
                int a = (int)Math.Round(x);
                if (a % 2 == 1)
                    a -= 1;
                if (Math.Abs(x - a) < Math.Abs(a + 2 - x))
                    return a;
                else
                    return a + 2;
            };
            Cast c2 = delegate (double x) { return (int)Math.Log10(x); };
            Console.WriteLine(c1(123.4));
            Console.WriteLine(c2(123.4));

            Cast c3 = (double x) => {
                int a = (int)Math.Round(x);
                if (a % 2 == 1)
                    a -= 1;
                if (Math.Abs(x - a) < Math.Abs(a + 2 - x))
                    return a;
                else
                    return a + 2;
            };
            Cast c4 = (double x) => ((int)Math.Log10(x));

            Cast c5 = c1 + c2;
            Console.WriteLine(c5(123.4));
        }
    }
}
