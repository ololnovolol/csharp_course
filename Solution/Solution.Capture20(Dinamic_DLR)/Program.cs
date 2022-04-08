using System;
using System.Collections.Generic;
using System.Dynamic;
using IronPython;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;



namespace Solution.Capture20_Dinamic_DLR_
{
    class Program
    {
        public static void Main(string[] args)
        {
            //BaseDynamicTests();
            //ExpandoObject();
            DynamicObjects();
          


        }
        public static void BaseDynamicTests()
        {
            dynamic d = 3;
            Console.WriteLine(d);
            d = "4";
            Console.WriteLine(d);
            d = 3.25m;
            Console.WriteLine(d);
            d = false;
            Console.WriteLine(d);

            object obj = 24;
            d = 24;
            int i = 24;

            //obj += 4;
            d += 4;
            i += 4;
            Console.WriteLine(d);
            Console.WriteLine(i);

            var p = new Person("nn", "52");

            string jojo = p.GetSalary(55, "string" );
            int jojojo = p.GetSalary(55, "int");

            Console.WriteLine($"{jojo}      {jojojo}");
        }
        public static void ExpandoObject()
        {
            dynamic person = new ExpandoObject();

            //person.One = ("Mem", 22, 80);
            //person.Two = ("Mr", 35, true);
            //person.Three = ("It", 666, "Darknes");     
            //Console.WriteLine($"{person.One}\n{person.Two}\n{person.Three}");

            person.Name = "bob";
            person.Age = 25;
            person.Language = new List<string> { "Eng", "Ukr", "Orks"};

            foreach (object? item in person.Language)
            {
                Console.WriteLine(item);
            }

            person.IncrementAge = (Action<int>)(x => person.Age += x);
            person.DecrementAge = (Action<int>)(x => person.Age -= x);

            person.IncrementAge(5);
            Console.WriteLine(person.Age);
            person.DecrementAge(10);
            Console.WriteLine(person.Age);

        }
        public static void DynamicObjects()
        {
            dynamic p1 = new personObject();

            p1.Name = "Sam";
            p1.Age = 25;

            int func(int x) { p1.Age += p1.Age; return p1.Age; }

            Console.WriteLine($"{p1.Name} - {p1.Age}");
            //p1.IncrementAge(5);
            //Console.WriteLine($"{p1.Name} - {p1.Age}");
            p1.DecrementAge = (Func<int, int>)func;
            p1.DecrementAge(5);
            Console.WriteLine($"{p1.Name} - {p1.Age}");


        }
  



        class Person
        {
            public string Name { get; }
            public dynamic Age { get; set; }
            public Person(string name, dynamic age)
            {
                Name = name; Age = age;
            }

            // выводим зарплату в зависимости от переданного формата
            public dynamic GetSalary(dynamic value, string format)
            {
                if (format == "string") return $"{value} euro";
                else if (format == "int") return value;
                else return 0.0;
            }

            public override string ToString() => $"Name: {Name}  Age: {Age}";
        }

        class personObject : DynamicObject
        {
            Dictionary<string, object> members = new Dictionary<string, object>();

            public override bool TrySetMember(SetMemberBinder binder, object? value)
            {
                if (value != null)
                {
                    members[binder.Name] = value;
                    return true;
                }

                return false;
            }
            public override bool TryGetMember(GetMemberBinder binder, out object? result)
            {
                result = null;
                if (members.ContainsKey(binder.Name))
                {               
                    result = members[binder.Name];
                    return true;
                }
                return false;
            }
            public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
            {
                result = null;
                if (args?[0] is int number)
                {
                    // получаем метод по имен
                    dynamic method = members[binder.Name];
                    // вызываем метод, передавая его параметру значение args?[0]
                    result = method(number);
                }
                // если result не равен null, то вызов метода прошел успешно
                return result != null;
            }
        }

    }
}