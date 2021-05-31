using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    interface IVocal
    {
        void DoSound();

    }

    abstract class Animal : IVocal
    {
        static int newId = 1;
        public int Id { get; }
        public string Name { get; set; }
        public bool IsTakenCare { get; set; }

        public Animal()
        {
            Id = newId++;
        }

        public override string ToString()
        {
            return $"{Id} {Name} " + (IsTakenCare ? "is taken care" : "isn't taken care");
        }

        public abstract void DoSound();
    }

    class Mammal : Animal, IVocal
    {
        int Paws { get; set; }

        public override string ToString()
        {
            return $"Mammal {Id} {Name} " + (IsTakenCare ? "is taken care" : "isn't taken care") + $" with {Paws} paws";
        }

        public override void DoSound()
        {
            Console.WriteLine("я млекопитающие, би-би-би");
        }

        public Mammal(string name, bool isTakenCare, int paws) : base()
        {
            Name = name;
            IsTakenCare = isTakenCare;
            Paws = paws;
        }
    }

    class Bird : Animal, IVocal
    {
        int Speed { get; set; }

        public override string ToString()
        {
            return $"Bird {Id} {Name} " + (IsTakenCare ? "is taken care" : "isn't taken care") + $" with speed {Speed}";
        }

        public Bird(string name, bool isTakenCare, int speed) : base()
        {
            Name = name;
            IsTakenCare = isTakenCare;
            Speed = speed;
        }

        public override void DoSound()
        {
            Console.WriteLine("я птичка, пип - пип - пип");
        }
    }

    class Zoo
    {
        public List<Animal> Animals { get; set; }

        public Zoo()
        {
            Animals = new List<Animal>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = int.Parse(Console.ReadLine());
            Zoo zoo = new Zoo();
            zoo.Animals = new List<Animal>(n);
            for (int i = 0; i < n; ++i)
            {
                Animal a;
                if (rnd.Next() % 2 == 0)
                    a = new Mammal(rnd.Next().ToString(), rnd.Next() % 2 == 0, rnd.Next(20));
                else
                    a = new Bird(rnd.Next().ToString(), rnd.Next() % 2 == 0, rnd.Next(100));
                zoo.Animals.Add(a);
            }

            foreach (Animal a in zoo.Animals)
            {
                Console.Write(a + " ");
                a.DoSound();
                Console.WriteLine();
            }

            Console.WriteLine();
            var birds = zoo.Animals.Where(a => a is Bird && a.IsTakenCare);
            foreach (Animal b in birds)
            {
                Console.WriteLine(b);
            }

            Console.WriteLine();
            var mammals = zoo.Animals.Where(a => a is Mammal && !a.IsTakenCare);
            foreach (Animal m in mammals)
            {
                Console.WriteLine(m);
            }
        }
    }
}
