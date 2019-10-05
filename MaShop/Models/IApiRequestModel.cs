using System.Net;
using Newtonsoft.Json.Linq;

namespace MaShop.Models
{
    public interface IApiRequestModel
    {
        JArray ApiPost(string url, WebHeaderCollection wbString);
        JArray ApiGet(string url);
    }
}