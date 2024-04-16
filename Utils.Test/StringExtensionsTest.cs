using Xunit;

namespace Utils.Test;

public abstract class StringExtensions
{
    public class OtherwiseTests
    {
        [Theory]
        [InlineData(null, "alternate")]
        [InlineData("", "alternate")]
        [InlineData("   ", "alternate")]
        public void GivenNullOrEmptyOrWhitespaceString_ThenAlternateStringIsReturned(
            string? input,
            string alternate)
        {
            // Act
            var result = input.Otherwise(alternate);

            // Assert
            Assert.Equal(alternate, result);
        }

        [Theory]
        [InlineData("input", "alternate")]
        [InlineData(" input ", "alternate")]
        public void GivenValidString_ThenInputStringIsReturned(
            string? input,
            string alternate)
        {
            // Act
            var result = input.Otherwise(alternate);

            // Assert
            Assert.Equal(input, result);
        }
    }
}