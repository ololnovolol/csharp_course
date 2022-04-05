using System;
using System.Reflection;

namespace Solution.Capture18_Reflection_
{
    class Program
    {
        public static void Main(string[] args)
        {
            //BasePrincips();

        }
        //part 1
        public static void BasePrincips()
        {
            Type myType = typeof(PersonNonGratt1);
            Type myType2 = typeof(Solution.Test.PersonNonGratt2);

            Console.WriteLine($"Name: {myType.Name}");              // получаем краткое имя типа
            Console.WriteLine($"Full Name: {myType.FullName}");     // получаем полное имя типа
            Console.WriteLine($"Namespace: {myType.Namespace}");    // получаем пространство имен типа
            Console.WriteLine($"Is struct: {myType.IsValueType}");  // является ли тип структурой
            Console.WriteLine($"Is class: {myType.IsClass}");

            Console.WriteLine();

            Console.WriteLine($"Name: {myType2.Name}");              // получаем краткое имя типа
            Console.WriteLine($"Full Name: {myType2.FullName}");     // получаем полное имя типа
            Console.WriteLine($"Namespace: {myType2.Namespace}");    // получаем пространство имен типа
            Console.WriteLine($"Is struct: {myType2.IsValueType}");  // является ли тип структурой
            Console.WriteLine($"Is class: {myType2.IsClass}");

            Console.WriteLine("Реализованные интерфейсы:");
            foreach (var item in myType.GetInterfaces())
            {
                Console.WriteLine("name = " + item.Name);
                Console.WriteLine("Fullname = " + item.FullName);
                Console.WriteLine("nameSpace = " + item.Namespace);
                Console.WriteLine("is value type = " + item.IsValueType);
                Console.WriteLine("is inteface  = " + item.IsInterface);
                Console.WriteLine();
            }

        }
        //part 2



    }

}
namespace Solution.Test
{
    internal class PersonNonGratt2
    {
        private string name;
        public int Age { get; set; }
        public PersonNonGratt2(string name)
        {
            this.name = name;
        }
        void Say()
        {
            Console.WriteLine(name);
        }
    }
}