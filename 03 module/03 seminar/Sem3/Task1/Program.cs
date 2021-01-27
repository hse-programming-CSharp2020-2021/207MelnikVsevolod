using System;

namespace Task1
{

    class Program
    {
        public delegate void OnSquareSizeChanged(double x);
        static public event OnSquareSizeChanged SquareChanged;

        class Square
        {
            double x1, x2, y1, y2;

            double X1
            {
                get
                {
                    return x1;
                }
                set
                {
                    
                    x1 = value;
                    SquareChanged?.Invoke(x1);
                }
            }

            double X2
            {
                get
                {
                    return x2;
                }
                set
                {

                    x2 = value;
                    SquareChanged?.Invoke(x2);
                }
            }

            double Y1
            {
                get
                {
                    return x1;
                }
                set
                {

                    x1 = value;
                    SquareChanged?.Invoke(x1);
                }
            }

            double Y2
            {
                get
                {
                    return y2;
                }
                set
                {

                    y2 = value;
                    SquareChanged?.Invoke(y2);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
