using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    public class WordRepository : IWordRepository
    {
        private HashSet<string> wordList;
        private bool loaded;

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
            if (!wordList.Contains(word))
                wordList.Add(word);
        }

        public Task LoadFromUrlAsync(string url)
        {
            return Task.Run(() =>
                {
                    if (loaded)
                        return;

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
                    loaded = true;
                });
        }

        public IEnumerable<string> GetWordsWithLength(int length)
        {
            foreach (string word in wordList)
                if (word.Length == length)
                    yield return word;
        }
    }
}
