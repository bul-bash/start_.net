using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Напишите функцию, которая находит корень уравнения методом дихотомии. 
//Аргументами функции являются границы интервала, на котором находится корень, делегат, 
//связанный с уравнением, и точность, с которой корень необходимо найти.

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var root = GetRoot(0, 1, x => x * x -25 , 0.0001);
                Console.WriteLine(root);
               
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadKey();
        }

        static double GetRoot(double left, double right, Func<double,double> func, double epsilon)
        {
            bool isIntervalCorrect = func(left) * func(right) < 0;
            if (!isIntervalCorrect)
            {
                throw new Exception("Error! На концах интервала функция имеет один и тот же знак=(");
            }
            double tmp;
            while (Math.Abs(right - left) > epsilon)
            {
                tmp= (left + right) / 2;
                if(func(tmp)*func(left)<=0)
                {
                    right = tmp;
                }
                else
                {
                    left = tmp;
                }

            }

            return (left + right) / 2;
        }
    }
}
