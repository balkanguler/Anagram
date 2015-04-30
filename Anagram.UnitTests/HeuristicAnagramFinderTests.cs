using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.UnitTests
{
    [TestFixture]
    public class HeuristicAnagramFinderTests
    {

        [Test]
        public void FindsCombinationsOnlyInListGiven()
        {
            IWordRepository wordRepository = Substitute.For<IWordRepository>();

            var word = "cdeab";
            var anagrams = new List<string>{"abcde", "bcdea", "edcba"};
            var existingWords = new List<string>{"12345", "xyzte"};
            existingWords.AddRange(anagrams);

            wordRepository.GetWordsWithLength(word.Length).Returns(existingWords);

            HeuristicAnagramFinder anagramFinder = new HeuristicAnagramFinder(wordRepository);

            var foundCombinations = anagramFinder.Find(word);

            Assert.AreEqual(anagrams.Count, foundCombinations.Count);

            anagrams.ForEach(a => Assert.IsTrue(foundCombinations.Contains(a)));

        }
        [Test]
        public void DoesNotFindsSameWordAsAnagram()
        {
            IWordRepository wordRepository = Substitute.For<IWordRepository>();

            var word = "abcd";
 
            var existingWords = new List<string> { word };

            wordRepository.GetWordsWithLength(4).Returns(existingWords);

            HeuristicAnagramFinder anagramFinder = new HeuristicAnagramFinder(wordRepository);

            var foundCombinations = anagramFinder.Find(word);

            Assert.IsFalse(foundCombinations.Contains(word));
        }
    }
}
