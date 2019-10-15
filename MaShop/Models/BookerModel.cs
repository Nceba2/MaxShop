using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MaShop.Models
{
    public class BookerModel:IBookerModel
    {
        string url = "https://localhost:5002/api/values";
        public WebHeaderCollection _webQueryString { get; set; }
        IApiRequestModel apiReq = new ApiRequestModel();

        public string date { get; set; }
        public string time { get; set; }
        public string user_id { get; set; }
        public string style_id { get; set; }

        public string AddEvent()
        {
            //pass values to api
            //api to sql query.

            _webQueryString = new WebHeaderCollection() { };
            _webQueryString.Add("tableName", "book");
            _webQueryString.Add("date", this.date);
            _webQueryString.Add("time", this.time);
            _webQueryString.Add("userId", this.user_id);
            _webQueryString.Add("styleId", this.style_id);

            JArray responJArray = apiReq.ApiPost(url, _webQueryString);
            dynamic responseListObj = responJArray.OfType<JObject>().ToList();

            string reponseStr = responseListObj[0]["response"];

            return reponseStr+" for hair cut";
        }

        public string DeleteEvent()
        {
            //pass values to api
            //api to sql query. 
            return null;
        }

        public string UpdateEvent()
        {
            //pass values to api
            //api to sql query. 
            return null;
        }
    }
}
