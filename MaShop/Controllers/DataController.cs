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
    public class DataController : IDataController
    {
        public WebHeaderCollection _webQueryString { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
        public string email { get; set; }

        public string _date { get; set; }
        public string _time { get; set; }
        public string _userId { get; set; }
        public string _styleId { get; set; }

        private IApiRequestModel apiReq;
        private IValidationMoel validation;
        private IBookerModel bookerModel;

        private string url;
        private bool validationBool;
        private JArray responseStr { get; set; }

        public DataController()
        {
             this.url = "https://localhost:5002/api/values";
             this.apiReq = new ApiRequestModel();
             this.validation = new ValidationModel();
            this.bookerModel = new BookerModel();
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

            this.validationBool = validation.ValidateLogin(responseStr);

            return validationBool;
        }

        public bool DoRegister()
        {
            if (this.confirm_password == this.phonenumber)
            {
                validation.name = this.name;
                validation.phonenumber = this.phonenumber;
                validation.email = this.email;
                validation.password = this.password;

                this.validationBool = validation.ValidateRegistration(responseStr);
            }
            else
            {
                this.validationBool = false;
            }
            return validationBool;
        }

        public string DoBooking()
        {
            bookerModel.date = _date;
            bookerModel.time = _time;
            bookerModel.user_id = _userId;
            bookerModel.style_id = _styleId;

            return bookerModel.AddEvent();
        }

        public string GetBookings()
        {
            this.responseStr = apiReq.ApiGet(url + "/table/bookings");
            return responseStr.ToString();
        }
    }
}
