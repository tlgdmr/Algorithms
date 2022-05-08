using System;
using System.Collections;
using System.Linq;

namespace CoinChange
{
    class Program
    {
        static GreedyApproach sort = new GreedyApproach();
        static DynamicProgramming dynamic = new DynamicProgramming();
        static int[] Coins = new int[] { 1, 2, 5, 10, 20, 50, 100 };
        static int input = 0;
        static int howMany = 0;
        static int change = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("1 = Task 1 , 2 = Task 2 , 3 = Task 3");
            change = Convert.ToInt16(Console.ReadLine());
            switch (change)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                default:
                    break;
            }
        }
        static void Task1()
        {
            Console.WriteLine("Change Coin to: ?");
            input = Convert.ToInt16(Console.ReadLine());
            if (input < 0)
            {
                Console.Clear();
                Console.WriteLine("Input should be positive integer!");
                return;
            }
            if (input == 0)
            {
                Console.Clear();
                Console.WriteLine("no need money (:");
                return;
            }
            sort.change(Coins, input, howMany);
            Main(null);
        }
        static void Task2()
        {
            bool isThere1 = false;
            int sizeOfArray = 0;
            int i = 0;
            var givenMoney = new int[6];
            while (sizeOfArray <= 6)
            {
                Console.WriteLine("What Kind Of Coin Do you Have");
                input = Convert.ToInt16(Console.ReadLine());
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
            // To check duplicate numbers.
            var count = givenMoney.GroupBy(x => x).Where(t => t.Count() > 1).Select(s => s.Key).ToList();
            if (count.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Coins should have unique values");
                Task2();
            }

            foreach (var item in givenMoney)
            {
                if (item < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Coin should be positive integer");
                    Task2();
                }
            }
            if (isThere1 == false)
            {
                Console.Clear();
                Console.WriteLine("One coin must have value of 1");
                Task2();
            }
            Console.WriteLine("Change Coin to: ?");
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
            sort.change(givenMoney, key, howMany);
            // Clear All Elements in the array.
            Array.Clear(givenMoney, 0, givenMoney.Length);
            Main(null);
        }
        static void Task3()
        {

            bool isThere1 = false;
            int sizeOfArray = 0;
            int i = 0;
            var givenMoney = new int[6];
            while (sizeOfArray <= 6)
            {
                Console.WriteLine("What Kind Of Coin Do you Have?");
                input = Convert.ToInt16(Console.ReadLine());
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

            var count = givenMoney.GroupBy(x => x).Where(t => t.Count() > 1).Select(s => s.Key).ToList();
            if (count.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Coins should have unique values");
                Task3();
            }

            int minus = givenMoney.Where(x => x < 0).Count();
            if (minus > 0)
            {
                Console.Clear();
                Console.WriteLine("Coin should be positive integer");
                Task3();
            }

            if (!isThere1)
            {
                Console.Clear();
                Console.WriteLine("One coin must have value of 1");
                Task2();
            }

            Console.WriteLine("Change Coin to: ?");
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

            Tuple<int, ArrayList> result = dynamic.getNumberOfWays(givenMoney, givenMoney.Length, key);
            Console.WriteLine($"Amount {result.Item1} and coins are {String.Join("x", result.Item2.ToArray())}");
            // Clear All Elements in the array.
            Array.Clear(givenMoney, 0, givenMoney.Length);
            Main(null);
        }
    }
}

