using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capure19
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Bee bee = new Bee("jonny", 11);
            Honey honey = new Honey();

            honey.GetHoney();
            bee.Eat();
            honey.GetHoney();

        }

        class Bee
        {
            string name = "bee";
            public int age { get; set; } = 2;

            public Bee(string name, int age)
            {
                this.name = name;
                this.age = age;
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
}
