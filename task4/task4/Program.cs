using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//4. (10 баллов) Написать программу для перевода десятичных дробей в систему
//счисления с основанием 𝑘. Ваша программа должна уметь выделять периодическую
//часть получившейся дроби.Реализовать возможность ввода данных как с
//клавиатуры, так и из файла.

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
    class Program
    {
        static void ProcessNumbers(string numberStr, string newSystemStr)
        {
            try
            {
                var newSystem = int.Parse(newSystemStr);
                var result = NumberSystem.ChangeNumberSystem(numberStr, newSystem);

                Console.WriteLine($"Number {numberStr} in system {newSystem} = {result}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void ProcessFilesInput(string fileName)
        {
            try
            {
                var dataFromFile = File.ReadAllText(fileName);
                var numberSplit = dataFromFile.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var first = "";
                var isFirst = true;
                foreach (var number in numberSplit)
                {
                    if (isFirst)
                    {
                        first = number;
                    }
                    else
                    {
                        ProcessNumbers(first, number);
                    }

                    isFirst = !isFirst;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void ProcessConsoleInput()
        {
            Console.Write("Enter number : ");
            var numberLine = Console.ReadLine();

            Console.Write("Enter new system : ");
            var newSystemLine = Console.ReadLine();

            ProcessNumbers(numberLine, newSystemLine);
        }

        static void Main(string[] args)
        {
            var nextArgumentIsFileName = false;

            foreach (var argument in args)
            {
                if (nextArgumentIsFileName)
                {
                    ProcessFilesInput(argument);
                    nextArgumentIsFileName = false;
                }

                switch (argument)
                {
                    case "-c": ProcessConsoleInput(); break;
                    case "-f": nextArgumentIsFileName = true; break;
                }
            }

            if (args.Length == 0)
            {
                ProcessConsoleInput();
            }



            Console.ReadKey();
        }
    }
}
