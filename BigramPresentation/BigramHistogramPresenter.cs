using System;
using System.Collections.Generic;
using BigramApi;

namespace BigramPresentation {
    public class BigramHistogramPresenter {
        public HistogramViewModel Prepare(BigramHistogram histogram) { 
            if (histogram == null) throw new ArgumentNullException(nameof(histogram));

            var viewModel = new HistogramViewModel();
            var data = new List<HistogramEntryViewModel>();

            foreach (var entry in histogram.Data) {
                data.Add(new HistogramEntryViewModel {Bigram = entry.Key, Count = entry.Value});
            }

            viewModel.Data = data;

            return viewModel;
        }
    }
}
