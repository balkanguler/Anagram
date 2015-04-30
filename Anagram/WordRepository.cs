using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Anagram
{
    public class WordRepository : IWordRepository
    {
        private HashSet<string> wordList;

        public WordRepository()
        {
            wordList = new HashSet<string>();
        }

        public bool Contains(string word)
        {
            return wordList.Contains(word);
        }

        public void Add(string word)
        {
            wordList.Add(word);
        }

        public void LoadFromUrl(string url)
        {
            var webRequest = WebRequest.Create(url);

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                string word = reader.ReadLine();
                while (word != null)
                {
                    Add(word);
                    word = reader.ReadLine();
                }
            }
        }

        public IEnumerable<string> GetWordsWithLength(int length)
        {
            foreach (string word in wordList)
                if (word.Length == length)
                    yield return word;
        }
    }
}
