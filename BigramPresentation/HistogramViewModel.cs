using System.Collections.Generic;

namespace BigramPresentation {
    public class HistogramViewModel {
        public IReadOnlyList<HistogramEntryViewModel> Data { get; set; }

        public int Count => Data.Count;
    }
}