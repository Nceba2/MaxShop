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
                    //string[] columns;

                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                    String name = reader.GetString(reader.GetOrdinal("name"));
                    String email = reader.GetString(reader.GetOrdinal("details"));
                    int price = reader.GetInt32(reader.GetOrdinal("price"));
                    String image = reader.GetString(reader.GetOrdinal("image"));

                    //columns = new string[] { id.ToString(), name, email, price.ToString(), image };


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

        internal JArray getBooking()
        {
            return rows;
        }
    }
}