using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {

            Matrix m1 = new Matrix(5, true);
            Matrix m2 = new Matrix(0);
            Console.WriteLine(m1);
            Console.WriteLine(m1.Determinant());
            Console.WriteLine(m1.Reverse());
            Console.WriteLine(m1* m1.Reverse());
         //   Console.WriteLine(m2.Reverse());
           // Console.WriteLine(Matrix.Mul(m1, m2));

            Console.WriteLine(m1+10);
            Console.WriteLine(m1-0009);
       
        }
    }
}
