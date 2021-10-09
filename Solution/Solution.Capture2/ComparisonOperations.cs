using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture2
{
    public static class ComparisonOperations
    {
        public static void PrintComparisonOperations()
        {
            int a = 10;
            int b = 4;
            bool c;
            bool b1 = true;
            bool b2 = false;
            Console.WriteLine($"----------------------\n int a = 10;\n int b = 4;\n----------------------");

            Console.WriteLine($"operation == :\n\tbool c = a == b // c = {c = a == b}\n");
            Console.WriteLine($"operation != :\n\tbool c = a != b // c = {c = a != b}\n");
            Console.WriteLine($"operation < :\n\tbool c = a < b // c = {c = a < b}\n");
            Console.WriteLine($"operation > :\n\tbool c = a > b // c = {c = a > b}\n");
            Console.WriteLine($"operation <= :\n\tbool c = a <= b // c = {c = a <= b}\n");
            Console.WriteLine($"operation >= :\n\tbool c = a >= b // c = {c = a >= b}\n");

            Console.WriteLine($"----------------------\n bool b1 = true;\n bool b2 = false;\n----------------------");
            Console.WriteLine($"Logic operation | :\n\tbool c =  b1 | b2; // c = {c = b1 | b2}\n");
            Console.WriteLine($"Logic operation & :\n\tbool c =  b1 & b2; // c = {c = b1 & b2}\n");
            Console.WriteLine($"Logic operation || :\n\tbool c =  b1 || b2; // c = {c = b1 || b2}\n");
            Console.WriteLine($"Logic operation && :\n\tbool c =  b1 && b2; // c = {c = b1 && b2}\n");
            Console.WriteLine($"Logic operation ! :\n\tbool c = ! b2; // c = {c = !b2}\n");
            Console.WriteLine($"Logic operation ^ :\n\tbool c =  false ^ b2; // c = {c = false ^ b2}\n");

            Cleaner.CCleaner();

        }
    }
}
