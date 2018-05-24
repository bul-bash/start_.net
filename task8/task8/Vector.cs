using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    internal class Vector<T> : IEnumerable<T>, ICloneable
    where T : IArithmeticOperations<T>, new()
    {
        private readonly List<T> _numbers;
        private static readonly ArefmeticOperations<T> _operations;

        static Vector()
        {
            _operations = ArefmeticOperations<T>.Instance;
        }

        public Vector()
        {
            _numbers = new List<T>();
        }

        public static T Norm(Vector<T> vector)
        {
            var result = new T();
            foreach (var item in vector)
                result = _operations.Add(result, _operations.Multiply(item, item));
            result = _operations.Multiply(result, result);
            return result;
        }

        public Vector(IEnumerable<T> numbers)
            : this()
        {
            foreach (var item in numbers)
                _numbers.Add(item);
        }

        public static T ScalarMultiplication(Vector<T> left, Vector<T> right)
        {
            var result = new T();
            for (var i = 0; i < left._numbers.Count; i++)
                result = _operations.Add(result, _operations.Multiply(left._numbers[i], right._numbers[i]));

            return result;

        }

        public static Vector<T> Add(Vector<T> left, Vector<T> right)
        {
            if (left._numbers.Count != right._numbers.Count)
                throw new Exception("Вектора разных размеров");

            var result = new Vector<T>();
            for (var i = 0; i < left._numbers.Count; i++)
                result._numbers.Add(_operations.Add(left._numbers[i], right._numbers[i]));

            return result;
        }

        public static Vector<T> UnaryMinus(Vector<T> vector)
        {
            var result = new Vector<T>();

            foreach (var item in vector._numbers)
                result._numbers.Add(_operations.UnaryMinus(item));

            return result;
        }

        public static Vector<T> Subtraction(Vector<T> left, Vector<T> right)
        {
            return Add(left, UnaryMinus(right));
        }

        public static Vector<T> Multipliction(Vector<T> vector, T number)
        {
            var result = new Vector<T>();
            foreach (var item in vector)
                result._numbers.Add(_operations.Multiply(item, number));
            return result;
        }

        public static Vector<T> operator +(Vector<T> left, Vector<T> right)
        {
            return Add(left, right);
        }

        public static Vector<T> operator -(Vector<T> left, Vector<T> right)
        {
            return Subtraction(left, right);
        }

        public static Vector<T> operator -(Vector<T> vector)
        {
            return UnaryMinus(vector);
        }

        public static Vector<T> operator *(Vector<T> vector, T number)
        {
            return Multipliction(vector, number);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _numbers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static bool operator ==(Vector<T> left, Vector<T> right)
        {
            if (left == null || right == null)
                throw new Exception("Один из аргументов нулевой");

            var result = Norm(left) == (dynamic)Norm(right);

            return result;
        }

        public static bool operator !=(Vector<T> left, Vector<T> right)
        {
            return !(left == right);
        }

        public static bool operator >(Vector<T> left, Vector<T> right)
        {
            if (left == null || right == null)
                throw new Exception("Один из аргументов нулевой");

            var result = Norm(left) > (dynamic)Norm(right);

            return result;
        }

        public static bool operator <(Vector<T> left, Vector<T> right)
        {
            if (left == null || right == null)
                throw new Exception("Один из аргументов нулевой");

            var result = Norm(left) < (dynamic)Norm(right);

            return result;
        }

        public static bool operator <=(Vector<T> left, Vector<T> right)
        {
            if (left == null || right == null)
                throw new Exception("Один из аргументов нулевой");

            var result = Norm(left) <= (dynamic)Norm(right);

            return result;
        }

        public static bool operator >=(Vector<T> left, Vector<T> right)
        {
            if (left == null || right == null)
                throw new Exception("Один из аргументов нулевой");

            var result = Norm(left) >= (dynamic)Norm(right);

            return result;
        }

        public static IEnumerable<Vector<T>> Orthogonalization(IEnumerable<Vector<T>> vectors)
        {
            var resultVectors = new List<Vector<T>>();
            var tmpVectors = vectors.ToList();

            for (var i = 0; i < tmpVectors.Count; i++)
            {
                var tmpVector = (Vector<T>)tmpVectors[i].Clone();

                for (var j = 0; j < resultVectors.Count; j++)
                    tmpVector -= Proj(tmpVectors[i], resultVectors[j]);

                resultVectors.Add(tmpVector);
            }

            return resultVectors;
        }

        private static Vector<T> Proj(Vector<T> a, Vector<T> b)
        {
            var result = b * (_operations.Divide(ScalarMultiplication(a, b), ScalarMultiplication(b, b)));
            return result;
        }

        public static explicit operator T[] (Vector<T> vector)
        {
            return (T[])vector._numbers.ToArray().Clone();
        }

        public static explicit operator Vector<T>(T[] array)
        {
            return new Vector<T>(array);
        }

        public object Clone()
        {
            var result = new Vector<T>();

            foreach (var item in _numbers)
                result._numbers.Add(item);

            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("{");
            for (var i = 0; i < _numbers.Count; i++)
            {
                result.Append(_numbers[i]);

                if (i < _numbers.Count - 1)
                    result.Append(", ");
            }
            result.Append("}");

            return result.ToString();
        }
    }
}
