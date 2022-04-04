using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution.Capture16_LINQ_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SelectLinq.txt key : value

            //part 1
            //BASEsyntaxisOPERATORSrequestLINQ();
            //BASEsyntaxisMETHODSextenshionsLINQ();
            //part2
            //EnumerationinMassive();
            //EnumerationinMassiveHard(); // опять версия с#



            Console.ReadKey();
        }
        //part1
        public static void BASEsyntaxisOPERATORSrequestLINQ()
        {
            string[] people = { "Sam", "Tom", "Evgen", "Tolya", "Entony", "Tony", "Oleg", "Sanya" };

            // создаем новый список для результатов
            var selectedPeople = from p in people // передаем каждый элемент из people в переменную p
                                 where p.ToUpper().StartsWith("T") //фильтрация по критерию
                                 orderby p  // упорядочиваем по возрастанию
                                 select p; // выбираем объект в создаваемую коллекцию

            foreach (var item in selectedPeople)
            {
                Console.WriteLine(item);
            }
        }
        public static void BASEsyntaxisMETHODSextenshionsLINQ()
        {
            string[] people = { "Sam", "Tom", "Evgen", "Tolya", "Entony",
                "Tony", "Oleg", "Sanya" };

            var selectPeople = people.Where(p => p.ToUpper().StartsWith("T"));

            int number = (from p in people where p.ToUpper().StartsWith("T") select p).Count();
            Console.WriteLine(number); // 3

            foreach (var item in selectPeople)
            {
                Console.WriteLine(item);
            }

            /*Select: определяет проекцию выбранных значений

            Where: определяет фильтр выборки
            OrderBy: упорядочивает элементы по возрастанию
            OrderByDescending: упорядочивает элементы по убыванию
            ThenBy: задает дополнительные критерии для упорядочивания элементов возрастанию
            ThenByDescending: задает дополнительные критерии для упорядочивания элементов по убыванию
            Join: соединяет две коллекции по определенному признаку
            Aggregate: применяет к элементам последовательности агрегатную функцию, которая сводит их к одному объекту
            GroupBy: группирует элементы по ключу
            ToLookup: группирует элементы по ключу, при этом все элементы добавляются в словарь
            GroupJoin: выполняет одновременно соединение коллекций и группировку элементов по ключу
            Reverse: располагает элементы в обратном порядке
            All: определяет, все ли элементы коллекции удовлятворяют определенному условию
            Any: определяет, удовлетворяет хотя бы один элемент коллекции определенному условию
            Contains: определяет, содержит ли коллекция определенный элемент
            Distinct: удаляет дублирующиеся элементы из коллекции
            Except: возвращает разность двух коллекцию, то есть те элементы, которые создаются только в одной коллекции
            Union: объединяет две однородные коллекции
            Intersect: возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях
            Count: подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию
            Sum: подсчитывает сумму числовых значений в коллекции
            Average: подсчитывает cреднее значение числовых значений в коллекции
            Min: находит минимальное значение
            Max: находит максимальное значение
            Take: выбирает определенное количество элементов
            Skip: пропускает определенное количество элементов
            TakeWhile: возвращает цепочку элементов последовательности, до тех пор, пока условие истинно
            SkipWhile: пропускает элементы в последовательности, пока они удовлетворяют заданному условию, и затем возвращает оставшиеся элементы
            Concat: объединяет две коллекции
            Zip: объединяет две коллекции в соответствии с определенным условием
            First: выбирает первый элемент коллекции
            FirstOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию
            Single: выбирает единственный элемент коллекции, если коллекция содержит больше или меньше одного элемента, то генерируется исключение
            SingleOrDefault: выбирает единственный элемент коллекции. Если коллекция пуста, возвращает значение по умолчанию. Если в коллекции больше одного элемента, генерирует исключение
            ElementAt: выбирает элемент последовательности по определенному индексу
            ElementAtOrDefault: выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, если индекс вне допустимого диапазона
            Last: выбирает последний элемент коллекции
            LastOrDefault: выбирает последний элемент коллекции или возвращает значение по умолчанию
            */
        }
        //part2
        public static void EnumerationinMassive()
        {
            string[] nameWithThreeLeunght = { "Tom", "Sam", "Ban", "Elice", "Karl", "Bob" };
            int[] nuberEqualtenRound = { 1, 25, 35, 10, 9, 8, 6, 15, 89, 4 };

            //var nameThree = nameWithThreeLeunght.Where(name => name.Length <= 3);
            IOrderedEnumerable<string> nameThree = from name in nameWithThreeLeunght
                                                   where name.Length <= 3
                                                   orderby name
                                                   select name;

            foreach (var item in nameThree)
            {
                Console.WriteLine(item);
            }

            //IEnumerable<int> numbers = nuberEqualtenRound.Where(num => num % 2 == 0 && num <= 10);
            var numbers = from n in nuberEqualtenRound
                          where n <= 10 && n % 2 == 0
                          select n;


            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
        public static void EnumerationinMassiveHard()
        {
            //    int[] AgeMas = { 55, 10, 15, 18, 25, 24, 35, 40, 80, 66 };
            //    string[] NameMas = { "Bob", "Oleg", "Sam", "Jack", "Dick", "Pusie", "Petro", "Kim", "Tom", "JrJim", };

            //    Dictionary<string, int> peoples = new Dictionary<string, int>();
            //    for (int i = 0; i < AgeMas.Length; i++)
            //    {
            //        if (AgeMas.Length == NameMas.Length)
            //        {
            //            peoples.Add(NameMas[i], AgeMas[i]);

            //        }
            //    }


            //    var peoplesCanSpeack = new List<Person>
            //{
            //    new Person("Bobbbb", 2555, new List<string> { "english", "german" }),
            //    new Person("Bobbbb", 2555, new List<string> { "english", "german" })
            //};
            //    Person p = new Person("Bob", 25, new List<string> { "english", "german" });
            //    peoplesCanSpeack.Add(p);

            //    var selectedPeople = from person in people
            //                         from lang in person.Languages
            //                         where person.Age < 28
            //                         where lang == "english"
            //                         select person;

            //    foreach (Person person in peoplesCanSpeack)
            //        Console.WriteLine($"{person.Name} - {person.Age}");

            //record class Person(string Name, int Age, List<string> Languages);

        }
        public void EnumeratorOfType()
        {
            //            var people= new List<Person>
            //{
            //    new Student("Tom"),
            //    new Person("Sam"),
            //    new Student("Bob"),
            //    new Employee("Mike")
            //};

            //    var students = people.OfType<Student>();

            //foreach (var student in students)
            //    Console.WriteLine(student.Name);


            //record class Person(string Name);
            //record class Student(string Name): Person(Name);
            //    record class Employee(string Name) : Person(Name);
        }
        public static void OperathorOrderBy()
        {

        }

        class Person
        {
            string name;
            int age;
            public List<string> Languages;

            public int Age { get; }
            public string Name { get; }

            public Person(string name, int age, List<string> Languages)
            {
                this.name = name;
                this.age = age;
                this.Languages = Languages;
            }
        }
       //record class Personss(string Name, int Age);
    }

}
