using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{
    class Program
    {
        static void Main(string[] args)
        {
            var s =" a imp b and c or e xor 1 eqv f coimp j nor a";
            var expr = BoolBash.ToCorrect(s);
            BoolBash.GetNumberOfArguments(expr);
           // var expr = BoolBash.ReplaceNotByXor(BoolBash.FormatExpression(s));
            var result = LogicCalculator.ParseExpression(expr, LogicCalculator.commands,null);
            Console.WriteLine();
            BoolBash.PrintTable(result);
            Console.WriteLine();
            var sknf = BoolBash.ToCorrect(result.SKNF());
            var sdnf = BoolBash.ToCorrect(result.SDNF());
            Console.WriteLine(sknf);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(sdnf);
            Console.WriteLine();
            BoolBash.GetNumberOfArguments(BoolBash.ToCorrect(sknf));
            BoolBash.Reset();
            BoolBash.PrintTable(LogicCalculator.ParseExpression(sknf, LogicCalculator.commands, null));
            BoolBash.Reset();

            Console.WriteLine();
            BoolBash.PrintTable(LogicCalculator.ParseExpression(sdnf, LogicCalculator.commands, null));

            BoolBash.Reset();

            var n = " a or b";
            var e = BoolBash.ToCorrect(n);

            Console.WriteLine(BoolBash.GetNumberOfArguments(e));

            BoolBash.PrintTable(LogicCalculator.ParseExpression(e, LogicCalculator.commands, null));

        }
    }
}
