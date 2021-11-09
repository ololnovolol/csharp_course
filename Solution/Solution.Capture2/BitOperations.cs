using System;

namespace Solution.Capture2
{
    public static class BitOperations
    {

        public static void PrintBO()
        {
            Console.Write("-------------------- \ninput number x1 : 2\n");
            int x1 = 2;
            Console.Write("input number x2: 5\n--------------------\n");
            int x2 = 5;

            Console.WriteLine($"result for (x1 & x2)  logical multiplication = {x1 & x2}");
            Console.WriteLine($"result for (x1 | x2)  logical sum = {x1 | x2}");
            Console.WriteLine($"result for (x1 ^ x2)  XOR = {x1 ^ x2}");
            Console.WriteLine($"result for (~x1)  logical negation or inversion = {~x1}");
            Console.WriteLine($"result for (~x2)  logical negation or inversion = {~x2}");

            Cleaner.CCleaner();
        }

    }
}
