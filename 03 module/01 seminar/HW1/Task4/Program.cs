using System;

namespace Task4
{
    class Robot
    {
        int x, y;
        char[,] field;

        public void Right() { x++; Check(); }
        public void Left() { x--; Check(); }
        public void Forward() { y++; Check(); }
        public void Backward() { y--; Check(); }

        public int getX() { return x; }
        public int getY() { return y; }

        public void Resize(int x, int y)
        {
            field = new char[x, y];
            for (int i = 0; i < field.GetLength(0); ++i)
                for (int j = 0; j < field.GetLength(1); ++j)
                    field[i, j] = ' ';
        }

        void Check()
        {
            if (x >= 0 && y >= 0 && x < field.GetLength(1)
                && y < field.GetLength(0))
                field[y, x] = '+';
            else
                Console.WriteLine("Error!!!");
        }

        public void Draw()
        {
            for (int i = 0; i < field.GetLength(0); ++i)
            {
                for (int j = 0; j < field.GetLength(1); ++j)
                    if (x == j && y == i)
                        Console.Write('*');
                    else
                        Console.Write(field[i, j]);
                Console.WriteLine("");
            }
        }

        public string Position()
        {
            return String.Format("The Robot position: x={0}, y={1}", x, y);
        }
    }

    class Program
    {
        delegate void Steps();

        static void Main(string[] args)
        {
            Robot rob = new Robot();
            rob.Resize(Console.WindowHeight, Console.WindowWidth);
            while (true)
            {
                string s = Console.ReadLine();
                Steps trace = null;
                for (int i = 0; i < s.Length; ++i)
                    if (s[i] == 'L')
                        trace += rob.Left;
                    else if (s[i] == 'R')
                        trace += rob.Right;
                    else if (s[i] == 'B')
                        trace += rob.Backward;
                    else
                        trace += rob.Forward;
                trace();
                int x = rob.getX();
                int y = rob.getY();
                if (x >= 0 && y >= 0 && x < Console.WindowWidth
                && y < Console.WindowHeight)
                    rob.Draw();
                else
                    return;
            }
        }
    }
}
