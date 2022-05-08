using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CoinChange
{
    class DynamicProgramming
    {
        public Tuple<int, ArrayList> getNumberOfWays(int[] coins, int size, int value)
        {
            ArrayList coinList = new ArrayList();

            Array.Sort(coins); Array.Reverse(coins);

            int i, count = 0;

            for (i = 0; i < size; i++)
            {
                while (value >= coins[i])
                {
                    value -= coins[i];
                    coinList.Add(coins[i]);
                    count++;
                }
                if (value == 0)
                    break;
            }
            return new Tuple<int, ArrayList>(count, coinList);
        }
    }
}
