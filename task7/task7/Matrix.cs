using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    public sealed class Matrix : ICloneable, IEnumerable, IEnumerator
    {
        private ushort _size;
        private int _position = -1;
        private double[,] _matrix;
 
        public Matrix(ushort size)
        {
            _size = size;
            _matrix = new double[_size,_size];
        
        }
        public Matrix(ushort size, double value)
        {
            _size = size;
            _matrix = new double[_size, _size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _matrix[i, j] = value;
                }
            }

        }
        public Matrix(Matrix source)
        {
            _size = source._size;
            _matrix = new double[_size, _size];
            for (var j = 0; j < _size; j++)
            {
                for (var i = 0; i < _size; i++)
                {
                    _matrix[j, i] = source._matrix[j, i];
                }
            }
        }
        public Matrix(ushort size, bool e)
        {
            _size = size;
            _matrix = new double[_size, _size];
            for (int i = 0; i < _size; i++)
            {
                _matrix[i, i] = 1;
            }

        }

        public void Init()
        {
            Random random = new Random();
            for (var j = 0; j < _size; j++)
            {
                
                for (var i = 0; i < _size; i++)
                {
                    
                    _matrix[j,i] = random.Next()%10;
                }
            }
        }

        public override string ToString()
        {
           
                StringBuilder str = new StringBuilder();
                for (var j = 0; j < _size; j++)
                {

                    for (var i = 0; i < _size; i++)
                    {

                        str.Append(Math.Round(_matrix[j,i], 10) + " ");
                    }
                    str.Append("\n");
                
            }

            return str.ToString();
        }


        public static Matrix operator +(Matrix left, Matrix right)
        {
            //TODO make test for eqal size matrix
            if(left._size!=right._size) throw new MatrixException("Matrix's sizes must be eqals!");
            Matrix tmp = left;
            for (var j = 0; j < left._size; j++)
            {
                for (var i = 0; i < left._size; i++)
                {
                    tmp._matrix[j, i] += right._matrix[j, i];
                }
            }
            return tmp;
        }
        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (left._size != right._size) throw new MatrixException("Matrix's sizes must be eqals!");

            Matrix tmp = left;
            for (var j = 0; j < left._size; j++)
            {
                for (var i = 0; i < left._size; i++)
                {
                    tmp._matrix[j, i] -= right._matrix[j, i];
                }
            }
            return tmp;
        }
        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left._size != right._size) throw new MatrixException("Matrix's sizes must be eqals!");

            Matrix tmp = new Matrix(left._size);
            for (var j = 0; j < left._size; j++) // строка 1
            {
                for (var i = 0; i < left._size; i++) //столбец 2
                {
                    for (var k = 0; k < left._size; k++) //строка 2 столбец 1
                    {
                        tmp._matrix[j, i] += left._matrix[j, k] * right._matrix[k,i];
                    }
                }
            }
            return tmp;
        }
        public static Matrix operator /(Matrix left, Matrix right)
        {
            //TODO make test for eqal size matrix
            if (left._size != right._size) throw new MatrixException("Matrix's sizes must be eqals!");

            return left * right.Reverse();
        }

        public static Matrix operator +(Matrix left, double right)
        {
            Matrix tmp = new Matrix(left);
            for (int i = 0; i < left._size; i++)
            {
                for (int j = 0; j < left._size; j++)
                {
                    tmp._matrix[i,j] += right;
                }
            }

            return tmp;
        }
        public static Matrix operator -(Matrix left, double right)
        {
            Matrix tmp = new Matrix(left);
            for (int i = 0; i < left._size; i++)
            {
                for (int j = 0; j < left._size; j++)
                {
                    tmp._matrix[i, j] -= right;
                }
            }

            return tmp;
        }
        public static Matrix operator *(Matrix left, double right)
        {
            Matrix tmp = new Matrix(left);
            for (int i = 0; i < left._size; i++)
            {
                for (int j = 0; j < left._size; j++)
                {
                    tmp._matrix[i, j] *= right;
                }
            }

            return tmp;
        }
        public static Matrix operator /(Matrix left, double right)
        {
            Matrix tmp = new Matrix(left);
            for (int i = 0; i < left._size; i++)
            {
                for (int j = 0; j < left._size; j++)
                {
                    tmp._matrix[i, j] /= right;
                }
            }

            return tmp;
        }

        public static Matrix operator +(double left, Matrix right)
        {
            Matrix tmp = new Matrix(right);
            for (int i = 0; i < right._size; i++)
            {
                for (int j = 0; j < right._size; j++)
                {
                    tmp._matrix[i, j] += left;
                }
            }

            return tmp;
        }
        public static Matrix operator *(double left, Matrix right)
        {
            Matrix tmp = new Matrix(right);
            for (int i = 0; i < right._size; i++)
            {
                for (int j = 0; j < right._size; j++)
                {
                    tmp._matrix[i, j] *= left;
                }
            }

            return tmp;
        }


        public Matrix Transponse()
        {
            Matrix tmp = new Matrix(this._size);
            for (var j = 0; j <_size; j++)
            {
                for (var i = 0; i < _size; i++)
                {
                    tmp._matrix[j, i] = _matrix[i, j];
                }
            }

            return tmp;
        }

        public Matrix Reverse()
        {
            Matrix tmp=new Matrix(_size);
            if (Determinant()==0) throw new MatrixException("Determinant should not equal zero!");

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    tmp._matrix[i, j] = GetAdjugateMatrix()._matrix[j,i]/Determinant();
                   
                }
            }
            return tmp;
        }

        private Matrix GetAdjugateMatrix()
        {
            Matrix tmp = new Matrix(_size);
            int sign = 1;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    tmp._matrix[i, j] = Minor((ushort)i, (ushort)j).Determinant()*sign;
                    sign = -sign;
                }
            }

            return tmp;
        }

        public object Clone()
        {
            return new Matrix(this);
        }
        /// <summary>
        /// Вычеркнуть из _matrix col столбец row строку
        /// </summary>
        public Matrix Minor(ushort row, ushort col)
        {
            Matrix result = new Matrix((ushort)(_size-1));
            ushort _i = 0;
            ushort _j = 0;
            for (int i = 0; i < _size; i++)
            {
                _j = 0;
                if (i == row) continue;
                for (int j = 0; j < _size; j++)
                {
                    if (j == col) continue;
                    result._matrix[_i, _j++] = _matrix[i, j];

                }

                _i++;
            }

            return result;
        }

        public double Determinant()
        {
            int k = 1;
            double res = 0;
            if (_matrix.Length == 1)
                return _matrix[0, 0];
            if (_matrix.Length == 4)
                return _matrix[0, 0] * _matrix[1, 1] - _matrix[1, 0] * _matrix[0, 1];

            for (int i = 0; i < _size; i++)
            {
                res += k * _matrix[0, i] * Minor(0, (ushort)i).Determinant();
                k = -k;
            }
            return res;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _matrix.Length);
        }
        public void Reset()
        {
            _position = 0;
        }
        public object Current
        {
            get { return _matrix[_position / _size, _position % _size]; }
        }

        public IEnumerator GetEnumerator()
        {
           return _matrix.GetEnumerator();
        }
    }
}
