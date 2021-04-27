using System;

namespace Task522
{
    class Matrix
    {
        double[,] M = new double[2, 2];

        public Matrix(double a11, double a12, double a21, double a22)
        {
            M[0, 0] = a11;
            M[0, 1] = a12;
            M[1, 0] = a21;
            M[1, 1] = a22;
        }

        public Matrix(double a11, double a22)
        {
            M[0, 0] = a11;
            M[1, 1] = a22;
            M[0, 1] = 0;
            M[1, 0] = 0;
        }

        public Matrix(Matrix m)
        {
            M[0, 0] = m.M[0, 0];
            M[0, 1] = m.M[0, 1];
            M[1, 0] = m.M[1, 0];
            M[1, 1] = m.M[1, 1];
        }

        public double Det()
        {
            return M[0, 0] * M[1, 1] - M[0, 1] * M[1, 0];
        }

        public Matrix Inverse()
        {
            if (Det() == 0)
                throw new DivideByZeroException("Det is 0");
            return new Matrix(M[1, 1] / Det(), -M[0, 1] / Det(), -M[1, 0] / Det(), M[0, 0] / Det());
        }

        public Matrix Transpose()
        {
            return new Matrix(M[0, 0], M[1, 0], M[0, 1], M[1, 1]);
        }

        public override string ToString()
        {
            return $"{M[0, 0]:F2}, {M[0, 1]:F2}" + System.Environment.NewLine +
                $"{M[1, 0]:F2}, {M[1, 1]:F2}" + System.Environment.NewLine;
        }

        static public Matrix operator +(Matrix a, Matrix b)
        {
            return new Matrix(a.M[0, 0] + b.M[0, 0], a.M[0, 1] + b.M[0, 1], a.M[1, 0] + b.M[1, 0], a.M[1, 1] + b.M[1, 1]);
        }

        static public Matrix operator -(Matrix a, Matrix b)
        {
            return new Matrix(a.M[0, 0] - b.M[0, 0], a.M[0, 1] - b.M[0, 1], a.M[1, 0] - b.M[1, 0], a.M[1, 1] - b.M[1, 1]);
        }

        static public Matrix operator *(Matrix a, double b)
        {
            return new Matrix(a.M[0, 0] * b, a.M[0, 1] * b, a.M[1, 0] * b, a.M[1, 1] * b);
        }

        static public Matrix operator /(Matrix a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Can't devide matrix by zero.");
            return new Matrix(a.M[0, 0] / b, a.M[0, 1] / b, a.M[1, 0] / b, a.M[1, 1] / b);
        }

        static public Matrix operator *(Matrix a, Matrix b)
        {
            return new Matrix(a.M[0, 0] * b.M[0, 0] + a.M[0, 1] * b.M[0, 1],
                              a.M[0, 0] * b.M[1, 0] + a.M[0, 1] * b.M[1, 1],
                              a.M[1, 0] * b.M[0, 0] + a.M[1, 1] * b.M[0, 1],
                              a.M[1, 0] * b.M[1, 0] + a.M[1, 1] * b.M[1, 1]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix(1, 2, 4, 5);
            Matrix b = new Matrix(4, 2, 6, 5);
            Console.WriteLine(a.Det());
            Console.WriteLine(a.Inverse());
            Console.WriteLine(a.Transpose());
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a * 5);
            Console.WriteLine(a / 5);
        }
    }
}
