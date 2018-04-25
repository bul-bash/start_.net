using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public static class TaskB
    {
        private static void CountAverageGarmonic(string inputString)
        {
            if (inputString != null)
            {
                double sum = 0;
                double number;
                int count = 0;
                var symbols = inputString.Split();
                foreach (var symbol in symbols)
                {
                    string tmp = symbol.Replace(",", ".");
                    if (Double.TryParse(tmp, NumberStyles.Number, CultureInfo.InvariantCulture, out number))
{
                        sum += 1.0/number;
                        count++;
                    }

                }

                if (count > 0)
                {
                    Console.WriteLine($"Среднее Гармоническое введенных чисел: {count/sum}");
                }
                else
                {
                    Console.WriteLine($"ВЫ не ввели ни одного адекватного числа!=(");
                }
            }
        }
        private static void CountAverageGeometric(string inputString)
        {
            if (inputString != null)
            {
                double mul = 1;
                double number;
                int count = 0;
                var symbols = inputString.Split();
                foreach (var symbol in symbols)
                {
                    string tmp=symbol.Replace(",", ".");
                    var parseSuccess = Double.TryParse(tmp, NumberStyles.Number, CultureInfo.InvariantCulture, out number);
                    if (parseSuccess)
                    {
                        mul *= number;
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"Не могу привести '{symbol}' к числу!");
                    }
                }

                if (count > 0)
                {
                    Console.WriteLine($"Среднее Геометрическое введенных чисел: {Math.Pow(mul, 1.0/count)}");
                }
                else
                {
                    Console.WriteLine($"ВЫ не ввели ни одного адекватного числа!=(");
                }
            }
        }

        private static void FileInput(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                string inputString = streamReader.ReadToEnd();
                Console.WriteLine("Считана последовательность символов, разделенных пробелами:");
                Console.WriteLine(inputString);
                CountAverageGeometric(inputString);
                CountAverageGarmonic(inputString);

            }

        }
        private static void ConsoleInput()
        {
            Console.WriteLine("Введите последовательность символов, разделенных пробелами.");
            string inputString = Console.ReadLine();
            CountAverageGeometric(inputString);
            CountAverageGarmonic(inputString);


        }

        public static void Start(string[] args)
        {
            if (args.Length == 0)
            {
                ConsoleInput();
                return;
            }
            else if (args[0] == "-c")
            {
                ConsoleInput();
                return;
            }
            else if ((args[0] == "-f") && (args.Length > 1))
            {
                try
                {
                    FileInput(args[1]);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Ошибка открытия файла '{args[1]}' \nПроверьте путь и имя файла");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Не удалось распознать аргументы коммандной строки! \nПроверьте корректность ввода!");
            }
        }
    }
}
