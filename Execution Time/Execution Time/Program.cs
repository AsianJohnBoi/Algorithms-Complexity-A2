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
        private static double timer1;
        private static long timer2;
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
                timer1 = sw.Elapsed.TotalMilliseconds;
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
                    timer2 = timer.ElapsedMilliseconds; //assigns the timer to the global variable
                    return A[i];
                }
            }
            return 0;
        }
        //End of BruteForce Median algorithm

        static void Main(string[] args)
        {
            timer1 = 0;
            timer2 = 0;

            int numberOfTimes = 30;
            for (int size = 1; size <= 20; size += 1) //number of tests for each array size
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    int[] test = GenerateRandomArray(size);
                    Median(test);
                    BruteForceMedian(test);

                }
                Console.WriteLine("For size {0}, execution time of Median: {1}, execution time of BruteForceMedian: {2}", size, timer1, timer2);
            }
          
            Console.ReadKey();
        }
    }
}
