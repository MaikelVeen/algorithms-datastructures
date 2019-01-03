using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class InsertionSort
    {
        public static T[] Execute<T>(T[] A) where T : IComparable<T>
        {
            for (int j = 1; j < A.Length; j++)
            {
                // Set the key: the value that will be sorted this iteration
                T key = A[j];

                // Set the initial value to compare to
                int i = j - 1;
                //int x = A[i].CompareTo(key);

                while (i >= 0 && A[i].CompareTo(key) > 0)
                {
                    // Shift the value to the right
                    A[i + 1] = A[i];

                    // Shift the value to compare to
                    i--;
                }

                A[i + 1] = key;
            }

            return A;
        }
    }
}