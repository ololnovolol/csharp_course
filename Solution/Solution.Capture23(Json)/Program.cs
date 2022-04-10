using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Solution.Capture23_Json_
{
    class Program
    {

        public static async Task Main(string[] args)
        {
            //TestBasicTranslate();
            await WriteCreateJsonFileAsync(new Person("Semen", 25));
            await ReadCreateJsonFileAsync(new Person("Semen", 25));

            await WriteCreateJsonFileAsync(new Person("withAtributsPlusIgnoreAge", 33));
            await ReadCreateJsonFileAsync(new Person("withAtributsPlusIgnoreAge", 33));



        }
        public static void TestBasicTranslate()
        {
            Person p = new Person("Semen", 25);

            string json = JsonSerializer.Serialize(p);
            Console.WriteLine("Json FileText >> " + json);

            Person? p1 = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine("with Json to obj Person  >> Name =" + p1.Name + ", Age = " + p1.Age);
        }

        public static async Task WriteCreateJsonFileAsync(Person person)
        {
            using (FileStream fs = new FileStream("test.json", FileMode.OpenOrCreate))
            {
                var optioms = new JsonSerializerOptions // разделитель пробелами
                {

                    WriteIndented = true
                    // или AllowTrailingCommas = true - разделитель запятыми
                    // иил  IgnoreReadOnlyProperties добавление свойств для чтения в файл
                };
                await JsonSerializer.SerializeAsync(fs, person, optioms);

                Console.WriteLine("Data has been saved in file ");

            }

        }
        public static async Task ReadCreateJsonFileAsync(Person person)
        {
            using (FileStream fs = new FileStream("test.json", FileMode.Open))
            {
                Person? newPerson = await JsonSerializer.DeserializeAsync<Person>(fs);

                Console.WriteLine($"name ={newPerson.Name}, age = {newPerson.Age}");
            }

        }



    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }
    }
 
    
    class PerDson
    {
        [JsonPropertyName("SecondName")]
        public string Name { get; set; }
        [JsonIgnore]
        public int Age { get; set; }

        public PerDson(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}