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
        private List<byte> _values; //по умолчанию - 01 //потом хранить столбец из таблицы истинности
        private static readonly byte _one = 1;

        public BoolBash(string name)
        {
            _name =name;
            if (name == "1") _values = new List<byte>() {1};
            else if (name == "0") _values = new List<byte>() {0};
            else _values = new List<byte>() {0, 1};
        }

        public BoolBash(string name, List<byte> values)
        {
            _name = "(" + name + ")";
            _values = values;
        }
    //    {"EQV", "IMP", "COIMP", "XOR", "OR", "AND", "NOR", "NAND", "NOT"};
    
    static Dictionary<string, Func<byte, byte, byte>> operationsDictionary =
            new Dictionary<string, Func<byte, byte, byte>>{
                { "EQV", EQV},
                { "IMP", IMP},
                { "COIMP", COIMP },
                { "XOR", XOR },
                { "OR", OR },
                { "AND", AND },
                { "NOR", NOR },
                { "NAND", NAND },
                { "NOT", NOT }
            };

    #region logical operations
        public static byte IMP(byte leftBit, byte rightBit)
        {
            return (byte)(_one ^ leftBit ^ rightBit & leftBit);
        }

        public static byte EQV(byte leftBit, byte rightBit)
        {
            return (byte)(_one ^ leftBit ^ rightBit);
        }
    
        public static byte COIMP(byte leftBit, byte rightBit)
        {
            return (byte)(leftBit ^ rightBit & leftBit);
        }

        public static byte XOR(byte leftBit, byte rightBit)
        {
            return (byte)(leftBit ^ rightBit);
        }

        public static byte OR(byte leftBit, byte rightBit)
        {
            return (byte)(leftBit ^ rightBit^rightBit & leftBit);
        }

        public static byte AND(byte leftBit, byte rightBit)
        {
            return (byte)(rightBit & leftBit);
        }

        public static byte NOR(byte leftBit, byte rightBit)
        {
            return (byte)(_one ^ leftBit ^ rightBit ^ rightBit & leftBit);
        }

        public static byte NAND(byte leftBit, byte rightBit)
        {
            return (byte)(_one ^  rightBit & leftBit);
        }

        public static byte NOT(byte leftBit, byte rightBit) //leftBit - not used
        {
            return (byte)(_one ^ rightBit);
        }

#endregion

        public static BoolBash Operation(BoolBash left, BoolBash right, string operation) 
        {
            List<byte> resultBytes = new List<byte>();
            if (operation != "NOT")
            {
                foreach (var leftBit in left?._values)
            {

                foreach (var rightBit in right._values)
                {
                    resultBytes.Add(operationsDictionary[operation].Invoke(leftBit, rightBit));
                }
            }
            }
            else
            {
                foreach (var rightBit in right._values)
                {
                    resultBytes.Add(operationsDictionary[operation].Invoke(0, rightBit));
                }
            }

            return new BoolBash($"{left?._name} {operation} {right._name}", resultBytes);
        }
        

        public override string ToString()
        {
            StringBuilder result=new StringBuilder();
            foreach (var bit in _values)
            {
                result.Append(bit);
            }

            return _name+" "+result.ToString();
        }

        public static void Logged(BoolBash boolBash)
        {
            Console.WriteLine(boolBash.ToString());
        }

    }
}
