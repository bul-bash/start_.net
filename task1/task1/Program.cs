using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("введите коэффициенты");
            double a=0, b=0, c=0, d=0;
            try
            {

                Console.Write("a=");
                a = double.Parse(Console.ReadLine());
                Console.Write("b=");
                b = Double.Parse(Console.ReadLine());
                Console.Write("c=");
                c = Double.Parse(Console.ReadLine());
                Console.Write("d=");
                d = Double.Parse(Console.ReadLine());

             
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
                throw;
            }
            CubicEquation cubicEquation = new CubicEquation(a, b, c, d);
            Complex x1;
            Complex x2;
            Complex x3;
            cubicEquation.DecideWithCardano(out x1, out x2, out x3);
            Console.WriteLine($"Решение Исходного кубического уравнения методом кардано: " +
                              $"\n{x1.ToString("0.000")}\n{x2.ToString("0.000")}\n{x3.ToString("0.000")}");


            cubicEquation.DecideWithoutCardano(out x1, out x2, out x3);
            Console.WriteLine($"Решение Исходного кубического уравнения:" +
                              $" \n{x1.ToString("0.000")}\n{x2.ToString("0.000")}\n{x3.ToString("0.000")}");


            Console.ReadKey();
        }
       
    }
}
