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
            var s =" 1 xor x xor c xor v xor b xor n xor m)";
            BoolBash.GetNumberOfArguments(s);
            var expr = BoolBash.ReplaceNotByXor(BoolBash.FormatExpression(s));
            var result = LogicCalculator.ParseExpression(expr, LogicCalculator.commands,BoolBash.Logged);
            BoolBash.PrintTable(result);
        }
    }
}
