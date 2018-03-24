using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public static class TaskC
    {
        public static string AntiGorner(int number, int basis)
        {
            if (basis < 2 || basis > 36)
            {
                throw new ArgumentException($"Система счисления должна быть в интервале [2; 36], а не быть равной {basis}!");
                return null;
            }
            else
            {
                var isNegative = false;
                if (number < 0)
                {
                    isNegative = true;
                    number = -number;
                }

                var result = "";

                if (number == 0)
                {
                    return "0";
                }

                while (number != 0)
                {
                    var n = number % basis;
                    if (n < 10)
                    {
                        result = (char)(n + '0') + result;
                    }
                    else
                    {
                        result = (char)(n + 'A' - 10) + result;
                    }

                    number /= basis;
                }

                if (isNegative)
                {
                    result = "-" + result;
                }

                return result;
            }
        }


        public static void Start(string[] args)
        {
            int number;
            int basis;
            if ((args.Length == 2) &&
                (int.TryParse(args[0], out number)) &&
                (int.TryParse(args[1], out basis)))
            {
                try
                {
                    var answer = AntiGorner(number, basis);
                    Console.WriteLine($"{number} в системе счисления с основанием {basis} выглядит так: {answer}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    
                }
            }
            else 
            {
                Console.WriteLine("Ошибка входных параметров!");
                return;
            }
        }
    }
}
