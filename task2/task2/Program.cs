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
            Console.WriteLine("e:");
            Console.WriteLine($"e: {MathematicConstants.Euler}");
            Console.WriteLine($"Первый способ: {MathematicConstants.GetE_1()}");
            Console.WriteLine($"Второй способ: {MathematicConstants.GetE_2()}");

            Console.WriteLine("pi:");
            Console.WriteLine($"pi: {MathematicConstants.Pi}");
            Console.WriteLine($"Первый способ: {MathematicConstants.GetPi_1()}");
            Console.WriteLine($"Второй способ: {MathematicConstants.GetPi_2()}");

            Console.WriteLine("ln(2):");
            Console.WriteLine($"ln(2): {MathematicConstants.Ln2}");
            Console.WriteLine($"Первый способ: {MathematicConstants.GetLn2_1()}");
            Console.WriteLine($"Второй способ: {MathematicConstants.GetLn2_2()}");

            Console.WriteLine("sqrt(2):");
            Console.WriteLine($"sqrt(2): {MathematicConstants.Sqrt2}");
            Console.WriteLine($"Первый способ: {MathematicConstants.GetSqrt2_1()}");
            Console.WriteLine($"Второй способ: {MathematicConstants.GetSqrt2_2()}");

            Console.WriteLine("Gamma:");
            Console.WriteLine($"Gamma: {MathematicConstants.Gamma}");
            Console.WriteLine($"Первый способ: {MathematicConstants.GetGamma_1()}");
            Console.WriteLine($"Второй способ: {MathematicConstants.GetGamma_2()}");


            Console.WriteLine("Нажмите любую кнопку чтобы выйти...");
            Console.ReadKey();
        
    }


 

    }
}
