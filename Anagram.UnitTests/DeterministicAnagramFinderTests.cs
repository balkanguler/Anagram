using NUnit.Framework;
using Anagram;
using System.Collections.Generic;
using NSubstitute;

namespace Anagram.UnitTests
{
    [TestFixture]
    public class DeterministicAnagramFinderTests
    {

        [Test]
        public void ReturnsAnagramsInRepository()
        {
            var word = "abc";
            List<string> anagrams = new List<string> { "acb", "bac", "bca", "cab", "cba" };

            IWordRepository repository = Substitute.For<IWordRepository>();
            
            anagrams.ForEach(a => repository.Contains(a).Returns(true));

            var anagramFinder = new DeterministicAnagramFinder(repository);

            List<string> foundedAnagrams = anagramFinder.Find(word);

            anagrams.ForEach(anagram => Assert.IsTrue(foundedAnagrams.Contains(anagram)));
        }

        [Test]
        public void DoesNotReturnAnagramsNotInRepository()
        {
            var word = "wired";
            var anagramWord = "wierd";

            IWordRepository repository = Substitute.For<IWordRepository>();

            repository.Contains(anagramWord).Returns(false);

            var anagramFinder = new DeterministicAnagramFinder(repository);

            List<string> foundedAnagrams = anagramFinder.Find(word);

            Assert.IsFalse(foundedAnagrams.Contains(anagramWord));
        }
    }
}
