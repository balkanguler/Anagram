using NUnit.Framework;

namespace Anagram.UnitTests
{
    [TestFixture]
    public class WordRepositoryTests
    {
        WordRepository repository;
        string word;

        [SetUp]
        public void Setup()
        {
            repository = new WordRepository();
            word = "word";
            repository.Add(word);
        }

        [Test]
        public void VerifiesContainingWord()
        {
            Assert.IsTrue(repository.Contains(word));
        }
    }
}
