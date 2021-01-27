using System;

namespace Task1
{
    class Plant
    {
        double growth, photosensivity, frostresistance;

        public Plant(double g, double p, double f)
        {
            growth = g;
            photosensivity = p;
            frostresistance = f;
        }

        public double Growth
        {
            get
            {
                return growth;
            }
        }

        public double Photosensivity
        {
            get
            {
                return photosensivity;
            }
        }

        public double Frostresistance
        {
            get
            {
                return frostresistance;
            }
        }

        public override string ToString()
        {
            return growth + " " + photosensivity + " " + frostresistance;
        }
    }

    class Program
    {
        static Random rnd = new Random();

        static int Cmp(Plant x, Plant y)
        {
            if (x.Photosensivity % 2 > y.Photosensivity % 2)
                return 1;
            else if (x.Photosensivity % 2 == y.Photosensivity % 2)
                return 0;
            else
                return -1;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Plant[] plants = new Plant[n];
            for (int i = 0; i < n; ++i)
                plants[i] = new Plant(rnd.Next(25, 100), rnd.Next(0, 100), rnd.Next(0, 80));
            Array.ForEach(plants, (x) => Console.WriteLine(x));
            Array.Sort(plants, (Plant x, Plant y) => { if (x.Growth > y.Growth) return -1;
                else if (x.Growth == y.Growth)
                    return 0;
                else return 1;
            });
            Array.ForEach(plants, (x) => Console.WriteLine(x));

            Array.Sort(plants, (Plant x, Plant y) => {
                if (x.Frostresistance > y.Frostresistance) return 1;
                else if (x.Frostresistance == y.Frostresistance)
                    return 0;
                else return -1;
            });
            Array.ForEach(plants, (x) => Console.WriteLine(x));

            Array.Sort(plants, Cmp);
            Array.ForEach(plants, (x) => Console.WriteLine(x));
        }
    }
}
