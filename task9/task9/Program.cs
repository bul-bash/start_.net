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
            //BoolBash A = new BoolBash("A");
            //BoolBash B = new BoolBash("B");
            //BoolBash C = BoolBash.Operation(A, B, "XOR");
            //Console.WriteLine(C);

            //A = BoolBash.Operation(C,B,"EQV");
            //Console.WriteLine(A);
           // Console.WriteLine(Math.Log(1,2));
          //  var expr = BoolBash.ReplaceNotByXor(BoolBash.FormatExpression("a and b or c xor a)"));
            //Console.WriteLine(LogicCalculator.ParseExpression(expr, LogicCalculator.commands,BoolBash.Logged));

            //BoolBash boolBash0 = new BoolBash("A", 4);
            //BoolBash boolBash1 = new BoolBash("b", 4);
            //BoolBash boolBash2 = new BoolBash("c", 4);
            //BoolBash boolBash6 = new BoolBash("c", 4);
            //BoolBash boolBash3 = new BoolBash("d", 4);
            //BoolBash boolBash4 = new BoolBash("0", 4);
            //Console.WriteLine(boolBash0);
            //Console.WriteLine(boolBash1);
            //Console.WriteLine(boolBash2);
            //Console.WriteLine(boolBash3);
            //Console.WriteLine(boolBash4);
            //Console.WriteLine(boolBash6);
            BoolBash.GetNumberOfArguments("a and b or c xor a)");
            var expr = BoolBash.ReplaceNotByXor(BoolBash.FormatExpression("a or b and c xor a)"));
            Console.WriteLine(LogicCalculator.ParseExpression(expr, LogicCalculator.commands,BoolBash.Logged));

        }
    }
}
