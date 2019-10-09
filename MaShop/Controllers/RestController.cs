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
        public string name { get; set; }
        public string phonenumber { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        IApiRequestModel apiReq = new ApiRequestModel();
        IValidationMoel validation = new ValidationModel();

        public RestController()
        {
        }

        public JArray GetStyles()
        {
            this.responseStr = apiReq.ApiGet(url + "/table/styles");
            return responseStr;
        }

        public bool DoLogin()
        {
            validation.email = this.email;
            validation.password = this.password;
            bool validationBool = validation.ValidateLogin(responseStr);

            return validationBool;
        }

        public bool DoRegister()
        {
            validation.name = this.name;
            validation.phonenumber = this.phonenumber;
            validation.email = this.email;
            validation.password = this.password;

            bool validationBool = validation.ValidateRegistration(responseStr);
            
            return validationBool;
        }

        public string DoBooking()
        {
            return "booking";
        }

    }
}
