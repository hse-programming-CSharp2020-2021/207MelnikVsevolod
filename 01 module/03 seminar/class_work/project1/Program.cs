using System;

namespace project1
{
    class Program
    {
        public static string get_result(int x)
        {
            switch (x)
            {
                case 1:
                case 2:
                case 3:
                    return "neudovletvoritelno";
                case 4:
                case 5:
                    return "udovletvoritelno";
                case 6:
                case 7:
                    return "horosho";
                default:
                    return "otlichno";
            }
        }
        
        static void Main(string[] args)
        {
            int x = 0;
            if (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Wrong input");
            }
            else
            {
                Console.WriteLine(get_result(x));
            }
        }
    }
}//dz 3, 4, 6, 7, slaidi 13,14