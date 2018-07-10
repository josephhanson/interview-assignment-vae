using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BigramApi {
    public class WordStream : IWordStream {
        private readonly ICharacterStream _characterStream;
        private readonly char _separator;
        private readonly string _wordRegex;
        private readonly StringBuilder _buffer = new StringBuilder();

        public WordStream(ICharacterStream characterStream, char separator = ' ', string wordRegex = @"^[a-zA-Z]+$") {
            _characterStream = characterStream ?? throw new ArgumentNullException(nameof(characterStream));
            _separator = separator;
            _wordRegex = wordRegex;
        }

        public IEnumerable<string> Next() {
            foreach (var character in _characterStream.Next()) {
                if (character == _separator && !BufferIsEmpty()) {
                    yield return Word;
                    ResetBuffer();
                } else {
                    if (character == _separator) continue;

                    if (Regex.IsMatch(character.ToString(), _wordRegex)) {
                        _buffer.Append(character);
                    }
                }
            }

            if (!BufferIsEmpty()) {
                yield return Word;
            }
        }

        public string Word => _buffer.ToString();

        private bool BufferIsEmpty() {
            return _buffer.Length == 0;
        }

        private void ResetBuffer() {
            _buffer.Clear();
        }
    }
}
