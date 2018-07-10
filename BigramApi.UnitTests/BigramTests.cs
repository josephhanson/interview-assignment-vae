using System;
using System.Linq;
using BigramApi.UnitTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigramApi.UnitTests {
    [TestClass]
    public class BigramTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWithoutFilepath() {
            var stream = new BigramStream(null);
        }

        [TestMethod]
        public void ShouldNotOutputABigramAfterReadingASingleWord() {
            var words = new[] {"test1"};

            var wordStream = new MockWordStream(words);
            var bigramStream = new BigramStream(wordStream);

            var results = bigramStream.Next().ToList();

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ShouldOutputABigramAfterReadingTwoWords() {
            var words = new[] { "test1", "test2"};

            var wordStream = new MockWordStream(words);
            var bigramStream = new BigramStream(wordStream);

            var results = bigramStream.Next().ToList();

            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void ShouldOutputABigramContainingTheSecondAndThirdWordsAfterReadingThreeWords() {
            var words = new[] { "test1", "test2", "test3" };

            var wordStream = new MockWordStream(words);
            var bigramStream = new BigramStream(wordStream);

            var results = bigramStream.Next().ToList();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("test2", results[1].LeftWord);
            Assert.AreEqual("test3", results[1].RightWord);
        }
    }
}