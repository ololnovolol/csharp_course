﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Solution.Capture9
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayListMethod();
            //ListMethod();


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
            var type0ik =list[3];
            var type1ik = list[4];
            var type2ik = list[5];
            Console.WriteLine("\tzero = " + type0ik.ToString() + "\n\tzero type = " + type0ik.GetType());
            Console.WriteLine("\tone = " + type1ik.ToString() + "\n\tone type = " + type1ik.GetType());
            Console.WriteLine("\ttwo = " + type2ik.ToString() + "\n\tztwo type = " + type2ik.GetType());
        }
        public static void ListMethod()
        {
            List<int> numbers = new() { 0, 1, 1, 2, 3, 4, 5 };
           
            numbers.AddRange(new int[] { 6, 7, 8, 10, });
            numbers.Insert(9, 9);
            numbers.RemoveAt(2);

            foreach (int item in numbers)
            {
                Console.Write(item + " ");
            }

            List<Person> human = new(3);
            human.Add(new Person() { Name = "Oleg"});
            human.Add(new Person() { Name = "Ivan" });

            foreach (Person item in human)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();

        }

    }

    internal class Person
    {
        public string Name { get; set; }
    }
}
