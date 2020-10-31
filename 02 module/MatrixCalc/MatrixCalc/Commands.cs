using System;
using System.IO;

namespace MatrixCalc
{
    partial class Program
    {
        /// <summary>
        /// Transpose matrix.
        /// </summary>
        /// <param name="m"> Matrix. </param>
        /// <returns> Transposed matrix. </returns>
        static Matrix T(Matrix m)
        {
            Matrix mt = m.Transpose();
            string[] s1, s2;
            s1 = FormatMatrix(m);
            s2 = FormatMatrix(mt);
            int l1 = s1.Length;
            int l2 = s2.Length;

            // Max height for correct drawing of matrixes.
            int max_height = Math.Max(l1, l2);
            Array.Resize(ref s1, max_height);
            Array.Resize(ref s2, max_height);
            for (int i = l1; i < max_height; ++i)
            {
                s1[i] = "";
                for (int j = 0; j < s1[0].Length; ++j)
                    s1[i] += " ";
            }
            for (int i = l2; i < max_height; ++i)
            {
                s2[i] = "";
                for (int j = 0; j < s2[0].Length; ++j)
                    s2[i] += " ";
            }

            string[] text = new string[max_height];
            for (int i = 0; i < s1.Length; ++i)
                if (i == max_height / 2)
                    text[i] = s1[i] + " T= " + s2[i];
                else
                    text[i] = s1[i] + "    " + s2[i];
            WriteOperation(text);
            return mt;
        }

        /// <summary>
        /// Multiply matrix on scalar.
        /// </summary>
        /// <param name="m"> Matrix. </param>
        /// <param name="s"> Scalar. </param>
        /// <returns></returns>
        static Matrix Mult_s(Matrix m, double s)
        {
            Matrix m2 = m * s;
            string[] s1, s2;
            s1 = FormatMatrix(m);
            s2 = FormatMatrix(m2);
            int l1 = s1.Length;

            string[] text = new string[l1];

            string op = $" * {s:F2} = ";
            string space = "";
            for (int i = 0; i < op.Length; ++i)
                space = space + " ";

            for (int i = 0; i < l1; ++i)
                if (i == l1 / 2)
                    text[i] = s1[i] + op + s2[i];
                else
                    text[i] = s1[i] + space + s2[i];
            WriteOperation(text);
            return m2;
        }

        /// <summary>
        /// Find determinant of matrix.
        /// </summary>
        /// <param name="m"> Matrix. </param>
        /// <returns> Determinant. </returns>
        static double Det(Matrix m, out bool error)
        {
            error = false;
            if (m.Rows != m.Columns)
            {
                error = true;
                error_message = "Нельзя найти определитель не квадратной матрицы.";
                return 0;
            }
            double d = m.Det;
            string[] s = FormatMatrix(m, true);
            for (int i = 0; i < s.Length; ++i)
                if (i == s.Length / 2)
                    s[i] = s[i] + " = " + d.ToString();
            WriteOperation(s);
            return d;
        }

        /// <summary>
        /// Find trace of the matrix.
        /// </summary>
        /// <param name="m"> Matrix. </param>
        /// <returns></returns>
        static double Trace(Matrix m, out bool error)
        {
            error = false;
            if (m.Rows != m.Columns)
            {
                error = true;
                error_message = "Нельзя найти след не квадратной матрицы.";
                return 0;
            }
            double t = m.Trace;
            string[] s = FormatMatrix(m);
            for (int i = 0; i < s.Length; ++i)
                if (i == s.Length / 2)
                    s[i] = "Trace" + s[i] + " = " + t.ToString();
                else
                    s[i] = "     " + s[i];
            WriteOperation(s);
            return t;
        }

        /// <summary>
        /// Add 2 matrixes and draw equation.
        /// </summary>
        /// <param name="m1"> Matrix 1. </param>
        /// <param name="m2"> Matrix 2. </param>
        /// <returns> Sum of matrixes. </returns>
        static Matrix Add(Matrix m1, Matrix m2, out bool error)
        {
            error = false;
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
            {
                error = true;
                error_message = "Размеры матриц не подходят для сложения.";
                return new Matrix();
            }
            Matrix m3 = m1 + m2;
            string[] s1, s2, s3;
            s1 = FormatMatrix(m1);
            s2 = FormatMatrix(m2);
            s3 = FormatMatrix(m3);
            string[] text = new string[s1.Length];
            for (int i = 0; i < s1.Length; ++i)
                if (i == s1.Length / 2)
                    text[i] = s1[i] + " + " + s2[i] + " = " + s3[i];
                else
                    text[i] = s1[i] + "   " + s2[i] + "   " + s3[i];
            WriteOperation(text);
            return m3;
        }

        /// <summary>
        /// Substract 2 matrixes and draw equation.
        /// </summary>
        /// <param name="m1"> Matrix 1. </param>
        /// <param name="m2"> Matrix 2. </param>
        /// <returns> Substraction of matrixes. </returns>
        static Matrix Sub(Matrix m1, Matrix m2, out bool error)
        {
            error = false;
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
            {
                error = true;
                error_message = "Размеры матриц не подходят для вычитания.";
                return new Matrix();
            }
            Matrix m3 = m1 - m2;
            string[] s1, s2, s3;
            s1 = FormatMatrix(m1);
            s2 = FormatMatrix(m2);
            s3 = FormatMatrix(m3);
            string[] text = new string[s1.Length];
            for (int i = 0; i < s1.Length; ++i)
                if (i == s1.Length / 2)
                    text[i] = s1[i] + " - " + s2[i] + " = " + s3[i];
                else
                    text[i] = s1[i] + "   " + s2[i] + "   " + s3[i];
            WriteOperation(text);
            return m3;
        }

        /// <summary>
        /// Multiply 2 matrixes and draw equation.
        /// </summary>
        /// <param name="m1"> Matrix 1. </param>
        /// <param name="m2"> Matrix 2. </param>
        /// <returns> Multiplication of matrixes. </returns>
        static Matrix Mult(Matrix m1, Matrix m2, out bool error)
        {
            error = false;
            if (m1.Columns != m2.Rows)
            {
                error = true;
                error_message = "Размеры матриц не подходят для умножения.";
                return new Matrix();
            }
            Matrix m3 = m1 * m2;
            string[] s1, s2, s3;
            s1 = FormatMatrix(m1);
            s2 = FormatMatrix(m2);
            s3 = FormatMatrix(m3);
            int l1 = s1.Length;
            int l2 = s2.Length;
            int l3 = s3.Length;

            // Max height for correct drawing of matrixes.
            int max_height = Math.Max(Math.Max(l1, l2), l3);
            Array.Resize(ref s1, max_height);
            Array.Resize(ref s2, max_height);
            Array.Resize(ref s3, max_height);
            for (int i = l1; i < max_height; ++i)
            {
                s1[i] = "";
                for (int j = 0; j < s1[0].Length; ++j)
                    s1[i] += " ";
            }
            for (int i = l2; i < max_height; ++i)
            {
                s2[i] = "";
                for (int j = 0; j < s2[0].Length; ++j)
                    s2[i] += " ";
            }
            for (int i = l3; i < max_height; ++i)
            {
                s3[i] = "";
                for (int j = 0; j < s3[0].Length; ++j)
                    s3[i] += " ";
            }

            string[] text = new string[max_height];
            for (int i = 0; i < max_height; ++i)
                if (i == max_height / 2)
                    text[i] = s1[i] + " * " + s2[i] + " = " + s3[i];
                else
                    text[i] = s1[i] + "   " + s2[i] + "   " + s3[i];
            WriteOperation(text);
            return m3;
        }

        /// <summary>
        /// Get matrix from text presentation.
        /// </summary>
        /// <param name="text"> Text presentation of the matrix. </param>
        /// <param name="error"> Error </param>
        /// <returns></returns>
        static Matrix MatrixFromText(string[] text, out bool error)
        {
            error = false;
            int n = text.Length;
            int m = text[0].Split().Length;
            Matrix M = new Matrix(n, m);
            for (int i = 0; i < n; ++i)
            {
                string[] s_numbers = text[i].Split();
                if (s_numbers.Length != m)
                {
                    error_message = $"Нехватает чисел в {i + 1} строке. Их {s_numbers.Length}, а должно быть {m}";
                    error = true;
                    return M;
                }
                // Next number.
                double x = 0;
                for (int j = 0; j < m; ++j)
                    if (double.TryParse(s_numbers[j], out x))
                        M[i, j] = x;
                    else
                    {
                        error_message = "Матрица может содержать только числа.";
                        error = true;
                        return M;
                    }
            }
            return M;
        }

        /// <summary>
        /// Read matrix from keyboard.
        /// </summary>
        /// <param name="error"> Error. </param>
        static void ReadMatrix(out bool error)
        {
            error = false;
            Console.WriteLine("Введите матрицу, разделяя числа в строке пробелом, а строки - переводом строки.");
            Console.WriteLine("Чтобы закончить ввод введите пустую строку.");
            Console.WriteLine("");
            string line = " ";
            string[] text = new string[0];
            while (line != "")
            {
                line = Console.ReadLine();
                if (line != "")
                {
                    Array.Resize(ref text, text.Length + 1);
                    text[text.Length - 1] = line;
                }
            }

            Matrix M = MatrixFromText(text, out error);
            if (!error)
            {
                StoreMatrix(M);
                Console.WriteLine($"Матрица сохранена под номером {memory.Length - 1}");
            }
        }

        /// <summary>
        /// Read and store matrix from file.
        /// </summary>
        /// <param name="error"> Error. </param>
        static void ReadFromFile(out bool error)
        {
            error = false;
            Console.WriteLine("Введите относительный или полный путь к файлу с матрицей.");
            Console.WriteLine("Матрица должна содержать только числа - элементы матрицы," +
                              "разделённые пробелами или переводами строк");
            string[] text = new string[0];
            string path = Console.ReadLine();
            try
            {
                text = File.ReadAllLines(path);
            }
            catch (FileNotFoundException ex_fnf)
            {
                error = true;
                error_message = "Файл не найден." + System.Environment.NewLine + ex_fnf.Message;
                return;
            }
            catch (Exception ex)
            {
                error = true;
                error_message = ex.Message;
                return;
            }
            Matrix M = MatrixFromText(text, out error);
            if (!error)
            {
                StoreMatrix(M);
                if (write_all_ops)
                    Print(memory.Length - 1, out error);
                Console.WriteLine($"Матрица сохранена под номером {memory.Length - 1}");
            }
        }

        /// <summary>
        /// Create and store random matrix with given parameters.
        /// </summary>
        /// <param name="error"> Error. </param>
        static void RandomMatrix(out bool error)
        {
            error = false;
            int n = 0, m = 0;
            double lowerBound = 0, upperBound = 1;
            while (true)
            {
                Console.WriteLine("Введите количество строк (целое число не меньше 1):");
                if (int.TryParse(Console.ReadLine(), out n) && n >= 1)
                    break;
            }
            while (true)
            {
                Console.WriteLine("Введите количество столбцов (целое число не меньше 1):");
                if (int.TryParse(Console.ReadLine(), out m) && m >= 1)
                    break;
            }
            while (true)
            {
                Console.WriteLine("Введите минимальное возможное сгенерированное число:");
                if (double.TryParse(Console.ReadLine(), out lowerBound))
                    break;
            }
            while (true)
            {
                Console.WriteLine("Введите максимальное возможное сгенерированное число:");
                if (double.TryParse(Console.ReadLine(), out upperBound))
                    break;
            }

            Matrix M = new Matrix(n, m, rnd.Next(), lowerBound, upperBound);
            StoreMatrix(M);
            if (write_all_ops)
                Print(memory.Length - 1, out error);
            Console.WriteLine($"Матрица сохранена под номером {memory.Length - 1}");
        }
    }
}