using System;

namespace Task_1
{
    class Program
    {
        static bool IsPrime(int n)
        {
            int cnt = 0;
            for (int i = 1; i * i <= n; ++i)
            {
                if (n % i == 0)
                {
                    if (n / i == i)
                        cnt += 1;
                    else
                        cnt += 2;
                }
            }
            return (cnt == 2);
        }

        static int[] Primes(int[] sequence)
        {
            int[] primes = new int[0];
            for (int i = 0; i < sequence.Length; ++i)
            {
                if (IsPrime(sequence[i]))
                {
                    Array.Resize(ref primes, primes.Length + 1);
                    primes[primes.Length - 1] = sequence[i];
                }
            }
            return primes;
        }

        static bool IsNotDecreasing(int[] sequence, out int min)
        {
            min = sequence[0];
            bool is_n_d = true;
            for (int i = 1; i < sequence.Length; ++i)
            {
                if (sequence[i - 1] > sequence[i])
                    is_n_d = false;
                if (sequence[i] < min)
                    min = sequence[i];
            }
            return is_n_d;
        }

        static int[] Gen(int n)
        {
            Random rnd = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; ++i)
                arr[i] = rnd.Next(50);
            return arr;
        }

        static void Write(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] arr = Gen(10);
            Write(arr);
            Console.WriteLine("Простые:");
            int[] primes = Primes(arr);
            Console.WriteLine(primes.Length);
            Write(primes);
            int min;
            Console.WriteLine("Неубывающая:");
            Console.WriteLine(IsNotDecreasing(arr, out min));
            Console.WriteLine("Минимальный элемент:");
            Console.WriteLine(min);
        }
    }
}
