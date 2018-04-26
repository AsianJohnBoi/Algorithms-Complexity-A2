using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median_algorithm
{
    class Program
    {
        private static int counter;
        private static int num;
        static int Median(int[] A) {
            if(A.Length == 1) {
                return A[0];
            } else {
                return Select(A, 0, A.Length / 2, A.Length - 1);
            }
        }


        static int Select(int[] A, int l, int m, int h)
        {
            
            int pos;
            pos = Partition(A, l, h);
            
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
                   // count++;
                    pivotloc = pivotloc + 1;
                    swap(A, pivotloc, j);
                }
              
            }
            
            swap(A, l, pivotloc);
                  foreach (int i in A) {
                       Console.Write("{0}  ", i);
                  }
                Console.WriteLine();
            //      Console.WriteLine("count: {0}", count);
            // Console.WriteLine(count);
            counter += count;
            return pivotloc;
        }

        static void swap(int[] A, int first, int second)
        {
            int s = A[second];
            A[second] = A[first];
            A[first] = s;
        }




        static void Main(string[] args) {
            int[] B = new int[] {1,2,3,4,5};
            
            Console.WriteLine(Median(B));
           Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}
