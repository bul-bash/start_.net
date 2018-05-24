using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public static class TaskA
    {


        static char CalculateAverageMean(string data)
        {
            var list = new List<int>();
            var splited = data.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var symbol in splited)
            {
                if (symbol.Length == 1)
                {
                    list.Add(symbol.First());
                }
                else
                {
                    Console.WriteLine($"Symbol.length != 1 : {symbol}");
                }
            }

            var result = 0.0;

            if (list.Count > 0)
            {
                result = list.Sum() / (double)list.Count;
            }

            return (char)result;
        }

        static void ProcessFilesInput(string fileName)
        {
            try
            {
                var dataFromFile = File.ReadAllText(fileName);
                var result = CalculateAverageMean(dataFromFile);
                Console.WriteLine($"Среднеарифметическое с файла {fileName} = {result}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void ProcessConsoleInput()
        {
            Console.WriteLine("Введите строку с числами разделенными пробелами");
            var inputData = Console.ReadLine();
            var result = CalculateAverageMean(inputData);

            Console.WriteLine($"Среднеарифметическое = {result}");
        }

        public static void Start(string[] args)
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
        }

    }

    
}
