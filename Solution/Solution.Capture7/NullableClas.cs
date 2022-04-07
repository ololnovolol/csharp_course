using System;

namespace Solution.Capture7
{
    public class NullableClas
    {
        int? x = 35;
        string str = null;
        bool? enable = null;

        public string Str { get => str; set => str = value; }

        public void PrinterNullable()
        {
            if (x.HasValue)
            {
                Console.WriteLine(x.Value);
            }
            else
            {
                Console.WriteLine("x is equal to null");
            }
        }

        public void ExplicitConversFromTtoTNull()
        {
            int? x1 = null;
            if (x1.HasValue)
            {
                int x2 = (int)x1;
                Console.WriteLine("ExplicitConversFromTtoT = " + x2);
            }
        }
        public void ExplicitConversFromTtoT()
        {
            int? x1 = 0;
            if (x1.HasValue)
            {
                int x2 = (int)x1;
                Console.WriteLine("ExplicitConversFromTtoT = " + x2);
            }
        }
        public void ImplicitConversFromTtoT()
        {
            int x1 = 1;
            int? x2 = x1;
            Console.WriteLine("ImplicitConversFromTtoT = " + x2.Value);
        }
        public void ImplicitConvExtenshions()
        {
            int x1 = 2;
            long? x2 = x1;
            Console.WriteLine("ImplicitConvExtenshions = " + x2.Value);
        }
        public void ExplicitNarrowingConv()
        {
            long x1 = 3;
            int? x2 = (int?)x1;
            Console.WriteLine("ExplicitNarrowingConv = " + x2.Value);
        }
        public void VtoT()
        {
            long? x1 = 4;
            int? x2 = (int?)x1;
            Console.WriteLine("VtoT = " + x2.Value);
        }
        public void TtoV()
        {
            long? x1 = 5;
            int x2 = (int)x1;
            Console.WriteLine("TtoV = " + x2);
        }
    }
}
