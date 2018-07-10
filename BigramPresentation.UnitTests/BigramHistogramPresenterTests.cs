using BigramApi;
using BigramPresentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigramPresentationTests {
    [TestClass]
    public class BigramHistogramPresenterTests {
        [TestMethod]
        public void ShouldPrepareViewModelForSingleBigram() {
            var histogram = new BigramHistogram();
            histogram.Add(new Bigram {LeftWord = "the", RightWord = "quick"});
            var presenter = new BigramHistogramPresenter();

            var view = presenter.Prepare(histogram);

            Assert.AreEqual(1, view.Count);
            Assert.AreEqual("the quick", view.Data[0].Bigram);
            Assert.AreEqual(1, view.Data[0].Count);
        }

        [TestMethod]
        public void ShouldPrepareViewModelForMultipleBigrams() {
            var histogram = new BigramHistogram();
            histogram.Add(new Bigram { LeftWord = "the", RightWord = "quick" });
            histogram.Add(new Bigram { LeftWord = "quick", RightWord = "brown" });
            histogram.Add(new Bigram { LeftWord = "the", RightWord = "quick" });
            var presenter = new BigramHistogramPresenter();

            var view = presenter.Prepare(histogram);

            Assert.AreEqual(2, view.Count);
            Assert.AreEqual("the quick", view.Data[0].Bigram);
            Assert.AreEqual(2, view.Data[0].Count);
        }
    }
}
