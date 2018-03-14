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
 

            CubicEquation cubicEquation = new CubicEquation(1,3,4,0);
            Complex x1, x2, x3;
            cubicEquation.DecideWithCardano(out x1,out x2,out x3);
            Console.WriteLine($"{x1}   {x2}   {x3}   ");

            cubicEquation.DecideWithoutCardano(out x1,out x2,out x3);
            Console.WriteLine($"{x1}   {x2}   {x3}   ");

        }
       
    }
}
