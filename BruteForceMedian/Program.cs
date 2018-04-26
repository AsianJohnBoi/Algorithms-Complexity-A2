using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] {1, 2, 5, 4, 3};
            int result = BruteForceMedian(array);

            Console.WriteLine(result);
            Console.ReadKey();
        }

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
                if (numsmaller < k && k <= (numsmaller + numequal)){
                    Console.WriteLine(counter);
                    return A[i];
                }
            }
            return 0;
        }
    }
}
