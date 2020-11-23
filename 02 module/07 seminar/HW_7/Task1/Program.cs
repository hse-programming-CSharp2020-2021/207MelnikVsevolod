using System;

namespace Task1
{
    class A
    {
        virtual public char getA()
        {
            return 'A';
        }
    }

    class B : A
    {
        override public char getA()
        {
            return 'B';
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            A[] arr = new A[10];
            for (int i = 0; i < 10; ++i)
                if (rnd.Next(3) == 0)
                    arr[i] = new A();
                else
                    arr[i] = new B();
            foreach (A d in arr)
                Console.WriteLine(d.getA());
            Console.WriteLine("Обьекты класса B: ");
            foreach (A d in arr)
                if (d is B)
                    Console.WriteLine(d.getA());
            Console.WriteLine("Обьекты класса A: ");
            foreach (A d in arr)
                if (!(d is B))
                    Console.WriteLine(d.getA());
        }
    }
}
