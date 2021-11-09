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
            Part3dot1();

            HelpMEClean.Cleaner();
            print.WriteLine("Solution 3 is comlete=)");
            Console.ReadKey();
        }

        static void ChangeValueTypesAndReferenceTypes(ref ValueTypesAndReferenceTypes vtpart)
        {

            vtpart.name = "nononame";

            vtpart = new ValueTypesAndReferenceTypes { name = "Oleg", age = 28 };
        }

        public static void Part3dot1()
        {
            print.WriteLine(">>Part 3.1 :\t Classes and objects!\n");
            stru cao = new(" ", 18, "novakoleg107@gmail.com");
            HelpMEClean.Cleaner();
            Part3dot2();

        }
        public static void Part3dot2()
        {
            Console.WriteLine(">>Part 3.2 :\t Structires!\n"); // раскажи как часто ты их юзаешь понмаю про быстродействие за счет обьема... не понимаю в другие удобства структур
            Structures structure = new() { name = "olegg", age = 28 };
            structure.DisplayInfo();
            structure.age = 23;
            structure.name = "Oleg";
            structure.DisplayInfo();
            Structures structure1 = new() { name = "Ivan", age = 55 };
            structure1.DisplayInfo();
            HelpMEClean.Cleaner();
            Part3dot3();
        }
        public static void Part3dot3()
        {
            Console.WriteLine(">>Part 3.3 :\t Value types and reference types!\n");
            ValueTypesAndReferenceTypes vtpart = new ValueTypesAndReferenceTypes() { name = "noname", age = 0 };
            ChangeValueTypesAndReferenceTypes(ref vtpart);
            Console.WriteLine("name = " + vtpart.name + "; age =  " + vtpart.age + ";");

            string nameUser = "Oleg";
            uint ageUser = 28;
            char groupBlood = '+';
            ValueTypesAndReferenceTypes vv = new ValueTypesAndReferenceTypes();
            vv.ClearWithBase(ref nameUser, out ageUser, groupBlood);
            print.WriteLine($"name = {nameUser}, age = {ageUser}, blood = {groupBlood}\n");

            int[] massive = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int i = 0;

            ValueTypesAndReferenceTypes.AddOrDeleteToArray(ref massive, 100, 10);
            foreach (var item in massive)
            {
                print.WriteLine($"[{i++}] element = {item}");
            }
            i = 0;
            print.WriteLine();

            ValueTypesAndReferenceTypes.AddFirst(ref massive, 11);
            foreach (var item in massive)
            {
                print.WriteLine($"[{i++}] element = {item}");
            }
            i = 0;
            print.WriteLine();

            ValueTypesAndReferenceTypes.AddLast(ref massive, 99);
            foreach (var item in massive)
            {
                print.WriteLine($"[{i++}] element = {item}");
            }

            HelpMEClean.Cleaner();
            Part3dot4();
        }
        public static void Part3dot4()
        {
            print.WriteLine(">>Part 3.4 :\t Namespaces, aliases, and static imports!\n");
            stru usingstr = new stru("OLOLO", 25, "string");
            Cycles.taskThree();
            Cleaner.CCleaner();
            Part3dot5();
        }
        public static void Part3dot5()
        {
            print.WriteLine(">>Part 3.5 :\t Creating a class library!\n");
            MyCleaner cap1 = new MyCleaner();
            Cleaner.CCleaner();
            Part3dot6();
        }
        public static void Part3dot6()
        {
            print.WriteLine(">>Part 3.6 :\t Access modifiers!\n"); // самые частые ?? public , private, protected  ??
            AccessModifiers pv = new AccessModifiers(10, 10, 10);
            pv.publ = 25;
            pv.intern = 10;
            pv.protecIntern = 10;
            pv.Printer();

            AccessModifiers.AccessModifiersSubClass subpv = new AccessModifiers.AccessModifiersSubClass("hi", "hi", "hi");
            subpv.publ = "hi";
            subpv.intern = "hi";
            subpv.protecIntern = "hi";
            subpv.SubClassPrinter();
            HelpMEClean.Cleaner();
            Part3dot7();
        }
        public static void Part3dot7()
        {
            print.WriteLine(">>Part 3.7:\t Properties!\n");

            Properties prop = new Properties(10, 20);
            prop.propertyAge = 55;
            int g = prop.propertyAge;
            print.WriteLine(prop.propertyAge);
            HelpMEClean.Cleaner();
            Part3dot8();
        }
        public static void Part3dot8()
        {
            print.WriteLine(">>Part 3.8:\t Method overloading!\n");
            MethodOverloading over = new MethodOverloading();
            over.Add(10, 10);
            over.Add(10, 10, 10);
            over.Add(10, 10, 10, 10);
            over.Add(10.00, 10.00);
            HelpMEClean.Cleaner();
            Part3dot9();
        }
        public static void Part3dot9()
        {
            print.WriteLine(">>Part 3.9:\t Static class members!\n");
            StaticClassMembers scm = new StaticClassMembers(); // access to non-static methods and properties is prohibited
            scm.number = 5; // access to non-static methods and properties is prohibited
            StaticClassMembers.Printer();
            StaticClassMembers.Accessor();
            StaticClassMembers.Printer();
            HelpMEClean.Cleaner();
            Part3dot10();
        }
        public static void Part3dot10()
        {
            print.WriteLine(">>Part 3.10:\t Reading Constants, Fields, and Structures!\n");
            ReadingConstantsFieldsStructures rcfs = new ReadingConstantsFieldsStructures(10);
            print.WriteLine("readonly = " + rcfs.field);
            print.WriteLine("constanta = " + ReadingConstantsFieldsStructures.KOEF);
            HelpMEClean.Cleaner();
            Part3dot11();
        }
        public static void Part3dot11()
        {
            print.WriteLine(">>Part 3.11:\t Operator Overloading!\n");  /// вопрос ниже=)

            OperatorOverloading.State state1 = new OperatorOverloading.State();
            state1.population = 100;
            state1.area = 500.000m;
            OperatorOverloading.State state2 = new OperatorOverloading.State();
            state2.population = 25;
            state2.area = 1000.000m;
            OperatorOverloading.State state3 = state1 + state2;
            print.WriteLine($"State3Population = {state3.population}, State3Area = {state3.area}");

            bool isGreater = state1 > state2;
            print.WriteLine("\nstate1 area > state 2 area = " + isGreater);



            OperatorOverloading.State aragon = new OperatorOverloading.State { area = 23, population = 2 };
            OperatorOverloading.State kastilia = new OperatorOverloading.State { area = 41, population = 5 };
            OperatorOverloading.State spain = aragon + kastilia;
            Console.WriteLine(spain.population);    // 7
            if (aragon > kastilia)
            {
                Console.WriteLine("Aragon greater than Castile");
            }
            else
            {
                Console.WriteLine("Aragon is smaller than Castile");
            }



            OperatorOverloading.Bread bread = new OperatorOverloading.Bread { Weight = 80 };             ///////////////////////////////////////////в каком месте стоит располагать оператор перегрузки
            OperatorOverloading.Butter butter = new OperatorOverloading.Butter { Weight = 20 };
            OperatorOverloading.Sandwich sandwich = bread + butter;
            Console.WriteLine("\t" + sandwich.Weight);  // 100
            HelpMEClean.Cleaner();
            Part3dot12();
        }
        public static void Part3dot12()
        {
            print.WriteLine(">>Part 3.12:\t Null value!\n");

            object x = null;
            object y = x ?? 100;
            print.WriteLine(y);

            object z = 200;
            object t = z ?? 44;
            print.WriteLine(t);
            HelpMEClean.Cleaner();

            NullValue nv = new NullValue { };
            string companyName = nv?.Phone?.Company?.Name ?? "не установлено";
            print.WriteLine(companyName);
            Part3dot13();
        }
        public static void Part3dot13()
        {
            print.WriteLine(">>Part 3.13:\t Indexers!\n"); // частота  использования
            //created two players
            Indexers.FootballPayer player1 = new Indexers.FootballPayer() { name = "Sheva", numberOfPlayer = 7 };
            Indexers.FootballPayer player2 = new Indexers.FootballPayer() { name = "Rebrov", numberOfPlayer = 2 };
            print.WriteLine("Player " + player1.name + " - Have number " + player1.numberOfPlayer);
            print.WriteLine("Player " + player2.name + " - Have number " + player2.numberOfPlayer);

            //createb FBTeam
            Indexers.FootballTeam metalist = new Indexers.FootballTeam();
            metalist[0] = new Indexers.FootballPayer { name = "Sheva", numberOfPlayer = 7 };
            metalist[1] = new Indexers.FootballPayer { name = "Rebrov", numberOfPlayer = 2 };
            print.WriteLine("first Player " + (metalist[0]?.name ?? "<<does not exist>>") + " - Have number " + (metalist[0]?.numberOfPlayer ?? 0));
            print.WriteLine("second Player " + (metalist[1]?.name ?? "<<does not exist>>") + " - Have number " + (metalist[1]?.numberOfPlayer ?? 0));
            //check for non - existent element and Null
            print.WriteLine("three Player " + (metalist[25]?.name ?? "<<does not exist>>") + " - Have number " + (metalist[25]?.numberOfPlayer ?? 0));

            Indexers.Dictionary translate = new Indexers.Dictionary();
            translate["red"] = new Indexers.Word("red", "жопа");
            print.WriteLine(translate["red"].Target);
            print.WriteLine(translate["blue"].Target);
            print.WriteLine(translate["green"].Target);
            translate["green"].Target = "сова";
            translate["red"].Target = "красный";
            print.WriteLine(translate["red"].Target);
            print.WriteLine(translate["green"].Target);
            HelpMEClean.Cleaner();
            Part3dot14();
        }
        public static void Part3dot14()
        {
            print.WriteLine(">>Part 3.14:\t Inheritance!\n");  /// вопрос достежимости мать его кода в наследниках protected
            Intheritance.Manager manager = new Intheritance.Manager(27, "Oleg") { age = 28 };
            print.WriteLine(manager.age);
            print.WriteLine(manager.name);
            print.WriteLine(manager.rase);

            print.WriteLine(" ");

            Intheritance.Builder builder = new Intheritance.Builder(35, "Tolyan", false);
            print.WriteLine(builder.age);
            print.WriteLine(builder.name);
            print.WriteLine(builder.rase);

            print.WriteLine(" ");

            Intheritance.Employe employe = new Intheritance.Employe(85, "Hui Lun");
            print.WriteLine(employe.age);
            print.WriteLine(employe.name);
            print.WriteLine(employe.rase);
            HelpMEClean.Cleaner();
            Part3dot15();
        }
        public static void Part3dot15()
        {
            Intheritance.Builder builder = new Intheritance.Builder(35, "Tolyan", false);
            print.WriteLine(builder.age);
            print.WriteLine(builder.name);
            print.WriteLine(builder.rase);

            Intheritance.Manager manager = new Intheritance.Manager(27, "Oleg") { age = 28 };
            print.WriteLine(manager.age);
            print.WriteLine(manager.name);
            print.WriteLine(manager.rase);

            print.WriteLine(">>Part 3.15:\t Type conversion!\n");
            print.WriteLine("Part one: Upcasting");
            Intheritance.Human human = builder;
            print.WriteLine("Upcasting bulider in Human = " + human.rase);

            Intheritance.Human human1 = manager;
            print.WriteLine("Upcasting manager in Human = " + human1.rase);

            print.WriteLine("Part two: Downcasting");

            Intheritance.Manager manager2 = (Intheritance.Manager)human1;
            print.WriteLine("Downcasting Human in manager = " + manager2.name);


            Intheritance.Human humanoid = new Intheritance.Human(true);
            Intheritance.Builder buldozer = humanoid as Intheritance.Builder;
            if (buldozer == null)
            {
                Console.WriteLine("\nConversion failed!");
            }
            else
            {
                Console.WriteLine(buldozer.rase);
            }

            Intheritance.Children Chilik = humanoid as Intheritance.Children;
            if (Chilik == null)
            {
                Console.WriteLine("\nConversion failed!");
            }
            else
            {
                Console.WriteLine();
            }
            HelpMEClean.Cleaner();
            Part3dot16();
        }
        public static void Part3dot16()
        {
            print.WriteLine(">>Part 3.16:\t Overloading Type Conversion Operations!\n");

            print.WriteLine("\nPart one !!!\n");
            OverloadingTypeConversionOperations.Clock clock = new OverloadingTypeConversionOperations.Clock { Hours = 24 };

            int xxx = (int)clock;
            print.WriteLine(xxx);

            OverloadingTypeConversionOperations.Clock clock2 = 64;
            print.WriteLine(clock2.Hours);
            clock2 = 49;
            print.WriteLine(clock2.Hours);

            print.WriteLine("\nPart Two !!!\n");
            OverloadingTypeConversionOperations.Celcius celcius = new OverloadingTypeConversionOperations.Celcius() { Gradus = 99 };
            OverloadingTypeConversionOperations.Fahrenheit farengeit = new OverloadingTypeConversionOperations.Fahrenheit() { Gradus = 186 };

            celcius = (OverloadingTypeConversionOperations.Celcius)farengeit;
            print.WriteLine(celcius.Gradus); //85,55555555555556
            celcius.Gradus = 18;
            farengeit = (OverloadingTypeConversionOperations.Fahrenheit)celcius;
            print.WriteLine(farengeit.Gradus); //211,6
            print.WriteLine("\nPart three !!!\n");
            OverloadingTypeConversionOperations.Dollar baks = new OverloadingTypeConversionOperations.Dollar { Sum = 100m };
            OverloadingTypeConversionOperations.Euro euro = new OverloadingTypeConversionOperations.Euro { Sum = 200m };

            baks = (OverloadingTypeConversionOperations.Dollar)euro.Sum;
            print.WriteLine($"{euro.Sum} evro = {baks.Sum} dollars (course = 1.14)"); //228.00

            baks.Sum = 99.99m;
            euro = baks;
            print.WriteLine($"{baks.Sum} dollars = {euro.Sum} euro (course = 1.14)"); // 87,71052631578947368421052632
            HelpMEClean.Cleaner();
            Part3dot17per20();
        }
        public static void Part3dot17per20()
        {
            print.WriteLine(">>Part 3.17-3.18-3.19-3.20:\t Virtual methods and properties!\n");

            Intheritance.Human humanVirtual = new Intheritance.Human();
            humanVirtual.Display();// not undefined            !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!к полю не применилось значение// если указать так Intheritance.Human()

            Intheritance.Children baby = new Intheritance.Children { age = 12, name = "Stepan", rase = "Зелёненький" };
            baby.Display();
            HelpMEClean.Cleaner();

            print.WriteLine(">>Part 3.21:\t The System.Object Class and Its Methods!\n");
            Clock tiktak = new Clock() { Hours = 9, Minutess = 25, Seconds = 55, CName = "22/09/2021" };
            print.WriteLine(tiktak.ToString());
            Clock tiktak1 = new Clock() { CName = "22/09/2021" };
            print.WriteLine(tiktak1.GetHashCode());
            Clock tiktak2 = new Clock() { CName = "01/10/2022" };
            print.WriteLine(tiktak2.GetHashCode());
            Clock tiktak3 = new Clock() { CName = "22/09/2021" };
            print.WriteLine(tiktak3.GetHashCode());

            print.WriteLine(tiktak1.GetType().Equals(tiktak3.GetType()));
            print.WriteLine(tiktak1.Equals(tiktak2));
            print.WriteLine(tiktak1.Equals(tiktak3));
            HelpMEClean.Cleaner();
            Part3dot21();
        }
        public static void Part3dot21()
        {
            print.WriteLine(">>Part 3.21:\t Generics!\n");
            GenericAccount<string> genAcaunt = new GenericAccount<string>("25t625", "Oleg", 28);
            print.WriteLine($"{genAcaunt.Id} his type = { genAcaunt.GetType()}");
            GenericAccount<int> genAcaunt1 = new GenericAccount<int>(25625, "Oleg", 29);
            print.WriteLine(genAcaunt1.Id);
            GenericAccount<byte> genAcaunt2 = new GenericAccount<byte>(254, "Oleg", 30);
            print.WriteLine(genAcaunt2.Id);
            print.WriteLine("\tPart two");
            MasiveGeneric<int> arrInt = new MasiveGeneric<int>();
            MasiveGeneric<string> arrString = new MasiveGeneric<string>();
            MasiveGeneric<char> arrChar = new MasiveGeneric<char>();

            arrInt.AddGenMasive(12);
            arrInt.AddGenMasive(120);
            arrInt.AddGenMasive(1200);
            arrInt.PrintMasive();
            print.WriteLine("masive l = " + arrInt.GetGenMasiveLeunght());
            arrInt.RemoveGenMasiveforIndex(0);
            arrInt.RemoveGenMasiveforIndex(2);
            arrInt.PrintMasive();
            print.WriteLine();
            arrString.AddGenMasive("Hi");
            arrString.AddGenMasive("World");
            arrString.AddGenMasive("Hello");
            arrString.PrintMasive();
            arrString.RemoveGenMasiveforIndex(0);
            arrString.PrintMasive();


            Generic.Account acc1 = new Generic.Account(252) { CurrentSum = 25000 };
            Generic.Account acc2 = new Generic.Account(253) { CurrentSum = 100 };
            Generic.Transaction<Generic.Account> operation1 = new Generic.Transaction<Generic.Account> { FromAccount = acc1, ToAccount = acc2, SumTransaction = 50 };
            print.WriteLine("sum = acc1 = " + acc1.CurrentSum);
            print.WriteLine("sum = acc2 = " + acc2.CurrentSum);
            print.WriteLine("after transaction");
            operation1.Execute();

            Generic.DepositAccount<int> acc11 = new Generic.DepositAccount<int>(34);
            Generic.DepositAccount<string> acc12 = new Generic.DemandAccount<string>("45");
            Generic.DemandAccount<int> acc13 = new Generic.DemandAccount<int>(49);
            Console.WriteLine(acc11.id);
            Console.WriteLine(acc12.id);
            Console.WriteLine(acc13.id);
        }
    }
}

