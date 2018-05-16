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
        /// Finds the median of a given array
        /// </summary>
        /// <param name="A">Takes in a given array to solve</param>
        /// <returns>The median value</returns>
        static int Median(int[] A) //Takes in array to find the Median
        {
            if (A.Length == 1)//Checks if array has one value
            {
                return A[0]; //Returns the only value in the array as median
            }
            else
            {
                return Select(A, 0, A.Length / 2, A.Length - 1); //Runs select procedure passing the array, number zero as a pivot, median index, and length of array 
            }
        }


        static int Select(int[] A, int l, int m, int h)
        {
            int pos = Partition(A, l, h); //calls partition procedure and passing array, pivot, median index, array size. Obtains the position of the pivot

            if (pos == m) //Checks if position is equal to the median index
            {
                return A[pos]; //Returns array position as final median
            }
            if (pos > m) //Checks if position is greater than the median index
            {
                return Select(A, l, m, pos - 1); //Re-runs this select procedure
            }
            if (pos < m) //Checks if the position is less than the median index
            {
                return Select(A, pos + 1, m, h); //Re-runs this select procedure
            }
            return 0;

        }


        static int Partition(int[] A, int l, int h)
        {
            int pivotval = A[l]; //uses the pivot’s value
            int pivotloc = l; //uses the pivot index

            for (int j = l + 1; j <= h; j++)//Uses each element in array to compare with the pivot
            {
                if (A[j] < pivotval) //if the current element is less than the pivot
                {
                    pivotloc = pivotloc + 1; //increment the pivot by one 
                    swap(A, pivotloc, j); //swap pivot index with the current element
                }

            }
            swap(A, l, pivotloc); //swap pivot index with the pivotloc value
            return pivotloc; //return pivot index
        }
        //End of the Median Algorithm


        /// <summary>
        /// takes array, and the two indexes to swap 
        /// </summary>
        /// <param name="A">Array</param>
        /// <param name="first">index one</param>
        /// <param name="second">index two</param>
        static void swap(int[] A, int first, int second)
        {
            int s = A[second]; //assigns value of index two to variable s
            A[second] = A[first]; //assigns value of index two with the value of index one
            A[first] = s; //assigns value of index one with value of variable s
        }


        /// <summary>
        /// Creates a new array
        /// </summary>
        /// <param name="size">the size of the array to generate</param>
        /// <returns>the generated array</returns>
        static int[] GenerateRandomArray(int size)
        {
            int[] A = new int[size]; //creates new array with given size
            for (int i = 0; i < A.Length; i++)
            { //iterates the following from zero to one
                int n; //creates new variable without assigning any value
                do
                {
                    n = rand.Next(0, 10000); //generates number between 0 and 10000
                                             //checks if the number is already in the array, if true then repeat the do-loop to generate a new number
                } while (A.Contains(n));
                A[i] = n; //adds generated number to the array
            }
            return A; //return array
        }

        /// <summary>
        /// Finds the Median value of a given array
        /// </summary>
        /// <param name="A">Gets the array</param>
        /// <returns>Median value</returns>
        static int BruteForceMedian(int[] A)
        {
            double k = Math.Ceiling(A.Length / 2.0); //Gets the position of the Median
            for (int i = 0; i < A.Length; i++) //Uses each element of the array as pivot
            {
                int numsmaller = 0; //Sets variables to zero
                int numequal = 0; //Sets variables to zero

                for (int j = 0; j < A.Length; j++) //Uses each element of array to compare with the pivot
                {
                    if (A[j] < A[i]) //if the pivot is greater than current element
                    {
                        numsmaller = numsmaller + 1; //increments by one
                    }
                    else
                    {
                        if (A[j] == A[i]) //if pivot is equal to current element
                        {
                            //incremenet variable by one
                            numequal = numequal + 1;
                        }
                    }
                }

                if (numsmaller < k && k <= (numsmaller + numequal)) //Determines if the value of k is greater than the value of numsmaller and is less than or equal to the numsmaller and numequal combined
                {
                    return A[i]; //returns pivot value as the median
                }
            }
            return 0;
        }

        /// <summary>
        /// Main controller of the program. Controls which algorithms, procedures and functions to run
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.ReadKey(); //waits for user input to end program
        }
    }
}
