using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MaShop.Models
{
    public class ValidationModel : IValidationMoel
    {
        string url = "https://localhost:5002/api/values";
        public WebHeaderCollection _webQueryString { get; set; }
        IApiRequestModel apiReq = new ApiRequestModel();

        public string name { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string password { get; set; }

        public ValidationModel()
        {
        }
        public bool ValidateLogin(JArray responseStr)
        {

            _webQueryString = new WebHeaderCollection() { };
            _webQueryString.Add("tableName", "login");
            _webQueryString.Add("password", this.password);
            _webQueryString.Add("email", this.email);

            JArray responJArray = apiReq.ApiPost(url, _webQueryString);
            dynamic responseListObj = responJArray.OfType<JObject>().ToList();

            string emailAddress_from_db = responseListObj[0]["email"];
            string type_from_db = responseListObj[0]["type"];

            if (emailAddress_from_db == email && type_from_db != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ValidateRegistration(JArray responseStr)
        {
            //check for null... if all not null return true
            //else false

            if (this.name !=null && this.phonenumber !=null && this.password !=null && this.email !=null) {
                _webQueryString = new WebHeaderCollection() { };
                _webQueryString.Add("process", "register");
                _webQueryString.Add("name", this.name);
                _webQueryString.Add("phonenumber", this.phonenumber);
                _webQueryString.Add("password", this.password);
                _webQueryString.Add("email", this.email);

                JArray responJArray = apiReq.ApiPost(url, _webQueryString);
                var responseListObj = responJArray.OfType<JObject>().ToList();

                if (responseListObj[0] != null)
                    return true;
                else
                    return false;
            }else {
                return false;
            }
        }
    }
}
