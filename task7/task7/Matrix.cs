using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    public sealed class Matrix : ICloneable
    {
        private ushort _size;

        private double[,] _matrix;
 //       private ArrayList<double, double> = new Array();
        public Matrix(ushort size)
        {
            _size = size;
            _matrix = new double[_size,_size];
        
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

                        str.Append(_matrix[j,i] + " ");
                    }
                    str.Append("\n");

            }

            return str.ToString();
        }

        public Matrix(Matrix source)
        {
            _size = source._size;
            _matrix = new double[_size,_size];
            for (var j = 0; j < _size; j++)
            {
                for (var i = 0; i < _size; i++)
                {
                    _matrix[j, i] = source._matrix[j, i];
                }
            }
        }


        public static Matrix Add(Matrix left, Matrix right)
        {
            //TODO make test for eqal size matrix
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
        public static Matrix Sub(Matrix left, Matrix right)
        {
            //TODO make test for eqal size matrix
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
        public static Matrix Mul(Matrix left, Matrix right)
        {
            //TODO make test for eqal size matrix
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

        public double Determinant()
        {
            int sign = 1;
            for (int i = 1; i < _size; i++)
            {
                for (int j = i; j < _size; j++)
                {
                    
                    double coef = _matrix[i - 1, j - 1] / _matrix[i, j - 1];
                    _matrix[i, j] = _matrix[i - 1, j] - coef * _matrix[i, j];
                }
            }

            double det = 1;
            for (int i = 0; i < _size; i++)
            {
                det *= _matrix[i, i];
            }

            return det;
        }
        public Matrix Reverse()
        {
            Matrix tmp=new Matrix(_size);
            return tmp;
        }
        public object Clone()
        {
            return new Matrix(this);
        }
        /// <summary>
        /// Вычеркнуть из _matrix col столбец row строку
        /// </summary>
        public Matrix Minor(ushort col, ushort row)
        {
            Matrix result = new Matrix((ushort)(_size-1));
            ushort _i = 0;
            ushort _j = 0;
            for (int i = 1; i < _size; i++)
            {
                _j = 0;
                if (i == col) continue;
                for (int j = i; j < _size; j++)
                {
                    if (j == row) continue;
                    result._matrix[_i, _j++] = _matrix[i, j];

                }

                _i++;
            }

            return result;
        }
    }
}
