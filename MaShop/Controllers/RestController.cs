using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using MaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MaShop.Controllers
{
    public class RestController : IRestController
    {
        string url = "https://localhost:5002/api/values";

        JArray responseStr { get; set; }
        public WebHeaderCollection _webQueryString { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        IApiRequestModel apiReq = new ApiRequestModel();

        public RestController()
        {
        }

        public JArray GetStyles()
        {
            this.responseStr = apiReq.ApiGet(url + "/table/styles");
            return responseStr;
        }

        public List<JObject> DoLogin()
        {
            _webQueryString = new WebHeaderCollection() { };
            _webQueryString.Add("tableName", "login");
            _webQueryString.Add("password", this.password);
            _webQueryString.Add("email", this.email);

            this.responseStr = apiReq.ApiPost(url, _webQueryString);

            return responseStr.OfType<JObject>().ToList();
        }

        public string DoRegister()
        {
            return "register";
        }

        public string DoBooking()
        {
            return "booking";
        }
    }
}
