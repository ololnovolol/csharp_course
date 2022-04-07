using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capure19
{
    class Program

    {
        static void Main(string[] args)
        {
            //Runner();

            var bee1 = new Bee("jo", 10);
            var bee2 = new Bee("jojo", 1010);

            bool bee1isValid = ValidateUser(bee1);
            bool bee2isValid = ValidateUser(bee2);

            Console.WriteLine();
            Console.WriteLine();



        }

        static bool ValidateUser(Bee bee)
        {
            Type type = typeof(Bee);

            object[] attributes = type.GetCustomAttributes(false);

            foreach (object attr in attributes)
            {
                if (attr is AgeValidationAttribute ageAttr) 
                    return bee.Age >= ageAttr.Age;
            }
            return false;
        }

        public static void Runner()
        {
            Bee bee = new Bee("jonny", 11);
            Honey honey = new Honey();

            honey.GetHoney();
            bee.Eat();
            honey.GetHoney();
        }

        [AgeValidation(20)]
        public class Bee
        {
            string name = "bee";
            public int Age { get; set; } = 2;

            public Bee(string name, int age)
            {
                this.name = name;
                this.Age = age;
            }

            public void Eat()
            {
                Honey honey = new Honey();
            }
        }
        class Honey
        {
            private int countHoney = 100;
            public Honey()
            {
                if(countHoney > 0)
                {
                    countHoney--;
                    Console.WriteLine("nice honey=)");
                }
                else
                {
                    Console.WriteLine("No honey");
                }
                
            }
            public void GetHoney()
            {
                Console.WriteLine("count honey is" + countHoney);
            }
        }

    }

    class AgeValidationAttribute : Attribute
    {
        public int Age { get; }
        public AgeValidationAttribute() { }
        public AgeValidationAttribute(int age) => Age = age;
    }
}
