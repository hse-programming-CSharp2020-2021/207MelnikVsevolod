using System;

namespace Task1
{
    public class Number
    {
        int field;
        public Number() { }
        public Number(int x) { field = x; }
    }

    public class ExtNumber : Number
    {
        public ExtNumber() { }
        public ExtNumber(int x) : base() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}

/*
5
***
2
145
123

 
 
 */