using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram
{
    /// <summary>
    /// Retrieves same length words from repo and checks if they are anagrams.
    /// </summary>
    public class HeuristicAnagramFinder : IAnagramFinder
    {
        private IWordRepository wordRepository;

        public HeuristicAnagramFinder(IWordRepository wordRepository)
        {
            // TODO: Complete member initialization
            this.wordRepository = wordRepository;
        }

        public List<string> Find(string word)
        {
            List<string> wordsInRepository = new List<string>(wordRepository.GetWordsWithLength(word.Length));
            List<string> anagrams = new List<string>();

            foreach (string existingWord in wordsInRepository)
                if (areAnagrams(existingWord, word))
                    anagrams.Add(existingWord);

            return anagrams;
        }

        private bool areAnagrams(string word1, string word2)
        {
            if (word1.Length != word2.Length)
                return false;

            char[] charsOfWord1 = word1.ToCharArray();

            //if we remove all characters of word1 from word2, word2 should become an empty string.
            foreach (char ch in charsOfWord1)
            {
                int firstIndexOfCh = word2.IndexOf(ch);
                if (firstIndexOfCh < 0)
                    return false;
                word2 = word2.Remove(firstIndexOfCh, 1);
            }

            if (string.IsNullOrEmpty(word2))
                return true;

            return false;
        }
    }
}
