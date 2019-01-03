using System;
using System.Collections.Generic;


namespace Algorithms
{
    // TODO: Remove ref and make sure the unit tests work on the algorithm
    public class MergeSortAlgorithm
    {
        public static T[] Execute<T>(T[] A) where T : IComparable<T>
        {
            T[] sortedArray = MergeSort(ref A, 0, A.Length - 1);
            return sortedArray;
        }

        private static T[] MergeSort<T>(ref T[] array, int firstIndex, int lastIndex) where T : IComparable<T>
        {
            if (firstIndex < lastIndex)
            {
                int middle = (firstIndex + lastIndex) / 2;
                MergeSort(ref array, firstIndex, middle);
                MergeSort(ref array, middle + 1, lastIndex);
                Merge(ref array, firstIndex, middle, lastIndex);
            }

            return array;
        }

        private static void Merge<T>(ref T[] input, int low, int middle, int high) where T : IComparable<T>
        {
            int left = low;
            int right = middle + 1;
            T[] tmp = new T[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left].CompareTo(input[right]) < 0)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                }

                tmpIndex = tmpIndex + 1;


                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }

                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }
        }
    }
}