using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    public sealed class Polynom<T> : IEnumerable, IEnumerator, ICloneable
    {

        private readonly Dictionary<uint, T> _polynomData;

        Polynom()
        {
            _polynomData = new Dictionary<uint, T>();
        }
        Polynom(Dictionary<uint, T> polynomData)
        {
            _polynomData = polynomData;
        }




        public object Current => throw new NotImplementedException();

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
