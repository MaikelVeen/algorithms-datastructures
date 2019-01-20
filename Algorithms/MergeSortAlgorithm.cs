using System;
using System.Collections.Generic;
using System.Reflection;


namespace Algorithms
{
    /// <summary>
    /// Wrapper class for merge sort algorithm
    /// </summary>
    public static class MergeSort
    {
        /// <summary>
        /// Returns a given array sorted. Uses merge sort as underlying
        /// sorting algorithm
        /// </summary>
        /// <typeparam name="T">Array to sort</typeparam>
        /// <returns></returns>
        public static T[] Sort<T>(T[] array) where T : IComparable
        {
            return Algorithm(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Actual implementation of merge sort
        /// </summary>
        /// <param name="arrayToSort">The current (sub-array) to be sorted</param>
        /// <param name="p">The first index of (sub)array</param>
        /// <param name="r">The last index of (sub)array</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T[] Algorithm<T>(T[] arrayToSort, int p, int r) where T : IComparable
        {
            if (!(p < r)) return arrayToSort;

            // Calculate the middle 
            int q = (p + r) / 2;

            // Recursively call merge sort on sub-arrays
            Algorithm(arrayToSort, p, q);
            Algorithm(arrayToSort, q + 1, r);
            Merge(arrayToSort, p, q, r);
            return arrayToSort;
        }

        private static T[] Merge<T>(T[] array, int p, int q, int r) where T : IComparable
        {
            // Calculate the lengths of the sub-arrays
            int n1 = q - p + 1;
            int n2 = r - q;

            T[] L = new T[n1 + 1];
            T[] R = new T[n2 + 1];

            for (int u = 0; u < n1; u++)
            {
                L[u] = array[p + u];
            }

            for (int w = 0; w < n2; w++)
            {
                R[w] = array[q + w];
            }

            // Initial indexes of first and second sub-arrays 
            int i = 0, j = 0;

            // Initial index of the merged sub-array
            int k = p;
            while (i < n1 && j < n2)
            {
                // Compare the left with the right
                if (L[i].CompareTo(R[j]) <= 0)
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }

                k++;
            }

            // Copy last elements of first array to merged
            while (i < n1)
            {
                array[k] = L[i];
                i++;
                k++;
            }

            // Copy last elements of second array to merged
            while (j < n2)
            {
                array[k] = R[j];
                j++;
                k++;
            }

            return array;
        }
    }
}