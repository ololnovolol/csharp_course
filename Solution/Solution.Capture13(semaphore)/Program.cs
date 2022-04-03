using System;

namespace Solution.Capture13_semaphore_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                Reader reader = new Reader(i);
            }
            Console.ReadLine();
        }
    }
}
