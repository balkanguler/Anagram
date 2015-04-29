using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram
{
    public class WordRepository
    {
        private List<string> wordList;

        public WordRepository(string[] words)
        {
            wordList = new List<string>();
            wordList.AddRange(words);
        }

        public bool Contains(string word)
        {
            return wordList.Contains(word);
        }
    }
}
