using Newtonsoft.Json.Linq;

namespace MaxShopApi.Controllers
{
    public interface IProccessController
    {
        string processName { get; set; }

        //for booking
        string date { get; set; }
        string time { get; set; }
        string userid { get; set; }
        string styleid { get; set; }

        //for registering
        string _Name { get; set; }
        string email { get; set; }
        string password { get; set; }
        string phonenumber { get; set; }

        void setCredentials(string userpassword, string emailaddress);
        void setProccess();
        JArray getFeedback();
    }
}