using System;
using System.IO;
using System.Text;

namespace Project2
{
    class Program
    {
        static string RandomInts(int n)
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < n; ++i)
            {
                s = s + r.Next(10, 101).ToString() + " ";
                if (i % 5 == 4)
                    s = s + Environment.NewLine;
            }
            return s;
        }

        static void Main(string[] args)
        {
            string path = @"Data.txt";

            // Создаем файл с данными
                // TODO1: сохранить в файл целые случайные значения из диапазона [10;100)
            string createText = RandomInts(15);
            File.WriteAllText(path, createText, Encoding.UTF8);

            // Open the file to read from
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string[] stringValues = readText.Split(' ');
                int[] arr = StringArrayToIntArray(stringValues);
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }

                // обрабатываем элементы массива
                // TODO2: Создать два массива по исходному
                int[] a = new int[0];
                int[] b = new int[0];
                for (int i = 0; i < arr.Length; ++i)
                    if (arr[i] % 2 == 0)
                    {
                        Array.Resize(ref a, a.Length + 1);
                        a[a.Length - 1] = i;
                    }
                    else
                    {
                        Array.Resize(ref b, b.Length + 1);
                        b[b.Length - 1] = i;
                    }

                // в первый поместить индексы чётных элементов, во второй - нечётных
                // TODO3: Заменяем все нечётные числа исходного массива нулями
                for (int i = 0; i < b.Length; ++i)
                    arr[b[i]] = 0;
            }
        } // end of Main()
        // преобразование массива строк в массив целых чисел
        public static int[] StringArrayToIntArray(string[] str)
        {
            int[] arr = null;
            if (str.Length != 0)
            {
                arr = new int[0];
                foreach (string s in str)
                {
                    int tmp;
                    if (int.TryParse(s, out tmp))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                } // end of foreach (string s in str)      
            }
            return arr;
        } // end of StringToIntArray()
    } // end of Program
}
