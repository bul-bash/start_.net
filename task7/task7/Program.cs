using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] d = new double[,]{{1,5,0, 9, 4}, {0,2,4, 8,3}};
            Matrix m1 = new Matrix(4);

            Matrix m2 = new Matrix(m1);
            Matrix m3;
            m3 = m2;
            Console.WriteLine(m1);
            Console.WriteLine();
            Console.WriteLine(m2);
            Console.WriteLine(m3);
            m1.Init();
            Console.WriteLine();
            m3 = m1.Transponse();
            Console.WriteLine(m1);
            Console.WriteLine();
            Console.WriteLine(m2);
            Matrix m = m1.Minor(0, 0);
         //   m.Init();
            Console.WriteLine(m);
            Console.WriteLine(m.Determinant());
        }
    }
}
