using NUnit.Framework;
using Anagram;
using System.Collections.Generic;

namespace Anagram.UnitTests
{
    [TestFixture]
    public class StringCombinationGeneratorTests
    {
        StringCombinationGenerator generator;

        [SetUp]
        public void Setup()
        {
            generator = new StringCombinationGenerator();
        }
        [Test]
        public void GeneratesSameLengthCombinationOfAString()
        {
            var word = "ab";

            List<string> combinations = generator.GenerateSameLengthCombinations(word);

            Assert.AreEqual(1, combinations.Count);
            Assert.IsTrue(combinations.Contains("ba"));
        }

        [Test]
        [TestCase("a")]
        [TestCase("abc")]
        [TestCase("abcd")]
        [TestCase("abcde")]
        [TestCase("aabbccccddee")]
        public void DoesNotGenerateSameWord(string word)
        {
            List<string> combinations = generator.GenerateSameLengthCombinations(word);

            Assert.IsFalse(combinations.Contains(word));
        }

        [Test]
        [TestCase("a")]
        [TestCase("abc")]
        [TestCase("abcd")]
        [TestCase("abcde")]
        [TestCase("aabbccccddee")]

        public void DoesNotGeneratesACombinationMoreThanOnce(string word)
        {
            List<string> combinations = generator.GenerateSameLengthCombinations(word);

            combinations.ForEach(c => Assert.AreEqual(combinations.FindAll(i => i == c).Count, 1));
        }

        [Test]
        [TestCase("a")]
        [TestCase("abc")]
        [TestCase("abcd")]
        [TestCase("abcde")]
        [TestCase("aabbccccddee")]
        public void GeneratesCombinationsWithSameLength(string word)
        {
            List<string> combinations = generator.GenerateSameLengthCombinations(word);

            combinations.ForEach(c => Assert.AreEqual(word.Length, c.Length));
        }

        [Test]
        [TestCase("a")]
        [TestCase("abc")]
        [TestCase("abcd")]
        [TestCase("abcde")]
        public void GeneratesCorrectNumberOfCombinations(string word)
        {
            List<string> combinations = generator.GenerateSameLengthCombinations(word);

            //For a word with unique characters, should generate (n! -1) combinations.
            Assert.AreEqual(calculateFactorialOf(word.Length) - 1, combinations.Count);
        }

        private int calculateFactorialOf(int number)
        {
            int factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial = factorial * i;

            }

            return factorial;
        }
    }
}
