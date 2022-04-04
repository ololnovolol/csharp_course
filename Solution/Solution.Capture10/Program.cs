using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Solution.Capture10
{
    class Program
    {
        static void Main(string[] args)
        {
            VariableMethodString();
            FormatNumbers();
            CreateStringBuilder();
            RegularExpressions();

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
        public static void FormatNumbers()
        {
            int number = 23;
            string result = string.Format("{0:f}", number);
            Console.WriteLine(result); // 23,00

            double number2 = 45.08;
            string result2 = string.Format("{0:f4}", number2);
            Console.WriteLine(result2); // 45,0800

            double number3 = 25.07;
            string result3 = string.Format("{0:f1}", number3);
            Console.WriteLine(result3); // 25,1

            int x = 8;
            int y = 7;
            string resultInterpol = $"{x} + {y} = {x + y}";
            Console.WriteLine(result); // 8 + 7 = 15

            string name = "Tom";
            int age = 23;

            Console.WriteLine($"Имя: {name,-5} Возраст: {age}"); // пробелы после
            Console.WriteLine($"Имя: {name,5} Возраст: {age}"); // пробелы до

        }
        public static void CreateStringBuilder()
        {

            StringBuilder sb = new StringBuilder("Here I am", 32);
            Console.WriteLine(sb);
            string str = sb.ToString();
            Console.WriteLine(str);
            Console.WriteLine(str.GetType());
            Console.WriteLine(sb.GetType());
            OperationsWithSB();
        }
        public static void OperationsWithSB()
        {

            var sb = new StringBuilder("Название: ");
            Console.WriteLine(sb);   // Название: 
            Console.WriteLine($"Длина: {sb.Length}"); // 10
            Console.WriteLine($"Емкость: {sb.Capacity}"); // 16

            sb.Append(" Руководство");
            Console.WriteLine(sb);   // Название: Руководство
            Console.WriteLine($"Длина: {sb.Length}"); // 22
            Console.WriteLine($"Емкость: {sb.Capacity}"); // 32

            sb.Append(" по C# для начинающих");
            Console.WriteLine(sb);   // Название: Руководство по C#
            Console.WriteLine($"Длина: {sb.Length}"); // 28
            Console.WriteLine($"Емкость: {sb.Capacity}"); // 32
        }
        public static void RegularExpressions()
        {
            string s = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа";
            string ss = "Жыд жыл жыва жизнь жыза жыга, жлоб жыло жыла джын джып";
            Regex regex = new Regex(@"туп(\w*)", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(s);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);

                }
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }

            Console.WriteLine("Своя тяга");

            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            var data = new string[]
            {
            "tom@gmail.com",
            "+12345678999",
            "bob@yahoo.com",
            "+13435465566",
            "sam@yandex.ru",
            "+43743989393"
            };

            Console.WriteLine("Email List");
            for (int i = 0; i < data.Length; i++)
            {
                if (Regex.IsMatch(data[i], pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine(data[i]);
                }
                else
                {
                    Console.WriteLine("\t" + data[i] + " - не является почтой");
                }

                ReplaceMethod();
            }
        }
        public static void ReplaceMethod()
        {
            string phoneNumber = "+1(876)-234-12-98";
            string pattern = @"\D";
            string target = "";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(phoneNumber, target);
            Console.WriteLine(result);  // 18762341298
        }

    }
}
