using System;

namespace Solution.Capture2
{
    public static class Methods
    {
        public static void Met1 ()
        {
            Console.WriteLine("Hello i am Method Met1");
        }
        public static string Met2()
        {
            return "Hello i am Method Met2";
        }

        public static void Met3(string str,string hello = "hi")
        {
            Console.WriteLine($"Hello i am Method Met3 i have parametr = {str}");
        }

        public static void Met4()
        {
            Console.WriteLine("Hello i am Method Met4");
        }

        public static void Met5() => Console.WriteLine("Hello i am Abbreviated notation  Method Met5");

        public static string Met6() => "Hello i am Abbreviated notation Method Met6";

        public static void Addition(ref int x, int y)
        {
            x += y;
        }

        public static  void IncrementVal(int x)
        {
            x++;
            Console.WriteLine($"IncrementVal: {x}");
        }

        public static void IncrementRef(ref int x)
        {
            x++;
            Console.WriteLine($"IncrementRef: {x}");
        }

        public static void GetData(int x, int y, out int area, out int perim)
        {
            area = x * y;
            perim = (x + y) * 2;
        }

        public static void GetDataOut(in int x, int y, out int area, out int perim)
        {
            // x = x + 10; parameter value cannot be changed x
            y = y + 10;
            area = x * y;
            perim = (x + y) * 2;
        }

    }
}
