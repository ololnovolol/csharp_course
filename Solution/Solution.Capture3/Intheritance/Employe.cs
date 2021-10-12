using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3.Intheritance
{
    class Employe : Student
    {

        protected bool work = true;
        public Employe(int age, string name, bool colorOgTheSkinWhite = true) : base(age, name, colorOgTheSkinWhite)
        {

            Console.WriteLine($"I am Employe, I am learning a profession!my name is = {name},i am {25} years old,  my race is = {rase},");

            this.name = (name != null) ? name : "i don't know";  // почему этот код достежим в наследниках
            this.age = (age != 0) ? age : 3;                              //

        }
        public Employe()
        {

        }


    }
}
