using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    public interface IWordRepository
    {
        bool Contains(string word);

        void Add(string word);

        IEnumerable<string> GetWordsWithLength(int length);
    }
}
