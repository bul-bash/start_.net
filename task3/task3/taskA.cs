using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public static class TaskA
    {
        public static void FileInput()
        {

        }
        public static void ConsoleInput()
        {
            Console.WriteLine("Введите последовательность символов, разделенных пробелами.");
            string inputString = Console.ReadLine();
            if (inputString != null)
            {
                float sum = 0;
                int number;
                int count = 0;
                var symbols = inputString.Split();
                foreach (var symbol in symbols)
                {

                    if (Int32.TryParse(symbol, out number))
                    {
                        sum += number;
                        count++;
                    }
                }

                if (count > 0)
                {
                    Console.WriteLine($"Среднее Арифметическое введенных чисел: {sum / count}");
                }
                else
                {
                    Console.WriteLine($"ВЫ не ввели ни одного числа!=(");
                }

            }
        }

    }
}
