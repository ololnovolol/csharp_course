using System.ComponentModel.DataAnnotations;
using Solution.Capture26_Validation_.attributes;

namespace Solution.Capture26_Validation_
{
    internal class Person
    {
        //Required требует обзательного наличия значения.
        //StringLength устанавливает максимальную и минимальную длину строки,
        //Range устанавливает диапазон приемлемых значений.

        [Required (ErrorMessage = "Не указано имя пользователя")]
        [StringLength(22, MinimumLength = 2, ErrorMessage = "Длина имени должна быть в диапазоне от {2}-{1} символов")]
        [IfUserNameAdmin]
        public string Name { get; set; } = "unfame";

        //[Range(1, 100)]
        public int Age { get; set; } = 25;

        [Required(AllowEmptyStrings = true)] // данный атрибут позволяет создавать пустую строку
        public string Company { get; set; } = "";

        [RegularExpression(@"^\+[1-9]\d{3}-\d{3}-\d{4}$")]
        //[Phone]
        public string Phone { get; set; } = "+3959-528-2922";

        [Required]
        [Compare("Password", ErrorMessage = "пароли не совпадают!!!!")]
        public string ConfirmPassword { get; set; } = "jojo";

        [Required]
        public string Password { get; set; } = "jojo";


        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Person(string phone)
        {
            Phone = phone;
        }

        //EmailAddress: определяет, является ли значение свойства электронным адресом

        //CreditCard: определяет, является ли значение свойства номером кредитной карты

        //Url: определяет, является ли значение свойства гиперссылкой


        public Person(string pasw, string ConfirmPassword)
        {
            Password = pasw;
            this.ConfirmPassword = ConfirmPassword;
            
        }
    }
}
