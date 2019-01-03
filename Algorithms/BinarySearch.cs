namespace Algorithms
{
    public static class BinarySearch
    {
        public static int Execute(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int middle = (low + high) / 2;

                //if (middle > array.Length - 1) break;

                if (value < array[middle])
                {
                    high = middle - 1;
                }
                
                else if (value > array[middle])
                {
                    low = middle + 1;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }
    }
}