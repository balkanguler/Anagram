using NUnit.Framework;
using Anagram;
using System.Collections.Generic;

namespace Anagram.UnitTests
{
    [TestFixture]
    public class StringCombinationGeneratorTests
    {
        [Test]
        public void GeneratesSameLengthCombinationOfAString()
        {
            var word = "ab";

            StringCombinationGenerator generator = new StringCombinationGenerator();
            List<string> combinations = generator.GenerateSameLengthCombinations(word);

            Assert.AreEqual(1, combinations.Count);
            Assert.IsTrue(combinations.Contains("ba"));
        }

        [Test]
        public void DoesNotGenerateSameWord()
        {
            var word = "ab";

            StringCombinationGenerator generator = new StringCombinationGenerator();
            List<string> combinations = generator.GenerateSameLengthCombinations(word);

            Assert.IsFalse(combinations.Contains(word));
        }

        [Test]
        public void DoesNotGeneratesACombinationMoreThanOnce()
        {
            var word = "abc";

            StringCombinationGenerator generator = new StringCombinationGenerator();
            List<string> combinations = generator.GenerateSameLengthCombinations(word);

            combinations.ForEach(c => Assert.AreEqual(combinations.FindAll(i => i == c).Count, 1));
        }
    }
}
