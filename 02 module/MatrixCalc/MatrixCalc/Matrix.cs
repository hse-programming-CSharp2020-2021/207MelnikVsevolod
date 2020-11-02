using System;
namespace MatrixCalc
{
    /// <summary>
    /// Matrix of doubles.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// n and m - number of rows and columns.
        /// </summary>
        int n, m;

        /// <summary>
        /// M - matrix itself.
        /// </summary>
        double[,] M;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Matrix()
        {
            n = m = 1;
            M = new double[1, 1];
        }

        /// <summary>
        /// Constructor of zero matrix with given size.
        /// </summary>
        /// <param name="n"> Number of rows. </param>
        /// <param name="m"> Number of columns. </param>
        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            M = new double[n, m];
        }

        /// <summary>
        /// Constructor from 2-dimensional array.
        /// </summary>
        /// <param name="M"> 2-dimensional array. </param>
        public Matrix(double[,] M)
        {
            n = M.GetLength(0);
            m = M.GetLength(1);
            this.M = M;
        }

        /// <summary>
        /// Create random matrix of given size.
        /// </summary>
        /// <param name="n"> Number of rows. </param>
        /// <param name="m"> Number of columns. </param>
        /// /// <param name="seed">Seed for random.</param>
        /// <param name="lowerBound"> Lower bound of elements. </param>
        /// <param name="upperBound"> Upper bound of elements. </param>
        public Matrix(int n, int m, int seed, double lowerBound = 0, double upperBound = 1)
        {
            this.n = n;
            this.m = m;
            M = new double[n, m];
            if (lowerBound > upperBound)
                throw new Exception("Upper bound can't be less then lower bound");
            Random rnd = new Random(seed);
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    M[i, j] = rnd.NextDouble() * (upperBound - lowerBound) + lowerBound;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="m2"> Matrix to copy. </param>
        public Matrix(Matrix m2)
        {
            n = m2.Rows;
            m = m2.Columns;
            M = new double[n, m];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    M[i, j] = m2[i, j];
        }

        public int Rows
        {
            get
            {
                return n;
            }
        }

        public int Columns
        {
            get
            {
                return m;
            }
        }

        /// <summary>
        /// Returns transposed matrix.
        /// </summary>
        /// <returns> Transposed matrix. </returns>
        public Matrix Transpose()
        {
            double[,] Mt = new double[m, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    Mt[j, i] = M[i, j];
            return new Matrix(Mt);
        }

        /// <summary>
        /// Return minor of matrix without r row and c column.
        /// </summary>
        /// <param name="r"> Row not used in minor. </param>
        /// <param name="c"> Column not used in minor. </param>
        /// <returns> Minor without row r and column c. </returns>
        Matrix Minor(int r, int c)
        {
            double[,] Mn = new double[n - 1, m - 1];
            // Indexes of minor.
            int im, jm;
            im = jm = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (i != r && j != c)
                        Mn[im, jm++] = M[i, j];
                    if (jm == m - 1)
                    {
                        jm = 0;
                        ++im;
                    }
                }
            }
            return new Matrix(Mn);
        }

        /// <summary>
        /// Returns determinant using decomposition by column.
        /// </summary>
        public double Det
        {
            get
            {
                if (n != m)
                    throw new Exception("Can't get determinant of matrix with different n and m");
                double det = 0;
                if (n == 1)
                    return M[0, 0];
                // Sign of minor.
                int sign = 1;
                for (int i = 0; i < n; ++i)
                {
                    det += sign * M[i, 0] * Minor(i, 0).Det;
                    sign *= -1;
                }
                return det;
            }
        }

        /// <summary>
        /// Trace of the matrix.
        /// </summary>
        public double Trace
        {
            get
            {
                if (n != m)
                    throw new Exception("Can't get trace of matrix with different n and m");
                double tr = 0;
                for (int i = 0; i < n; ++i)
                    tr += M[i, i];
                return tr;
            }
        }

        /// <summary>
        /// Access to elements of matrix.
        /// </summary>
        /// <param name="x"> Row. </param>
        /// <param name="y"> Columns. </param>
        /// <returns> M[x, y] </returns>
        public double this[int x, int y]
        {
            get
            {
                return M[x, y];
            }
            set
            {
                M[x, y] = value;
            }
        }

        /// <summary>
        /// Multiply matrix on scalar.
        /// </summary>
        /// <param name="m"> Matrix. </param>
        /// <param name="s"> Scalar. </param>
        /// <returns> m1 * s </returns>
        public static Matrix operator *(Matrix m, double s)
        {
            Matrix ms = new Matrix(m);
            for (int i = 0; i < ms.Rows; ++i)
                for (int j = 0; j < ms.Columns; ++j)
                    ms[i, j] *= s;
            return ms;
        }

        /// <summary>
        /// Sum of matrixes.
        /// </summary>
        /// <param name="m1"> Matrix 1. </param>
        /// <param name="m2"> Matrix 2. </param>
        /// <returns> m1 + m2 </returns>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                throw new Exception("Matrixes are not compatible for sum.");
            Matrix sum = new Matrix(m1);
            for (int i = 0; i < m1.Rows; ++i)
                for (int j = 0; j < m1.Columns; ++j)
                    sum[i, j] += m2[i, j];
            return sum;
        }

        /// <summary>
        /// Substraction of matrixes.
        /// </summary>
        /// <param name="m1"> Matrix 1. </param>
        /// <param name="m2"> Matrix 2. </param>
        /// <returns> m1 - m2 </returns>
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                throw new Exception("Matrixes are not compatible for substraction.");
            Matrix sum = new Matrix(m1);
            for (int i = 0; i < m1.Rows; ++i)
                for (int j = 0; j < m1.Columns; ++j)
                    sum[i, j] -= m2[i, j];
            return sum;
        }

        /// <summary>
        /// Multiplication of matrixes.
        /// </summary>
        /// <param name="m1"> Matrix 1. </param>
        /// <param name="m2"> Matrix 2. </param>
        /// <returns> m1 * m2 </returns>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
                throw new Exception("Matrixes are not compatible for mutliplication.");
            Matrix mult = new Matrix(m1.Rows, m2.Columns);
            for (int i = 0; i < mult.Rows; ++i)
            {
                for (int j = 0; j < mult.Columns; ++j)
                {
                    for (int r = 0; r < m1.Columns; ++r)
                        mult[i, j] += m1[i, r] * m2[r, j];
                }
            }
            return mult;
        }

        /// <summary>
        /// Multiply row on number.
        /// (First elementary transformation)
        /// </summary>
        /// <param name="r"> Row. </param>
        /// <param name="x"> Number. </param>
        void MultRow(int r, double x)
        {
            for (int j = 0; j < m; ++j)
                M[r, j] *= x;
        }

        /// <summary>
        /// Swap 2 rows of numbers.
        /// (Second elementary transformation)
        /// </summary>
        /// <param name="r1"> First row. </param>
        /// <param name="r2"> Second row. </param>
        void Swap(int r1, int r2)
        {
            double t;
            for (int j = 0; j < m; ++j)
            {
                t = M[r1, j];
                M[r1, j] = M[r2, j];
                M[r2, j] = t;
            }
        }

        /// <summary>
        /// Multiply row on number and add to another row.
        /// (Third elementary transformation)
        /// </summary>
        /// <param name="r1"> First row. </param>
        /// <param name="r2"> Second row. </param>
        /// <param name="x"> Number to multiply first row. </param>
        void AddRow(int r1, int r2, double x)
        {
            for (int j = 0; j < m; ++j)
                M[r2, j] += M[r1, j] * x;
        }

        /// <summary>
        /// Checks if element is zero and round it if it's true.
        /// </summary>
        /// <param name="i"> Row. </param>
        /// <param name="j"> Columns. </param>
        /// <returns></returns>
        bool EqZero(int i, int j)
        {
            double e = 1e-8;
            if (Math.Abs(M[i, j]) < e)
            {
                M[i, j] = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Apply Gauss method to matrix.
        /// </summary>
        public void Gauss()
        {
            int i, j;
            i = j = 0;

            while (true)
            {
                // 1.
                if (!EqZero(i, j))
                {
                    MultRow(i, 1 / M[i, j]);
                    for (int k = 0; k < n; ++k)
                        if (k != i)
                            AddRow(i, k, -M[k, j] / M[i, j]);
                    if (i == n - 1 || j == m - 1)
                        break;
                    ++i;
                    ++j;
                    continue;
                }

                // 2.
                bool swaped = false;
                for (int k = i + 1; k < n; ++k)
                {
                    if (!EqZero(k, j))
                    {
                        Swap(i, k);
                        swaped = true;
                        break;
                    }
                }
                if (swaped)
                    continue;

                // 3.
                if (j == m - 1)
                    break;
                ++j;
            }
            for (i = 0; i < n; ++i)
                for (j = 0; j < m; ++j)
                    EqZero(i, j);
        }

        /// <summary>
        /// Make text presentation of matrix.
        /// </summary>
        /// <returns> Array of strings. </returns>
        public string[] Show()
        {
            // Formated numbers.
            string[,] numbers = new string[n, m];
            // Max length for cenetring numbers.
            int max_length = 0;
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                {
                    numbers[i, j] = string.Format("{0:F1}", M[i, j]);
                    if (numbers[i, j].Length > max_length)
                        max_length = numbers[i, j].Length;
                }

            // Moving short numbers to the right so "." will be on same level.
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                {
                    int l1 = numbers[i, j].Length;
                    for (int k = l1; k < max_length; ++k)
                        numbers[i, j] = " " + numbers[i, j];
                }
            string[] str = new string[n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    str[i] = str[i] + string.Format("{0} ", numbers[i, j]);
            return str;
        }
    }
}
