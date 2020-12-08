using System;

namespace Task1
{
    public class Matrix
    {
        int[,] ar;

        public void MatrPrint()
        {
            for (int i = 0; i < ar.GetLength(0); ++i)
            {
                for (int j = 0; j < ar.GetLength(1); ++j)
                    Console.Write(ar[i, j] + " ");
                Console.WriteLine("");
            }
        }

        public void UnitMatr(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException("Аргумент метода должен быть положительным.");
            ar = new int[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    ar[i, j] = (i == j ? 1 : 0);
        }

    }

    public static class Methods
    {
        public static int GetIntValue(string comment)
        {
            bool success = false;
            int value = 0;
            while (!success)
            {
                Console.Write(comment);
                try
                {
                    value = int.Parse(Console.ReadLine());
                    success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка" + e.Message);
                    success = false;
                }
            }
            return value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix();
            int rank;
            do
            {
                try
                {
                    rank = Methods.GetIntValue("Введите порядок матрицы: ");
                    m.UnitMatr(rank);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Esc");
                    continue;
                }
                catch (ArgumentNullException e1)
                {
                    Console.WriteLine("Нет матрицы " + e1.Message);
                }
                catch (FormatException e2)
                {
                    Console.WriteLine("Неверный формат " + e2.Message);
                }
                catch (OverflowException e3)
                {
                    Console.WriteLine(e3.Message);
                }
                m.MatrPrint();
                Console.WriteLine("Esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
