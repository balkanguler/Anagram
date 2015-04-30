﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Console.WriteLine("Wellcome to the Anagram Finder");

            while (!input.Equals("E"))
            {
                Console.WriteLine("Please enter words to find anagrams. To start search press 'S'. For exit press 'E' ");

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
                    Console.WriteLine("Searching ...");
                    WordRepository wordRepository = new WordRepository();
                    wordRepository.LoadFromUrl("http://www-01.sil.org/linguistics/wordlists/english/wordlist/wordsEn.txt");

                    AnagramFinder anagramFinder = new AnagramFinder(wordRepository);
                    foreach (string word in words)
                    {
                        List<string> foundAnagrams = anagramFinder.Find(word);
                        Console.Write(word);
                        if (foundAnagrams.Count == 0)
                            Console.WriteLine(" :  << Could not find any anagramas for this word >>");
                        else
                        {
                            string anagramsText = string.Join(", ", foundAnagrams.ToArray());

                            Console.WriteLine(" : " + anagramsText);
                        }
                    }
                }
            }

            Console.WriteLine("Good Bye");
            Console.ReadKey();
        }
    }
}
