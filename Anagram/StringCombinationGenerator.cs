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
                char currentChar = charsOfWord[i];

                string leftString = string.Empty;
                string rightString = string.Empty;

                if (i > 0)
                    leftString = word.Substring(0, i);

                if (i < word.Length - 1)
                    rightString = word.Substring(i + 1, word.Length - (i + 1));


                string wordWithOutCurrentChar = leftString + rightString;

                for (int j = 0; j < wordWithOutCurrentChar.Length; j++)
                {
                    string combination = wordWithOutCurrentChar.Insert(j, currentChar.ToString());
                    if (!combinations.Contains(combination) && !word.Equals(combination))
                        combinations.Add(combination);
                }
            }

            return combinations;
        }
    }
}
