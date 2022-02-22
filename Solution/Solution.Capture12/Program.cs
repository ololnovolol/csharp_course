using System;

namespace Solution.Capture12
{
    class Program
    {
        static void Main(string[] args)
        {
            //LazyType();
            //ResizeMasive();
            //SpanType();
            //IndexType();
            RangeType();
        }

        public static void LazyType()
        {
            var people = new string[] { "Tom", "Sam", "Bob", "Kate", "Tom", "Alice" };

            // находим индекс элемента "Bob"
            int bobIndex = Array.BinarySearch(people, "Bob");
            // находим индекс первого элемента "Tom"
            int tomFirstIndex = Array.IndexOf(people, "Tom");
            // находим индекс последнего элемента "Tom"
            int tomLastIndex = Array.LastIndexOf(people, "Tom");
            // находим индекс первого элемента, у которого длина строки больше 3
            int lengthFirstIndex = Array.FindIndex(people, person => person.Length > 3);
            // находим индекс последнего элемента, у которого длина строки больше 3
            int lengthLastIndex = Array.FindLastIndex(people, person => person.Length > 3);

            Console.WriteLine($"bobIndex: {bobIndex}");                 // 2
            Console.WriteLine($"tomFirstIndex: {tomFirstIndex}");       // 0
            Console.WriteLine($"tomLastIndex: {tomLastIndex}");         // 4
            Console.WriteLine($"lengthFirstIndex: {lengthFirstIndex}"); // 3
            Console.WriteLine($"lengthLastIndex: {lengthLastIndex}");   // 5
            Elements();
        }
        public static void Elements()
        {
            var people = new string[] { "Tom", "Sam", "Bob", "Kate", "Tom", "Alice" };

            // находим первый и последний элементы
            // где длина строки больше 3 символов
            string? first = Array.Find(people, person => person.Length > 3);
            Console.WriteLine(first); // Kate
            string? last = Array.FindLast(people, person => person.Length > 3);
            Console.WriteLine(last); // Alice

            // находим элементы, у которых длина строки равна 3
            string[] group = Array.FindAll(people, person => person.Length == 3);
            foreach (var person in group) Console.WriteLine(person);
            // Tom Sam Bob Tom

            Array.Reverse(people);

            foreach (var person in people)
                Console.Write($"{person} ");
            // "Alice", "Tom", "Kate", "Bob", "Sam", "Tom"

            // изменяем порядок 3 элементов начиная c индекса 1  
            Array.Reverse(people, 1, 3);

            foreach (var person in people)
                Console.Write($"{person} ");
            // "Tom", "Kate", "Bob", "Sam", "Tom", "Alice"
        }
        public static void ResizeMasive()
        {
            var people = new string[] { "Tom", "Sam", "Bob", "Kate", "Tom", "Alice" };

            // уменьшим массив до 4 элементов
            Array.Resize(ref people, 4);

            foreach (var person in people)
                Console.Write($"{person} ");
            // "Tom", "Sam", "Bob", "Kate"

            var employees = new string[3];

            // копируем 3 элемента из массива people c индекса 1  
            // и вставляем их в массив employees начиная с индекса 0
            Array.Copy(people, 1, employees, 0, 3);

            foreach (var person in employees)
                Console.Write($"{person} ");
            // Sam Bob Kate

            Array.Sort(people);

            foreach (var person in people)
                Console.Write($"{person} ");

            // Alice Bob Kate Sam Tom Tom
        }
        public static void SpanType()
        {
            string[] people = new string[] { "Tom", "Alice", "Bob" };
            Span<string> peopleSpan = people;

            peopleSpan[1] = "Ann";              // переустановка значения элемента
            Console.WriteLine(peopleSpan[2]);   // получение элемента
            Console.WriteLine(peopleSpan.Length);   // получение длины Span

            // перебор Span
            foreach (var s in peopleSpan)
            {
                Console.WriteLine(s);
            }
            int[] temperatures = new int[]
            {
                10, 12, 13, 14, 15, 11, 13, 15, 16, 17,
                18, 16, 15, 16, 17, 14,  9,  8, 10, 11,
                12, 14, 15, 15, 16, 15, 13, 12, 12, 11
            };
            Span<int> temperaturesSpan = temperatures;

            Span<int> firstDecade = temperaturesSpan.Slice(0, 10);    // нет выделения памяти под данные
            Span<int> lastDecade = temperaturesSpan.Slice(20, 10);    // нет выделения памяти под данные

            ReadOnlySpanType();

        }
        public static void ReadOnlySpanType()
        {
            string text = "hello, world";
            string worldString = text.Substring(startIndex: 7, length: 5);           // есть выделение памяти под символы
            ReadOnlySpan<char> worldSpan = text.AsSpan().Slice(start: 7, length: 5); // нет выделения памяти под символы
                                                                                     //worldSpan[0] = 'a'; // Нельзя изменить
            Console.WriteLine(worldSpan[0]); // выводим первый символ

            // перебор символов
            foreach (var c in worldSpan)
            {
                Console.Write(c);
            }
        }
        public static void IndexType()
        {
            Index myIndex1 = 2;     // третий элемент
            Index myIndex2 = ^2;    // предпоследний элемент

            string[] people = { "Tom", "Bob", "Sam", "Kate", "Alice" };
            string selected1 = people[myIndex1];    // Sam
            string selected2 = people[myIndex2];    // Kate
            Console.WriteLine(selected1);
            Console.WriteLine(selected2);
        }
        public static void RangeType()
        {
            string[] people = { "Tom", "Bob", "Sam", "Kate", "Alice" };
            string[] peopleRange = people[1..4]; // получаем 2, 3 и 4-й элементы из массива
            foreach (var person in peopleRange)
            {
                Console.WriteLine(person);
            }

            //string[] peopleRange1 = people[..4];     // Tom, Bob, Sam, Kate
            //string[] peopleRange2 = people[1..];     // Bob, Sam, Kate, Alice
            //string[] peopleRange3 = people[^2..];       // два последних - Kate, Alice
            //string[] peopleRange4 = people[..^1];       // начиная с предпоследнего - Tom, Bob, Sam, Kate
            //string[] peopleRange5 = people[^3..^1];     // два начиная с предпоследнего - Sam, Kate

            string[] people1 = { "Tom", "Bob", "Sam", "Kate", "Alice" };
            Span<string> peopleSpan = people1;
            Span<string> selectedPeopleSpan = peopleSpan[1..4];
            foreach (var person in selectedPeopleSpan)
            {
                Console.WriteLine(person);
            }
        }
    }
}
