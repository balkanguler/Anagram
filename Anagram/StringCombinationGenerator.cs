using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagram
{
    public class StringCombinationGenerator
    {
        public List<string> GenerateSameLengthCombinations(string word)
        {
            var combinations = generateCombinationsRecursive(word);

            combinations.Remove(word);

            return combinations;
        }

        private List<string> generateCombinationsRecursive(string word)
        {
            if (word.Length == 1)
                return new List<string> { word };

            char[] charsOfWord = word.ToCharArray();
            List<string> combinations = new List<string>();


            for (int i = 0; i < charsOfWord.Length; i++)
            {
                string wordWithOutCurrentChar = createStringWithoutCharAtIndex(word, i);

                List<string> innerCombinations = generateCombinationsRecursive(wordWithOutCurrentChar);

                foreach (string innerCombination in innerCombinations)
                {
                    IEnumerable<string> combinationsWithCurrentChar = generateCombinationsWithChar(charsOfWord[i], innerCombination);

                    combinationsWithCurrentChar.ToList().ForEach((combination) =>
                    {
                        if (!combinations.Contains(combination))
                            combinations.Add(combination);
                    });
                }
            }

            return combinations;
        }

  
        private static string createStringWithoutCharAtIndex(string word, int index)
        {
            string leftString = string.Empty;
            string rightString = string.Empty;

            if (index > 0)
                leftString = word.Substring(0, index);

            if (index < word.Length - 1)
                rightString = word.Substring(index + 1, word.Length - (index + 1));


            return leftString + rightString;
        }

        private static IEnumerable<string> generateCombinationsWithChar(char currentChar, string wordWithOutCurrentChar)
        {
            for (int j = 0; j < wordWithOutCurrentChar.Length; j++)
            {
                yield return wordWithOutCurrentChar.Insert(j, currentChar.ToString());
            }
        }
    }
}
