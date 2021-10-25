using System;

namespace Solution.Capture6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p = new Person { name = "Test", age = 99 };
            //Student s = new Student();
            //p.Print();
            //s.Print();

            IPrintablePerson pp = new Person() { name = "Iprintable test", age = 99 + 1 };
            IPrintablePerson ss = new Student() { nameS = "Petya", ageS = 16, groupe = 2 };
            IPrintableStudent pp1 = new Person() { name = "Tolya", age = 20 };
            IPrintableStudent ss1 = new Student() { nameS = "Roma", ageS = 55, groupe = 4 };

            pp.Print();
            ss.Print();
            pp1.Print();
            ss1.Print();

            Console.WriteLine("---------------Clone");
            Person p3 = new Person() { name = "Iprintable test", age = 99 + 1 };
            Person p4 = (Person)p3.Clone();
            Console.WriteLine(p3.name);
            Console.WriteLine(p3.age);

            Student s1 = new Student { nameS = "Petya", ageS = 11, groupe = 2 };
            Student s2 = new Student { nameS = "JOHNnn", ageS = 15, groupe = 3 };
            Student s3 = new Student { nameS = "JOHN", ageS = 18, groupe = 3 };
            Student s4 = new Student { nameS = "JO", ageS = 25, groupe = 3 };
           
            
            Student[] course = new Student[] { s1, s2, s3, s4 };
            Console.WriteLine("---------------Sort by name.Leunght");
            Array.Sort(course, new Student()); //////////////////////////////////тут у меня затуп что делает - new Student

            foreach (Student s in course)
            {
                Console.WriteLine($"name {s.nameS}=  age = {s.ageS}");
            }
            Console.WriteLine("---------------Sort by age");
            //Student[] sc = new Student.StudentComparer[](5);
            Array.Sort(course, new Student.StudentComparer());
            ///////////////////////////////////////////Array.Sort как добавить другие перегрузки
            /////Реализовать интерфейс IComparer<Student> в классе StudentComparer, вложенном в Student.
            ///Параметром его конструктора должен выступать критерий сортировки. Реализовать в классе Student несколько статических свойств по количеству критериев сортировки
            ///(например, Student.SortByGroup).
            ///Воспользовавшись второй формой Array.Sort, отсортировать массив студентов по разным критериям.

            foreach (Student s in course)
            {
                Console.WriteLine($"name {s.nameS}=  age = {s.ageS}");
            }


            Console.ReadKey();
        }
    }
}
