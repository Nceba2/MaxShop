using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace MaShop.Models
{
    public class ApiRequestModel: IApiRequestModel
    {

        JArray responseStr { get; set; }

        public ApiRequestModel()
        {
        }

        public JArray ApiGet(string url)
        {
            using (var wb = new WebClient())
            {
                this.responseStr = JArray.Parse(wb.DownloadString(url));
            }
            return responseStr;
        }

        public JArray ApiPost(string url, WebHeaderCollection wbString)
        {
            string resp;
            using (var wb = new WebClient())
            {
                wb.Headers = wbString;

                byte[] data = wb.UploadData(url, "POST", Encoding.Default.GetBytes("{\"test\": \"none\"}"));
                resp = Encoding.ASCII.GetString(data);
            }
            this.responseStr = JArray.Parse(resp);

            return responseStr;
        }

    }
}
