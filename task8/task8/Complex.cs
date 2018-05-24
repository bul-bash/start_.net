using System;
using System.Globalization;
using System.Text;

namespace task8
{
    public class Complex : ICloneable, IArithmeticOperations<Complex>
    {
        private readonly double _realPart;
        private readonly double _imaginaryPart;

        public static readonly Complex Zero = new Complex(0.0, 0.0);
        public static readonly Complex One = new Complex(1.0, 0.0);
        public static readonly Complex ImaginaryOne = new Complex(0.0, 1.0);

        public Complex() { }

        public Complex(double realPar, double imaginaryPart = 0)
        {
            _realPart = realPar;
            _imaginaryPart = imaginaryPart;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            if (_realPart != 0 || _imaginaryPart == 0)
                str.Append(_realPart.ToString(CultureInfo.InvariantCulture));

            if (Math.Abs(_imaginaryPart) > 0 || Math.Abs(_imaginaryPart) < 0)
            {
                if (_imaginaryPart > 0 && _realPart != 0)
                    str.Append("+");
                if (Math.Abs(_imaginaryPart) != 1)
                    str.Append(_imaginaryPart.ToString(CultureInfo.InvariantCulture));
                str.Append("i");
            }

            return str.ToString();
        }

        public static Complex Add(Complex left, Complex right)
        {
            var resNumber = new Complex(left._realPart + right._realPart, left._imaginaryPart + right._imaginaryPart);
            return resNumber;
        }

        Complex IArithmeticOperations<Complex>.Multiplication(Complex a, Complex b)
        {
            return Multiplication(a, b);
        }

        public Complex Subtraction(Complex a, Complex b)
        {
            return Subtract(a, b);
        }

        Complex IArithmeticOperations<Complex>.Division(Complex a, Complex b)
        {
            return Division(a, b);
        }

        Complex IArithmeticOperations<Complex>.UnaryMinus(Complex a)
        {
            return UnaryMinus(a);
        }

        Complex IArithmeticOperations<Complex>.Add(Complex a, Complex b)
        {
            return Add(a, b);
        }

        public static Complex Multiplication(Complex left, Complex right)
        {
            var resNumber = new Complex(left._realPart * right._realPart - left._imaginaryPart * right._imaginaryPart,
                left._realPart * right._imaginaryPart + right._realPart * left._imaginaryPart);
            return resNumber;
        }

        public static Complex Subtract(Complex left, Complex right)
        {
            var resNumber = new Complex(left._realPart - right._realPart, left._imaginaryPart - right._imaginaryPart);
            return resNumber;
        }

        public static Complex Division(Complex left, Complex right)
        {
            if (right._realPart == 0 && right._imaginaryPart == 0)
                throw new Exception("Деление на 0");
            var tmp = right._imaginaryPart * right._imaginaryPart + right._realPart * right._realPart;
            var resNumber = new Complex((left._realPart * right._realPart + left._imaginaryPart * right._imaginaryPart) / tmp,
                (right._realPart * left._imaginaryPart - left._realPart * right._imaginaryPart) / tmp);
            return resNumber;
        }

        public static Complex UnaryMinus(Complex number)
        {
            return new Complex(-number._realPart, -number._imaginaryPart);
        }

        public static Complex operator +(Complex left, Complex right)
        {
            return Add(left, right);
        }

        public static Complex operator -(Complex left, Complex right)
        {
            return Subtract(left, right);
        }

        public static Complex operator -(Complex number)
        {
            return UnaryMinus(number);
        }

        public static Complex operator *(Complex left, Complex right)
        {
            return Multiplication(left, right);
        }

        public static Complex operator /(Complex left, Complex right)
        {
            return Division(left, right);
        }

        public static bool operator <(Complex left, Complex right)
        {
            return left._realPart < right._realPart;
        }

        public static bool operator >(Complex left, Complex right)
        {
            return left._realPart > right._realPart;
        }

        public static Complex Pow(Complex value, Complex power) /* A complex number raised to another complex number */
        {

            if (power == Complex.Zero)
            {
                return Complex.One;
            }

            if (value == Complex.Zero)
            {
                return Complex.Zero;
            }

            var a = value._realPart;
            var b = value._imaginaryPart;
            var c = power._realPart;
            var d = power._imaginaryPart;

            var rho = Complex.Abs(value);
            var theta = Math.Atan2(b, a);
            var newRho = c * theta + d * Math.Log(rho);

            var t = Math.Pow(rho, c) * Math.Pow(Math.E, -d * theta);

            return new Complex(t * Math.Cos(newRho), t * Math.Sin(newRho));
        }

        public static double Abs(Complex number)
        {
            if (double.IsInfinity(number._realPart) || double.IsInfinity(number._imaginaryPart))
            {
                return double.PositiveInfinity;
            }

            // |value| == sqrt(a^2 + b^2)
            // sqrt(a^2 + b^2) == a/a * sqrt(a^2 + b^2) = a * sqrt(a^2/a^2 + b^2/a^2)
            // Using the above we can factor out the square of the larger component to dodge overflow.


            var c = Math.Abs(number._realPart);
            var d = Math.Abs(number._imaginaryPart);

            if (c > d)
            {
                var r = d / c;
                return c * Math.Sqrt(1.0 + r * r);
            }
            else if (d == 0.0)
            {
                return c;  // c is either 0.0 or NaN
            }
            else
            {
                var r = c / d;
                return d * Math.Sqrt(1.0 + r * r);
            }
        }

        public object Clone()
        {
            return new Complex(_realPart, _imaginaryPart);
        }
    }
}