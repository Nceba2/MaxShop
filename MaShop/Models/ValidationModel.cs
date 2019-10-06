using System;
namespace MaShop.Models
{
    public class ValidationModel : IValidationMoel
    {
        public ValidationModel()
        {
        }
        public bool ValidateLogin()
        {
            return true;
        }
        public bool ValidateRegistration()
        {
            return true;
        }
    }
}
