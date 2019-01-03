using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class LinearSearch
    {
        public static int Execute<T>(T searchValue, T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(array[i], searchValue))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}