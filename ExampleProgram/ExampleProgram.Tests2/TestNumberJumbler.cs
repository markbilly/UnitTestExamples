using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleProgram.Tests
{
    [TestFixture]
    public class TestNumberJumbler
    {
        [TestCase("12345", "54321")]
        [TestCase("66666", "66666")]
        public void NumberJumbler_GivenANumber_DigitsReversed(string inputNumber, string expected)
        {
            // Arrange
            var jumbler = new NumberJumbler(null);

            // Action
            var result = jumbler.Jumble(inputNumber);

            // Assert
            Assert.AreEqual(expected, result, "Number not reversed");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void NumberJumbler_GivenCharactersInput_ThrowsArgumentException()
        {
            // Arrange
            var input = "hello";
            var jumbler = new NumberJumbler(null);

            // Action
            var result = jumbler.Jumble(input);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NumberJumbler_GivenNullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string input = null;
            var jumbler = new NumberJumbler(null);

            // Action
            var result = jumbler.Jumble(input);
        }

        [Test]
        public void NumberJumbler_GivenBulkNumbers_ReturnsAllNumbersReversed()
        {
            // Arrange
            var mockFileRepository = new Mock<ITextFileRepository>();
            mockFileRepository.Setup(x => x.GetFileLines(It.IsAny<string>()))
                .Returns(new string[3] { "051", "584", "321" });

            var jumbler = new NumberJumbler(mockFileRepository.Object);

            // Actions
            var result = jumbler.BulkJumble("boo");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("150", result.ElementAt(0));
            Assert.AreEqual("485", result.ElementAt(1));
            Assert.AreEqual("123", result.ElementAt(2));
        }
    }
}
