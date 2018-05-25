using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{
    class Program
    {
        static void Main(string[] args)
        {


            Start(@"A:\1.txt");
        }
        static void Start(string path)
        {
            using (var stream = new StreamReader(path))
            {
                while (!stream.EndOfStream)
                {
                    var input = stream.ReadLine();
                    BoolBash.Reset();

                    var expr = BoolBash.ToCorrect(input);
                    Console.WriteLine(input);
                    BoolBash.GetNumberOfArguments(expr);

                    var result = LogicCalculator.ParseExpression(expr, LogicCalculator.commands, null);
                    Console.WriteLine();
                    BoolBash.PrintTable(result);
                    Console.WriteLine();
                    var sknf = BoolBash.ToCorrect(result.SKNF());
                    var sdnf = BoolBash.ToCorrect(result.SDNF());
                    Console.WriteLine($"SKNF:\n{BoolBash.DelSpaces(sknf)}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"SDNF:\n{BoolBash.DelSpaces(sdnf)}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                }
            }


        }
    }
}
