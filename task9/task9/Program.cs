﻿using System;
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
            var expr = BoolBash.ReplaceNotByXor(BoolBash.FormatExpression("Not A and not B)"));
            Console.WriteLine(LogicCalculator.ParseExpression(expr, LogicCalculator.commands,BoolBash.Logged));
        }
    }
}
