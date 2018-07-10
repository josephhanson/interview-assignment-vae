using System.Collections.Generic;
using BigramPresentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigramPresentationTests {
    [TestClass]
    public class JsonOutputTests {
        [TestMethod]
        public void ShouldProduceJsonRepresentation() {
            var expected = @"{
""the quick"" : ""1"",
""quick brown"" : ""1""
}";
            var view = new HistogramViewModel();
            var data = new List<HistogramEntryViewModel>();
            data.Add(new HistogramEntryViewModel {Bigram = "the quick", Count = 1});
            data.Add(new HistogramEntryViewModel {Bigram = "quick brown", Count = 1});
            view.Data = data;

            var output = new JsonOutput(view);
            var actual = output.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
