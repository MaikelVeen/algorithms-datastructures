using Xunit;
using Algorithms;

namespace Testing
{
    public class MergeSortTest
    {
        readonly int[] unsortedIntegers = {5, 3, 1, 9, 12};
        readonly int[] sortedIntegers = {1, 3, 5, 9, 12};
        
        [Fact]
        public void TestMergeSortIntegers()
        {
            Assert.Equal(sortedIntegers, MergeSortAlgorithm.Execute(unsortedIntegers));
        }
    }
    
 }