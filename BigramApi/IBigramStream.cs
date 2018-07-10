using System.Collections.Generic;

namespace BigramApi {
    public interface IBigramStream {
        IEnumerable<Bigram> Next();
    }
}