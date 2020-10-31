using System;
using System.IO;

namespace MatrixCalc
{
    partial class Program
    {
        /// <summary>
        /// Checks if solution exists.
        /// </summary>
        /// <param name="m"> Matrix in canonical form. </param>
        /// <returns> True if solutions exists, false if it does not. </returns>
        static bool SolutionExists(Matrix m)
        {
            for (int i = 0; i < m.Rows; ++i)
            {
                bool zeros = true;
                for (int j = 0; j < m.Columns - 1; ++j)
                    if (m[i, j] != 0)
                        zeros = false;
                if (zeros && m[i, m.Columns - 1] != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Print how SLE was solved.
        /// </summary>
        /// <param name="m"> Extended matrix. </param>
        /// <param name="m2"> Extended matrix in canonical form. </param>
        static void PrintHowSolved(Matrix m, Matrix m2)
        {
            string[] s1, s2;
            s1 = FormatMatrix(m);
            s2 = FormatMatrix(m2);
            int l1 = s1.Length;

            string[] text = new string[l1];

            string op = " -> ";
            string space = "    ";

            for (int i = 0; i < l1; ++i)
                if (i == l1 / 2)
                    text[i] = s1[i] + op + s2[i];
                else
                    text[i] = s1[i] + space + s2[i];
            WriteOperation(text);
        }

        /// <summary>
        /// Print solution of the SLE.
        /// </summary>
        /// <param name="is_defined"> Is x[i] defined. </param>
        /// <param name="any_number"> Is x[i] can be any number. </param>
        /// <param name="x"> Defined part of x[i]. </param>
        /// <param name="formulas"> Formula of undefined part of x[i]. </param>
        static void PrintSolution(bool[] is_defined, bool[] any_number, double[] x, string[] formulas)
        {
            for (int j = 0; j < x.Length; ++j)
            {
                Console.Write($"X{j} = ");
                if (is_defined[j])
                    Console.WriteLine(x[j]);
                else if (any_number[j])
                    Console.WriteLine("любое вещественное число");
                else
                {
                    Console.Write(x[j]);
                    Console.WriteLine(formulas[j]);
                }
            }
        }

        /// <summary>
        /// Solve a system of linear equations.
        /// Print result on the screen.
        /// </summary>
        /// <param name="m"> Extended matrix, that presents SLE. </param>
        static void Solve(Matrix m)
        {
            // Apply gauss method to the matrix.
            Matrix m2 = new Matrix(m);
            m2.Gauss();
            PrintHowSolved(m, m2);

            // Find solutions.
            if (!SolutionExists(m2))
            {
                Console.WriteLine("Решений нет.");
                return;
            }
            // is_defined - true if x[i] is a number, false if not.
            bool[] is_defined = new bool[m2.Columns - 1];
            // any_number - true if x[i] can be any number, false if not.
            bool[] any_number = new bool[m2.Columns - 1];
            double[] x = new double[m2.Columns - 1];
            // formulas - formulas of undefined parts of x[i].
            string[] formulas = new string[m2.Columns - 1];

            for (int j = 0; j < m2.Columns - 1; ++j)
                any_number[j] = true;

            for (int i = m2.Rows - 1; i >= 0; --i)
            {
                int first_elem = -1;
                for (int j = 0; j < m2.Columns - 1; ++j)
                    if (m2[i, j] != 0 && first_elem == -1)
                        first_elem = j;
                if (first_elem == -1)
                    continue;
                bool def = true;
                any_number[first_elem] = false;
                x[first_elem] = m2[i, m2.Columns - 1];
                for (int j = first_elem + 1; j < m2.Columns - 1; ++j)
                {
                    if (is_defined[j])
                        x[first_elem] += -m2[i, j] * x[j];
                    else if (m2[i, j] != 0)
                        formulas[first_elem] += $" -X{j} * {m2[i, j]}";
                    if (m2[i, j] != 0 && !is_defined[j])
                        def = false;
                }
                if (def)
                    is_defined[first_elem] = true;
            }
            PrintSolution(is_defined, any_number, x, formulas);
        }
    }
}