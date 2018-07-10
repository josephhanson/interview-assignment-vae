using System;
using System.Collections.Generic;
using System.IO;

namespace BigramApi {
    public class NtfsFileCharacterStream : ICharacterStream {
        private readonly string _filepath;
        private readonly long _bufferSize;

        public NtfsFileCharacterStream(string filepath, long bufferSize = 4096) {
            if (string.IsNullOrEmpty(filepath)) throw new ArgumentException("filepath is required");

            _filepath = filepath;
            _bufferSize = bufferSize;
        }

        public IEnumerable<char> Next() {
            using (var stream = File.OpenText(_filepath)) { 
                var buffer = new char[_bufferSize];
                var length = stream.Read(buffer, 0, (int)_bufferSize);

                while (length > 0) {
                    for (var i = 0; i < length; i++) {
                        yield return buffer[i];
                    }

                    length = stream.Read(buffer, 0, (int)_bufferSize);
                }
            }
        }
    }
}