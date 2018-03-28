using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task11
{
    public static class TextUserInterface
    {
        public static void Start()
        {
            while (work)
            {
                Console.WriteLine("***** Task11 *****");

                for (int i = 0; i < menuAction.Length; i++)
                {
                    Console.WriteLine($"press {i} to {menuAction[i].Method.Name}");
                }

                if ((Int32.TryParse(Console.ReadLine(), out int choise)) && (choise >= 0) &&
                    (choise < menuAction.Length))
                {
                    menuAction[choise].Invoke();
                   

                }
                else
                {
                   // Console.WriteLine(choise);
                }

                Console.WriteLine("Press any key");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static readonly Action[] menuAction = new Action[]
        {
            Info,
            SearchFilesByName,
            SearchFilesByRegex,
            SearchFilesBySequence,
            OpenFile,
            GetWordStatistic,
            CompressFileGZip,
            DeompressFileGZip,
            Exit
        };
        

        public static void SearchFilesByName()
        {
            Console.WriteLine("enter the file name:");
            string fileName = Console.ReadLine();
            Console.WriteLine("enter the directory name:");
            string directory = Console.ReadLine();
            Console.WriteLine("I found this...");
            foreach (var files in WorkWithFiles.SearchFilesByName(fileName, directory))
            {
                Console.WriteLine(files);   
            }

            Console.WriteLine("It's All!");
            


        }
        public static void SearchFilesBySequence()
        {
            Console.WriteLine("enter the sequence string:");
            string sequence = Console.ReadLine();
            Console.WriteLine("enter the directory name:");
            string directory = Console.ReadLine();
            Console.WriteLine("I found this...");
            foreach (var files in WorkWithFiles.SearchFilesBySequence(sequence, directory))
            {
                Console.WriteLine(files);
            }

            Console.WriteLine("It's All!");


        }
        public static void SearchFilesByRegex()
        {
            Console.WriteLine("enter the regex string:");
            string regex = Console.ReadLine();
            Console.WriteLine("enter the directory name:");
            string directory = Console.ReadLine();
            Console.WriteLine("I found this...");
            foreach (var files in WorkWithFiles.SearchFilesByRegex(new Regex(regex), directory))
            {
                Console.WriteLine(files);
            }

            Console.WriteLine("It's All!");


        }
        public static void OpenFile()
        {
            Console.WriteLine("enter the file name:");
            string fileName = Console.ReadLine();
            WorkWithFiles.OpenFile(fileName);
            //Console.WriteLine($"{fileName} is opened!");


        }
        public static void GetWordStatistic()
        {
            Console.WriteLine("enter the file name:");
            string fileName = Console.ReadLine();
            
            Console.WriteLine("Look at that!");
            Console.WriteLine("count    word");
            foreach (var stat in WorkWithFiles.GetWordStatistic(fileName))
            {
                Console.WriteLine(stat.Value+"        "+stat.Key);
            }

            Console.WriteLine("It's All!");


        }
        public static void CompressFileGZip()
        {
            Console.WriteLine("enter the file name:");
            string fileName = Console.ReadLine();

            if(WorkWithFiles.CompressFileGZip(fileName))
                Console.WriteLine("success!");



        }
        public static void DeompressFileGZip()
        {
            Console.WriteLine("enter the file name:");
            string fileName = Console.ReadLine();

            if(WorkWithFiles.DecompressFileGZip(fileName))
                Console.WriteLine("success!");


        }
        public static void Exit()
        {
            work = false;
        }

        public static void Info()
        {
            Console.WriteLine(@"Приложение для обработки файлов. Приложение 
предоставляет возможность поиска всех файлов с заданным именем на компьютере,
поиск файлов содержащих заданную последовательность символов, или
последовательность символов, которая удовлетворяет заданному шаблону,
возможность отобразить статистику слов в файле. Реализована возможность
просмотра найденных файлов в программе, которая проассоциирована с ними в
вашей ОС, и компрессии/декомпресии с использованием объекта класса GZipStream.");
        }
        private static bool work = true;
    }
}
