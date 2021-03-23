using System;
using System.Collections.Generic;

namespace StreetLib
{
    public class Street
    {
        public string Name { get; private set; }
        public int[] Houses { get; set; }

        public Street(string name)
        {
            Name = name;
        }

        public static int operator ~(Street street)
        {
            return street.Houses.Length;
        }

        public static bool operator +(Street street)
        {
            return new List<int>(street.Houses).Contains(7);
        }

        public override string ToString()
        {
            string line = Name;
            for (int i = 0; i < Houses.Length; ++i)
                line += " " + Houses[i].ToString();
            return line;
        }
    }
}
