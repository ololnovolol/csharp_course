using System;

namespace Solution.Capture21_GarbageCollection_
{
    public class Person
    {
        public string Name { get; }
        public Person(string name)
        {
            this.Name = name;
        }
        ~Person()
        {
            Console.WriteLine($"{Name} has been deleted about Work Destructor");
        }
    }


}
