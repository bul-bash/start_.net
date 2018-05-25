using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{

    public class Polynom<T> : ICloneable, IEnumerable<KeyValuePair<int, T>> where T : IArithmeticOperations<T>, IEquatable<T>
    {
        private SortedDictionary<int, T> _polynom = new SortedDictionary<int, T>();
        private static ArefmeticOperations<T> _operations;

        //private const string Pattern = @"([-+]?\d+\.\d+|[-+]?\d*)((?:x(?:\^-?\d+)?)?)";

        static Polynom()
        {
            _operations = ArefmeticOperations<T>.Instance;
        }

        public T this[int index]
        {
            get => _polynom[index];
            set => _polynom[index] = value;
        }

        public KeyValuePair<int, T> this[KeyValuePair<int, T> kek]
        {
            set => _polynom.Add(value.Key, value.Value);
        }



        public Polynom()
        {
        }

        public Polynom(IDictionary<int, T> dictionary)
        {
            foreach (var item in dictionary)
            {
                _polynom.Add(item.Key, item.Value);
            }
        }

        public Polynom(params KeyValuePair<int, T>[] itemOfPolynom)
        {
            foreach (var item in itemOfPolynom)
                _polynom.Add(item.Key, item.Value);

        }



        public static Polynom<T> Add(Polynom<T> polynom1, Polynom<T> polynom2)
        {
            var resPolynom = (Polynom<T>)polynom1.Clone();

            foreach (var item in polynom2._polynom)
            {
                if (resPolynom._polynom.ContainsKey(item.Key))
                    resPolynom._polynom[item.Key] = _operations.Add(resPolynom._polynom[item.Key], item.Value);
                else resPolynom._polynom.Add(item.Key, item.Value);
            }

            return resPolynom.Simplify();
        }

        public static Polynom<T> Subtraction(Polynom<T> polynom1, Polynom<T> polynom2)
        {
            return Add(polynom1, -polynom2);
        }

        public static Polynom<T> UnaryMinus(Polynom<T> polynom)
        {
            var resPolynom = new Polynom<T>();

            foreach (var item in polynom._polynom)
                resPolynom._polynom.Add(item.Key, -(dynamic)item.Value);

            return resPolynom.Simplify();
        }

        public static Polynom<T> Division(Polynom<T> polynom1, Polynom<T> polynom2)
        {
            var copyPolynom1 = (Polynom<T>)polynom1.Clone();
            var resPolynom = new Polynom<T>();

            var maxMonomPolynom1 = new KeyValuePair<int, T>(polynom1._polynom.Last().Key, polynom1._polynom.Last().Value);
            var maxMonomPolynom2 = new KeyValuePair<int, T>(polynom2._polynom.Last().Key, polynom2._polynom.Last().Value);


            while (maxMonomPolynom1.Key >= maxMonomPolynom2.Key)
            {
                if (maxMonomPolynom2.Value.Equals(_operations.Subtract(maxMonomPolynom2.Value, maxMonomPolynom2.Value)))
                    throw new Exception("Деление на ноль");

                maxMonomPolynom1 = new KeyValuePair<int, T>(maxMonomPolynom1.Key - maxMonomPolynom2.Key,
                    _operations.Divide(maxMonomPolynom1.Value, maxMonomPolynom2.Value));

                if (maxMonomPolynom1.Value.Equals(_operations.Subtract(maxMonomPolynom2.Value, maxMonomPolynom2.Value)))
                    break;

                if (!resPolynom._polynom.ContainsKey(maxMonomPolynom1.Key))
                    resPolynom._polynom.Add(maxMonomPolynom1.Key, maxMonomPolynom1.Value);
                else resPolynom._polynom[maxMonomPolynom1.Key] = _operations.Add(resPolynom._polynom[maxMonomPolynom1.Key], maxMonomPolynom1.Value);

                var tmp = new Polynom<T>();
                tmp._polynom.Add(maxMonomPolynom1.Key, maxMonomPolynom1.Value);

                tmp *= polynom2;
                copyPolynom1 -= tmp;

                copyPolynom1 = copyPolynom1.Simplify();
                maxMonomPolynom1 = new KeyValuePair<int, T>(copyPolynom1._polynom.Last().Key, copyPolynom1._polynom.Last().Value);
            }

            return resPolynom.Simplify();
        }

        public Polynom<T> Simplify()
        {
            var resPolynom = new Polynom<T>();

            foreach (var item in _polynom)
                if (!item.Value.Equals(0))
                    resPolynom._polynom.Add(item.Key, item.Value);

            return resPolynom;
        }

        public static Polynom<T> Multiplication(Polynom<T> polynom1, Polynom<T> polynom2)
        {
            var resPolynom = new Polynom<T>();

            foreach (var item1 in polynom1._polynom)
            {
                foreach (var item2 in polynom2._polynom)
                {
                    if (resPolynom._polynom.ContainsKey(item1.Key + item2.Key))
                        resPolynom._polynom[item1.Key + item2.Key] = _operations.Add(resPolynom._polynom[item1.Key + item2.Key], _operations.Multiply(item1.Value, item2.Value));
                    else resPolynom._polynom.Add(item1.Key + item2.Key, _operations.Multiply(item1.Value, item2.Value));
                }
            }

            return resPolynom.Simplify();
        }

        public static Polynom<T> operator +(Polynom<T> polynom1, Polynom<T> polynom2)
        {
            return Add(polynom1, polynom2);
        }

        public static Polynom<T> operator -(Polynom<T> polynom1, Polynom<T> polynom2)
        {
            return Subtraction(polynom1, polynom2);
        }

        public static Polynom<T> operator -(Polynom<T> polynom)
        {
            return UnaryMinus(polynom);
        }

        public static Polynom<T> operator *(Polynom<T> polynom1, Polynom<T> polynom2)
        {
            return Multiplication(polynom1, polynom2);
        }

        public static Polynom<T> operator /(Polynom<T> polynom1, Polynom<T> polynom2)
        {
            return Division(polynom1, polynom2);
        }

        public object Clone()
        {
            var resPolynom = new Polynom<T>();

            foreach (var item in _polynom)
                resPolynom._polynom.Add(item.Key, item.Value);

            return resPolynom;
        }

        public IEnumerator<KeyValuePair<int, T>> GetEnumerator()
        {
            return _polynom.GetEnumerator();
        }

        public override string ToString()
        {
            var resString = new StringBuilder();
            var tmpPolynom = _polynom.Reverse().ToArray();

            foreach (var item in tmpPolynom)
            {
                if (item.Key != tmpPolynom.First().Key && (dynamic)item.Value > 0)
                    resString.Append("+");
                resString.Append(item.Value);
                if (!item.Key.Equals(0)) resString.Append("x");
                if (!item.Key.Equals(0) && item.Key != 1) resString.Append("^" + item.Key);
            }

            return resString.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
