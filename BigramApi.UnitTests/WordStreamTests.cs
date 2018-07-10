using System;
using System.Linq;
using BigramApi.UnitTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigramApi.UnitTests {
    [TestClass]
    public class WordStreamTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWithoutFilepath() {
            var stream = new WordStream(null);
        }

        [TestMethod]
        public void ShouldReadZeroWords() {
            var characterStream = new MockCharacterStream("");
            var wordStream = new WordStream(characterStream);
            var actual = wordStream.Next().ToList();

            Assert.IsTrue(actual.Count == 0);
        }

        [TestMethod]
        public void ShouldReadOneWord() {
            var expected = "The";
            var characterStream = new MockCharacterStream(expected);
            var wordStream = new WordStream(characterStream);

            var words = wordStream.Next().ToList();

            Assert.IsTrue(words.Count == 1);
            Assert.AreEqual(expected, words[0]);
        }

        [TestMethod]
        public void ShouldReadTwoWords() {
            var firstWord = "The";
            var secondWord = "fox";
            var characterStream = new MockCharacterStream("The fox");
            var wordStream = new WordStream(characterStream);

            var words = wordStream.Next().ToList();

            Assert.IsTrue(words.Count == 2);
            Assert.AreEqual(firstWord, words[0]);
            Assert.AreEqual(secondWord, words[1]);
        }

        [TestMethod]
        public void ShouldFilterNonAlphaCharacters() {
            var firstWord = "The";
            var secondWord = "foxes";
            var characterStream = new MockCharacterStream("The \r\n 2 - foxes?");
            var wordStream = new WordStream(characterStream);

            var words = wordStream.Next().ToList();

            Assert.IsTrue(words.Count == 2);
            Assert.AreEqual(firstWord, words[0]);
            Assert.AreEqual(secondWord, words[1]);
        }
    }
}
