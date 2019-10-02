using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace MaShop.Controllers
{
    interface IRestController
    {
        void ApiRequest_setResponse(string url);

        JArray GetStyles();

        string DoLogin(string[] Login_data);

        string DoRegister(string[] Register_data);

        string DoBooking(string[] Booking_data);
    }

}