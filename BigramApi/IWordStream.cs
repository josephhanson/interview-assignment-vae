using System.Collections.Generic;

namespace BigramApi {
    public interface IWordStream {
        IEnumerable<string> Next();
    }
}