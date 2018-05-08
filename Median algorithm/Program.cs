using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median_algorithm
{
    class Program
    {
        private static int counterForMedian;
        private static int counterForBrute;
        private static Random rand = new Random();

        /// <summary>
        /// Median Algorithm
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        static int Median(int[] A) {
            if(A.Length == 1) {
                return A[0];
            } else {
                return Select(A, 0, A.Length / 2, A.Length - 1);
            }
        }


        static int Select(int[] A, int l, int m, int h) {
            int pos = Partition(A, l, h);
            
            if (pos == m) {
                return A[pos]; 
            }
            if (pos > m) {
                return Select(A, l, m, pos - 1);
            }
            if(pos < m) {
                return Select(A, pos + 1, m, h);
            }
            return 0;

        }


        static int Partition(int[] A, int l, int h) {
            int pivotval = A[l];
            int pivotloc = l;
            int count = 0;
          
            for (int j = l+1; j <= h; j++) {
               count++;
                if (A[j] < pivotval) {
                    pivotloc = pivotloc + 1;
                    swap(A, pivotloc, j);
                }
              
            }
            swap(A, l, pivotloc);
         
            counterForMedian += count;
            return pivotloc;
        }

        static void swap(int[] A, int first, int second) {
            int s = A[second];
            A[second] = A[first];
            A[first] = s;
        }


        static int[] GenerateRandomArray(int size) {
            int[] A = new int[size];
            for (int i = 0; i < A.Length; i++) {
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
            int counter = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int numsmaller = 0;
                int numequal = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    counter++;
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
                    counterForBrute += counter;
                    return A[i];
                }
            }
            return 0;
        }
        //End of BruteForce Median algorithm
    
        static void Main(string[] args) {
        
         
            int numberOfTimes = 3;
            for (int size = 1; size <= 20; size+= 1) //number of tests for each array size
            {
                int averageOneForMedian = 0;
                int averageTwoForMedian = 0;
                int averageOneForBrute = 0;
                int averagetwoForBrute = 0;
                for (int i = 0; i < numberOfTimes; i++)
                {
                    counterForMedian = 0;
                    counterForBrute = 0;
                    int[] test = GenerateRandomArray(size);
                    Median(test);
                    BruteForceMedian(test);
                    averageOneForMedian += counterForMedian;
                    averageOneForBrute += counterForBrute;

                }
                averageTwoForMedian = averageOneForMedian / numberOfTimes;
                averagetwoForBrute = averageOneForBrute / numberOfTimes;
                Console.WriteLine("size: {0}  median average: {1} brute average: {2} ", size, averageTwoForMedian, averagetwoForBrute);
            }
            //   int numberOfTimes = 20;
            // double average;
            //for (int i = 0; i < numberOfTimes; i++) {
           //  int[] b = GenerateRandomArray(4);
          //   Median(b);
       //  }
      /*   average = counter/ numberOfTimes;
         Console.Write(average);
        int[] b = new int[]{ 1,4,2,3 };
            Console.WriteLine(Median(b));
           
    */
            Console.ReadKey();
        }
    }
}
