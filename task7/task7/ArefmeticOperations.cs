using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    public class ArefmeticOperations<T>
        where T : IArithmeticOperations<T>
    {
        private static ArefmeticOperations<T> _instance;

        private ArefmeticOperations() { }

        public static ArefmeticOperations<T> Instance =>
            _instance ?? (_instance = new ArefmeticOperations<T>());

        public T Add(T a, T b)
        {
            return a.Add(a, b);
        }

        public T Multiply(T a, T b)
        {
            return a.Multiplication(a, b);
        }

        public T Subtract(T a, T b)
        {
            return a.Subtraction(a, b);
        }

        public T Divide(T a, T b)
        {
            return a.Division(a, b);
        }
    }
}
