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
        private static double medianTimer;
        private static double bruteTimer;
        private static Stopwatch sw;
        private static Random rand = new Random();

        /// <summary>
        /// Median Algorithm
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
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
                sw.Stop();
                medianTimer = sw.Elapsed.TotalMilliseconds;
                sw.Reset();
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
            sw.Start();

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
        //End of the Median Algorithm

        /// <summary>
        /// Brute Force Algorithm
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
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
        //End of BruteForce Median algorithm

        static void Main(string[] args)
        {
            sw = new Stopwatch();
            int numberOfTimes = 30;
            for (int size = 1; size <= 100; size += 1) //number of tests for each array size
            {
                double averageMedianTimer = 0;
                double averageBruteForceTimer = 0;

                for (int i = 0; i < numberOfTimes; i++)
                {
                    //medianTimer = 0; 
                    //bruteTimer = 0; //Don't need to reset as its values are always replaced.
                    int[] test = GenerateRandomArray(size);
                    Median(test);
                    BruteForceMedian(test);

                    averageMedianTimer += medianTimer;
                    averageBruteForceTimer += bruteTimer;                 
                }
                averageMedianTimer = averageMedianTimer / numberOfTimes;
                averageBruteForceTimer = averageBruteForceTimer / numberOfTimes;
                //Console.WriteLine("For size {0}, execution time of Median: {1}, execution time of BruteForceMedian: {2}", size, averageMedianTimer, averageBruteForceTimer);
                Console.WriteLine("{0} {1}", Math.Round(averageMedianTimer, 5), Math.Round(averageBruteForceTimer, 5));
            }
            Console.ReadKey();
        }
          
            
    }
}
