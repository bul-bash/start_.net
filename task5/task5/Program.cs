using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//5. Пользователем задается строка или из файла, или с клавиатуры.
//a) (1 балл) Выполнить сортировку слов строки по алфавиту и вывести на экран
//слово, состоящее из последних символов этих слов.
//b) (1 балл) В каждом слове строки поднять регистр первой буквы слова и опустить
//регистр последней буквы.
//c) (1 балл) Подсчитать сколько раз в этой строке встречается заданное слово.
//d) (1 балл) Заменить в данной строке предпоследнее слово на слово, которое ввел
//пользователь.
//e) (1 балл) Найти 𝑘 − ое слово в строке начинающиеся с заглавной буквы.

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            string input;

            Console.WriteLine("напишите 'file' для ввода информации из файла или что-то еще для ввода информации через консоль...");
            try
            {
                if (Console.ReadLine() == "file")
                {
                    input = FileInput();
                }
                else
                {
                    input = ConsoleInput();
                }
            }
            catch (Exception exception)
            {
               // Console.WriteLine(exception);
                return;
            }

            Console.WriteLine("введенная строка:");
            Console.WriteLine(input);
            Console.WriteLine("слово из последних букв отсортировонной строки");
            Console.WriteLine(Sort(input));
            Console.WriteLine("строка с измененным регистром");
            Console.WriteLine(UpperLower(input));
            Console.WriteLine("введите слово для подсчета");
            string word = Console.ReadLine();
            Console.WriteLine($"слово '{word}' {Count(input, word)} раз");
            Console.WriteLine("введите слово для замены предпоследнего слова");
            word = Console.ReadLine();
            Console.WriteLine("строка с новым словом");
            Console.WriteLine(Replace(input, word));
            Console.WriteLine("введите число для поиска");
            int num = int.TryParse(Console.ReadLine(), out int n)?n:1;
            Console.WriteLine($"{num}-е слово, начинающееся с зашлавной буквы:");
            Console.WriteLine(Search(input, num));
            Console.ReadKey();
        }

        static string FileInput()
        {
            Console.WriteLine("введите имя файла:");
            var fileName = Console.ReadLine();
            try
            {
                using (var file = new StreamReader(fileName))
                {
                    return file.ReadToEnd();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }

            
        }
        static string ConsoleInput()
        {
            Console.WriteLine("введите строку");
            return Console.ReadLine();
        }
        static string Sort(string source)
        {
            StringBuilder result = new StringBuilder();
            var words = source.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            foreach (var word in words)
            {
                result.Append(word[word.Length - 1]);

            }

            return result.ToString();
        }

        static string UpperLower(string source)
        {
            StringBuilder result = new StringBuilder();
            var words = source.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                string tmp = "";
                if (word.Length>1)
                {
                    tmp = word.Substring(1, word.Length - 2);
                    result.Append($"{char.ToUpper(word[0])}{tmp}{char.ToLower(word[word.Length - 1])} ");

                }
                else
                {
                    result.Append(word);
                }

            }

            return result.ToString();
        }

        static int Count(string source, string wordForSearch)
        {
            int count = 0;
            var words = source.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (wordForSearch.Equals(word)) count++;
            }

            return count;
        }

        static string Replace(string source, string wordForReplace)
        {
            StringBuilder result = new StringBuilder();
            
            var words = source.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 2) return "";
            words[words.Length - 2] = wordForReplace;
            foreach (var word in words)
            {
                result.Append(word+ " ");

            }

            return result.ToString();

        }
        static string Search(string source, int numberOfWord)
        {
            
            var words = source.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in words)
            {
                if (char.IsUpper(word[0])) numberOfWord--;
                if (numberOfWord==0)
                {
                    return word;
                }
            }

            return null;

        }

    }
}
