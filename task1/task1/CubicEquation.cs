using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace task1
{
    public sealed class CubicEquation
    {

        private double _a;
        private double _b;
        private double _c;
        private double _d;

        public CubicEquation(double a, double b, double c, double d)
        {
            try
            {
                if (a == 0)
                    throw new Exception("коэффициент при х^3 не может быть равен нулю!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            //_a = a;
            _b = b/a;
            _c = c/a;
            _d = d/a;
        }

        public void DecideWithCardano(out Complex x1, out Complex x2, out Complex x3)
        {


            var p = -Math.Pow(_b, 2) / 3 + _c;
            var q = (2 * Math.Pow(_b / 3.0, 3) - _b * _c / 3.0 + _d);
            var Q = (Math.Pow(p / 3, 3)) + Math.Pow(q / 2, 2);
            var cardanoA = Complex.Pow((-q / 2) + Complex.Sqrt(Q), (1.0 / 3.0));
            var cardanoB = (cardanoA == 0) ? 0.0 : -p / cardanoA/3;

            x1 = (cardanoA + cardanoB) - _b / 3;
            x2 = -(cardanoA + cardanoB) / 2 - (_b / 3) +
                 (Complex.ImaginaryOne * Math.Sqrt(3) * (cardanoA - cardanoB) / 2);
            x3 = -(cardanoA + cardanoB) / 2 - (_b / 3) -
                 (Complex.ImaginaryOne * Math.Sqrt(3) * (cardanoA - cardanoB) / 2);

            if (cardanoA == cardanoB)
            {
                x3 = x2 = -cardanoA - _b / 3;
                return;
            }

            return;

    }


        public void DecideWithoutCardano(out Complex x1, out Complex x2, out Complex x3)
        {
          //  _b = 0;
            Complex y1, y2, y3;
            Complex p =  -Complex.Pow(_b,2) / 3.0 + _c;
            Complex q = 2 * Complex.Pow(_b / 3.0, 3) - _b * _c / 3.0 + _d;
            if (p == 0)
            {
                y1 = y2 = y3 = 0;
            }
            else
            {
               Complex cosPhi  = -q / 2 * Complex.Pow(3.0 / (-p), 3.0 / 2);
            //    var cosPhi  =  -q / 2 * Math.Pow(3.0 / (-p), 3.0 / 2);
                y1 = 2 * Complex.Sqrt(-p / 3)* Complex.Cos(Complex.Acos(cosPhi) / 3.0);
                y2 = 2 * Complex.Sqrt(-p / 3) * Complex.Cos(Complex.Acos(cosPhi) / 3.0 + 2*Math.PI/3.0);
                y3 = 2 * Complex.Sqrt(-p / 3) * Complex.Cos(Complex.Acos(cosPhi) / 3.0 - 2 * Math.PI / 3.0);

            }

            x1 = y1    - _b/3;
            x2 = y2    - _b/3;
            x3 = y3    - _b/3;
            
        }
        



    }
}
