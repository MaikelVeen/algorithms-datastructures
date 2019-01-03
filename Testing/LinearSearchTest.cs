using Xunit;
using Algorithms;

namespace Testing
{
    public class LinearSearchTest
    {
        [Fact]
        public void LinearSearchTestString()
        {
            string[] strings = {"One", "Two", "Three"};
            Assert.Equal(1, LinearSearch.Execute("Two", strings));
            Assert.Equal(-1, LinearSearch.Execute("Four", strings));
        }
        
        [Fact]
        public void LinearSearchTestInteger()
        {
            int[] integers = {2, 5, 7, 3, 5};
            Assert.Equal(3, LinearSearch.Execute(3, integers));
        }

    }
}