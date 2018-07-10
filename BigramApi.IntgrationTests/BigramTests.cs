using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigramApi.IntegrationTests {
    [TestClass]
    public class BigramTests {
        [TestMethod]
        public void OutputShouldMatchInterviewExpectationsV2() {
            var histogram = new BigramHistogram();
            var characters = new NtfsFileCharacterStream("files\\sample-text.txt");
            var words = new WordStream(characters);
            var bigramStream = new BigramStream(words);

            foreach (var bigram in bigramStream.Next()) {
                histogram.Add(bigram);
            }

            Assert.AreEqual(7, histogram.Data.Count);
            var data = histogram.Data;

            Assert.AreEqual(data["the quick"], 2);
            Assert.AreEqual(data["quick brown"], 1);
            Assert.AreEqual(data["brown fox"], 1);
            Assert.AreEqual(data["fox and"], 1);
            Assert.AreEqual(data["and the"], 1);
            Assert.AreEqual(data["quick blue"], 1);
            Assert.AreEqual(data["blue hare"], 1);
        }
    }
}
