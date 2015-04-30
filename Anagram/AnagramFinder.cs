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
        public List<string> Find(string word)
        {
            StringCombinationGenerator combinationGenerator = new StringCombinationGenerator();

            List<string> anagrams = combinationGenerator.ProvideSameLengthCombinations(word);


            return anagrams.FindAll(a => repository.Contains(a));
        }
    }
}
