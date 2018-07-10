﻿using System;
using System.Collections.Generic;

namespace BigramApi {
    public class BigramStream : IBigramStream {
        private readonly IWordStream _wordStream;
        private string _lastWord;
        private string _currentWord;

        public BigramStream(IWordStream wordStream) {
            _wordStream = wordStream ?? throw new ArgumentNullException(nameof(wordStream));
        }

        public IEnumerable<Bigram> Next() {
            foreach (var word in _wordStream.Next()) {
                _lastWord = _currentWord;
                _currentWord = word.ToLower();

                if (IsValid()) {
                    yield return new Bigram {LeftWord = _lastWord, RightWord = _currentWord};
                }
            }
        }

        private bool IsValid() {
            return !string.IsNullOrEmpty(_lastWord) && !string.IsNullOrEmpty(_currentWord);
        }
    }
}
