using NUnit.Framework;
using Anagram;
using System.Collections.Generic;

namespace Anagram.UnitTests
{
    [TestFixture]
    public class AnagramFinderTests
    {
        [Test]
        public void FindsAnagramsOfAWord()
        {
            AnagramFinder finder = new AnagramFinder();
            var word = "wired";

            string[] anagrams = finder.Find(word);

            Assert.That(new List<string>(anagrams).Contains("wierd"), Is.True);

        }
    }
}
