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
            Console.WriteLine("0,577215664901532860606512090 082 402 431 042 159 335 939 923 ");
            Console.WriteLine( Gamma());
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

        /// <summary>
        /// Нахождение корня по формуле Герона
        /// </summary>
        static decimal SQRT_1(int a=2)
        {
            decimal x = 1m / 2m * (a +1);
            for (int i = 0; i < 5; i++)
            {
                x = 1m / 2m * (x + a / x);
            }
            return x;
        }


        ///<summary>
        ///  Нахождение постоянной Эйлера
        ///  0,577 215 664 901 532 860 606 512 090 082 402 431 042 159 335 939 923 598 805 767 234 884 867 726 777 664 670 936 947 063 291 746 749 515
        /// </summary>
        static decimal Gamma()
        {
            decimal harmonic = 1m;
            int n = 256000000;
            for (int i = 2; i < n; i++)
            {
                harmonic += 1m / i;
            }
            

            return harmonic -(Decimal)Math.Log(n);

        }

        private static decimal Integral(decimal a, decimal b, FuncDelegate f)
        {
            int n = 2000000;
            decimal h = (b - a) / n;
            decimal sum = 0;
            decimal x0 = a, x1 = a + h;
            for (int i = 0; i < n; i++)
            {
                sum += f(x0) + 4m * f(x0 + h / 2m) + f(x1);
                x0 += h;
                x1 += h;
            }
            return (h / 6m) * sum;
        }

    }
}
