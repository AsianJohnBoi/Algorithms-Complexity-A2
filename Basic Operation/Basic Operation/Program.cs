using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Average_basic_operation
{
    class Program
    {
        private static int counterForMedian;//global variable to store counter value of median
        private static int counterForBrute; //global variable to store counter value of Brute 
        private static Random rand = new Random();

        static int Median(int[] A)
        {
            if (A.Length == 1)
            {
                return A[0];
            }
            else
            {
                return Select(A, 0, A.Length / 2, A.Length - 1);
            }
        }


        static int Select(int[] A, int l, int m, int h)
        {
            int pos = Partition(A, l, h);

            if (pos == m)
            {
                return A[pos];
            }
            if (pos > m)
            {
                return Select(A, l, m, pos - 1);
            }
            if (pos < m)
            {
                return Select(A, pos + 1, m, h);
            }
            return 0;

        }

        static int Partition(int[] A, int l, int h)
        {
            int pivotval = A[l];
            int pivotloc = l;
            int count = 0; //new variable count starting from zero

            for (int j = l + 1; j <= h; j++)
            {
                count++;  //increment counter by one
                if (A[j] < pivotval)
                {
                    pivotloc = pivotloc + 1;
                    swap(A, pivotloc, j);
                }
            }
            swap(A, l, pivotloc);
            counterForMedian += count; //add value of counter to global variable 
            return pivotloc;
        }

        static void swap(int[] A, int first, int second)
        {
            int s = A[second];
            A[second] = A[first];
            A[first] = s;
        }

        static int[] GenerateRandomArray(int size)
        {
            int[] A = new int[size];
            for (int i = 0; i < A.Length; i++)
            {
                int n;
                do
                {
                    n = rand.Next(0, 10000);
                } while (A.Contains(n));
                A[i] = n;
            }
            return A;
        }

        static int BruteForceMedian(int[] A)
        {
            double k = Math.Ceiling(A.Length / 2.0);
            int counter = 0; //new counter variable starting from zero
            for (int i = 0; i < A.Length; i++)
            {
                int numsmaller = 0;
                int numequal = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    counter++; //increment counter by one
                    if (A[j] < A[i])
                    {
                        numsmaller = numsmaller + 1;
                    }
                    else
                    {
                        if (A[j] == A[i])
                        {
                            numequal = numequal + 1;
                        }
                    }
                }
                if (numsmaller < k && k <= (numsmaller + numequal))
                {
                    counterForBrute += counter;//Add counter value to global variable
                    return A[i];
                }
            }
            return 0;
        }
        //End of BruteForce Median algorithm

        static void Main(string[] args)
        {
            int numberOfTimes = 30;
            for (int size = 1; size <= 100; size += 1) //number of tests for each array size
            {
                int averageOneForMedian = 0; //new variables starting from zero
                int averageTwoForMedian = 0;
                int averageOneForBrute = 0;
                int averagetwoForBrute = 0;
                for (int i = 0; i < numberOfTimes; i++)
                {
                    counterForMedian = 0; //resets global variable to zero
                    counterForBrute = 0; //resets global variable to zero
                    int[] test = GenerateRandomArray(size);
                    Median(test);
                    BruteForceMedian(test);
                    averageOneForMedian += counterForMedian; //add global variable
                    averageOneForBrute += counterForBrute; //add global variable

                }
                averageTwoForMedian = averageOneForMedian / numberOfTimes; //divide averageOneForMedian to get the average result of thirty tests
                averagetwoForBrute = averageOneForBrute / numberOfTimes; //divide averageOneForBrute to get the average result of thirty tests
                Console.WriteLine("size: {0}  median average: {1} brute average: {2} ", size, averageTwoForMedian, averagetwoForBrute);
            }
            Console.ReadKey();
        }
    }
}
