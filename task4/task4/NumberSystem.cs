using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Целая часть:
//Последовательно делим целую часть десятичного числа на основание системы, в которую переводим, 
//пока десятичное число не станет равно нулю.
//Полученные при делении остатки являются цифрами искомого числа.Число в новой системе записывают, 
//начиная с последнего остатка.

//Дробная часть:
//Дробную часть десятичного числа умножаем на основание системы, в которую требуется перевести. 
//Отделяем целую часть.Продолжаем умножать дробную часть на основание новой системы, пока она не станет равной 0.
//Число в новой системе составляют целые части результатов умножения в порядке, соответствующем их получению.

namespace task4
{
    public static class NumberSystem
    {

        public static string ChangeNumberSystem(string numberString, int newSystem)
        {
            if (newSystem < 2 || newSystem > 36)
            {
                throw new ArgumentException("New system < 2 || > 36");
            }

            var isNumber = Regex.IsMatch(numberString, "^[-+]?\\d+([,\\.]\\d+)?$");
            if (!isNumber)
            {
                throw new ArgumentException("Incorrect number(R)");
            }

            var splitResult = numberString.Split(new[] { ',', '.' });
            if (splitResult.Length > 2)
            {
                throw new ArgumentException("Incorrect number");
            }

            var parseIntegerPartResult = BigInteger.TryParse(splitResult[0], out var integerPart);
            if (!parseIntegerPartResult)
            {
                throw new ArgumentException("Incorrect number");
            }

            var result = GetIntegerPart(integerPart, newSystem);

            if (splitResult.Length <= 1)
                return result;


            var tmp = splitResult[1].TrimEnd('0');
            if (tmp.Length == 0)
            {
                tmp = "0";
            }
            var one = BigInteger.Parse("1".PadRight(tmp.Length + 1, '0'));

            var parseFractionPartResult = BigInteger.TryParse(tmp, out var fractionPart);
            if (!parseFractionPartResult)
            {
                throw new ArgumentException("Incorrect number");
            }

            var fractionPartResult = GetFractionPart(one, fractionPart, newSystem);
            result += "." + fractionPartResult;

            return result;
        }

        static string GetIntegerPart(BigInteger integerPart, int newSystem)
        {
            var isNegative = (integerPart < 0);
            var positiveIntegerPart = BigInteger.Abs(integerPart);

            var integerPartResult = "";

            while (positiveIntegerPart > 0)
            {
                var n = (int)(positiveIntegerPart % newSystem);

                if (n < 10)
                {
                    integerPartResult = (char)('0' + n) + integerPartResult;
                }
                else
                {
                    integerPartResult = (char)('A' + n - 10) + integerPartResult;
                }

                positiveIntegerPart /= newSystem;
            }

            if (isNegative)
            {
                integerPartResult = "-" + integerPartResult;
            }

            if (integerPartResult.Length == 0)
            {
                integerPartResult = "0";
            }

            return integerPartResult;
        }

        static string GetFractionPart(BigInteger one, BigInteger fractionPart, int newSystem)
        {
            var result = "";
            var fractionsHistory = new List<BigInteger>() { fractionPart };

            while (fractionPart > 0)
            {
                fractionPart *= newSystem;
                if (fractionPart >= one)
                {
                    var h = fractionPart / one;
                    result += GetIntegerPart(h, newSystem);
                    fractionPart %= one;
                }
                else
                {
                    result += "0";
                }

                var index = fractionsHistory.FindIndex(el => el == fractionPart);
                if (index < 0)
                {
                    fractionsHistory.Add(fractionPart);
                    continue;
                }


                var notPeriodPart = $"{result.Substring(0, index)}";
                var periodPart = $"({result.Substring(index, result.Length - index)})";

                result = notPeriodPart + periodPart;
                break;
            }

            if (result.Length == 0)
            {
                result = "0";
            }

            return result;
        }
    }
}
