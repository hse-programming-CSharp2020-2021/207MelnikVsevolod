using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class TringleNums
    {
        int curr = 1;

        public IEnumerable<int> nextNumb(int n)
        {
            for (int i = 0; i < n; i++)
            {
                curr = (i + 1) * i / 2;
                yield return curr;
            }
        }
    }

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
        static void Main(string[] args)
        {
            var tn = new TringleNums().nextNumb(7).ToArray();
            var fb = new Fibbonacci().nextFib(7).ToArray();
            foreach (int numb in fb)
                Console.Write(numb + " ");
            Console.WriteLine();

            foreach (int numb in tn)
                Console.Write(numb + " ");
            Console.WriteLine();

            for (int i = 0; i < tn.Count(); ++i)
                Console.Write($"{tn[i] + fb[i]} ");
        }
    }
}
