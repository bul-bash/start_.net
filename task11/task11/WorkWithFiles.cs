using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
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
                using (var file = new StreamReader(fileName, Encoding.Default))
                {
                    while (!file.EndOfStream)
                    {
                      //  Encoding.Convert(Encoding.ASCII, file.ReadLine().ToCharArray())
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
                    using (var file = new StreamReader(fileName, Encoding.Default))
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

        public static void OpenFile(string fileName)
        {
            try
            {
                Process.Start(fileName);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                
            }
        }

        public static Dictionary<string, int> GetWordStatistic(string fileName)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            try
            {
                using (var file = new StreamReader(fileName, Encoding.Default))
                {
                    while (!file.EndOfStream)
                    {
                        string line = file.ReadLine();
                        var words = line?.Split(new char[] {',', '.', '?', '!', ';', ' ', '\t'},
                            StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in words)
                        {
                            if (dictionary.ContainsKey(word))
                            {
                                dictionary[word]++;
                            }
                            else
                            {
                                dictionary.Add(word, 1);
                            }
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

        public static bool CompressFileGZip(string fileName)
        {
            try
            {
                if (fileName.Contains(".gz")) throw new Exception("File is already Compressed!");

                using (var sourceStream = new FileStream(fileName, FileMode.Open))
                {

                    using (var targetStream = File.Create(fileName + ".gz"))

                    using (var compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }

            return true;
        }
        public static bool DecompressFileGZip(string fileName)
        {
            try
            {
                if((fileName!="")&&(!fileName.Contains(".gz"))) throw new Exception("File is already decompressed!");
                using (var sourceStream = new FileStream(fileName, FileMode.Open))
                {

                    using (var targetStream = File.Create(fileName.Remove(fileName.Length-3)))

                    using (var decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                    }
                }
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }

            return true;
        }
    }
    }



