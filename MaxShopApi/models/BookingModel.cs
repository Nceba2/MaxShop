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
        private StyleModel styleModel;
        private JArray rows;

        public BookingModel()
        {
            SqlConnModel = new SqlConnectionModel();
            styleModel = new StyleModel();
            this.rows = new JArray();
        }
        internal void setBooking(string sql_query)
        {
            //execute sql query
            SqlConnModel.setData(sql_query);
            MySqlDataReader reader = SqlConnModel.getData();

            if (reader.HasRows)
            {
                //if query results are returned... build a Json array for the results
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                    String _styleid = reader.GetString(reader.GetOrdinal("style_id"));
                    string start = reader.GetString(reader.GetOrdinal("start"));
                    String end = reader.GetString(reader.GetOrdinal("end"));

                    //get style name by id
                    styleModel.setStyles("SELECT name FROM styles WHERE id=\""+_styleid+"\"");
                    dynamic responseListObj = styleModel.getStyles().OfType<JObject>().ToList();
                    string styleName = responseListObj[0]["name"];

                    //fix values to mach required JSON format:
                    //"[{\"id\":\"5\",\"text\":\"Germen Cut\",\"start\":\"2019-10-18T10:30:00\",\"end\":\"2019-10-18T11:30:00\"}]"
                    var columns = new JObject();
                    columns["id"] = id.ToString();
                    columns["text"] = styleName;
                    columns["start"] = start;
                    columns["end"] = end;

                    this.rows.Add(columns);
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
                string sql_query = "INSERT(user_id,style_id,start,end,total_price) VALUES(\"" + userid + "\",\"" + styleid + "\",\"" + start + "\",\"" + end + "\",\"R50\") INTO booking";

                SqlConnModel.setData(sql_query);
                MySqlDataReader reader = SqlConnModel.getData();
                string sqlResponse = reader.GetString(reader.ToString());
                return sqlResponse;
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