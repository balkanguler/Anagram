using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram
{
    public class AnagramFinder
    {
        private IWordRepository repository;

        public AnagramFinder(IWordRepository repository)
        {
            this.repository = repository;
        }
        public string[] Find(string word)
        {
            List<string> anagrams = new List<string> { "wierd", "erdwi" };

            return anagrams.FindAll(a => repository.Contains(a)).ToArray();
        }
    }
}
