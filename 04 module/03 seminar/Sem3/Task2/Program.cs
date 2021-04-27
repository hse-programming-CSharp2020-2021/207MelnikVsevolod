using System;

namespace Task2
{
    class State
    {
        public decimal Population { get; set; }// население
        public decimal Area {get;set; }      // территория

        public static State operator +(State a, State b)
        {
            State s = new State();
            s.Population = a.Population + b.Population;
            s.Area = a.Area + b.Area;
            return s;
        }

        public static bool operator >(State a, State b)
        {
            return a.Population > b.Population;
        }

        public static bool operator <(State a, State b)
        {
            return a.Population < b.Population;
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            State state1 = new State();
            State state2 = new State();
            State state3 = state1 + state2;
            bool isGreater = state1 > state2;
        }
    }
}
