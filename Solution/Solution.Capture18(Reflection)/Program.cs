using System.Reflection;
using Solution.Capure19;


namespace Solution.Capture18_Reflection_
{
    class Program
    {
        public static void Main(string[] args)
        {
            //BasePrincips();
            //GetMembers();
            //BindingFlags();
            //resultComponents();
            //Worker();
            //Upper();
            AssemblyLoadForm();


            Console.ReadKey();
        }
        //part 1
        public static void BasePrincips()
        {
            Type myType = typeof(PersonNonGratt1);
            Type myType2 = typeof(Solution.Test.PersonNonGratt2);

            Console.WriteLine($"Name: {myType.Name}");              // получаем краткое имя типа
            Console.WriteLine($"Full Name: {myType.FullName}");     // получаем полное имя типа
            Console.WriteLine($"Namespace: {myType.Namespace}");    // получаем пространство имен типа
            Console.WriteLine($"Is struct: {myType.IsValueType}");  // является ли тип структурой
            Console.WriteLine($"Is class: {myType.IsClass}");

            Console.WriteLine();

            Console.WriteLine($"Name: {myType2.Name}");              // получаем краткое имя типа
            Console.WriteLine($"Full Name: {myType2.FullName}");     // получаем полное имя типа
            Console.WriteLine($"Namespace: {myType2.Namespace}");    // получаем пространство имен типа
            Console.WriteLine($"Is struct: {myType2.IsValueType}");  // является ли тип структурой
            Console.WriteLine($"Is class: {myType2.IsClass}");

            Console.WriteLine("Реализованные интерфейсы:");
            foreach (var item in myType.GetInterfaces())
            {
                Console.WriteLine("name = " + item.Name);
                Console.WriteLine("Fullname = " + item.FullName);
                Console.WriteLine("nameSpace = " + item.Namespace);
                Console.WriteLine("is value type = " + item.IsValueType);
                Console.WriteLine("is inteface  = " + item.IsInterface);
                Console.WriteLine();
            }

        }
        //part 2
        public static void GetMembers()
        {
            // DeclaringType: возвращает полное название типа.
            //MemberType: возвращает значение из перечисления MemberTypes:
            //MemberTypes.Constructor
            //MemberTypes.Method
            //MemberTypes.Field
            //MemberTypes.Event
            //MemberTypes.Property
            //MemberTypes.NestedType
            //Name: возвращает название компонента

            Type myType = typeof(PersonNonGratt1);
            Type myType1 = typeof(Solution.Test.PersonNonGratt2);

            Console.WriteLine("class PersonNonGratt1");
            foreach (MemberInfo item in myType.GetMembers())
            {
                Console.WriteLine($"{item.DeclaringType}: {item.MemberType}, {item.Name}  ");
            }

            Console.WriteLine();

            Console.WriteLine("class PersonNonGratt2");
            foreach (var item in myType1.GetMembers())
            {
                Console.WriteLine($"{item.DeclaringType}: {item.MemberType}, {item.Name}  ");

            }
        }
        public static void BindingFlags()
        {
            //DeclaredOnly: получает только методы непосредственно данного класса, унаследованные методы не извлекаются
            //Instance: получает только методы экземпляра
            //NonPublic: извлекает не публичные методы
            //Public: получает только публичные методы
            //Static: получает только статические методы

            Type mytype1 = typeof(PersonNonGratt1);
            Type mytype2 = typeof(Solution.Test.PersonNonGratt2);

            Console.WriteLine("PersonNonGratt1");
            foreach (var item in mytype1.GetMembers(System.Reflection.BindingFlags.DeclaredOnly
                | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Public))
            {
                Console.WriteLine($"{item.DeclaringType} - {item.Name} {item.MemberType}");
            }
            Console.WriteLine();

            Console.WriteLine("PersonNonGratt2");
            foreach (var item in mytype2.GetMembers(System.Reflection.BindingFlags.DeclaredOnly
                | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Public))
            {
                Console.WriteLine($"{item.DeclaringType} - {item.Name} {item.MemberType}");
            }
        }
        public static void resultComponents()
        {
            Type type1 = typeof(PersonNonGratt1);
            Type mytype2 = typeof(Solution.Test.PersonNonGratt2);

            //PersonNonGratt1 получаем компонент метода есть
            Console.WriteLine("PersonNonGratt1");
            var result1 = type1.GetMember("Eat", System.Reflection.BindingFlags.Instance
                        | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);

            foreach (var item in result1)
            {
                Console.WriteLine(item.DeclaringType + " " + item.MemberType + " " + item.Name);
            }
            Console.WriteLine();

            //PersonNonGratt2 получаем компонент метода Говорить
            Console.WriteLine("PersonNonGratt2");
            MemberInfo[] result2 = mytype2.GetMember("Say", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            foreach (var item in result2)
            {
                Console.WriteLine($"{item.DeclaringType} {item.MemberType} {item.Name}");
            }
        }
        //part 3
        public static void Worker()
        {
            Type type1 = typeof(PersonNonGratt1);
            Type type2 = typeof(Test.PersonNonGratt2);


            //Part3InfoMethods(type1.Name + " Class", type1);
            //Part3InfoMethods(type2.Name + " Class", type2);

            //Part3InfoParams(type1.Name + " Class", type1);

            //CallPublicMethod(type1.Name + " Class", type1);
            //CallPrivateMethod(type1.Name + " Class", type1);
            //Console.WriteLine(CallPrivateMethod( type1));
            // CallWithDoubleAndTrancendParameters(type1.Name + " Class", type1);
            //CallTtypes();
           // GetCtor();

        }
        public static void Part3InfoMethods(string name, Type type)
        {

            Console.WriteLine(name);
            foreach (var item in type.GetMethods(System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic).Where(m => !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_")))
            {
                string modyficator = "";

                if (item.IsPublic)
                {
                    modyficator += "public ";
                }
                if (item.IsPrivate)
                {
                    modyficator += "private ";
                }
                if (item.IsStatic)
                {
                    modyficator += "static ";
                }
                if (item.IsVirtual)
                {
                    modyficator += "virtual ";
                }
                if (item.IsFamily)
                {
                    modyficator += "protected ";
                }
                Console.WriteLine($"{modyficator}{item.ReturnType.Name} {item.Name}");

            }
            Console.WriteLine();

        }
        public static void Part3InfoParams(string name, Type type)
        {
            Console.WriteLine(name);
            foreach (var item in type.GetMethods())
            {
                ParameterInfo[] parametrs = item.GetParameters();
                string modific = " ";

                Console.Write($"{item.ReturnType.Name} {item.Name} (");

                for (int i = 0; i < parametrs.Length; i++)
                {
                    if (parametrs[i].IsIn)
                    {
                        modific += " In";
                    }
                    if (parametrs[i].IsOut)
                    { 
                        modific += " out";
                    }

                    Console.Write($" {parametrs[i].ParameterType.Name} {parametrs[i].Name}");

                    if (parametrs[i].HasDefaultValue) Console.Write($"={parametrs[i].DefaultValue}");
                    if (i < parametrs.Length - 1)
                    {
                        Console.Write(",");
                    }
                }

                Console.Write(");");
                Console.WriteLine();

            }
        }
        public static void CallPublicMethod(string name, Type type)
        {
            Console.WriteLine(name);

            PersonNonGratt1 objectOne = new PersonNonGratt1("moveee");
            var paramsss = type.GetMethod("Puck");

            paramsss?.Invoke(objectOne, parameters: null);
        }
        public static void CallPrivateMethod(string name, Type type)
        {
            Console.WriteLine(name);

            PersonNonGratt1 objectOne = new PersonNonGratt1("moveee");
            string nameMethod = String.Format("belching").Replace('b', 'B');

            var serj = type.GetMethod((nameMethod), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);

            serj?.Invoke(objectOne, parameters: null);
        }
        public static object CallPrivateMethod(Type type)
        {
            
            PersonNonGratt1 objectOne = new PersonNonGratt1("moveee");
            string nameMethod = String.Format("belching").Replace('b', 'B');

            var serj = type.GetMethod((nameMethod), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);          
            
            var result = serj?.Invoke(objectOne, parameters: null);

            object obj = 0;

            if (result != null)
            {
                return result;
            }
            else
            {
                return obj;
            }

        }
        public static void CallWithDoubleAndTrancendParameters(string name, Type type)
        {
            Console.WriteLine(name);

            PersonNonGratt1 p1 = new PersonNonGratt1();

            var human = type.GetMethod("Say", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Public);

            human?.Invoke(p1, new object[] { "Privet" });



        }
        public static void CallTtypes()
        {
            Console.WriteLine();

            PersonNonGratt1 p1 = new PersonNonGratt1();

            var getMethod = typeof(PersonNonGratt1).GetMethod("Print");

            var getTMethod = getMethod?.MakeGenericMethod(typeof(string));

            var result = getTMethod?.Invoke(p1, new object[] { "a4" });




        }
        public static void GetCtor()
        {
            var p1 = typeof(PersonNonGratt1);

            foreach (ConstructorInfo ctor in p1.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic))
            {
                Console.WriteLine();
                string paramss = "";
                if(ctor.IsAbstract) paramss += "abstract";
                if (ctor.IsPublic) paramss += "public";
                if (ctor.IsPrivate) paramss += "sealed";
                if (ctor.IsPrivate) paramss += "private";
                if (ctor.IsAbstract) paramss += "abstract";
                if (ctor.IsVirtual) paramss += "virtual";
                if (ctor.IsAssembly) paramss += "internal";
                if (ctor.IsFamily) paramss += "protected";

                ParameterInfo[] pi = ctor.GetParameters();

                Console.Write($"{paramss} {p1.Name}( ");

                for (int i = 0; i < pi.Length; i++)
                {
                    var param = pi[i];
                    Console.Write($"{pi[i].ParameterType.Name} {pi[i].Name}");
                    if (i < pi.Length - 1) Console.Write(", ");
                }
                Console.Write(" )");

            }
            Console.WriteLine();
        }
        //part 4
       public static void Upper()
        {
            GetFildes();
            GetProperties();

        }
        public static void GetFildes()
        {
            Type type = typeof(PersonNonGratt1);

            foreach (FieldInfo item in type.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Static))
            {
                string pip = "";
                if (type.IsAbstract) pip += "abstract ";
                if (type.IsPublic) pip += "public ";
                if (type.IsSealed) pip += "sealed ";
                if (type.IsNestedPrivate) pip += "private ";
                if (type.IsNestedFamily) pip += "protected ";
                if (type.IsNestedAssembly) pip += "internal ";
              

                Console.WriteLine($"{pip} {item.FieldType.Name} {item.Name}");

            }

        }
        public static void GetFilde()
        {
            Type type = typeof(PersonNonGratt1);


            
        }
        public static void GetProperties()
        {
            var person = new PersonNonGratt1("Saha", 25, "Black");
            person.Prntered();
            Type type = typeof(PersonNonGratt1);

            Console.WriteLine();

            var name = type.GetField("name", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            var age = type.GetProperty("Age", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            var race = type?.GetField("race", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);

            Console.WriteLine($"{name?.FieldType.Name} {name?.Name} = {name?.GetValue(person)};");
            Console.WriteLine($"{age?.PropertyType.Name} {age?.Name} = {age?.GetValue(person)};");
            Console.WriteLine($"{race?.FieldType.Name} {race?.Name} = {race?.GetValue(person)};");
            var value = name?.GetValue(person);
            name?.SetValue(person, "Reflection_Man");
            age?.SetValue(person, 33);


            person.Prntered();


        }
        //part 5
        public static void AssemblyLoadForm()
        {
            Assembly asm = Assembly.LoadFrom("Solution.Capure19.dll");

            // Console.WriteLine(asm.FullName); //Solution.Capure19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

            var typesAll = asm.GetTypes();   // we get a list clases

            foreach (var item in typesAll)
            {
                Console.WriteLine(item); // we get a list clases
            }

            Type? type1 = asm.GetType("Program");
            Type? type2 = asm.GetType("Bee");
            Type? type3 = asm.GetType("Honey");

            if (type1 != null)
            {
                object? obj1 = Activator.CreateInstance(type1);

                MethodInfo? main = type1?.GetMethod("Main", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);           

                main?.Invoke(obj1, new object[] {new string[] { } });
            }
            if (type2 != null)
            {
                object? obj2 = Activator.CreateInstance(type2);

                MethodInfo? bee = type1?.GetMethod("Bee", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                bee?.Invoke(obj2, null);
               
            }
            if (type3 != null)
            {
                object? obj3 = Activator.CreateInstance(type3);

                MethodInfo? honey = type1?.GetMethod("Honey", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                honey?.Invoke(obj3, null);
            }

           


            





        }
        //part 6

    }

}
namespace Solution.Test
{
    internal class PersonNonGratt2
    {
        private string name;
        public int Age { get; set; }
        public PersonNonGratt2(string name)
        {
            this.name = name;
        }
        public void Say()
        {
            Console.WriteLine(name);
        }
         void Say(int count)
         {
            Console.WriteLine(name);
         }
    }
}