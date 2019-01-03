using Xunit;
using Algorithms;

namespace Search_Algorithms.Tests
{
    public class LinearSearchTests
    {
        [Fact]
        public void LinearSearchTest()
        {
            var integers = new int[] {2, 5, 7, 3, 5};
            var strings = new string[] {"One", "Tres", "One"};

            Assert.Equal(3, LinearSearch(3, integers));
            Assert.Equal(1, LinearSearch("Tres", strings));
            Assert.Equal(-1, LinearSearch("Ton", strings));
        }
    }
}