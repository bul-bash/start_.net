using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10
{
    public static class TextProcessor
    {
        //static char[] vowels = new char[]{'а','у','е','ы','о','э','я','и','ю','ё'};
        private const string vowels = "ёуеыаоэяию";
        private static Random random = new Random();
        public static int GetNumberOfSyllables(string word)
        {
            int count = 0;
            foreach (var letter in word.ToCharArray())
            {
                if (vowels.Contains(letter)) count++;
            }

            return count;
        }

        public static Dictionary<int, List<string>> GetDictionarySyllableCount(string fileName)
        {
            Dictionary<int, List<string>> dictionary =new Dictionary<int, List<string>>();
            try
            {
                using (var file = new StreamReader(fileName))
                {
                    while (!file.EndOfStream)
                    {
                        var words = file.ReadLine();
                        
                        foreach (var word in words?.Split())
                        {
                            if (dictionary.ContainsKey(TextProcessor.GetNumberOfSyllables(word))) dictionary[TextProcessor.GetNumberOfSyllables(word)].Add(word);
                            else dictionary.Add(TextProcessor.GetNumberOfSyllables(word), new List<string>(){word});
                        }
                       
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                
            }

            return dictionary;
        }

        public static List<string> ChangeWords(string poemFile, string outputFile,  string dictFile= "zdb-win.txt")
        {
            
            var dictSetWords = GetDictionarySyllableCount(dictFile);
            
            List<string> list = new List<string>();


            try
            {
                using (var inputFile = new StreamReader(poemFile))
                {
                    using (var file = new StreamWriter(outputFile))
                    {


                        while (!inputFile.EndOfStream)
                        {
                            var line = inputFile.ReadLine();
                            foreach (var poemWord in line.Split())
                            {
                                int count = GetNumberOfSyllables(poemWord);
                                var words = dictSetWords[count];
                                var word = words[random.Next(dictSetWords[count].Count)];
                                list.Add(word);
                                file.Write(word + " ");
                            }

                            file.WriteLine();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }

            return list;
        }
    }
}
