using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{
    public static class LogicCalculator
    {

        private static List<string> commands = new List<string>
            {"(", "EQV", "IMP", "COIMP", "XOR", "OR", "AND", "NOR", "NAND", "NOT"};

        static byte GetPriorytyOperation(string operation)
        {
            return (byte) commands.IndexOf(operation);
        }

        static Stack<string> stackOperations = new Stack<string>();
        static Stack<BoolBash> stackArguments = new Stack<BoolBash>();

        static void ParseExpression(string expression)
        {
            var lexeme = expression.Split();
        }

        public static List<byte> Calculate(string input)
        {
            List<byte> list = new List<byte>();
            return list;
        }

        //(A&B&C)|(A& !B&C)
        public static string SKNF(List<byte> func)
        {
            StringBuilder result = new StringBuilder();
            foreach (var element in func)
            {
                if (element==0)
                {
                    
                }
            }

            return "";
        }
    }
}
