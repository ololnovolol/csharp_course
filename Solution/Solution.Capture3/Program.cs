using System;
using print = System.Console;
using stru = Solution.Capture3.ClassesAndObjects;





namespace Solution.Capture3
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
            Console.WriteLine("----------------------------------------\nPart 3.1 :\t Classes and objects!\n----------------------------------------");
            ClassesAndObjects cao = new ClassesAndObjects(" ", 18, "novakoleg107@gmail.com");
            Helper.Cleaner();
            
            Console.WriteLine("----------------------------------------\nPart 3.2 :\t Structires!\n----------------------------------------");
            Structures structure = new Structures { name = "olegg", age = 28};
            structure.DisplayInfo();
            structure.age = 23;
            structure.name = "Oleg";
            structure.DisplayInfo();
            Structures structure1 = new Structures { name = "Ivan", age = 55 };
            structure1.DisplayInfo();
             Helper.Cleaner();
            
            Console.WriteLine("----------------------------------------\nPart 3.3 :\t Value types and reference types!\n----------------------------------------");
            ValueTypesAndReferenceTypes vtpart = new ValueTypesAndReferenceTypes() { name = "noname", age = 0 };
            ChangeValueTypesAndReferenceTypes(ref vtpart);
            Console.WriteLine("name = "+vtpart.name + "; age =  "+ vtpart.age+";");
            Helper.Cleaner();
            */
            print.WriteLine("----------------------------------------\nPart 3.4 :\t Namespaces, aliases, and static imports!\n----------------------------------------");
            stru usingstr = new stru("OLOLO", 25, "string");
            
            



            Helper.Cleaner();




            Console.ReadKey();
        }

        static void ChangeValueTypesAndReferenceTypes(ref ValueTypesAndReferenceTypes vtpart)
        {
            
            vtpart.name = "Alice";
            
            vtpart = new ValueTypesAndReferenceTypes { name = "Oleg", age = 28 };
        }



    }
}

