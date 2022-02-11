using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Solution.Capture9
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Caller();
        }
        public static void Caller()
        {
            //ArrayListMethod();
            //LinkedListMethodTwo();
            //QueueMethod();
            //StackMethod();
            //DictionaryMethod();
            //ObservableListMethod();
            //EnumerableANDEnumerator();
        }
        public static void ArrayListMethod()
        {
            ArrayList list = new();
            list.Add("test");
            list.Add(1.2);
            list.Add('r');
            Console.WriteLine(list.Count);
            list.AddRange(new string[] { "hana", "manana", "35" });

            foreach (object item in list)
            {
                Console.WriteLine(item);
            }
            var type0ik = list[3];
            var type1ik = list[4];
            var type2ik = list[5];
            Console.WriteLine("\tzero = " + type0ik.ToString() + "\n\tzero type = " + type0ik.GetType());
            Console.WriteLine("\tone = " + type1ik.ToString() + "\n\tone type = " + type1ik.GetType());
            Console.WriteLine("\ttwo = " + type2ik.ToString() + "\n\tztwo type = " + type2ik.GetType());
            ListMethod();
        }
        public static void ListMethod()
        {
            List<int> numbers = new() { 0, 1, 1, 2, 3, 4, 5 };

            numbers.AddRange(new int[] { 6, 7, 8, 10, });
            numbers.Insert(9, 9);
            numbers.RemoveAt(2);

            foreach (int item in numbers)
            {
                Console.Write(item + " ");
            }

            List<Person> human = new(3);
            human.Add(new Person() { Name = "Oleg" });
            human.Add(new Person() { Name = "Ivan" });

            foreach (Person item in human)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            LinkedListMethodOne();

        }
        public static void LinkedListMethodOne()
        {
            //var employees = new List<string> { "Tom", "Sam", "Bob" };

            //LinkedList<string> people = new LinkedList<string>(new[] { "Tom", "Sam", "Bob" });

            //// от начала до конца списка
            //var currentNode = people.First;
            //while (currentNode != null)
            //{
            //    Console.WriteLine(currentNode.Value);
            //    currentNode = currentNode.Next;
            //}

            //// с конца до начала списка
            //currentNode = people.Last;
            //while (currentNode != null)
            //{
            //    Console.WriteLine(currentNode.Value);
            //    currentNode = currentNode.Previous;
            //}

            var people = new LinkedList<string>();
            people.AddLast("Tom"); // вставляем узел со значением Tom на последнее место
                                   //так как в списке нет узлов, то последнее будет также и первым
            people.AddFirst("Bob"); // вставляем узел со значением Bob на первое место

            // вставляем после первого узла новый узел со значением Mike
            if (people.First != null) people.AddAfter(people.First, "Mike");

            // теперь у нас список имеет следующую последовательность: Bob Mike Tom
            foreach (var person in people) Console.WriteLine(person);
        }
        public static void LinkedListMethodTwo()
        {
            var company = new LinkedList<Person>();

            company.AddLast(new Person("Tom"));
            company.AddLast(new Person("Sam"));
            company.AddFirst(new Person("Bill"));

            foreach (var person in company) Console.WriteLine(person.Name);
        }
        public static void QueueMethod()
        {
            var patients = new Queue<Person>();
            patients.Enqueue(new Person("Tom"));
            patients.Enqueue(new Person("Bob"));
            patients.Enqueue(new Person("Sam"));

            var practitioner = new Doctor();
            practitioner.TakePatients(patients);
        }
        public static void StackMethod()
        {

            /*
             *Методы Stack
            В классе Stack можно выделить следующие методы:

            Clear: очищает стек

            Contains: проверяет наличие в стеке элемента и возвращает true при его наличии

            Push: добавляет элемент в стек в верхушку стека

            Pop: извлекает и возвращает первый элемент из стека

            Peek: просто возвращает первый элемент из стека без его удаления
            */
            var people = new Stack<string>();
            people.Push("Tom");
            // people = { Tom }
            people.Push("Sam");
            // people = { Sam, Tom }
            people.Push("Bob");
            // people = { Bob, Sam, Tom }

            // получаем первый элемент стека без его удаления 
            string headPerson = people.Peek();
            Console.WriteLine(headPerson);  // Bob

            string person1 = people.Pop();
            // people = { Sam, Tom }
            Console.WriteLine(person1);  // Bob

            string person2 = people.Pop();
            // people = { Tom }
            Console.WriteLine(person2);  // Sam

            string person3 = people.Pop();
            // people = { }
            Console.WriteLine(person3);  // Tom
        }
        public static void DictionaryMethod()
        {
            // условная телефонная книга
            var phoneBook = new Dictionary<string, string>();

            // добавляем элемент: ключ - номер телефона, значение - имя абонента
            phoneBook.Add("+123456", "Tom");
            // альтернативное добавление
            // phoneBook["+123456"] = "Tom";

            // Проверка наличия
            var phoneExists1 = phoneBook.ContainsKey("+123456");    // true
            Console.WriteLine($"+123456: {phoneExists1}");
            var phoneExists2 = phoneBook.ContainsKey("+567456");    // false
            Console.WriteLine($"+567456: {phoneExists2}");
            var abonentExists1 = phoneBook.ContainsValue("Tom");      // true
            Console.WriteLine($"Tom: {abonentExists1}");
            var abonentExists2 = phoneBook.ContainsValue("Bob");      // false
            Console.WriteLine($"Bob: {abonentExists2}");

            // удаление элемента
            phoneBook.Remove("+123456");

            // проверяем количество элементов после удаления
            Console.WriteLine($"Count: {phoneBook.Count}"); // Count: 0
        }
        public static void ObservableListMethod()
        {
            var people = new ObservableCollection<string>() { "l", "e" };
            people.Add("g");
            people.Insert(0, "o");

            for (int i = 0; i < people.Count; i++)
            {
                Console.Write(" " + people[i]);
            }
            Console.WriteLine();
            if (people.Contains("O") == true)
            {
                Console.WriteLine("Big O is present");
            }
            else
            {
                Console.WriteLine("Big O don`t present");
                if ((people.Contains("o") == true) && people.IndexOf("o") == 0)
                {
                    people.Remove("o");
                    people.Insert(0, "O");
                }
            }

            for (int i = 0; i < people.Count; i++)
            {
                Console.Write(" " + people[i]);
            }

        }
        public static void EnumerableANDEnumerator()
        {

        }



        internal class Person
        {
            public string Name { get; set; }
            public Person(string name) => Name = name;

            public Person()
            {
            }
        }
        private class Doctor
        {
            public void TakePatients(Queue<Person> patients)
            {
                while (patients.Count > 0)
                {
                    var patient = patients.Dequeue();
                    Console.WriteLine($"Осмотр пациента {patient.Name}");
                }
                Console.WriteLine("Доктор закончил осматривать пациентов");
            }
        }
    }
}
