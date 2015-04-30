using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram
{
    public class DeterministicAnagramFinder : IAnagramFinder
    {
        private IWordRepository repository;

        public DeterministicAnagramFinder(IWordRepository repository)
        {
            this.repository = repository;
        }
        public List<string> Find(string word)
        {
            StringCombinationGenerator combinationGenerator = new StringCombinationGenerator();

            List<string> anagrams = combinationGenerator.ProvideSameLengthCombinations(word);


            return anagrams.FindAll(anagram => repository.Contains(anagram));
        }
    }
}
