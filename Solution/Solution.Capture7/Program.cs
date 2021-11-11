using System;

namespace Solution.Capture7
{
    class Program
    {
        private static void Main(string[] args)
        {
            Zapuskator();
            NullableClassZapuskator();

            Console.Read();
        }
        public static ref int MinPlusTen(ref int a, ref int b)
        {
            if (b > a)
            {
                a += 10;
                return ref a;
            }
            else
            {
                b += 10;
                return ref b;
            }
        }
        static void UseHuman(Person p)
        {
            switch(p)
            {
                case Human human:
                    human.Say();
                    break;
                case null:
                    Console.WriteLine("object is null");
                    break;
                default:
                    Console.WriteLine("object is not Human");
                    break;

            }

        }
        public static string GetLanguage(Person p) //передает в клас данные
        {
            return p switch
            {
                { Language: "Rusian" } => "Привет",
                { Language: "Moldovian" } => "Пiрiвyeт",
                { Language: "England" } => "hello",
                { } => "не определено",
                _ => throw new NotImplementedException()
            };
        }
        public static string GetTranslate(Human huma) //берет данные из деконструктора
        {
            return huma switch
            {
                ("Pepito", _, "Italian", _) => "Pepito say 'Hola'",
                ("Pepito", _, "American", _) => "Pepito say 'Hi'",
                ("Pepito", _, "Ukraine", _) => "Pepito say 'Здоровенькі Були, як ся маєш'",
                ("Andy", _,"American", _) => "Andy say 'Hi'",
                ("Tolyan", _, "Ukraine", _) =>"Tolyan say 'Здоровенькі Були, як ся маєш'",
                (var name, var age, var language,var translate) => $"{name} not found, {age} unknown, {language} undefined",
            _ => "Здрасьть"
            };
        }
        static decimal Calculate(decimal sum)
        {
            return sum switch
            {
                <= 0 => 0,
                < 50000 => sum * 0.05m,
                < 100000 => sum * 0.1m,
                _ => sum * 0.2m
            };
        }
        static string CheckAge(int age)
        {
            return age switch
            {
                < 1 or > 110 => "Invalid age",
                >= 1 and < 18 => "Access is denied",
                _ => "Access is allowed"
            };
        }
        public static void Zapuskator()
        {
            string s = "Привет мир";
            char c = 'и';
            int i = s.CharCount(c);
            Console.WriteLine(i);

            var p = new Person { Age = 5 };
            p.SetName("Alex");
            p.Age = 25;
            Console.WriteLine(p.Name);

            Person persik = new Human();
            persik.SetName("Senya");
            persik.Age = 18;
            //Person persik = new Person();
            //persik = null;
            UseHuman(persik);

            (string name, int age) = persik;
            Console.WriteLine("Deconstruct = " + name + " " + age);

            Person langOleg = new() { Language = "Rusian", Age = 28 };
            string oleg = GetLanguage(langOleg);
            Person langStepan = new() { Language = "Moldovian", Age = 55 };
            string stepan = GetLanguage(langStepan);
            Console.WriteLine($"Pattern Switch Properties: \n\t Oleg speack on Rusian {oleg}\n\t Stepan speack on Moldovian {stepan} ");

            Human pozitionPatern0 = new Human { Name = "Pepito", Age = 777, Language = "Ukraine", Translate = "Hola" };
            Human pozitionPatern1 = new() { Name = "Andy", Age = 888, Language = "American", Translate = "Hi" };
            Human pozitionPatern2 = new() { Name = "Tolyan", Age = 999, Language = "American", Translate = "Здоровенькі Були, як ся маєш??" };
            string traPepito = GetTranslate(pozitionPatern0);
            string traAndy = GetTranslate(pozitionPatern1);
            string traTolyan = GetTranslate(pozitionPatern2);
            Console.WriteLine(traPepito);
            Console.WriteLine(traAndy);
            Console.WriteLine(traTolyan);
            Console.WriteLine("Relational and logical patterns");
            Console.WriteLine(Calculate(-200));
            Console.WriteLine(Calculate(0));
            Console.WriteLine(Calculate(10000));
            Console.WriteLine(Calculate(60000));
            Console.WriteLine(Calculate(200000));
            Console.WriteLine();
            Console.WriteLine(CheckAge(200));
            Console.WriteLine(CheckAge(0));
            Console.WriteLine(CheckAge(17));
            Console.WriteLine(CheckAge(18));
        }
        public static void NullableClassZapuskator()
        {
            NullableClas nc = new();
            nc.PrinterNullable();
            nc.ExplicitConversFromTtoTNull();
            nc.ExplicitConversFromTtoT();
            nc.ImplicitConversFromTtoT();
            nc.ImplicitConvExtenshions();
            nc.ExplicitNarrowingConv();
            nc.VtoT();
            nc.TtoV();
            Console.WriteLine("Local variable reference");
            int a = 5;
            int b = 10;
            ref int refic = ref a;
            Console.WriteLine(refic += 25);
            Console.WriteLine(refic = ref b);
            int res = 0;
            Console.WriteLine(res = MinPlusTen(ref a, ref b));


            PropInModificInit inits = new(24) { distanceInit = 25 };// ctor or autoprop
            //inits.distanceInit = 25; no

            Car audi = new Car() { speed = 250, name = "Audi" };
            Car deo = new Car() { speed = 60, name = "Deo" };

            Audi audiA = new() { speed = 250, name = "Audi" };
            Audi deoA = new() { speed = 60, name = "Deo" };
            var agrigat = deo with { speed = 60, name = "Aveo" };
            agrigat.Drive();

            Console.WriteLine(audi.Equals(deo));
            Console.WriteLine(audiA == deoA);

            var (speedA, nameA) = audi;
            Console.WriteLine(speedA + " km/h " + nameA);
        }
    }
    public static class StringExtension
    {
        public static int CharCount(this string str, char c)
        {
            int count = 0;
            int LocalFunk()
            {
                for (int i = 0; i < str?.Length; i++)
                {
                    if (str[i] == c)
                        count++;

                }
                return count;
            }
            return LocalFunk();

        }

    }

    public partial class Person
    {
        public partial void SetName(string name)
        {
            this.Name = name;
        }
    }
}

