using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {            
            WordRepository wordRepository = new WordRepository();
            Task taskWordLoad = wordRepository.LoadFromUrlAsync("http://www-01.sil.org/linguistics/wordlists/english/wordlist/wordsEn.txt");
            
            WriteConsoleWithRedColor("Wellcome to the Anagram Finder");

            string input = string.Empty;

            while (!input.Equals("E"))
            {
                WriteConsoleWithRedColor("****** Please enter words to find anagrams and press S to start searching.");
                WriteConsoleWithRedColor("****** For exit press E.");

                List<string> words = new List<string>();

                input = Console.ReadLine();

                if (input.Equals("E"))
                    break;

                while (!input.Equals("S"))
                {
                    words.Add(input);
                    input = Console.ReadLine();
                }

                if (words.Count > 0)
                {
                    WriteConsoleWithRedColor("Searching ...");
                    taskWordLoad.Wait();
                    foreach (string word in words)
                    {
                        try
                        {
                            AnagramProvider anagramProvider = new AnagramProvider(wordRepository);

                            List<string> foundAnagrams = anagramProvider.FindAnagrams(word);
                            Console.Write(word);
                            if (foundAnagrams.Count == 0)
                                Console.WriteLine(" :  << Could not find any anagrams for this word >>");
                            else
                            {
                                string anagramsText = string.Join(", ", foundAnagrams.ToArray());

                                Console.WriteLine(" : " + anagramsText);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oopps... An error occured");
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
            }

            WriteConsoleWithRedColor("Goodbye");
            Thread.Sleep(2000);
        }

        private static void WriteConsoleWithRedColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
