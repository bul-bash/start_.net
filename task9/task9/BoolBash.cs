using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{
    public class BoolBash
    {
        private string _name;
        private List<byte> _values = new List<byte>(); //по умолчанию - 01 //потом хранить столбец из таблицы истинности
        private int _length;
        private int _position;
        private static readonly byte _one = 1;
        private static int _countRow;
        private static int _countBool;

        public static int CountBool
        {
            get => _countBool;
            set => _countBool = value;
        }

        public static int GetNumberOfArguments(string expression)
        {
            var separator = new char[] { ' ' };
            
            HashSet<string> argSet = new HashSet<string>();
            var exp = FormatExpression(expression);
            var lexemes = exp.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var lexeme in lexemes)
            {
                if ((!operationsDictionary.ContainsKey(lexeme))&&(lexeme!="1") &&(lexeme!="0" ))
                    argSet.Add(lexeme);
            }

            _countBool = argSet.Count;
            return argSet.Count;
        }

        public BoolBash(string name, int countBool)
        {
            _countBool = countBool;
            int countRow = (int) Math.Pow(2, _countBool);
            _countRow= (int)Math.Pow(2, _countBool);
            _name = " " + name + " ";
            if (name == "1")
                for (int i = 0; i < _countRow; i++)
                {
                    _values.Add(1);
                }
            else if (name == "0")
                for (int i = 0; i < _countRow; i++)
                {
                    _values.Add(0);
                }
            else
            {


                if (!_usedVariables.ContainsKey(_name))
                {
                    _usedVariables.Add(_name, this);
                    _position = _usedVariables.Count;
                }
                else
                {
                    _position = _usedVariables[_name]._position;
                }

                int a = (int) Math.Pow(2, _position - 1);
                int b = (int) Math.Pow(2, _countBool) / 2 / a;




                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        _values.Add(0);

                    }

                    for (int j = 0; j < b; j++)
                    {
                        _values.Add(1);

                    }
                }
            }

        }

       
        public BoolBash(string name, List<byte> values)
        {
            _name = "(" + name + ")";
            _values = values;
            _length = (int)Math.Log(_values.Count, 2);

        }

        static Dictionary<string, Func<byte, byte, byte>> operationsDictionary =
            new Dictionary<string, Func<byte, byte, byte>>
            {
                {"EQV", EQV},
                {"IMP", IMP},
                {"COIMP", COIMP},
                {"XOR", XOR},
                {"OR", OR},
                {"AND", AND},
                {"NOR", NOR},
                {"NAND", NAND},
                {"NOT", NOT},
                {"(", null },
                {")", null }
            };

        #region logical operations

        public static byte IMP(byte leftBit, byte rightBit)
        {
            return (byte) (_one ^ leftBit ^ rightBit & leftBit);
        }

        public static byte EQV(byte leftBit, byte rightBit)
        {
            return (byte) (_one ^ leftBit ^ rightBit);
        }

        public static byte COIMP(byte leftBit, byte rightBit)
        {
            return (byte) (leftBit ^ rightBit & leftBit);
        }

        public static byte XOR(byte leftBit, byte rightBit)
        {
            return (byte) (leftBit ^ rightBit);
        }

        public static byte OR(byte leftBit, byte rightBit)
        {
            return (byte) (leftBit ^ rightBit ^ rightBit & leftBit);
        }

        public static byte AND(byte leftBit, byte rightBit)
        {
            return (byte) (rightBit & leftBit);
        }

        public static byte NOR(byte leftBit, byte rightBit)
        {
            return (byte) (_one ^ leftBit ^ rightBit ^ rightBit & leftBit);
        }

        public static byte NAND(byte leftBit, byte rightBit)
        {
            return (byte) (_one ^ rightBit & leftBit);
        }

        public static byte NOT(byte leftBit, byte rightBit) //leftBit - not used
        {
            return (byte) (_one ^ rightBit);
        }

        #endregion

        public static BoolBash Operation(BoolBash left, BoolBash right, string operation)
        {
            List<byte> resultBytes = new List<byte>();

            for (var i = 0; i < left?._values.Count; i++)
            {
             
                resultBytes.Add(operationsDictionary[operation].Invoke((left?._values)[i], right._values[i]));

            }

            return new BoolBash($"{left?._name} {operation} {right._name}", resultBytes);
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var bit in _values)
            {
                result.Append(bit);
            }

            return _name + " " + result.ToString();
        }

        public static void Logged(BoolBash boolBash)
        {
            Console.WriteLine(boolBash.ToString());
        }

        private static Dictionary<string, BoolBash> _usedVariables = new Dictionary<string, BoolBash>();

        public static string FormatExpression(string expression)
        {
            return " ( " + expression.Replace("(", " ( ").Replace(")", " ) ").ToUpper();
        }

        public static string ReplaceNotByXor(string expression)
        {
            return expression.Replace("NOT", "1 NOT");
        }

        public static bool operator ==(BoolBash left, BoolBash right)
        {
            return (left._name.Contains(right._name))|| (right._name.Contains(left._name));
        }

        public static bool operator !=(BoolBash left, BoolBash right)
        {
            return !(left == right);
        }

        public static void PrintTable(BoolBash result)
        {
            _usedVariables.Add(" res", result);
            foreach (var item in _usedVariables)
            {
                Console.Write($"{item.Key} ");
            }

            Console.WriteLine();
            for (int i = 0; i < _countRow; i++)
            {
                foreach (var item in _usedVariables)
                {
                    Console.Write($" {item.Value._values[i]}  ");
                }

                Console.WriteLine();
            }
        }
    }
}
