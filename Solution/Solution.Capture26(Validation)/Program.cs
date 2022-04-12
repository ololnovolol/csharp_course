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
            //ValidationArttr();

            Console.ReadKey();

        }
        public static void FirstTest()
        {
            ////Required требует обзательного наличия значения.
            ////StringLength устанавливает максимальную и минимальную длину строки,
            ////Range устанавливает диапазон приемлемых значений.

            //CreatPerson("Perviy", 1);
            //CreatPerson("Posledniy", 100);
            //CreatPerson("ne popal", 101);
            //CreatPerson("", 55);
            //CreatPerson("12345678910111213141516171819202122", 55);

            //// проверка на свой атрибут value не должен быть admin
            //CreatPerson("admin", 55);

            //проверка своего атрибута класса не том и возраст больше 0 и меньше 100

            //Validate(new Human(69, "putin"));
            //Validate(new Human(-55, "kadirov"));
            //Validate(new Human(25, "Ukraine"));

            Validate(new Login("MOM", 25));
            Validate(new Login("M", 25));
            Validate(new Login("MOM", -5));




        }
        public static void ValidationArttr()
        {
            //CreatePersonphine("+380636468868");
            //CreatePersonphine("+1111-111-2345");
            //CreatePersonphine("+38063-346-8868");
            //CreatePersonphine("+3063-645-6468");
            //CreatePersonphine("38-063-646-88-68");

            //CreateUserPass("qwerty", "qwerty");
            //CreateUserPass("qwerty1212", "baracuda");
            //CreateUserPass("drEvi1", "drEvil");
            



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

        static void CreatePersonphine(string phone)
        {
            Person p = new Person(phone);
            

            ValidationContext context = new ValidationContext(p);

            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(p, context, results, true))
            {
                Console.WriteLine($"{p.Phone} прошел валидацию");
            }
            else
            {
                Console.WriteLine( $"{p.Phone} >>НЕ<< прошел валидацию");
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine();
            }


        }

        static void CreateUserPass(string pasw, string confpw)
        {
            Person us = new Person(pasw, confpw);

            ValidationContext context = new ValidationContext(us);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(us, context, results, true))
            {
                Console.WriteLine($"{us.Password} - пароль прошел");
             
            }
            else
            {
                Console.WriteLine($"{us.Password} != {us.ConfirmPassword} пароль НЕ прошел");
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine();
            }


        }

        static void Validate<T>(T user)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
                Console.WriteLine("Пользователь прошел валидацию");
            Console.WriteLine();
        }
 
    }
}


