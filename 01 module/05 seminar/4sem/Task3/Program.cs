using System;

namespace Task3
{
    class Program
    {
        static bool Triangle(double x, double y, double z, out double p, out double s)
        {
            if (x + y < z || x + z < y || y + z < x)
                return false;
            p = x + y + z;
            s = Math.Sqrt((p / 2 - x) * (p / 2 - y) * (p / 2 - z) * (p / 2));
            return true;
        }

        static void Main(string[] args)
        {
            double x, y, z, p, s;
            string xs = Console.ReadLine();
            string ys = Console.ReadLine();
            string zs = Console.ReadLine();
            if (!double.TryParse(xs, out x) || !double.TryParse(ys, out y) || !double.TryParse(zs, out z))
                Console.WriteLine();
            Console.WriteLine("Hello World!");
        }
    }
}
