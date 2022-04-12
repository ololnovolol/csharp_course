using System;
using System.ComponentModel.DataAnnotations;

namespace Solution.Capture26_Validation_
{
    internal class IfUserNameAdminAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string userName)
            {
                if (userName != "admin")    // если имя не равно admin
                    return true;
                else
                    ErrorMessage = "Некорректное имя: admin";
            }
            return false;
        }
    }
}
