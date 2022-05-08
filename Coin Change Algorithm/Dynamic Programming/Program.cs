using System;
using System.Linq;

class DynamicProgramming
{
    // m is size of coins array
    static int minCoins(int[] coins,
                        int m, int V)
    {
        // table[i] will be storing the minimum number of coins required for i value. So table[V] will have result.
        int[] table = new int[V + 1];

        // Base case (If given value V is 0)
       table[0] = 0;

        // Initialize all table 
        for (int i = 1; i <= V; i++)
            table[i] = int.MaxValue;

        // Compute minimum coins required for all values from 1 to V
        for (int i = 1; i <= V; i++)
        {
            // Go through all coins smaller than i
            for (int j = 0; j < m; j++)
                if (coins[j] <= i)
                {
                    int sub_res = table[i - coins[j]];
                    if (sub_res != int.MaxValue && sub_res + 1 < table[i])
                    {
                        table[i] = sub_res + 1;
                    }
                }
        }
        return table[V];
    }

   static public void Main()
   {
        bool isThere1 = false;
        int sizeOfArray = 0;
        int i = 0;
        var givenMoney = new int[6];
        while (sizeOfArray <= 6)
        {
            Console.WriteLine("What Kind Of Coin Do you Have?");
            int input = Convert.ToInt16(Console.ReadLine());
            givenMoney[i] = input;
            sizeOfArray++;
            i++;
            if (input == 1)
            {
                isThere1 = true;
            }
            if (sizeOfArray == 6)
            {
                break;
            }
        }
        // check if there is a duplicate number.
        var count = givenMoney.GroupBy(x => x).Where(t => t.Count() > 1).Select(s => s.Key).ToList();
        if (count.Count != 0)
        {
           Console.Clear();
            Console.WriteLine("Coins should have unique values");
            Main();
        }
        // check if there is a negative number.
        int minus = givenMoney.Where(x => x < 0).Count();
        if (minus > 0)
        {
            Console.Clear();
            Console.WriteLine("Coin should be positive integer");
            Main();
        }

        if (!isThere1)
        {
            Console.Clear();
            Console.WriteLine("One coin must have value of 1");
            Main();
        }

        Console.WriteLine("Money ?");
        int key = int.Parse(Console.ReadLine());
        if (key < 0)
        {
            Console.Clear();
            Console.WriteLine("Input should be positive integer!");
            return;
        }
        if (key == 0)
        {
            Console.Clear();
            Console.WriteLine("No need money (:");
            return;
        }
        Console.WriteLine("Minimum coins required is " + minCoins(givenMoney, givenMoney.Length, key));
   }
}
