﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//11. (40 баллов) Напишите приложение для обработки файлов.Ваше приложение должно
//предоставлять возможность поиска всех файлов с заданным именем на компьютере,
//поиск файлов содержащих заданную последовательность символов, или
//последовательность символов, которая удовлетворяет заданному шаблону
//(например, найти все электронные адреса с указанием файлов, где они встречаются),
//и иметь возможность отобразить статистику слов в файле.Реализовать возможность
//просмотра найденных файлов в программе, которая проассоциирована с ними в
//вашей ОС, и сжатия с использованием объекта класса GZipStream.

namespace task11
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var file in WorkWithFiles.SearchFilesByRegex(new Regex(@"\D"), "C:\\DW\\"))
            {
                Console.WriteLine(file);
            }

            
        }
    }
}
