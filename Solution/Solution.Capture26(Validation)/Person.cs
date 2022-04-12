using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;

namespace Solution.Capture26_Validation_
{
    internal class Person
    {
        //Required требует обзательного наличия значения.
        //StringLength устанавливает максимальную и минимальную длину строки,
        //Range устанавливает диапазон приемлемых значений.

        [Required]
        [StringLength(22, MinimumLength = 2)]
        public string Name { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = true)] // данный атрибут позволяет создавать пустую строку
        public string Company { get; set; } = "";

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
