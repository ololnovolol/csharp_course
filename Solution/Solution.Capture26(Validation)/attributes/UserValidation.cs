using System.ComponentModel.DataAnnotations;

namespace Solution.Capture26_Validation_.attributes
{
    internal class UserValidationPutinAttribute : ValidationAttribute
    {
        private int min = 0;
        private int max = 100;
        private string name = "putin";

        public UserValidationPutinAttribute(string name, int min, int max)
        {
            this.min = min;
            this.max = max;
            this.name = name;
        }
        public UserValidationPutinAttribute()
        {

        }

        public override bool IsValid(object value)
        {
            
            if (value is Human human)
            {
                if (human.Name != this.name && human.Age > this.min && human.Age < this.max)
                {
                    return true;
                }        
                if (human.Name != this.name)
                {
                    if(human.Age > this.min && human.Age < this.max)
                    return true;
                }
                else
                {
                    ErrorMessage = "имя не должно быть putin и    0 < возраст > 100";
                    return false;
                    
                }
            }
            else
            {
                ErrorMessage = "имя не должно быть putin и    0 < возраст > 100";
                return false;
            }
            ErrorMessage = "имя не должно быть putin и    0 < возраст > 100";
            return false;
        }
    }
}
