using Newtonsoft.Json.Linq;

namespace MaShop.Models
{
    public interface IValidationMoel
    {
        string name { get; set; }
        string email { get; set; }
        string phonenumber { get; set; }
        string password { get; set; }

        bool ValidateLogin(JArray responseStr);

         bool ValidateRegistration(JArray responseStr);
    }
}