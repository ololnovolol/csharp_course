using System;

namespace Solution.Capture10
{
    class Program
    {
        static void Main(string[] args)
        {
            VariableMethodString();

        }
        public static void VariableMethodString()
        {
            string s1 = "hello";
            string s2 = new String('a', 6); // результатом будет строка "aaaaaa"
            string s3 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
            string s4 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' }, 1, 3); // orl
            char fChar = s1[2];

            Console.WriteLine(s1);  // hello
            Console.WriteLine(s2);  // aaaaaaa
            Console.WriteLine(s3);  // world
            Console.WriteLine(s4);  // orl
            Console.WriteLine(fChar);
        }
    }
}
