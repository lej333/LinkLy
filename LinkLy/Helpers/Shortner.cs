using LinkLy.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkLy.Helpers
{
    /// <summary>
    /// Helper class which generates short and easy to remember strings for links based on numeric id value
    /// </summary>
    public class Shortner : IShortner
    {
        private string _alphabet = "";
        private readonly IDictionary<char, int> _alphabetIndex;
        private int _base = 0;

        public Shortner(string alphabet) {
            _alphabet = alphabet;
            _base = _alphabet.Length;

            _alphabetIndex = _alphabet
                .Select((c, i) => new { Index = i, Char = c })
                .ToDictionary(c => c.Char, c => c.Index);
        }

        public string GenerateGuid(int id)
        {
            if (id < _base)
            {
                return _alphabet[id].ToString();
            }

            var guid = new StringBuilder();
            var i = id;

            while (i > 0)
            {
                guid.Insert(0, _alphabet[i % _base]);
                i /= _base;
            }

            return guid.ToString();
        }

        public int RestoreGuid(string guid)
        {
            return guid.Aggregate(0, (current, c) => current * _base + _alphabetIndex[c]);
        }
    }
}
