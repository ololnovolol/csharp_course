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
            //part 2
            //DataProjectionVol1();
            //DataProjectionVol2();
            //DataProjectionVol3();
            //part 3
            //EnumerationinMassive();
            //EnumerationinMassiveHard(); // опять версия с#
            //part 4
            //SortNumbersOrderBy();
            //SortStringsOrderBy();
            //SortObjOrderBy();
            //SortStringsIComparerOrderBy();
            //part 5
            //Worker();
            //HardWorker();
            //pert 6
            //AgregateOperation();
            //part 7
            //SkipTakeSkipWhileTakeWhile();
            //part 8
            //Group();
            //GroupObj();
            GroupeWithSubqueries();
            // part 9






            Console.ReadKey();
        }
        //part 1
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
        //part 2
        public static void DataProjectionVol1()
        {
            // создать обьект анонимного типа с помощью LINQ select new оператора LET и метода LINQ
            var people = new List<Person>
            {
                new Person("Sam", 25),
                new Person("Bob", 30),
                new Person("Smith", 25),
                new Person("Jordj", 55),
                new Person("JB", 46),
                new Person("Onyx", 33),
            };

            //var newPeople = from p in people
            //                select new {p.Name, yearBird = ( DateTime.Now.Year - p.Age) };

            var newPeople = from p in people
                            let name = $"Mr.{p.Name}"
                            let age = ( DateTime.Now.Year - p.Age)
                            select new { name, age };


            foreach (var item in newPeople)
            {
                Console.WriteLine(item);
            }

        }
        public static void DataProjectionVol2()
        {
            // сделать выборку и слияние с нескольких обьектов класса select new
            var people = new List<Person>
            {
                new Person("Sam", 25),
                new Person("Bob", 30),
                new Person("Smith", 25),
                new Person("Jordj", 55),
                new Person("JB", 46),
                new Person("Onyx", 33),
            };

            var company = new List<Company>
            {
                new Company ("BBC"),
                new Company ("node"),
                new Company ("utp"),
                new Company ("volya"),
            };

            var employers = from p in people
                            from c in company
                            orderby c.Name
                            select new { Company = c.Name, Emploee = p.Name };


            foreach (var item in employers)
            {
                Console.WriteLine(item.Company + " - " + item.Emploee);
            }

        }
        public static void DataProjectionVol3()
        {
            // SelectMany с помощью оператора и метода LINQ
            var companies = new List<SomeCompany>
                {
                    new SomeCompany("Google", new List<string>{"Jeremy", "Olol" }),
                    new SomeCompany("Moogle", new List<string>{"Dim", "Dimych" }),
                    new SomeCompany("Jungle", new List<string>{"Sam", "Gad" })
                };

            //var employers = companies.SelectMany(p => p.Stuff);
            //var employers = from com in companies
            //               from emp in com.Stuff
            //               select emp;
            var employers = from com in companies
                            from emp in com.Stuff
                            select new { name = com.Name, company = emp };


            foreach (var item in employers)
            {
                Console.WriteLine(item);
            }

        }
        //part 3
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
            int[] AgeMas = { 55, 10, 15, 18, 25, 24, 35, 40, 80, 66 };
            string[] NameMas = { "Bob", "Oleg", "Sam", "Jack", "Dick", "Pusie", "Petro", "Kim", "Tom", "JrJim", };

            Dictionary<string, int> peoples = new Dictionary<string, int>();
            for (int i = 0; i < AgeMas.Length; i++)
            {
                if (AgeMas.Length == NameMas.Length)
                {
                    peoples.Add(NameMas[i], AgeMas[i]);
                }
            }

            int countIter = 1;
            var peoplesCanSpeack = new List<PersonSpeack>();
            
            foreach (var item in peoples)
            {
                if (countIter % 2 == 0)
                {
                    peoplesCanSpeack.Add(new PersonSpeack(item.Key, item.Value, new List<string> { "English", "German" }));
                    countIter++;
                }
                else
                {
                    peoplesCanSpeack.Add(new PersonSpeack(item.Key, item.Value, new List<string> { "Rusian", "*****" }));
                    countIter++;
                }
            }

            foreach (var item in peoplesCanSpeack)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            var selectedPeopleCanSpeackEnglish = from person in peoplesCanSpeack
                                                 from lang in person.Language
                                                 where lang == "English"
                                                 where person.Age < 30
                                                 select person;



            foreach (var person in selectedPeopleCanSpeackEnglish)
            {
                Console.WriteLine(person);
            }


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
        //part 4
        public static void SortNumbersOrderBy()
        {
            int[] numbers = { 5, 2, 3, 9, 10, 6, 7, 8, 4, 1 };
            // отсортировать масив чисел с помощью OrderBy метода оператора расширения
            var numbersSort = from n in numbers
                              where n > 0
                              orderby n
                              select n;

            foreach (var item in numbersSort)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            // отсортировать масив чисел с помощью OrderByDescending() метода расширения
            var numbersDescendingSort = numbers.OrderByDescending(x => x);
            foreach (var item in numbersDescendingSort)
            {
                Console.Write(item + " ");
            }

        }
        public static void SortStringsOrderBy()
        {
            string[] strings = { "Samuel", "Ed", "Thomas", "D", "GoldenRush", "abc", "-Tp-Link" };
            //  отсортировать масив строк помощью OrderBy по алфавиту
            var stringsSortAZ = from n in strings
                                orderby n
                                select n;

            foreach (var item in stringsSortAZ)
            {
                Console.Write("_" + item);
            }
            Console.WriteLine();
            //  отсортировать масив строк помощью OrderBy метода расширения по длинне строки
            var stringsLeunghtSort = strings.OrderBy(s => s.Length);
            foreach (var item in stringsLeunghtSort)
            {
                Console.Write("_" + item);
            }

        }
        public static void SortObjOrderBy()
        {
            var people = new List<Person>
            {
                new Person("Sam", 25),
                new Person("Thor", 10),
                new Person("Ban", 80),
                new Person("Lol", 65),
                new Person("Oleg", 32),
            };

            //   отсортировать масив обьектов с помощью OrderBy метода расширения
            var peoplesOrderByAge = people.OrderBy(x => x.Age);
            var peoplesOrderByName = people.OrderBy(x => x.Name);

            //   отсортировать масив обьектов с помощью OrderByDescending() и OrderByAscending()метода расширения
            var peoplesOrderNameZAAgeAscend = people.OrderByDescending(x => x.Name).OrderBy(y => y.Age);

            foreach (var item in peoplesOrderNameZAAgeAscend)
            {
                Console.WriteLine("Age: " + item.Age + ", " + "Name: " + item.Name);
            }
            Console.WriteLine();

            //   отсортировать масив обьектов с помощью OrderByDescending() и OrderByAscending()операторров
            var peoplesOrderNameAZAgeDescend = from n in people
                                               orderby n.Name, n.Age
                                               select n;
            foreach (var item in peoplesOrderNameAZAgeDescend)
            {
                Console.WriteLine(item.ToString());
            }

        }
        public static void SortStringsIComparerOrderBy()
        {
            string[] strings = { "Samuel", "Ed", null, "D", "GoldenRush", "abc", "-Tp-Link" };
            //  отсортировать масив строк помощью созданного CustomStringComparer : IComparer<String>

            var stringSortByMyICOmparer = strings.OrderBy(s => s, new customStringComparer());

            foreach (var item in stringSortByMyICOmparer)
            {
                Console.WriteLine(item);
            }

        }
        //part 5
        public static void Worker()
        {
            string[] species = { "перец", "соль", "10_овощей", "паприка", "карри", };
            string[] speseasoningcies = { "сахар", "перец", "паприка", "соевый_соус", "темьян", };

            Excepter(species, speseasoningcies);
            Intersecter(species, speseasoningcies);
            Distincter(species);
            Distincter(speseasoningcies);
            Unioner(species, speseasoningcies);
            Concater(species, speseasoningcies);

        }
        public static void Excepter(string[] one, string[] two)
        {
            // Except() можно получить разность двух последовательностей:
            var result = one.Except(two);

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------");

        }
        public static void Intersecter(string[] one, string[] two)
        {
            // Intersect Для получения пересечения последовательностей
            var result = one.Intersect(two);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------");
        }
        public static void Distincter(string[] one)
        {
            // Для удаления дублей в наборе используется метод Distinct:
            var result = one.Distinct();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------");
        }
        public static void Unioner(string[] one, string[] two)
        {
            // для объединения двух последовательностей используется метод Union и убирает дубли
            var result = one.Union(two);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------");
        }
        public static void Concater(string[] one, string[] two)
        {
            // Если же нам нужно простое объединение двух наборов, то мы можем использовать метод Concat:
            var result = one.Concat(two);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------");

        }
        public static void HardWorker()
        {
            //Работа со сложными объектами
            //Для сравнения объектов в последовательностях применяются
            //реализации методов GetHeshCode() и Equals(). 
            //Поэтому если мы хотим работать с последовательностями, 
            //которые содержат объекты своих классов и структур, то нам
            //необходимо определить для них подобные методы:
            var pers1 = new List<Person>{new Person("po", 25), new Person("by", 35), new Person("bi", 45), new Person("bi", 45) };
            var pers2 = new List<Person> { new Person("po", 52), new Person("py", 53), new Person("bi", 54) };

            //var young = pers1.Distinct();
            var young = pers2.Except(pers1);
            //var young = pers1.Intersect(pers2);
            //var young = pers1.Union(pers2);
            //var young = pers1.Concat(pers2);

            foreach (var item in young)
            {
                Console.WriteLine(item);
            }
        }
        //part 6
        public static void AgregateOperation()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[] go =
                {
                numbers.Aggregate((x, y) => x - y),
                numbers.Aggregate((x, y) => x + y),
                numbers.Count(),
                numbers.Sum(),
                numbers.Min(),
                numbers.Max(),
                (int)numbers.Average()
                };

            foreach (var item in go)
            {
                Console.WriteLine(item);
            }

            var person = new List<Person>
            {
                    new Person("One", 1),
                    new Person("Two", 1),
                    new Person("Three", 1)
            };

            int minAge = person.Min(p => p.Age); // минимальный возраст
            int maxAge = person.Max(p => p.Age); // максимальный возраст
            double averageAge = person.Average(p => p.Age); //средний возраст

            Console.WriteLine($"Min Age: {minAge}");           // Min Age: 28
            Console.WriteLine($"Max Age: {maxAge}");           // Max Age: 41
            Console.WriteLine($"Average Age: {averageAge}");   // Average Age: 35,33

        }
        //part 7
        public static void SkipTakeSkipWhileTakeWhile()
        {
            string[] people = { "Tom", "Sam", "Bob", "Mike", "Kate", "Alice" };

            //var result = people.Skip(2);
            //var result = people.SkipWhile(p => p.Length == 3);
            //var result = people.Take(3);
            //var result = people.TakeWhile(p => p.Length == 3);
            var result = people.Skip(3).Take(2);

            foreach (var person in result)
                Console.WriteLine(person);


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        //part 8
        public static void Group()
        {
            var people = new List<Person>
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
            };

            //var groupe = from p in people
            //             group p by p.CompanyName;

            var groupe = people.GroupBy(p => p.CompanyName);

            foreach (var company in groupe)
            {
                Console.WriteLine(company.Key);

                foreach (var person in company)
                {
                    Console.WriteLine(person.Name);
                }
                Console.WriteLine("-------"); // для разделения между группами
            }
        }
        public static void GroupObj()
        {
            var people = new List<Person>
            {
                    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
                    new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
             };

            var companies = people
                    .GroupBy(p => p.CompanyName)
                    .Select(g => new { Name = g.Key, Count = g.Count() });


            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Name} : {company.Count}");
            }

        }
        public static void GroupeWithSubqueries()
        {
            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
            };

            //var companies = from person in people
            //                group person by person.CompanyName into g
            //                select new
            //                {
            //                    Name = g.Key,
            //                    Count = g.Count(),
            //                    Employees = from p in g select p
            //                };

            var companies = people.GroupBy(p => p.CompanyName).Select(g => new
                    {
                        Name = g.Key,
                        Count = g.Count(),
                        Employees = g.Select(p => p)
                    });

            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Name} : {company.Count}");
                foreach (var employee in company.Employees)
                {
                    Console.WriteLine(employee.Name);
                }
                Console.WriteLine("--------------");
            }
        }
        //part 9



        class Person
        {
            public int Age { get; }
            public string Name { get; }
            public string CompanyName {  get; }

            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;

            }
            public Person(string name, string cName)
            {
                this.Name = name;
                CompanyName = cName;

            }

            public override string ToString()
            {
                return string.Format($"Name:{Name}, Age:{Age}");
            }

            public override int GetHashCode() => Name.GetHashCode();

            public override bool Equals(object obj)
            {
                if (obj is Person person) return Name.Equals(person.Name);
                return false;
            }
        }
        class Company
        {
            public string Name { get; set; }
            public Company(string name)
            {
                Name = name;
            }
        }
        class SomeCompany : Company
        {
           public List<string> Stuff;

            public SomeCompany(string name, List<string> stuff) : base(name)
            {
                Stuff = stuff;
            }
        }
        class PersonSpeack
        {
            public int Age { get; }
            public string Name { get; }
            public List<string> Language { get; set; }

            public PersonSpeack(string name, int age, List<string> Language)
            {
                this.Name = name;
                this.Age = age;
                this.Language = Language;

            }

            public override string ToString()
            {
                if(Language.Count == 1)
                {
                    return string.Format($"Name:{Name}, Age:{Age}, Speack:{Language[0]}");
                }
                if(Language.Count == 2)
                {
                    return string.Format($"Name:{Name}, Age:{Age}, Speack:{Language[0]},{Language[1]}");
                }
                else
                {
                    return string.Format($"Name:{Name}, Age:{Age}, Speack: None=(");
                }


            }
        }
        class customStringComparer : IComparer<String>
        {
            public int Compare(string x, string y)
            {
                int xLength = x?.Length ?? 0; // если x равно null, то длина 0
                int yLength = y?.Length ?? 0;
                return xLength - yLength;
            }

        }
    }

}
