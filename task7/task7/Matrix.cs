using System;
using System.Collections;
using System.Text;

namespace task7
{
    public class Matrix : ICloneable, IEnumerable, IArithmeticOperations<Matrix>, IEquatable<Matrix>
    {
        private double[,] _coefficients;
        public double[,] Coefficients
        {
            get => _coefficients;
            set => _coefficients = (double[,])value.Clone();
        }

        private int _size = 0;
        public int Size => _size;

        public Matrix(params double[] coefficients)
        {
            var sqrt = Math.Sqrt(coefficients.Length);
            _size = sqrt - (int)sqrt > 0 ? (int)sqrt + 1 : (int)sqrt;
            _coefficients = new double[_size, _size];

            int x = 0, y = 0;
            foreach (var value in coefficients)
            {
                if (y == _size)
                {
                    x++;
                    y = 0;
                }
                _coefficients[x, y++] = value;
            }
        }

        public Matrix(int size = 0)
        {
            _size = size;
            _coefficients = new double[size, size];
        }

        public Matrix()
        {
            _size = 0;
            _coefficients = new double[_size, _size];
        }


        public object Clone()
        {
            var matrix = new Matrix(_size) { Coefficients = (double[,])Coefficients.Clone() };
            return matrix;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _coefficients.GetEnumerator();
        }

        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1._size != matrix2._size)
                throw new MatrixException("Матрицы разного размера");

            var resMatrix = new Matrix(matrix1._size);

            for (var x = 0; x < matrix1._size; x++)
                for (var y = 0; y < matrix1._size; y++)
                    resMatrix.Coefficients[x, y] = matrix1.Coefficients[x, y] + matrix2.Coefficients[x, y];

            return resMatrix;
        }

        Matrix IArithmeticOperations<Matrix>.Add(Matrix a, Matrix b)
        {
            return Add(a, b);
        }

        Matrix IArithmeticOperations<Matrix>.Multiplication(Matrix a, Matrix b)
        {
            return Multiplication(a, b);
        }

        Matrix IArithmeticOperations<Matrix>.Subtraction(Matrix a, Matrix b)
        {
            return Subtraction(a, b);
        }

        Matrix IArithmeticOperations<Matrix>.Division(Matrix a, Matrix b)
        {
            return Division(a, b);
        }

        public static Matrix Subtraction(Matrix matrix1, Matrix matrix2)
        {
            return Add(matrix1, -matrix2);
        }

        public static Matrix Multiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1._size != matrix2._size)
                throw new MatrixException("Матрицы разного размера");

            var resMatrix = new Matrix(matrix1._size);

            for (var x = 0; x < matrix1._size; x++)
                for (var y = 0; y < matrix1._size; y++)
                    for (var t = 0; t < matrix1._size; t++)
                        resMatrix.Coefficients[x, y] += matrix1.Coefficients[x, t] * matrix2.Coefficients[t, y];

            return resMatrix;
        }

        public static Matrix MultiplicationOnNumber(Matrix matrix, double k)
        {
            var resMatrix = (Matrix)matrix.Clone();

            for (var x = 0; x < matrix._size; x++)
                for (var y = 0; y < matrix._size; y++)
                    resMatrix.Coefficients[x, y] *= k;

            return resMatrix;
        }

        public static Matrix UnaryMinus(Matrix matrix)
        {
            var resMatrix = new Matrix(matrix._size);

            for (var x = 0; x < matrix._size; x++)
                for (var y = 0; y < matrix._size; y++)
                    resMatrix.Coefficients[x, y] = -matrix.Coefficients[x, y];

            return resMatrix;
        }

        public static Matrix Division(Matrix matrix1, Matrix matrix2)
        {
            var resMatrix = Multiplication(matrix1, matrix2.Reverse());

            return resMatrix;
        }

        public Matrix Transpose()
        {
            var resMatrix = new Matrix(_size);

            for (var x = 0; x < _size; x++)
                for (var y = 0; y < _size; y++)
                    resMatrix.Coefficients[x, y] = Coefficients[y, x];

            return resMatrix;
        }

        public double Determinant()
        {
            double det = 1;
            var copy = (double[,])Coefficients.Clone();

            for (var j = 0; j < _size - 1; j++)
                for (var i = j + 1; i < _size; i++)
                {
                    if (copy[i, j].Equals(0)) continue;

                    if (copy[j, j].Equals(0))
                        for (var l = 0; l < _size; l++)
                            copy[j, l] = copy[j, l] + copy[i, l];

                    var tmp = -(copy[i, j] / copy[j, j]);

                    for (var l = 0; l < _size; l++)
                        copy[i, l] = copy[i, l] + (tmp * copy[j, l]);
                }

            for (var i = 0; i < _size; i++)
                det *= copy[i, i];

            return det;
        }

        public Matrix GetMinor(int a, int b)
        {
            var resMatrix = new Matrix(_size - 1);
            int x = 0, y = 0;

            for (var i = 0; i < _size; i++)
                for (var j = 0; j < _size; j++)
                {
                    if (i == a || j == b) continue;

                    resMatrix.Coefficients[x, y++] = Coefficients[i, j];

                    if (y != resMatrix._size) continue;

                    y = 0;
                    x++;
                }

            return resMatrix;
        }

        public Matrix Reverse()
        {
            var resMatrix = (Matrix)Clone();

            var det = Determinant();

            if (det.Equals(0))
                throw new MatrixException("No reverce matirx");

            for (var i = 0; i < resMatrix._size; i++)
                for (var j = 0; j < resMatrix._size; j++)
                {
                    var tmp = GetMinor(i, j);
                    resMatrix.Coefficients[i, j] = tmp.Determinant() * Math.Pow(-1, (i + j + 2));
                }

            resMatrix = resMatrix.Transpose();
            resMatrix *= (dynamic)1 / det;

            return resMatrix;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            return Add(matrix1, matrix2);
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            return Subtraction(matrix1, matrix2);
        }

        public static Matrix operator -(Matrix matrix)
        {
            return UnaryMinus(matrix);
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            return Multiplication(matrix1, matrix2);
        }

        public static Matrix operator *(Matrix matrix, double k)
        {
            return MultiplicationOnNumber(matrix, k);
        }

        public static Matrix operator /(Matrix matrix1, Matrix matrix2)
        {
            return Division(matrix1, matrix2);
        }

        public static bool operator >(Matrix matrix, double num)
        {
            return true;
        }

        public static bool operator <(Matrix matrix, double num)
        {
            return false;
        }

        public static bool operator ==(Matrix left, Matrix right)
        {
            var result = true;

            if ((object)right == null || (object)left == null)
                throw new Exception("Один из полиномов не инициализирован");

            if (left.Size != right.Size)
                result = false;
            else
            {
                for (var i = 0; i < left.Size; i++)
                    for (var j = 0; j < left.Size; j++)
                    {
                        if (left.Coefficients[i, j] != right.Coefficients[i, j])
                        {
                            result = false;
                            break;
                        }

                        if (result == false) break;
                    }
            }

            return result;
        }

        public static bool operator !=(Matrix left, Matrix right)
        {
            return !(left == right);
        }

        public bool Equals(Matrix other)
        {
            var result = other.Size == Size;

            if (result)
                for (var i = 0; i < other.Size; i++)
                {
                    if (!result) break;
                    for (var j = 0; j < other.Size; j++)
                    {
                        if (_coefficients[i, j] != other._coefficients[i, j])
                            result = false;
                        break;
                    }
                }

            return result;
        }

        public override string ToString()
        {
            var strMatrix = new StringBuilder();

            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                {
                    strMatrix.Append("[");
                    strMatrix.Append(Coefficients[i, j]);
                    strMatrix.Append("]");
                }
                if (i < _size - 1) strMatrix.Append("|");
            }

            return strMatrix.ToString();
        }
    }
}
