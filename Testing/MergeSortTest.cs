using System;
using Xunit;
using Algorithms;

namespace Testing
{
    public class MergeSortTest
    {
        private static readonly int[] unsortedIntegers = {5, 3, 1, 9, 12};
        private static readonly int[] unsortedIntegersDuplicates = {5, 5, 5, 3, 1, 9, 12, 8, 8};

        private static readonly string[] unsortedStrings = {"Xray", "Alpha", "Charlie", "Beta", "Kilo", "India"};

        private static readonly string[] unsortedStringsDuplicates =
            {"Xray", "Alpha", "Alpha", "Charlie", "Beta", "Beta", "Kilo", "India"};


        [Fact]
        public void TestMergeSort_Integer()
        {
            int[] sortedArray = MergeSort.Sort(unsortedIntegers);
            Array.Sort(unsortedIntegers);
            Assert.Equal(unsortedIntegers, sortedArray);
        }

        [Fact]
        public void TestMergeSortEmpty_Integer()
        {
            int[] empty = { };
            int[] sortedArray = MergeSort.Sort(empty);
            Array.Sort(empty);
            Assert.Equal(empty, sortedArray);
        }

        [Fact]
        public void TestMergeSortDuplicates_Integers()
        {
            int[] sortedArray = MergeSort.Sort(unsortedIntegersDuplicates);
            Array.Sort(unsortedIntegersDuplicates);
            Assert.Equal(unsortedIntegersDuplicates, sortedArray);
        }

        [Fact]
        public void TestMergeSortRandomLarge_Integers()
        {
            Random random = new Random();
            int upper_bound = 1000000;
            int[] randomValues = new int[upper_bound];
            for (int i = 0; i < upper_bound; i++)
            {
                randomValues[i] = random.Next(int.MinValue, int.MaxValue);
            }

            int[] sortedArray = MergeSort.Sort(randomValues);
            Array.Sort(sortedArray);

            Assert.Equal(sortedArray, randomValues);
        }

        [Fact]
        public void TestMergeSort_String()
        {
            string[] sortedArray = MergeSort.Sort(unsortedStrings);
            Array.Sort(unsortedStrings);
            Assert.Equal(unsortedStrings, sortedArray);
        }

        [Fact]
        public void TestMergeSortEmpty_String()
        {
            string[] empty = { };
            string[] sortedArray = MergeSort.Sort(empty);
            Array.Sort(empty);
            Assert.Equal(empty, sortedArray);
        }

        [Fact]
        public void TestMergeSortDuplicates_String()
        {
            string[] sortedArray = MergeSort.Sort(unsortedStringsDuplicates);
            Array.Sort(unsortedStringsDuplicates);
            Assert.Equal(unsortedStringsDuplicates, sortedArray);
        }
    }
}