using System;

namespace Sorting_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1= Insertion Sort, 2 = HeapSort, 3 = Counting Sort");
            int sorting = int.Parse(Console.ReadLine());
            switch (sorting)
            {
                case 1:
                    InsertionSortAlgorithm();
                    break;
                case 2:
                    heapSort();
                    break;
                case 3:
                    CountingSort();
                    break;
                default:
                    break;
            }
        }
        public static void  InsertionSortAlgorithm()
        {
            InsertionSort sort = new InsertionSort();
            int[] generator = CreateAscendingArray(10000);
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            sort.Sort(generator);
            watch.Stop();
            Console.WriteLine($"Ascending Order: Size={generator.Length}, Time={watch.ElapsedMilliseconds}ms");

            int[] generator2 = CreateDescendingArray(10000);
            var watch2 = new System.Diagnostics.Stopwatch();
            watch2.Start();
            sort.Sort(generator2);
            watch2.Stop();
            Console.WriteLine($"Descending Order: Size={generator2.Length}, Time={watch2.ElapsedMilliseconds}ms");

            int[] generator3 = CreateRandomArray(10000);
            var watch3 = new System.Diagnostics.Stopwatch();
            watch3.Start();
            sort.Sort(generator3);
            watch3.Stop();
            Console.WriteLine($"Random Array: Size={generator3.Length}, Time={watch3.ElapsedMilliseconds}ms");

            int[] generator4 = CreateVshapeArray(10000);
            var watch4 = new System.Diagnostics.Stopwatch();
            watch4.Start();
            sort.Sort(generator4);
            watch4.Stop();
            Console.WriteLine($"V shape Array: Size={generator4.Length}, Time={watch4.ElapsedMilliseconds}ms");

            int[] generator5 = CreateAshapeArray(10000);
            var watch5 = new System.Diagnostics.Stopwatch();
            watch5.Start();
            sort.Sort(generator5);
            watch5.Stop();
            Console.WriteLine($"A shape Array: Size={generator5.Length}, Time={watch5.ElapsedMilliseconds}ms");
            Main(null);
        }
        public static void heapSort()
        {
            HeapSort heap = new HeapSort();
            int[] generator = CreateAscendingArray(100000);
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            heap.sorting(generator);
            watch.Stop();
            Console.WriteLine($"Ascending Order: Size={generator.Length}, Time={watch.ElapsedMilliseconds}ms");

            int[] generator2 = CreateDescendingArray(100000);
            var watch2 = new System.Diagnostics.Stopwatch();
            watch2.Start();
            heap.sorting(generator2);
            watch2.Stop();
            Console.WriteLine($"Descending Order: Size={generator2.Length}, Time={watch2.ElapsedMilliseconds}ms");

            int[] generator3 = CreateRandomArray(100000);
            var watch3 = new System.Diagnostics.Stopwatch();
            watch3.Start();
            heap.sorting(generator3);
            watch3.Stop();
            Console.WriteLine($"Random Array: Size={generator3.Length}, Time={watch3.ElapsedMilliseconds}ms");

            int[] generator4 = CreateVshapeArray(100000);
            var watch4 = new System.Diagnostics.Stopwatch();
            watch4.Start();
            heap.sorting(generator4);
            watch4.Stop();
            Console.WriteLine($"V shape Array: Size={generator4.Length}, Time={watch4.ElapsedMilliseconds}ms");

            int[] generator5 = CreateAshapeArray(100000);
            var watch5 = new System.Diagnostics.Stopwatch();
            watch5.Start();
            heap.sorting(generator5);
            watch5.Stop();
            Console.WriteLine($"A shape Array: Size={generator5.Length}, Time={watch5.ElapsedMilliseconds}ms");
            Main(null);
        }
        public static void CountingSort()
        {
            CountingSort counting = new CountingSort();
            int[] generator = CreateAscendingArray(1000000);
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            counting.countingSort(generator);
            watch.Stop();
            Console.WriteLine($"Ascending Order: Size={generator.Length}, Time={watch.ElapsedMilliseconds}ms");

            int[] generator2 = CreateDescendingArray(1000000);
            var watch2 = new System.Diagnostics.Stopwatch();
            watch2.Start();
            counting.countingSort(generator2);
            watch2.Stop();
            Console.WriteLine($"Descending Order: Size={generator2.Length}, Time={watch2.ElapsedMilliseconds}ms");

            int[] generator3 = CreateRandomArray(1000000);
            var watch3 = new System.Diagnostics.Stopwatch();
            watch3.Start();
            counting.countingSort(generator3);
            watch3.Stop();
            Console.WriteLine($"Random Array: Size={generator3.Length}, Time={watch3.ElapsedMilliseconds}ms");

            int[] generator4 = CreateVshapeArray(1000000);
            var watch4 = new System.Diagnostics.Stopwatch();
            watch4.Start();
            counting.countingSort(generator4);
            watch4.Stop();
            Console.WriteLine($"V shape Array: Size={generator4.Length}, Time={watch4.ElapsedMilliseconds}ms");

            int[] generator5 = CreateAshapeArray(1000000);
            var watch5 = new System.Diagnostics.Stopwatch();
            watch5.Start();
            counting.countingSort(generator5);
            watch5.Stop();
            Console.WriteLine($"A shape Array: Size={generator5.Length}, Time={watch5.ElapsedMilliseconds}ms");
            Main(null);
        }
        static int[] CreateAscendingArray(int size)
        {
            // To create a array.
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            return array;
        }
        static int[] CreateDescendingArray(int size)
        {
            // To create a array.
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            Array.Reverse(array);
            return array;
        }
        static int[] CreateRandomArray(int size)
        {
            Random rnd = new Random();
            // To create a array.
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                int randomNumber = rnd.Next(0, 10000000);// For InsertionSort and Heap sort use rnd.next(0,10000000)
                array[i] = randomNumber;                  // For Counting Sort, write the same number of size of Array.(I mean size of (int[] generator)
                                                          // which is in the other function)
            }
            return array;
        }
        static int[] CreateVshapeArray(int size)
        {
            int count = 0;
            // To create a array.
            int[] array = new int[size];
            for (int i = array.Length / 2; i >= 0; i--)
            {
                array[count] = i;
                count++;
            }
            for (int i = array.Length - 1; i > array.Length / 2; i--)
            {
                array[i] = i;
            }

            return array;
        }
        static int[] CreateAshapeArray(int size)
        {

            // To create a array.
            int[] array = new int[size];
            int count = array.Length / 2;
            for (int i = 0; i < array.Length / 2; i++)
            {
                array[i] = i;
            }
            for (int i = array.Length / 2; i > 0; i--)
            {
                array[count] = i;
                count++;
            }

            return array;
        }
        
    }
}