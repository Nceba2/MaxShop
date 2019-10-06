namespace MaShop.Models
{
    public interface IValidationMoel
    {
         bool ValidateLogin();

         bool ValidateRegistration();
    }
}