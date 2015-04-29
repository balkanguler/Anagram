using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram
{
    public class WordRepository : IWordRepository
    {
        private List<string> wordList;

        public WordRepository()
        {
            wordList = new List<string>();
        }

        public bool Contains(string word)
        {
            return wordList.Contains(word);
        }

        public void Add(string word)
        {
            wordList.Add(word);
        }
    }
}
