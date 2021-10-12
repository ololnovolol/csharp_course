using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3.Intheritance
{
    class Schoolboy : Children
    {
        public Schoolboy(int age, string name, bool colorOgTheSkinWhite = true) : base(age, name, colorOgTheSkinWhite)
        {
            Console.WriteLine($"I am Schollboy i can learn! i can speak, my name is = {name},i am {12} years old,  my race is = {rase},");
        }
        public Schoolboy()
        {

        }

        public sealed override void Display()
        {
            base.Display();
        }

    }
}
