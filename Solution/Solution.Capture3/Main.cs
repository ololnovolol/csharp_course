using System;
using print = System.Console;
using stru = Solution.Capture3.ClassesAndObjects;
using Solution.Capture2;
using OlolLybrary;





namespace Solution.Capture3
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
            Console.WriteLine("----------------------------------------\nPart 3.1 :\t Classes and objects!\n----------------------------------------");
            ClassesAndObjects cao = new ClassesAndObjects(" ", 18, "novakoleg107@gmail.com");
            HelpMEClean.Cleaner();
            
            Console.WriteLine("----------------------------------------\nPart 3.2 :\t Structires!\n----------------------------------------\n");
            Structures structure = new Structures { name = "olegg", age = 28};
            structure.DisplayInfo();
            structure.age = 23;
            structure.name = "Oleg";
            structure.DisplayInfo();
            Structures structure1 = new Structures { name = "Ivan", age = 55 };
            structure1.DisplayInfo();
            HelpMEClean.Cleaner();
            
            Console.WriteLine("----------------------------------------\nPart 3.3 :\t Value types and reference types!\n----------------------------------------\n");
            ValueTypesAndReferenceTypes vtpart = new ValueTypesAndReferenceTypes() { name = "noname", age = 0 };
            ChangeValueTypesAndReferenceTypes(ref vtpart);
            Console.WriteLine("name = "+vtpart.name + "; age =  "+ vtpart.age+";");
            HelpMEClean.Cleaner();
            
            print.WriteLine("----------------------------------------\nPart 3.4 :\t Namespaces, aliases, and static imports!\n----------------------------------------\n");
            stru usingstr = new stru("OLOLO", 25, "string");
            Cycles.taskThree();
            Cleaner.CCleaner();
            

            print.WriteLine("----------------------------------------\nPart 3.5 :\t Creating a class library!\n----------------------------------------\n");
            MyCleaner cap1 = new MyCleaner();
            Cleaner.CCleaner();

            print.WriteLine("----------------------------------------\nPart 3.6 :\t Access modifiers!\n----------------------------------------\n");
            AccessModifiers pv = new AccessModifiers(10,10,10);
            pv.publ = 25;
            pv.intern = 10;
            pv.protecIntern = 10;
            pv.Printer();
            
            AccessModifiers.AccessModifiersSubClass subpv = new AccessModifiers.AccessModifiersSubClass("hi","hi","hi");
            subpv.publ = "hi";
            subpv.intern = "hi";
            subpv.protecIntern = "hi";
            subpv.SubClassPrinter();
            Cleaner.CCleaner();
            
            print.WriteLine("----------------------------------------\nPart 3.7:\t Properties!\n----------------------------------------\n");

            Properties prop = new Properties(10,20);
            //prop.propertyAge = 55;
            int g = prop.propertyAge;
            print.WriteLine(prop.propertyAge);
            Cleaner.CCleaner();
            
            print.WriteLine("----------------------------------------\nPart 3.8:\t Method overloading!\n----------------------------------------\n");
            MethodOverloading over = new MethodOverloading();
            over.Add(10, 10);
            over.Add(10, 10, 10);
            over.Add(10, 10, 10, 10);
            over.Add(10.00, 10.00);
            HelpMEClean.Cleaner();
            
            print.WriteLine("----------------------------------------\nPart 3.9:\t Static class members!\n----------------------------------------\n");
            StaticClassMembers scm = new StaticClassMembers(); // access to non-static methods and properties is prohibited
            scm.number = 5; // access to non-static methods and properties is prohibited
            StaticClassMembers.Printer();
            StaticClassMembers.Accessor();
            StaticClassMembers.Printer();
            HelpMEClean.Cleaner();
            */









            HelpMEClean.Cleaner();
            Console.ReadKey();
        }

        static void ChangeValueTypesAndReferenceTypes(ref ValueTypesAndReferenceTypes vtpart)
        {

            vtpart.name = "nononame";

            vtpart = new ValueTypesAndReferenceTypes { name = "Oleg", age = 28 };
        }



    }
}

