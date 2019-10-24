using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MaxShopApi.models
{
    internal class BookingModel
    {
        private SqlConnectionModel SqlConnModel;
        private StyleModel styles;
        private JArray rows;
        public JArray stylesArray { get; set; }

        public BookingModel()
        {
            SqlConnModel = new SqlConnectionModel();
            styles = new StyleModel();
            this.rows = new JArray();
        }

        internal void setBooking(string sql_query)
        {
            //execute sql query
            SqlConnModel.setData(sql_query);
            MySqlDataReader reader = SqlConnModel.getData();

            if (reader.HasRows)
            {
                int n= 1;

                //if query results are returned... build a Json array for the results
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                    int _styleid = reader.GetInt32(reader.GetOrdinal("style_id"));
                    string start = reader.GetDateTime(reader.GetOrdinal("start")).ToString("yyyy-MM-dd HH:mm:ss");
                    String end = reader.GetDateTime(reader.GetOrdinal("end")).ToString("yyyy-MM-dd HH:mm:ss");

                    //get style name by id

                    dynamic responseListObj = this.stylesArray.OfType<JObject>().ToList();
                    int styleID = _styleid - 1;
                    string styleName = responseListObj[styleID]["name"];

                    //"[{\"id\":\"5\",\"text\":\"Germen Cut\",\"start\":\"2019-10-18T10:30:00\",\"end\":\"2019-10-18T11:30:00\"}]"
                    var columns = new JObject();
                    columns["id"] = n;
                    columns["text"] = styleName;
                    columns["start"] = start.Replace(" ","T");
                    columns["end"] = end.Replace(" ","T");

                    this.rows.Add(columns);
                    n++;
                }
            }
        }

        public string insertBooking(string userid, string styleid,string date, string time )
        {
            /*
             * try to build start datetime and end datetime
             * build query to indsert to booking table
             * exercute query an get response as string to return to requester
             */

            try
            {
                string endtime = time.Replace("00", "30");
                string start = date + "T" + time + ":00";
                string end = date + "T" + endtime + ":00";
                string sql_query = "INSERT INTO booking(user_id,style_id,start,end,total_price) VALUES( "+userid+", "+styleid+", '"+start+"', '"+end+"',55)";

                SqlConnModel.insertData(sql_query);

                return "success";
            }
            catch (Exception e)
            {
                return e.ToString();//refactor to null or error message
            }
        }

        internal JArray getBooking()
        {
            return rows;//return JSon array to request
        }
    }
}