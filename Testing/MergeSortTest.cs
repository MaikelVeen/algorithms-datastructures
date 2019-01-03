using Xunit;
using Algorithms;

namespace Testing
{
    public class MergeSortTest
    {
        [Fact]
        public void TestMergeSortIntegers()
        {
            int[] unsortedIntegers = {5, 3, 1, 9, 12};
            int[] sortedIntegers = {1, 3, 5, 9, 12};

            Assert.Equal(sortedIntegers,  MergeSortAlgorithm.Execute(unsortedIntegers));
        }

        [Fact]
        public void TestMergeSortIntegerEmpty()
        {
            int[] unsortedIntegers = { };
            int[] sortedIntegers = { };

            Assert.Equal(sortedIntegers, MergeSortAlgorithm.Execute(unsortedIntegers));
        }

        [Fact]
        public void TestMergeSortIntegerDuplicate()
        {
            int[] unsortedIntegers = {5, 3, 3, 1, 1, 9, 12};
            int[] sortedIntegers = {1, 1, 3, 3, 5, 9, 12};

            Assert.Equal(sortedIntegers, MergeSortAlgorithm.Execute(unsortedIntegers));
        }

        [Fact]
        public void TestMergeSortStrings()
        {
            string[] unsortedIntegers = {"Xray", "Alpha", "Charlie", "Beta", "Kilo", "India"};
            string[] sortedIntegers = {"Alpha", "Beta", "Charlie", "India", "Kilo", "Xray"};

            Assert.Equal(sortedIntegers, MergeSortAlgorithm.Execute(unsortedIntegers));
        }

        [Fact]
        public void TestInsertionSortStringDuplicate()
        {
            string[] unsortedIntegers = {"Xray", "Alpha", "Charlie", "Beta", "Beta", "India"};
            string[] sortedIntegers = {"Alpha", "Beta", "Beta", "Charlie", "India", "Xray"};

            Assert.Equal(sortedIntegers, MergeSortAlgorithm.Execute(unsortedIntegers));
        }
    }
    
 }