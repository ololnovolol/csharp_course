using System;

namespace Solution.Capture2
{
    public class Factorial
    {
        public static int Factor(int x)
        {
            return x == 0 ? 1 : x * Factor(x - 1);
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

