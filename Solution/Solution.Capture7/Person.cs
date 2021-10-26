using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture7
{
    public partial class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Language { get; set; }
        public string Translate { get; set; }

        public partial void SetName(string name);

        public virtual void Say()
        {
            Console.WriteLine("i can speack");
        }
        public void Deconstruct(out string name, out int age)
        {
            name = Name;
            age = Age;
        }
    }
}
