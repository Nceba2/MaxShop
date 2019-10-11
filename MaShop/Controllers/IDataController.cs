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

        JArray GetStyles();

        bool DoLogin();

        bool DoRegister();

        string DoBooking();
    }

}