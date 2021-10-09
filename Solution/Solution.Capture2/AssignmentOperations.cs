using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture2
{
    public static class AssignmentOperations
    {
        public static void PrintAO()
        {
            int a = 10;
            Console.WriteLine($"Applying assignment operations: int a = 10 \na += 10; // {a+=10}");
            Console.WriteLine($"a -= 4; // {a -= 4}");
            Console.WriteLine($"a *= 2; // {a *= 2}");
            Console.WriteLine($"a /= 8; // {a /= 8}");
            Console.WriteLine($"a <<= 4; // {a <<= 4}");
            Console.WriteLine($"a >>= 2; // {a >>= 2}");
            a = 8;
            int b = 6;int c = 0;
            Console.WriteLine("------------------------\nint a = 8 \nint b = 6;");
            Console.WriteLine($"c = a += b -= 5; // {(c = a += b -= 5)}");

        }
    }
}
