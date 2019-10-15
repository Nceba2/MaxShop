using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MaShop.Controllers
{
    interface IDataController
    {
        string password { get; set; }

        string email { get; set; }

        WebHeaderCollection _webQueryString { get; set; }

        string _date { get; set; }

        string _time { get; set; }

        string _userId { get; set; }

        string _styleId { get; set; }

        JArray GetStyles();

        string GetBookings();

        bool DoLogin();

        bool DoRegister();

        string DoBooking();
    }

}