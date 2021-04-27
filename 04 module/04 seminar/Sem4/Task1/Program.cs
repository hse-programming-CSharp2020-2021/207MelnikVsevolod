using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Fibbonacci
    {
        int curr = 1;
        int last = 0;

        public IEnumerable<int> nextFib(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int t = curr;
                curr += last;
                last = t;
                yield return curr;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Fibbonacci fi = new Fibbonacci();
            foreach (int numb in fi.nextFib(7))
                Console.Write(numb + " ");
            Console.WriteLine();

            foreach (int numb in fi.nextFib(7))
                Console.Write(numb + " ");

            Console.WriteLine();
        }
    }
}
