using System;
using System.IO;
using System.Collections.Generic;



namespace Solutin.Capture12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LazyIni();
            // MathClass();
            // ConvertTypes();
            // ArrayStaticClass();
            //SpanStructMemryBostEffectPerformanse();


           // Program p = new Program();
           // p.CatalogsGetSet();


            Console.ReadKey();
        }

        public static void LazyIni()
        {
            Reader reader = new Reader();
            reader.ReadBook();
            reader.ReadEbook();
        }

        public static void MathClass()
        {
            int firstValue = 15;
            int secondValue = 25;;
            Console.WriteLine(Math.Abs(-12.5));
            double result1 = Math.Round(20.56); // 21
            double result2 = Math.Round(20.46); //20
            double result = Math.Truncate(16.89); // 16



        }

        public static void ConvertTypes()
        {

            int a = int.Parse("10");
            double b = double.Parse("23,56");
            decimal c = decimal.Parse("12,45");
            byte d = byte.Parse("4");
            Console.WriteLine($"a={a}  b={b}  c={c}  d={d}");

            int n = Convert.ToInt32("23");
            bool b1 = true;
            //потеря данных =1, так же может вызывать NumberFormatInfo
            double d1 = Convert.ToDouble(b1); // =1
            Console.WriteLine($"n={n}  d={d1}");
        }

        public static void ArrayStaticClass()
        {
            var people = new string[] { "Tom", "Sam", "Bob", "Kate", "Tom", "Alice" };

            var employees = new string[3];

            // копируем 3 элемента из массива people c индекса 1  
            // и вставляем их в массив employees начиная с индекса 0
            Array.Copy(people, 1, employees, 0, 3);

            foreach (var person in employees)
                Console.Write($"{person} ");
            // Sam Bob Kate

            // Search elementy by massive
            var people1 = new string[] { "Tom", "Sam", "Bob", "Kate", "Tom", "Alice" };

            // находим первый и последний элементы
            // где длина строки больше 3 символов
            string first = Array.Find(people1, person => person.Length > 3);
            Console.WriteLine(first); // Kate
            string last = Array.FindLast(people1, person => person.Length > 3);
            Console.WriteLine(last); // Alice

            // находим элементы, у которых длина строки равна 3
            string[] group = Array.FindAll(people1, person => person.Length == 3);
            foreach (var person in group) Console.WriteLine(person);
            // Tom Sam Bob Tom
        }

        public static void SpanStructMemryBostEffectPerformanse()
        {
            string[] humans = { "Tom", "Elice", "Bob" };

            Span<string> humansSpan = humans;
            // or >> Span<string> humansSpan = new Span<string>(humans);

            humansSpan[0] = "Кожемяка";
            humansSpan.Reverse();
            for(int i = 0; i < humans.Length; i++)
            {
                Console.WriteLine($"humans masive have {humans[i]}={humans.Length} items\nspanMassive have {humansSpan[i]}={humansSpan.Length} items");
                Console.WriteLine("");
            }
            foreach (var item in humansSpan)
            {
                Console.WriteLine(item);
            }

                        int[] temperatures = new int[]
            {
                10, 12, 13, 14, 15, 11, 13, 15, 16, 17,
                18, 16, 15, 16, 17, 14,  9,  8, 10, 11,
                12, 14, 15, 15, 16, 15, 13, 12, 12, 11
            };
            Span<int> temperaturesSpan = temperatures;

            Span<int> firstDecade = temperaturesSpan.Slice(0, 10);

            temperaturesSpan[0] = 25; // меняем в temperatureSpan
            Console.WriteLine(firstDecade[0]); //25


        }


        internal void CatalogsGetSet()
        {
            IEnumerable<string> listDirectories = Directory.EnumerateDirectories("D:");
            foreach (var dir in listDirectories)
            {
                Console.WriteLine(dir);
            }
        }
    }
}
