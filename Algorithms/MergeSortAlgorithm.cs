using System;
using System.Collections.Generic;


namespace Algorithms
{
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

        /*private static void Merge<T>(ref T[] array, int firstIndex, int middleIndex, int lastIndex)
            where T : IComparable<T>
        {
            int n1 = middleIndex - firstIndex;
            int n2 = lastIndex - middleIndex;

            T[] left = new T[n1 + 1];
            T[] right = new T[n2 + 1];

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = array[firstIndex + i];
            }

            for (int i = 0; i < right.Length; i++)
            {
                right[i] = array[middleIndex + i];
            }


            int a = 0;
            int s = 0;

            for (int k = firstIndex; k < firstIndex; k++)
            {
                if (left[a].CompareTo(right[s]) >= 0)
                {
                    array[k] = left[a];
                    a++;
                }
                else
                {
                    array[k] = right[s];
                    s++;
                }
            }
        }*/

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