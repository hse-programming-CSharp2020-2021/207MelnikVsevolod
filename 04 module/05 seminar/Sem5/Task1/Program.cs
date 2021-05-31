using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var city = new XElement("city", "Seattle");

            var customer1 = new XElement("customer", city);
            var customer2 = new XElement("customer", city);

            city.SetValue("London");
            Console.WriteLine(customer2.Element("city").Value);

            Random rnd = new Random();
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; ++i)
                numbers[i] = rnd.Next(-10000, 10000);
            foreach (int i in numbers)
                Console.Write(i + " ");

            var last = numbers.Select(x => Math.Abs(x) % 10);
            var digits = last.ToList();
            foreach (int d in digits)
                Console.Write(d + " ");
            Console.WriteLine();

            var positive = numbers.Where(x => x > 0 && x % 2 == 0).ToList();
            Console.WriteLine("Positive and even: " + positive.Count);

            Console.WriteLine(numbers.Aggregate((x, y) => x + y));

            var sorted = numbers.OrderBy(x => Math.Abs(x).ToString()[0]).ThenBy(x => Math.Abs(x) % 10).ToList();
            //foreach (int s in sorted)
            //    Console.Write(s + " ");
        }
    }
}
