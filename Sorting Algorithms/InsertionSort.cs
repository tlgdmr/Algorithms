using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting_Algorithms
{
    public class InsertionSort
    {
        public InsertionSort()
        {

        }
        public void Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j - 1] > array[j])
                {
                    //swap procedure
                    int temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                    j--;
                }
            }
        }
    }
}
