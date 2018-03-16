using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Log(2));
            Console.WriteLine( LN2_1());
        }

        static decimal E()
        {
            decimal result = Decimal.One;
            decimal factorial = Decimal.One;
            for (int i = 1; i < 20; i++)
            {
                factorial *= i;
                result += Decimal.One / factorial;
            }
            return result;
        }

        static decimal PI()
        {
            decimal result = 3;
            decimal coef = 4;
            for (long i = 2; i < 100000; i+=4)
            {
                    result += coef / (i * (i + 1) * (i + 2));
                    result -= coef / ((i+2) * (i + 3) * (i + 4));
            }
        return result;
        }

        /// <summary>
        /// Логарифм 2 с помощью ряда Тейлора
        /// </summary>
        static decimal LN2_1()
        {
            decimal result = 0;
            for (long i = 1; i < 1000000; i++)
            {
                result += (decimal) (1 / (i*Math.Pow(2,i)));
            }
            return result;
        }
        static decimal SQRT2_1()
        {
            decimal result = 0;
            for (long i = 1; i < 1000000; i++)
            {
                result += (decimal)(1 / (i * Math.Pow(2, i)));
            }
            return result;
        }
    }
}
