using System;

namespace Task_2
{
    class Program
    {
        static double[] Gen(int n)
        {
            Random rnd = new Random();
            double[] arr = new double[n];
            for (int i = 0; i < n; ++i)
                arr[i] = rnd.NextDouble() * 10 - 5;
            return arr;
        }

        static void Write(double[] X, double[] Y)
        {
            if (X == null)
            {
                Console.WriteLine("---");
                return;
            }
            for (int i = 0; i < X.Length; ++i)
                Console.Write($"({X[i].ToString("F1")}; {Y[i].ToString("F1")}) ");
            Console.WriteLine();
        }

        static void InOrOut(double[] X, double[] Y, out double[] Xin, out double[] Yin, out double[] Xout, out double[] Yout)
        {
            Xin = new double[0];
            Yin = new double[0];
            Xout = new double[0];
            Yout = new double[0];
            for (int i = 0; i < X.Length; ++i)
            {
                double R2 = X[i] * X[i] + Y[i] * Y[i];
                if (R2 >= 4 && R2 <= 16)
                {
                    Array.Resize(ref Xin, Xin.Length + 1);
                    Array.Resize(ref Yin, Yin.Length + 1);
                    Xin[Xin.Length - 1] = X[i];
                    Yin[Xin.Length - 1] = Y[i];
                }
                else
                {
                    Array.Resize(ref Xout, Xout.Length + 1);
                    Array.Resize(ref Yout, Yout.Length + 1);
                    Xout[Xout.Length - 1] = X[i];
                    Yout[Xout.Length - 1] = Y[i];
                }
            }
        }

        static void Main(string[] args)
        {
            double[] X = Gen(10), Y = Gen(10);
            Write(X, Y);
            Console.WriteLine("");
            double[] Xin, Yin, Xout, Yout;
            InOrOut(X, Y, out Xin, out Yin, out Xout, out Yout);
            Console.WriteLine("Внутри: ");
            Write(Xin, Yin);
            Console.WriteLine("Снаружи: ");
            Write(Xout, Yout);
        }
    }
}
