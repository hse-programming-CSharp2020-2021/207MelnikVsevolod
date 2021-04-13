using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Task3
{
    [Serializable]class Quadratic
    {
        public double a, b, c;

        public Quadratic()
        {
            a = 1;
            b = 2;
            c = 1;
        }

        public Quadratic(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            if (Discriminant < 0 || a == 0)
                throw new ArgumentException("A = 0");
        }

        public double Discriminant
        {
            get
            {
                return b * b - 4 * a * c;
            }
        }

        public double X1
        {
            get
            {
                return (-b + Math.Sqrt(Discriminant)) / (2 * a);
            }
        }

        public double X2
        {
            get
            {
                return (-b - Math.Sqrt(Discriminant)) / (2 * a);
            }
        }
    }

    delegate void Qdelegate(Quadratic qe);

    // Класс методов для обработки
    class Processing
    {
        static Random gen = new Random();
        // методы работы с файлами

        // Оценить дискриминант и для неотрицательного - вывести корни:
        public static void SolutionReal(Quadratic eq)
        {
            if (eq.Discriminant < 0) return;
            Console.WriteLine(eq.ToString() + " дискриминант = " + eq.Discriminant);
            Console.WriteLine("\tКорни: Х1={0,3:g3} \tX2={1,3:g3}", eq.X1, eq.X2);
        }

        public static void PrintEq(Quadratic eq)
        {
            Console.WriteLine(eq.ToString() + " дискриминант = " + (eq.Discriminant).ToString("g3"));
        }

        static public void WriteFile(string nameFile, int numb)
        {
            using (FileStream streamOut = new FileStream(nameFile, FileMode.Create))
            {
                BinaryFormatter formatOut = new BinaryFormatter();
                for (int j = 0; j < numb; j++)
                {
                    try
                    { // При А==0 - уравнение вырождается в линейное
                        Quadratic q = new Quadratic(gen.Next(-10, 11), gen.Next(-10, 11), gen.Next(-10, 11));
                        formatOut.Serialize(streamOut, q);
                    }
                    catch
                    { // Заменить вырожденное уравнение:
                        j--; continue;
                    }
                }
            }
        }

        public static void Process(string fileName, Qdelegate qDel)
        {
            using (FileStream streamIn = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatIn = new BinaryFormatter();
                Quadratic eq;
                while (true) // читать до конца файла - там исключение
                    try
                    {
                        eq = (Quadratic)formatIn.Deserialize(streamIn); qDel(eq);
                    }
                    catch (SerializationException) { streamIn.Close(); break; }
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Processing.WriteFile("equation.ser", 8);
            Console.WriteLine("Выполнена запись в режиме сериализации.");
            Console.WriteLine("Для вывода на экран нажмите любую клавишу."); Console.ReadKey(true);
            Console.WriteLine("В файле сведения о следующих уравнениях: ");
            // Обращение с использованием делегата:
            Processing.Process("equation.ser", new Qdelegate(Processing.PrintEq));
            Console.WriteLine("Для решения уравнений нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("\r\nРешения уравнений с вещественными корнями: ");
            Processing.Process("equation.ser", new Qdelegate(Processing.SolutionReal));
            Console.WriteLine("Для завершения работы нажмите ENTER."); Console.ReadLine();
        }
    }
}
