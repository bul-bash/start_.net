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
            Console.WriteLine( LN2());
        }

        static decimal E()
        {
            decimal e = Decimal.One;
            decimal f = Decimal.One;
            for (int i = 1; i < 20; i++)
            {
                f *= i;
                e += Decimal.One / f;
            }

            return e;
        }

        static decimal PI()
        {
            decimal pi = 3;
            decimal coef = 4;
            for (long i = 2; i < 100000; i+=4)
            {
                    pi += coef / (i * (i + 1) * (i + 2));
                    pi -= coef / ((i+2) * (i + 3) * (i + 4));
            }
        return pi;
        }

        static decimal LN2()
        {
            decimal res = 0;

            double sign = 1.0;

            for (long i = 1; i < 1000000000; i++)
            {
                
                res += (decimal)(sign / i);
                sign *= -1;
            }

            return res;
        }
    }
}
