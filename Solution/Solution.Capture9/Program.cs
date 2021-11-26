using System;
using System.Collections;

namespace Solution.Capture9
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayListMethod();


        }
        public static void ArrayListMethod()
        {
            ArrayList list = new();
            list.Add("test");
            list.Add(1.2);
            list.Add('r');
            Console.WriteLine(list.Count);
            list.AddRange(new string[] { "hana", "manana", "35" });

            foreach (object item in list)
            {
                Console.WriteLine(item);
            }
            var type0ik = list[0];
            var type1ik = list[1];
            var type2ik = list[2];
            Console.WriteLine("\tzero = " + type0ik.ToString() + "\n\tzero type = " + type0ik.GetType());
            Console.WriteLine("\tone = " + type1ik.ToString() + "\n\tone type = " + type1ik.GetType());
            Console.WriteLine("\ttwo = " + type2ik.ToString() + "\n\tztwo type = " + type2ik.GetType());
        }
    }
}
