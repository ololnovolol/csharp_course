using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Solution.Capture26_Validation_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstTest();
            ValidationArttr();

            Console.ReadKey();

        }
        public static void FirstTest()
        {
            //Required требует обзательного наличия значения.
            //StringLength устанавливает максимальную и минимальную длину строки,
            //Range устанавливает диапазон приемлемых значений.

            CreatPerson("Perviy", 1);
            CreatPerson("Posledniy", 100);
            CreatPerson("ne popal", 101);
            CreatPerson("", 55);
            CreatPerson("12345678910111213141516171819202122", 55);

        }
        public static void ValidationArttr()
        {



        }

        static void CreatPerson(string name, int age)
        {
            Person person = new Person(name, age);

            //Вначале мы создаем контекст валидации - объект
            ValidationContext context = new ValidationContext(person);

            // создаем список объектов валидации каждый ValidationResult содержит информацию о возникшей ошибке.
            var results = new List<ValidationResult>();

            // Собственно валидацию производит класс Validator и его метод TryValidateObject()
            if (!Validator.TryValidateObject(person, context, results, true))
            {
                Console.WriteLine("Не удалось создать объект User");
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine($"Объект User успешно создан. Name: {person.Name}\n");

        }
    }
}
