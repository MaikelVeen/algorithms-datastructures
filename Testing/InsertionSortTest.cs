using Xunit;
using Algorithms;

namespace Testing
{
    public class InsertionSortTest
    {
        [Fact]
        public void TestInsertionSortIntegers()
        {
            int[] unsortedIntegers = {5, 3, 1, 9, 12};
            int[] sortedIntegers = {1, 3, 5, 9, 12};

            Assert.Equal(sortedIntegers, InsertionSort.Execute(unsortedIntegers));
        }

        [Fact]
        public void TestInsertionSortIntegerEmpty()
        {
            int[] unsortedIntegers = { };
            int[] sortedIntegers = { };

            Assert.Equal(sortedIntegers, InsertionSort.Execute(unsortedIntegers));
        }

        [Fact]
        public void TestInsertionSortIntegerDuplicate()
        {
            int[] unsortedIntegers = {5, 3, 3, 1, 1, 9, 12};
            int[] sortedIntegers = {1, 1, 3, 3, 5, 9, 12};

            Assert.Equal(sortedIntegers, InsertionSort.Execute(unsortedIntegers));
        }

        [Fact]
        public void TestInsertionSortStrings()
        {
            string[] unsortedIntegers = {"Xray", "Alpha", "Charlie", "Beta", "Kilo", "India"};
            string[] sortedIntegers = {"Alpha", "Beta", "Charlie", "India", "Kilo", "Xray"};

            Assert.Equal(sortedIntegers, InsertionSort.Execute(unsortedIntegers));
        }

        [Fact]
        public void TestInsertionSortStringEmpty()
        {
            string[] unsortedIntegers = { };
            string[] sortedIntegers = { };

            Assert.Equal(sortedIntegers, InsertionSort.Execute(unsortedIntegers));
        }

        [Fact]
        public void TestInsertionSortStringDuplicate()
        {
            string[] unsortedIntegers = {"Xray", "Alpha", "Charlie", "Beta", "Beta", "India"};
            string[] sortedIntegers = {"Alpha", "Beta", "Beta", "Charlie", "India", "Xray"};

            Assert.Equal(sortedIntegers, InsertionSort.Execute(unsortedIntegers));
        }
    }
}