using NUnit.Framework;
using Anagram;
using System.Collections.Generic;
using NSubstitute;

namespace Anagram.UnitTests
{
    [TestFixture]
    public class AnagramFinderTests
    {

        [Test]
        public void DoesNotReturnAnagramsThatNotInRepository()
        {
            var word = "wired";
            var anagramWord = "wierd";

            IWordRepository repository = Substitute.For<IWordRepository>();

            repository.Contains(anagramWord).Returns(false);

            var sut = new AnagramFinder(repository);

            string[] anagrams = sut.Find(word);

            Assert.IsFalse(new List<string>(anagrams).Contains(anagramWord));
        }
    }
}
