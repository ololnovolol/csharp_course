using System;

namespace Solution.Capture3.Intheritance
{
    class Manager : Employe
    {
        public Manager()
        {
            Console.WriteLine($"I am Manager");
        }
        public Manager(int age, string name, bool colorOgTheSkinWhite = true) : base(age, name, colorOgTheSkinWhite)
        {
            Console.WriteLine($"I am work Manager,i can speak, my name is = {name},i am {age} years old,  my race is = {rase},");
        }
    }
}
