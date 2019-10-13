using Newtonsoft.Json.Linq;

namespace MaxShopApi.Controllers
{
    public interface ITablesController
    {
        string tableName { get; set; }

        string date { get; set; }
        string time { get; set; }
        string userid { get; set; }
        string styleid { get; set; }

        void setCredentials(string userpassword, string emailaddress);
        void setTable();
        JArray getTable();
    }
}