using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Task3_1
{
    [Serializable]
    public class Quadratic
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
                XmlSerializer formatOut = new XmlSerializer(typeof(List<Quadratic>), new Type[] { typeof(Quadratic)} );
                List<Quadratic> list = new List<Quadratic>();
                for (int j = 0; j < numb; j++)
                {
                    try
                    { // При А==0 - уравнение вырождается в линейное
                        Quadratic q = new Quadratic(gen.Next(-10, 11), gen.Next(-10, 11), gen.Next(-10, 11));
                        list.Add(q);
                    }
                    catch
                    { // Заменить вырожденное уравнение:
                        j--; continue;
                    }
                }
                formatOut.Serialize(streamOut, list);
            }
        }

        public static void Process(string fileName, Qdelegate qDel)
        {
            using (FileStream streamIn = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer formatIn = new XmlSerializer(typeof(List<Quadratic>), new Type[] { typeof(Quadratic) });
                List<Quadratic> list = (List<Quadratic>)formatIn.Deserialize(streamIn);
                foreach (Quadratic eq in list)
                    qDel(eq);
               streamIn.Close();
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Processing.WriteFile("equation.xml", 8);
            Console.WriteLine("Выполнена запись в режиме сериализации.");
            Console.WriteLine("Для вывода на экран нажмите любую клавишу."); Console.ReadKey(true);
            Console.WriteLine("В файле сведения о следующих уравнениях: ");
            // Обращение с использованием делегата:
            Processing.Process("equation.xml", new Qdelegate(Processing.PrintEq));
            Console.WriteLine("Для решения уравнений нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("\r\nРешения уравнений с вещественными корнями: ");
            Processing.Process("equation.xml", new Qdelegate(Processing.SolutionReal));
            Console.WriteLine("Для завершения работы нажмите ENTER."); Console.ReadLine();
        }
    }
}
