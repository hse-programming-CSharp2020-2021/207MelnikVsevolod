using System;

namespace Task5
{
    class Program
    {
        static void WriteArray(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write($"{a[i]} ");
            Console.WriteLine("");
        }

        static int Sum(int[][] results)
        {
            int sum = 0;
            for (int i = 0; i < results.Length; ++i)
                for (int j = 0; j < results[i].Length; ++j)
                    sum += results[i][j];
            return sum;
        }

        static int Max(int[][] results, int[] kvartals, string[] filials, out int kv, out string f)
        {
            kv = kvartals[0];
            f = filials[0];
            int m = results[0][0];
            for (int i = 0; i < results.Length; ++i)
                for (int j = 0; j < results[i].Length; ++j)
                {
                    if (results[i][j] > m)
                    {
                        m = results[i][j];
                        kv = kvartals[i];
                        f = filials[j];
                    }
                }
            return m;
        }

        static int MaxFilial(int[][] results, int[] kvartals, string[] filials, out string f)
        {
            f = filials[0];
            int m = 0;
            for (int j = 0; j < results[0].Length; ++j)
            {
                int sum = 0;
                for (int i = 0; i < results.Length; ++i)
                    sum += results[i][j];
                if (sum > m)
                {
                    m = sum;
                    f = filials[j];
                }
            }
            return m;
        }

        static int MaxKvartal(int[][] results, int[] kvartals, string[] filials, out int kv)
        {
            kv = kvartals[0];
            int m = 0;
            for (int i = 0; i < results.Length; ++i)
            {
                int sum = 0;
                for (int j = 0; j < results[i].Length; ++j)
                    sum += results[i][j];
                if (sum > m)
                {
                    m = sum;
                    kv = kvartals[i];
                }
            }
            return m;
        }

        static void Main(string[] args)
        {
            int[] kvartals = new int[4] { 1, 2, 3, 4 };
            string[] filials = new string[3] { "Западный", "Центральный", "Восточный" };
            int[][] results = new int[4][];
            results[0] = new int[3] { 20, 24, 25 };
            results[1] = new int[3] { 21, 20, 18 };
            results[2] = new int[3] { 23, 27, 24 };
            results[3] = new int[3] { 22, 19, 20 };

            Console.WriteLine("Всего: " + Sum(results).ToString());
            int m, kv;
            string f;
            m = Max(results, kvartals, filials, out kv, out f);
            Console.WriteLine("Больше всего продал: {0} {1}-ый квартал {2}", m, kv, f);

            m = MaxFilial(results, kvartals, filials, out f);
            Console.WriteLine("Больше всего продал за год: {0} {1}", m, f);

            m = MaxKvartal(results, kvartals, filials, out kv);
            Console.WriteLine("Самый успешный квартал: {0} {1}-ый", m, kv);
        }
    }
}
