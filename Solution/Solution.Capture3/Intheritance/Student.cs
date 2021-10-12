using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3.Intheritance
{
    class Student : Schoolboy

    {
        public Student(int age, string name, bool colorOgTheSkinWhite = true) : base(age, name, colorOgTheSkinWhite)
        {
            Console.WriteLine($"I am Student, I am already finishing my studies!my name is = {name},i am {18} years old,  my race is = {rase},");


            //this.name = (name != null) ? name : "i don't know"; а этот нет((
            //this.age = (age != 0) ? age : 3;
        }
        public Student()
        {

        }


    }
}
