using System;
using System.Linq;

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

            string s5 = "apple";
            string s6 = "a day";
            string s7 = "keeps";
            string s8 = "a doctor";
            string s9 = "away";
            string[] values = new string[] { s5, s6, s7, s8, s9 };

            string s10 = string.Join(" ", values);
            Console.WriteLine(s10); // apple a day keeps a doctor away 

            string[] files = new string[]
            {
                "myapp.exe",
                "forest.jpg",
                "main.exe",
                "book.pdf",
                "river.png"
            };

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].EndsWith(".exe"))
                    Console.WriteLine(files[i]);
            }

            long number = 19876543210;
            string result = string.Format("{0:+# (###) ###-##-##}", number);
            Console.WriteLine(result); // +1 (987) 654-32-10


        }
    }
}
