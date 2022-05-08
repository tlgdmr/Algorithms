using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting_Algorithms
{
    class CountingSort
    {
        public void countingSort(int[] array)
        {
            int length = array.Length;

            //Create a new "output" array
            int[] output = new int[length];

            //Create a new "counting" array which stores the count of each unique number
            int[] count = new int[10000000];// write size of Array which is in the int[] generator(in the program.cs) otherwise you get error.
            for (int i = 0; i < 100; ++i)
            {
                count[i] = 0;
            }
            for (int i = 0; i < length; ++i)
            {
                ++count[array[i]];
            }
            //Change count[i] so that count[i] now contains the actual position of this character in the output array.  
            for (int i = 1; i <= 99; ++i)
            {
                count[i] += count[i - 1];
            }
            //Build the output array To make this sorting algorithm stable
            for (int i = length - 1; i >= 0; i--)
            {
                output[count[array[i]] - 1] = array[i];
                --count[array[i]];
            }
            //Copy the output array to the final array.
            for (int i = 0; i < length; ++i)
            {
                array[i] = output[i];
            }
        }

    }
}
