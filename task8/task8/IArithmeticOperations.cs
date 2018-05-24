using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    public interface IArithmeticOperations<T>
    {
        T Add(T a, T b);
        T Multiplication(T a, T b);
        T Subtraction(T a, T b);
        T Division(T a, T b);
        T UnaryMinus(T a);
    }
}
