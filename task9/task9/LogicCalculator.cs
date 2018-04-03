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

        public static List<string> commands = new List<string>
            {")", "EQV", "IMP", "COIMP", "XOR", "OR", "AND", "NOR", "NAND", "NOT","("};

        static byte GetPriorytyOperation(string operation)
        {
            return (byte) commands.IndexOf(operation);
        }

        static Stack<string> stackOperations;
        static Stack<BoolBash> stackArguments;

        //A AND (B OR C)
        //A * (B + C) 
        //(A XOR B AND C)
        public static BoolBash ParseExpression(string expression, List<string> commands, Action<BoolBash> logged=null)
        {
            var separator = new char[] { ' ' };

            var stackOperations = new Stack<string>();
            stackOperations.Push("(");
            var stackArguments = new Stack<BoolBash>();
            string expressionEx = expression.Replace("(", " ( ").Replace(")", " ) ");
            BoolBash argument1;
            BoolBash argument2;
            var lexemes = expressionEx.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var lexeme in lexemes)
            {
                if (commands.Contains(lexeme))
                {
                    if (stackOperations.Count!=0)
                    {
                        while (GetPriorytyOperation(lexeme) < GetPriorytyOperation(stackOperations.Peek()) && stackOperations.Peek() != "(")
                        {
                            argument2 = stackArguments?.Pop() ?? null;
                            argument1 = stackArguments.Count!=0 ? stackArguments?.Pop() : null;
                            BoolBash tmp = BoolBash.Operation(argument1, argument2,
                                stackOperations.Pop());
                            stackArguments.Push(tmp);

                            logged?.Invoke(tmp);
                        }

                        if (lexeme == ")") stackOperations.Pop();
                        else stackOperations.Push(lexeme);
                    }
                    else
                    stackOperations.Push(lexeme);
                }
                else 
                {
                    stackArguments.Push(new BoolBash(lexeme));
                }

            }

            return stackArguments.Pop();
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
