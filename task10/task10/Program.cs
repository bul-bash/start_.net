using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    //10. (35 баллов) Необходимо написать программу, которая принимает на вход файл, в
    //котором записано стихотворение любого русского(можно и нерусского) поэта и
    //выдавать на выходе другой файл, который будет содержать то же стихотворение, в
    //котором все слова заменены на произвольные слова с эквивалентным числом слогов, 
    //выбранные из  обратного словаря  русских слов(http://www.speakrus.ru/dict/),  по 
    //возможности с сохранением рифмы. Передача аргументов в программу происходит
    //через командную строку. 
namespace task10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Task10 *****");

            Start(args);
            Console.ReadKey();

        }

        public static void Start(string[] args)
        {
            if (args.Length == 2)
            {
                try
                {
                    TextProcessor.ChangeWords(args[0], args[1]);

                    Process.Start(fileName: args[1]);

                    Console.WriteLine("Успех!");
                }
                catch (Exception exception)
                {
                    Console.WriteLine("что-то пошло не так =(");
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
