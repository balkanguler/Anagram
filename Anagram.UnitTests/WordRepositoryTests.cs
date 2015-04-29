using NUnit.Framework;

namespace Anagram.UnitTests
{
    [TestFixture]
    public class WordRepositoryTests
    {
        [Test]
        public void ReturnsTrueForAWordInRepository()
        {
            string word = "word";
            WordRepository repository = new WordRepository(new string[] { word });

            Assert.IsTrue(repository.Contains(word));
        }
    }
}
