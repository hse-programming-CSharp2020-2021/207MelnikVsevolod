/*
Организовать очередь на посадку пассажиров в транспорт. Очередь пассажиров (класс PassengerQueue) реализовать с использованием обобщённой очереди Queue<T>. 
В программе предусмотреть два типа пассажиров: обычный пассажир (класс Passenger) и пассажир с детьми (PassengerWithChildren)
Passenger 
Поля: строковые: имя и фамилия; целочисленное возраст
Свойства 
Для чтения и записи значений полей имени (состоит не более чем из 30 только латинских символов и пробелов, начинается с заглавной буквы) и фамилии (состоит не более чем из 40 только латинских символов и пробелов и тире, начинается с заглавной буквы) 
Автореализуемое IsOld логическое, открытое только для чтения, возвращает true для пассажира старше 65 лет
Переопределённый метод ToString() возвращает строку с данными о пассажире
PassengerWithChildren наследует из класса Passenger
Поля: целочисленной количество детей;
Свойства
Для чтения и записи поля о количестве детей (не менее одного, но не более 40)
Автореализуемое IsNewBorn, логическое, открытое только для чтения, возвращает true для пассажиров с младенцами
Переопределённый метод ToString() возвращает строку с данными о пассажире
PassengerQueue
Поля: две обобщённые очереди ordinaryQueue для обычных пассажиров и priorityQueue для приоритетных. Приоритет имеют пассажиры с младенцами и пассажиры старше 65 лет
Методы:
Открытый метод AddToQueue(), определяющий автоматически очередь, в которую поставить пассажира
Открытый метод StartServingQueue(), запускающий обслуживание очереди. Если в приоритетной очереди три и меньше пассажиров, они обслуживаются первыми, если больше то через одного с обычной очередью.
В основной программе считайте данные о пассажирах и файла csv, продумайте его структуру самостоятельно, считайте, что файл достаточно велик, чтобы не помещаться в память. Распределите пассажиров по очереди, запустите обработку. Интерфейс с пользователем для просмотра пассажиров в очередях продумайте и реализуйте самостоятельно
Для решения задачи можно добавлять дополнительные члены класса
Заготовки для классов и некоторые дополнительные требования ищете на следующих слайдах

*/

using System;
using System.Collections.Generic;

namespace A
{
    /// <summary>
    /// Пассажир
    /// </summary>
    public class Passenger
    {
        string name;
        string lastName;
        int age;
        public bool IsOld { private set; get; }
        public string Name
        {
            set
            { // only latin simbols and spaces
              // not longer 30 simbols 
            }
            get
            {
                return name;
            }
        }
        public string LastName
        {
            set
            { // only latin simbols and spaces
              // not longer 40 simbols 
            }
            get
            {
                return name;
            }
        }
        public int Age
        {
            set
            { // more then 0
            }
            get { return age; }
        }
        public override string ToString()
        {
            return $"{Name} {LastName} {Age}";
        }
    }
    /// <summary>
    /// Пассажир с детьми
    /// </summary>
    public class PassengerWithChildren : Passenger
    {
        int numberOfChildren;
        public bool IsNewBorn { private set; get; }
        public int NumberOfChildren
        {
            set
            { // strictly more then 0
            }
            get { return numberOfChildren; }
        }

        public override string ToString()
        {
            return $"{Name} {LastName} {Age} {numberOfChildren}";
        }
    }
    /// <summary>
    /// Очередь на посадку состоит из двух подочередей: обычной и приоритетной
    /// Пассажиры приоритетной очереди обслуживаются вне очереди
    /// </summary>
    public class PassengerQueue
    {
        // if passenger is ordinary we use ordinaryQueue
        Queue<Passenger> ordinaryQueue = new Queue<Passenger>();
        // if passenger is old or with newborns we use priorityQueue
        Queue<Passenger> priorityQueue = new Queue<Passenger>();

        public void AddToQueue(Passenger newPassenger)
        {
            if (newPassenger.Age > 65 || newPassenger is PassengerWithChildren && ((PassengerWithChildren)newPassenger).IsNewBorn) priorityQueue.Enqueue(newPassenger);
            else ordinaryQueue.Enqueue(newPassenger);
        }
        public void StartServingQueue()
        {
            Console.WriteLine("priorityQueue: ");
            foreach (Passenger p in priorityQueue)
                Console.WriteLine(p);
            Console.WriteLine("ordinaryQueue: ");
            foreach (Passenger p in ordinaryQueue)
                Console.WriteLine(p);
        }
    }

    class MainClass
    {
        static Random rnd = new Random();

        public static void Main()
        {
            PassengerQueue queue = new PassengerQueue();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; ++i)
            {
                Passenger p = new Passenger();
                p.Name = "qwerty";
                p.LastName = "uiop";
                p.Age = rnd.Next(0, 100);
                queue.AddToQueue(p);
            }
            queue.StartServingQueue();
        }
    }
}
