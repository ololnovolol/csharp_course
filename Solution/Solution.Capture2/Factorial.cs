using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture2
{
    public  class Factorial
    {


            public static int Factor(int x)
            {
                if (x == 0)
                {
                    return 1;
                }
                else
                {
                    return x * Factor(x - 1);
                }
            }

        public static void PrintArray(int[] masive, int i = 0)
        {
            if (i < masive.Length)
            {
                Console.WriteLine(masive[i]);
                i++;
                PrintArray(masive, i);
            }
            else
            {
                
            }
        }
        
    }
}

