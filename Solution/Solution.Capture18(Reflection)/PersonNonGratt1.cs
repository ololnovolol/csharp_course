using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture18_Reflection_
{
    class PersonNonGratt1 : IEater, IMovable
    {
        private string name = "dcvdc";
        public int Age { get; set; }
        public PersonNonGratt1(string name)
        {
            this.name = name;
        }
        public PersonNonGratt1()
        {
        }
        protected  PersonNonGratt1(int age, string name)
        {

        }


        public static void Say(string message)
        {
            Console.WriteLine(message);
        }
        private void Say(int age)
        {
            Console.WriteLine("go go go");
        }

        public void Eat(double ny9mka, string nameeat)
        {
            //double gg = 2.5;
            Console.WriteLine("Eating");
        }
        public void Eat()
        {
            //double gg = 2.5;
            Console.WriteLine("Eating");

        }
        private static void Eat(string ame, int kallorie)
        {
            Console.WriteLine("Eating"); ;
        }

        public void Move()
        {
            Console.WriteLine("name");


        }

        public void Move(List<string> km)
        {
            Console.WriteLine();
        }
        public void Puck()
        {
            Console.WriteLine("bzzzz");
        }
        private void Belching()
        {
            Console.WriteLine("ghee");
        }

        public static void Print<T>(T value)
        {
            Console.WriteLine(value);
        }
    }
}
