using System;

namespace Task2
{
    public class GeomProgr
    {
        public static uint objectNumber = 0;
        double _b; // первый член прогрессии b!=0
        double _q; // знаменатель прогрессии q!=0
        public double B
        {
            get { return _b; }
            set
            {
                if (value == 0)
                    throw new Exception("Недопустимое значение первого члена прогрессии!");
                _b = value;
            }
        }
        public double Q
        {
            get { return _q; }
            set
            {
                if (value == 0)
                    throw new Exception("Недопустимое значение знаменателя прогрессии!");
                _q = value;
            }
        }
        public GeomProgr() {
            _b = 1;
            _q = 1;
            objectNumber++;
            Console.WriteLine(objectNumber + ": Конструктор без параметров");
        }

        public GeomProgr(double b, double q) : this() {
            if (b == 0 || q == 0) {
                objectNumber--;
                throw new Exception("Ошибка в аргументах конструктора!");
            }
            _b = b;
            _q = q;
            Console.WriteLine(objectNumber + ": Конструктор с параметрами");
        }

        public double this[int n] {
            get
            {
                return _b * Math.Pow(_q, n - 1);
            }
        }

        public double ProgrSum(int n) {
            return (_b * (Math.Pow(_q, n) - 1)) / (_q - 1);
        } // end of ProgrSum()
    }

    class Program
    {
        static void Main()
        {
            GeomProgr geomProgrObj; // ссылка на объект типа GeomProgr bool flag;
            int b, q;
            bool flag = false;
            do
            {
                flag = false;
                try
                {
                    Console.Write("Введите начальный член прогрессии: "); b = int.Parse(Console.ReadLine()); Console.Write("Введите знаменатель прогрессии: ");
                    q = int.Parse(Console.ReadLine());
                    geomProgrObj = new GeomProgr(b, q); // создаем объект 2
                }
                catch (Exception e)
                { // ловим любые исключения flag = true;
                    Console.WriteLine("Некорректные входные данные! ");
                }
            } while (flag);
        }
    }
}
