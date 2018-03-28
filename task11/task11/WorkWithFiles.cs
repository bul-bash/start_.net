using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task11
{
    public static class WorkWithFiles
    {
        public static List<string> SearchFilesByName(string fileName, string directory)
        {
            try
            {
                var directories = Directory.GetDirectories(directory);
                var finded = Directory.GetFiles(directory, fileName, SearchOption.TopDirectoryOnly);
                var listFinded = finded.ToList();

                foreach (var currentDirectory in directories)
                {
                    var tmp = SearchFilesByName(fileName, currentDirectory);
                    listFinded.AddRange(tmp);
                }

                return listFinded;
            }
            catch
            {
                //nothing =)
            }
            return new List<string>();

        }

        public static List<string> SearchFilesBySequence(string sequence, string directory)
        {
            List<string> tmpList = SearchFilesByName("*", directory);
            List<string> finishedList=new List<string>();
            foreach (var fileName in tmpList)
            {
                try
                {
                using (var file = new StreamReader(fileName))
                {
                    while (!file.EndOfStream)
                    {
                        string tmp=file.ReadLine();
                        if (tmp?.IndexOf(sequence)>=0)
                        {
                            finishedList.Add(fileName);
                            break;
                        }
                    }
                }
                }
                catch
                {
                    
                }
            }

            return finishedList;
        }

        public static List<string> SearchFilesByRegex(Regex regex, string directory)
        {
            List<string> tmpList = SearchFilesByName("*", directory);
            List<string> finishedList = new List<string>();
            foreach (var fileName in tmpList)
            {
                bool isFinded = false;
                try
                {
                    using (var file = new StreamReader(fileName))
                    {
                        while ((!file.EndOfStream)&&(!isFinded))
                        {

                            string tmp = file.ReadLine();
                            if (tmp == null) continue;

                            foreach (var match in regex.Matches(tmp))
                            {
                                finishedList.Add(fileName);
                                isFinded = true;
                                break;
                            }
                        }
                    }
                }
                catch
                {

                }
            }

            return finishedList;

        }
    }
}

