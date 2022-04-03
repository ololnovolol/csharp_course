using System;

namespace Solution.Capture3
{
    class ClassesAndObjects
    {
        private string name = "null";
        private int age = 0;
        private string @mail = "null";
        public ClassesAndObjects(string name)
        {
            this.name = name;
        }
        public ClassesAndObjects(string name, int age) : this(name)
        {
            this.age = age;
        }
        public ClassesAndObjects(string name, int age, string @mail) : this("Oleg", age)
        {
            this.@mail = @mail;
            Console.WriteLine($"\nname = {this.name}, age = {this.age}, @mail = {this.@mail}");
        }
    }
}
