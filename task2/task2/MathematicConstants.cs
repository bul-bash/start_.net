using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public static class MathematicConstants
    {

        public static decimal Euler => 2.718281828459045m;
        public static decimal Pi => 3.141592653589793m;
        public static decimal Sqrt2 => 1.414213562373095m;
        public static decimal Ln2 => 0.693147180559945m;
        public static decimal Gamma => 0.577215664901533m;


        //R
        public static decimal GetGamma_2()
        {
            //Википедия статья про эту константу, 4 свойство

            const decimal integral = -0.870057726728315506734648m;
            const decimal sqrtPi = 1.772453850905516027298167m;

            var result = -2m * (2m * integral / sqrtPi + Ln2);
            return result;
        }

        //R
        public static decimal GetGamma_1()
        {
            //статья на википедии про констунту эйлера. Там есть e^Gamma = 1.7810...

            var result = (decimal)Math.Log(1.7810724179901979852);
            return result;
        }

        //R
        public static decimal GetLn2_2()
        {
            //какой то ряд
            var summ = 0m;

            for (var k = 1; k < 30; k += 2)
            {
                var tmp = 1m / (decimal)(k * Math.Pow(3.0, k));
                summ += tmp;
            }

            var result = 2m * summ;
            return result;
        }

        public static decimal GetLn2_1()
        {
            var result = 0m;
            var x = 2m;

            for (var k = 1m; k < 47; k++)
            {
                var tmp = 1m / (k * x);
                x *= 2m;
                result += tmp;
            }

            return result;
        }

        //R
        public static decimal GetSqrt2_1()
        {
            //цепная дробь
            var tmp = 2m;

            for (var k = 19; k >= 0; k--)
            {
                tmp = 2 + (1 / tmp);
            }

            var result = 1m + 1m / tmp;

            return result;
        }

        //R
        public static decimal GetSqrt2_2()
        {
            var result = 1m;

            for (var k = 0; k < 5; k++)
            {
                result = result / 2m + 1m / result;
            }

            return result;
        }

        //R
        public static decimal GetPi_2()
        {
            //Нашел ряд в инете
            var result = 3m;

            for (var k = 1; k < 70000; k++)
            {
                var p = k * 2 + 1;
                var tmp = 4m / ((p - 1m) * p * (p + 1m));

                if (k % 2 == 0)
                {
                    tmp = -tmp;
                }

                result += tmp;
            }

            return result;
        }

        //R
        public static decimal GetPi_1()
        {
            //Формула Бэйли — Боруэйна — Плаффа: (точнее похожая на нее)
            var summ = 0m;

            for (var k = 0; k < 13; k++)
            {
                var reverse = 1m / (decimal)Math.Pow(16, k);
                var k8 = 8m * k;
                var breckets = 8m / (k8 + 2) + 4m / (k8 + 3m) + 4m / (k8 + 4) - 1m / (k8 + 7m);

                summ += (reverse * breckets);
            }

            var result = summ / 2m;
            return result;
        }

        //R
        public static decimal GetE_1()
        {
            //ряд какой то
            var factorial = 1.0m;
            var eulerNumber = 1.0m;

            for (var n = 1; n < 18; n++)
            {
                factorial *= n;
                var tmp = 1.0m / factorial;
                eulerNumber += tmp;
            }
            return eulerNumber;
        }

        //R
        public static decimal GetE_2()
        {
            //через цепную дробь
            var tmp = 1m;

            for (var k = 7; k >= 0; k--)
            {
                tmp = (k * 4) + 2 + (1 / tmp);
            }

            var result = (tmp + 1m) / (tmp - 1m);

            return result;
        }







        //delete it
        public static decimal GetLn2_0()
        {
            //медленно сходится
            var result = 0m;

            for (var k = 1; k < 999; k++)
            {
                var tmp = 1m / k;

                if (k % 2 == 0)
                {
                    tmp = -tmp;
                }

                result += tmp;
            }

            return result;
        }

        //delete it
        public static decimal GetGamma_0()
        {
            //сходится очень медленно
            const decimal ln100 = 4.605170185988091368m;
            const decimal ln1000 = 6.907755278982137052m;
            const decimal ln100000 = 11.51292546497022842008m;

            var summ = 0m;
            const int max = 9900000;
            for (var k = 1; k < max; k++)
            {
                summ += (1m / k);
            }

            var result = summ - (decimal)Math.Log(max);
            return result;
        }

        //delete it
        public static decimal GetPi_0()
        {
            //Формула Валлиса - медленно сходится

            var result = 2m;

            for (var k = 1; k < 1234567; k++)
            {
                var k2 = k * 2m;
                var first = k2 / (k2 - 1m);
                var second = k2 / (k2 + 1m);

                result *= first;
                result *= second;
            }

            return result;
        }
    }
}
