using NUnit.Framework;

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
    }
}
