namespace _03.CountWordsInFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /**
     * 
     * Write a program that counts how many times each 
     * word from given text file words.txt appears in it. The 
     * character casing differences should be ignored. The result
     * words should be ordered by their number of occurrences in the text. Example:
	    is  2
	    the  2
	    this  3
	    text  6
    */

    class Program
    {
        private static string FileName = "../../files/words.txt";
        private static string ReadFile(string filename)
        {
            string text = File.ReadAllText(filename);
            return text;
        }

        private static void ShowResult(IDictionary<string, int> wordsCount)
        {
            foreach (var item in wordsCount)
            {
                Console.WriteLine("{0}  -->  {1}", item.Key, item.Value);
            }
        }

        static void Main(string[] args)
        {
            char[] charSeparators = 
                new char[] { ',', '.', '!', '?', '-', ' ', '\r', '\n' };

            string fileContent = ReadFile(FileName);
            var words = fileContent.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            IDictionary<string, int> wordsCount = new SortedDictionary<string, int>();

            foreach (var item in words)
            {
                string lower = item.ToLower();

                if (wordsCount.ContainsKey(lower))
                {
                    wordsCount[lower]++;
                }
                else
                {
                    wordsCount[lower] = 1;
                }
            }

            ShowResult(wordsCount);
        }
    }
}
