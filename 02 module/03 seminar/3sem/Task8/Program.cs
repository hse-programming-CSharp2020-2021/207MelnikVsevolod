using System;

namespace Task8
{
    class Schedule
    {
        private static readonly string[] day = new string[8]
        {
            "",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };

        public Schedule()
        {
            ;
        }
        public string this[int x]
        {
            get
            {
                if (x < 1 || x > 7)
                    return "Incorrect input";
                return day[x];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Schedule sh = new Schedule();
            for (int i = 0; i < 10; ++i)
                Console.WriteLine(sh[i]);
        }
    }
}
