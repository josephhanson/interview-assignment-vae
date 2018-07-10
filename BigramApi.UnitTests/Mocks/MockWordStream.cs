using System.Collections.Generic;

namespace BigramApi.UnitTests.Mocks {
    public class MockWordStream : IWordStream {
        private readonly string[] _words;

        public MockWordStream(string[] words) {
            _words = words;
        }

        public IEnumerable<string> Next() {
            foreach (var word in _words) {
                yield return word;
            }
        }
    }
}
