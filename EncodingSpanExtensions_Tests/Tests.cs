using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Text;

namespace EncodingSpanExtensions_Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GetBytesTest()
        {
            const string expectedString = "Hello";
            byte[] expected = Encoding.Default.GetBytes(expectedString);

            Span<byte> result = new byte[expected.Length];
            int byteCount = Encoding.Default.GetBytes(expectedString.AsSpan(), result);

            CollectionAssert.AreEqual(expected, result.ToArray());
            Assert.AreEqual(expected.Length, byteCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBytesUndersizedSpanTest()
        {
            const string expectedString = "Hello";

            Span<byte> undersizedSpan = new byte[1];
            Encoding.Default.GetBytes(expectedString.AsSpan(), undersizedSpan);
        }

        [TestMethod]
        public void GetByteCountTest()
        {
            const string expectedString = "Hello";

            int expected = Encoding.Default.GetByteCount(expectedString);

            int byteCount = Encoding.Default.GetByteCount(expectedString.AsSpan());

            Assert.AreEqual(expected, byteCount);
        }

        [TestMethod]
        public void GetStringTest()
        {
            const string expected = "Hello";

            byte[] bytes = Encoding.Default.GetBytes(expected);

            string result = Encoding.Default.GetString(bytes.AsSpan());

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetCharsTest()
        {
            const string expectedString = "Hello";

            byte[] expectedBytes = Encoding.Default.GetBytes(expectedString);
            char[] expectedChars = Encoding.Default.GetChars(expectedBytes);

            Span<char> result = new char[expectedChars.Length];
            int charCount = Encoding.Default.GetChars(expectedBytes.AsSpan(), result);

            CollectionAssert.AreEqual(expectedChars, result.ToArray());
            Assert.AreEqual(expectedChars.Length, charCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCharsUndersizedSpanTest()
        {
            const string expectedString = "Hello";

            Span<byte> expectedBytes = Encoding.Default.GetBytes(expectedString);

            Span<char> undersizedSpan = new char[1];
            Encoding.Default.GetChars(expectedBytes, undersizedSpan);
        }

        [TestMethod]
        public void GetCharCountTest()
        {
            const string expectedString = "Hello";

            byte[] expectedBytes = Encoding.Default.GetBytes(expectedString);
            int expected = Encoding.Default.GetCharCount(expectedBytes);

            int byteCount = Encoding.Default.GetCharCount(expectedBytes.AsSpan());

            Assert.AreEqual(expected, byteCount);
        }
    }
}