using Xunit;

namespace Utils.Test;

public abstract class EnumerableExtensions
{
    public class TakeWhileInclusiveTests
    {
        [Fact]
        public void GivenEnumerableOfNumbersOneToTen_WhenPredicateMustBeLessThanFive_ThenNumbersOneToFiveAreReturned()
        {
            // Arrange
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            var result = source.TakeUntil((item, _) => item < 5);

            // Assert
            Assert.Equal([1, 2, 3, 4, 5], result);
        }

        [Fact]
        public void GivenEnumerableOfNumbersOneToTen_WhenPredicateIndexMustBeLessThanFour_ThenNumbersOneToFiveAreReturned()
        {
            // Arrange
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            var result = source.TakeUntil((_, index) => index < 4);

            // Assert
            Assert.Equal([1, 2, 3, 4, 5], result);
        }
    }

    public class PartitionTests
    {
        [Fact]
        public void GivenFiveNumbers_WithEvenOddPredicate_ThenSplitsItemsBasedOnPredicate()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var (trueItems, falseItems) = source.Partition(x => x % 2 == 0);

            Assert.Equal(new[] { 2, 4 }, trueItems);
            Assert.Equal(new[] { 1, 3, 5 }, falseItems);
        }

        [Fact]
        public void GivenEmptySource_ThenReturnsEmptyLists()
        {
            var source = Array.Empty<int>();
            var (trueItems, falseItems) = source.Partition(x => x % 2 == 0);

            Assert.Empty(trueItems);
            Assert.Empty(falseItems);
        }

        [Fact]
        public void GivenFiveNumbers_WithAllTruePredicate_ReturnsAllItemsInTrueList()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var (trueItems, falseItems) = source.Partition(x => true);

            Assert.Equal(source, trueItems);
            Assert.Empty(falseItems);
        }

        [Fact]
        public void GivenFiveNumbers_WithAllFalsePredicate_ReturnsAllItemsInFalseList()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var (trueItems, falseItems) = source.Partition(x => false);

            Assert.Empty(trueItems);
            Assert.Equal(source, falseItems);
        }
    }

    public class JoinTests
    {
        [Fact]
        public void GivenDefaultSeparatorAndToStringFunction_ReturnsCommaSeparatedString()
        {
            var collection = new[] { 1, 2, 3 };
            var result = collection.Join();

            Assert.Equal("1, 2, 3", result);
        }

        [Fact]
        public void GivenCustomSeparator_ReturnsCustomSeparatedString()
        {
            var collection = new[] { 1, 2, 3 };
            var result = collection.Join("; ");

            Assert.Equal("1; 2; 3", result);
        }

        [Fact]
        public void GivenCustomToStringFunction_ReturnsTransformedString()
        {
            var collection = new[] { 1, 2, 3 };
            var result = collection.Join(", ", x => $"Item {x}");

            Assert.Equal("Item 1, Item 2, Item 3", result);
        }

        [Fact]
        public void GivenNullCollection_ReturnsEmptyString()
        {
            IEnumerable<int>? collection = null;
            var result = collection.Join();

            Assert.Equal("", result);
        }

        [Fact]
        public void GivenEmptyCollection_ReturnsEmptyString()
        {
            var collection = Array.Empty<int>();
            var result = collection.Join();

            Assert.Equal("", result);
        }
    }
}