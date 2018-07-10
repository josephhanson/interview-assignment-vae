using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigramApi.IntegrationTests {
    [TestClass]
    public class NtfsFileTokenStreamTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWithoutFilepath() {
            var stream = new NtfsFileCharacterStream("");
        }

        [TestMethod]
        public void ShouldReceiveAlphaNumeric() {
            var characterStream = new NtfsFileCharacterStream("files\\alphanumeric.txt");
            var actual = new StringBuilder();

            foreach (var token in characterStream.Next()) {
                actual.Append(token);
            }

            var array = new[] { 'T', 'h', 'i', 's', 'I', 's', '0', 'a', 'l', 'p', 'h', 'a', 'N', 'u', 'm', 'e', 'r', 'i', 'c' };
            var expected = new string(array);

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void ShouldReceiveSpacesAndPunctuation() {
            var characterStream = new NtfsFileCharacterStream("files\\spaces-and-punctuation.txt");
            var actual = new StringBuilder();
            foreach (var token in characterStream.Next()) {
                actual.Append(token);
            }

            var array = new[] { 'e', 'n', 'd', 's', ' ', 'w', 'i', 't', 'h', ' ', 'a', ' ', 's', 'p', 'a', 'c', 'e', '!', ' ' };
            var expected = new string(array);

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void ShouldReturnsAndNewLines() {
            var characterStream = new NtfsFileCharacterStream("files\\returns-and-new-lines.txt");
            var actual = new StringBuilder();
            foreach (var token in characterStream.Next()) {
                actual.Append(token);
            }
            
            var array = new[] {'h', 'a', 's', '\r', '\n', ' ', 'r', 'e', 't', 'u', 'r', 'n', 's', '\r', '\n', 'a', 'n', 'd', ' ', 'n', 'e', 'w', ' ', '\r', '\n', 'l', 'i', 'n', 'e', 's'};
            var expected = new string(array);

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
