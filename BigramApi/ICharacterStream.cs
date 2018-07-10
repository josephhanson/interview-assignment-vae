using System.Collections.Generic;

namespace BigramApi {
    public interface ICharacterStream {
        IEnumerable<char> Next();
    }
}