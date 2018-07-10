using System.Collections.Generic;

namespace BigramApi.UnitTests.Mocks {
    public class MockCharacterStream : ICharacterStream {
        private readonly string _characters;

        public MockCharacterStream(string characters) {
            _characters = characters;
        }

        public IEnumerable<char> Next() {
            foreach (var character in _characters) {
                yield return character;
            }
        }
    }
}
