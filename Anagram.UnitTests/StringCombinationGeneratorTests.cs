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
    }
}
