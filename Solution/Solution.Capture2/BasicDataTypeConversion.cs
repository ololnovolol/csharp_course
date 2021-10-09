using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture2
{
    public static class BasicDataTypeConversion
    {
        public static void PrintBDTC() {

            Console.WriteLine("Data loss and the checked keyword\n-----------------------------------\nint x = 33;\nint y = 600\n-----------------------------------");
                int x = 33;
                int y = 600;
                byte z = ((byte)(x + y));
                Console.WriteLine("byte z = ((byte)(x + y)) without use checked keyword byte z = " + z);

            Console.Write("byte z = ((byte)(x + y)) without use checked keyword byte z = ");
            try
            {
                int a = 33;
                int b = 600;
                byte c = checked((byte)(a + b));
                Console.WriteLine(c);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message + "!!!");
            }
        }
    }
}
