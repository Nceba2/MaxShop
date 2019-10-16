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
        private JArray rows;

        public BookingModel()
        {
            SqlConnModel = new SqlConnectionModel();
            this.rows = new JArray();
        }
        internal void setBooking(string sql_query)
        {
            SqlConnModel.setData(sql_query);
            MySqlDataReader reader = SqlConnModel.getData();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                    String name = reader.GetString(reader.GetOrdinal("name"));
                    String email = reader.GetString(reader.GetOrdinal("details"));
                    int price = reader.GetInt32(reader.GetOrdinal("price"));
                    String image = reader.GetString(reader.GetOrdinal("image"));

                    var columns = new JObject();
                    columns["id"] = id.ToString();
                    columns["name"] = name;
                    columns["email"] = email;
                    columns["price"] = price;
                    columns["image"] = image;

                    this.rows.Add(columns);
                }
            }
        }

        public string insertBooking(string sql_query)
        {
            try
            {
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
            return rows;
        }
    }
}