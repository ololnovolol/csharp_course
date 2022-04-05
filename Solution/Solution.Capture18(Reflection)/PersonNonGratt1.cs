using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture18_Reflection_
{
    class PersonNonGratt1 : IEater, IMovable
    {
        private string name;
        public int Age { get; set; }
        public PersonNonGratt1(string name)
        {
            this.name = name;
        }
        void Say()
        {
            Console.WriteLine(name);
        }

        public void Eat()
        {
            Console.WriteLine("Eating"); ;
        }

        public void Move()
        {
            Console.WriteLine("Moving");
            {
                throw new NotImplementedException();
            }
        }
    }
}
