using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BigramApi {
    public class BigramHistogram {
        private readonly Dictionary<string, int> _internalData = new Dictionary<string, int>();

        public void Add(Bigram bigram) {
            var entry = $"{bigram.LeftWord} {bigram.RightWord}";
            if (_internalData.ContainsKey(entry)) {
                _internalData[entry]++;
            } else {
                _internalData.Add(entry, 1);
            }
        }

        public ReadOnlyDictionary<string, int> Data => new ReadOnlyDictionary<string, int>(_internalData);
    }
}