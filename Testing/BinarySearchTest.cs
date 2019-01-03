using Xunit;
using Algorithms;

namespace Testing
{
    public class BinarySearchTest
    {
        [Fact]
        public void BinarySearchTests()
        {
            int[] sortedIntegers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            Assert.Equal(2, BinarySearch.Execute(sortedIntegers, 3));
            Assert.Equal(3, BinarySearch.Execute(sortedIntegers, 4));
            Assert.Equal(-1, BinarySearch.Execute(sortedIntegers, 12));
        }
    }
}