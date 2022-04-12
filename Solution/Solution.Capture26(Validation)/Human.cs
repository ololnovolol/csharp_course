using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Capture26_Validation_.attributes;

namespace Solution.Capture26_Validation_
{
    [UserValidationPutin("putin", 0, 100)]
    internal class Human
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Human(int age, string name)
        {
            Age = age;
            Name = name;


        }
    }
}
