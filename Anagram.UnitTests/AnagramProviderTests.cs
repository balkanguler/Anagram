using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anagram;

namespace Anagram.UnitTests
{
    [TestFixture]
    public class AnagramProviderTests
    {
        [Test]
        [TestCase("a")]
        [TestCase("ab")]
        [TestCase("abc")]
        [TestCase("abcd")]
        [TestCase("abcde")]
        public void UsesDeterministicAlgorithmForShortWords(string word)
        {
            IWordRepository repository = Substitute.For<IWordRepository>();

            AnagramProvider provider = new AnagramProvider(repository);

            provider.FindAnagrams(word);

            repository.DidNotReceive().GetWordsWithLength(word.Length);
        }

        [Test]
        [TestCase("abcdef")]
        [TestCase("abcdefg")]
        public void UsesHeuristicAlgorithmForShortWords(string word)
        {
            IWordRepository repository = Substitute.For<IWordRepository>();

            AnagramProvider provider = new AnagramProvider(repository);

            provider.FindAnagrams(word);

            repository.Received(1).GetWordsWithLength(word.Length);
        }
        
    }
}
