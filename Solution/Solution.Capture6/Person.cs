using System;

namespace Solution.Capture6
{
    class Person : IPrintablePerson, IPrintableStudent, ICloneable
    {
        public string name { get; set; }
        public int age { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        void IPrintableStudent.Print()
        {
            Console.WriteLine($"I am Person");
        }

        void IPrintablePerson.Print()
        {
            Console.WriteLine($"name = {name}, age = {age}");
        }
    }
}
