using System;

namespace Solution.Capture3
{
    struct Structures
    {
        public string name;
        public int age;
        public Structures(string n, int a)
        {
            name = n;
            age = a;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}  Age: {age}");
        }
    }
}
