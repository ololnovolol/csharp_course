using System;

namespace Solution.Capture3.Intheritance
{
    class Builder : Employe
    {
        public Builder(int age, string name, bool colorOgTheSkinWhite = true) : base(age, name, colorOgTheSkinWhite)
        {
            Console.WriteLine($"I am work Builder,i can speak, my name is = {name},i am {age} years old,  my race is = {rase}, i like a drink =)");
        }
    }
}
