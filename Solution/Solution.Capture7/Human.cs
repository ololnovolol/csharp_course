using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture7
{
    class Human : Person
    {
        public override void Say()
        {
            Console.WriteLine("i know English");
        }

        public void Deconstruct(out string name, out int age, out string language, out string translate)
        {
            name = Name;
            age = Age;
            language = Language;
            translate = Translate;

        }
    }
}
