using System;

namespace Solution.Capture3
{
    public  class StaticClassMembers
    {
        private static int count = 0;
        public int number;

        static StaticClassMembers()
        {
            count++;
            Console.WriteLine($"number of starts StaticClassMembers()= {count}");
        }

        public StaticClassMembers() => StaticClassMembers.Printer();
        public StaticClassMembers(int g)
        {
            number = g;
            Console.WriteLine("number StaticClassMembers(int g) = " + number);
        }

        public static void Accessor() { }
        public static void Printer()
        {    
            Console.WriteLine($"count of starts Printer()= {count}");
        }

    }
}
