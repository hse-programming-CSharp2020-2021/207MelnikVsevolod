using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
namespace Task3
{
    class Program
    {
        private const int RUNS = 1000;
        static readonly ConcurrentDictionary<int, int> concurrentDictionary = new ConcurrentDictionary<int, int>();
        static void Add()
        {
            for (var i = 0; i < RUNS; ++i)
            {
                bool result = concurrentDictionary.TryAdd(i, i);
                if (result)
                    Console.WriteLine(i + " was added");
            }
        }

        static void AddOrUpdate()
        {
            for (var i = 0; i < RUNS; ++i)
            {
                concurrentDictionary.AddOrUpdate(i, i, (key, val) => i);
                Console.WriteLine($"{i} was added or updated");
            }
        }

        static void Main(string[] args)
        {
            Task t = Task.WhenAll(
             Task.Run(() => Add()),
               Task.Run(() => Add()),
               Task.Run(() => Add()),
               Task.Run(() => Add()),
               Task.Run(() => Add()));
            t.Wait();
            Console.WriteLine($"Total number of elements: {concurrentDictionary.Count}");
        }
    }
}