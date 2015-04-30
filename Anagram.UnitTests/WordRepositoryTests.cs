using NUnit.Framework;
using System.Collections.Generic;

namespace Anagram.UnitTests
{
    [TestFixture]
    public class WordRepositoryTests
    {
        WordRepository repository;
        
        [SetUp]
        public void Setup()
        {
            repository = new WordRepository();            
        }

        [Test]
        public void VerifiesContainingWord()
        {
            string word = "word";
            repository.Add(word);
            Assert.IsTrue(repository.Contains(word));
        }

        [Test]
        [TestCase("a")]
        [TestCase("zyzzyvas")]
        public void LoadsWordsFromUrl(string word)
        {
            repository.LoadFromUrl("http://www-01.sil.org/linguistics/wordlists/english/wordlist/wordsEn.txt");
            Assert.IsTrue(repository.Contains(word));
        }

        [Test]
        public void ReturnsWordsWithSpecifiedLength()
        {
            string word1 = "word1";
            string word2 = "word2";
            string word3 = "word";

            repository.Add(word1);
            repository.Add(word2);
            repository.Add(word3);

            List<string> words = new List<string>(repository.GetWordsWithLength(5));

            Assert.AreEqual(2, words.Count);
            Assert.IsTrue(words.Contains(word1));
            Assert.IsTrue(words.Contains(word2));

        }
    }
}
