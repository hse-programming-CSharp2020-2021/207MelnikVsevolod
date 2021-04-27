using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class RandomCollection : IEnumerable
    {
        private int n;

        public RandomCollection(int n)
        {
            this.n = n;
        }

        public IEnumerator GetEnumerator()
        {
            return new RandomEnumerator(n);
        }
    }

    class RandomEnumerator : IEnumerator
    {
        private int n;
        private int curr = 0;
        private Random rnd = new Random();

        public object Current
        {
            get
            {
                return rnd.Next();
            }
        }

        public RandomEnumerator(int n)
        {
            this.n = n;
        }

        public bool MoveNext()
        {
            curr++;
            return curr <= n;
        }

        public void Reset()
        {
            curr = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RandomCollection c = new RandomCollection(5);
            foreach (int i in c)
                Console.WriteLine(i);
        }
    }
}
