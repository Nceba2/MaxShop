using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MaShop.Controllers
{
    public class RestController : IRestController
    {

        JArray responseStr { get; set; }
        public RestController()
        {
        }

        public void ApiRequest_setResponse(string url)
        {
            using (var wb = new WebClient())
            {
                this.responseStr = JArray.Parse(wb.DownloadString(url));
            }
        }

        public string DoBooking(string[] Booking_data)
        {
            return "booking";
        }

        public string DoLogin(string[] Login_data)
        {
            return "logging in";
        }

        public string DoRegister(string[] Register_data)
        {
            return "register";
        }

        public JArray GetStyles()
        {
            ApiRequest_setResponse("https://localhost:5002/api/values/table/styles");
            return responseStr;
        }
    }
}
