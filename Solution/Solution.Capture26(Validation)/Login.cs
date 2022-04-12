using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Solution.Capture26_Validation_
{
    internal class Login : IValidatableObject

    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Login(string name, int age)
        {
            this.Name = name;
            this.Age = age;

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add(new ValidationResult("Имя не указано"));
            }
            if (Name.Length < 2 || Name.Length > 20)
            {
                errors.Add(new ValidationResult("Имя не может быть короче 2х симв и длиннее 20 симв"));
            }
            if (Age > 100 || Age < 0)
            {
                errors.Add(new ValidationResult("Возраст должен быть больше 0 и меньше 100"));
            }
            return errors;
        }
    }
}
