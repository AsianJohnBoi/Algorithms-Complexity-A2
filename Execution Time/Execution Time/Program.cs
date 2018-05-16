using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median_algorithm
{
    class Program
    {
        private static double medianTimer; //Global variable 
        private static double bruteTimer; //global variable
        private static Stopwatch sw; //stopwatch
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
                sw.Stop(); //stops stopwatch
                medianTimer = sw.Elapsed.TotalMilliseconds; //converts stopwatch into milliseconds and assigns it to the global variable medianTimer
                sw.Reset(); //Resets stopwatch back to zero
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
            sw.Start(); //starts stopwatch 

            for (int j = l + 1; j <= h; j++)
            {
                if (A[j] < pivotval)
                {
                    pivotloc = pivotloc + 1;
                    swap(A, pivotloc, j);
                }
            }
            swap(A, l, pivotloc);
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
            var timer = System.Diagnostics.Stopwatch.StartNew(); //starts stopwatch
            for (int i = 0; i < A.Length; i++)
            {
                int numsmaller = 0;
                int numequal = 0;
                for (int j = 0; j < A.Length; j++)
                {
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
                    timer.Stop(); //stops stopwatch
                    bruteTimer = timer.Elapsed.TotalMilliseconds; //assigns the timer to the global variable
                    return A[i];
                }
            }
            return 0;
        }

        static void Main(string[] args)
        {
            sw = new Stopwatch(); //Creates new stopwatch
            int numberOfTimes = 30;
            for (int size = 1; size <= 100; size += 1)
            {
                double averageMedianTimer = 0; //new variable with value of zero
                double averageBruteForceTimer = 0; //new variable with value of zero

                for (int i = 0; i < numberOfTimes; i++)
                {
                    int[] test = GenerateRandomArray(size);
                    Median(test);
                    BruteForceMedian(test);
                    averageMedianTimer += medianTimer; //adds global variable
                    averageBruteForceTimer += bruteTimer; //adds global variable
                }
                averageMedianTimer = averageMedianTimer / numberOfTimes; //divides the value of the averageMedianTimer by the number of tests run to get the average
                averageBruteForceTimer = averageBruteForceTimer / numberOfTimes; //divides the value of the averageBruteForceTimer by the number of tests run to get the average
                Console.WriteLine("For size {0}, execution time of Median: {1}, execution time of BruteForceMedian: {2}", size, Math.Round(averageMedianTimer, 5), Math.Round(averageBruteForceTimer, 5)); //prints results in 5 decimal places
            }
            Console.ReadKey();
        }
    }
}
