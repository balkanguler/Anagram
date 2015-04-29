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
            char[] charsOfWord = word.ToCharArray();
            List<string> combinations = new List<string>();

            for (int i = 0; i < charsOfWord.Length; i++)
            {
                string wordWithOutCurrentChar = createStringWithoutCharAtIndex(word, i);

                IEnumerable<string> combinationsWithCurrentChar = generateCombinationsWithChar(charsOfWord[i], wordWithOutCurrentChar);

                combinationsWithCurrentChar.ToList().ForEach((combination) =>
                {
                    if (!combinations.Contains(combination) && !word.Equals(combination))
                        combinations.Add(combination);
                });
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


            string wordWithOutCurrentChar = leftString + rightString;
            return wordWithOutCurrentChar;
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
