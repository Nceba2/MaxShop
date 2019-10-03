using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MaxShopApi.models
{
    public class userModel
    {
        private SqlConnectionModel SqlConnModel;
        private JArray rows;

        public userModel()
        {
            SqlConnModel = new SqlConnectionModel();
            this.rows = new JArray();
        }
        public void setUsers(string sql_query)
        {
            SqlConnModel.setData(sql_query);
            MySqlDataReader reader = SqlConnModel.getData();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                    String name = reader.GetString(reader.GetOrdinal("name"));
                    String email = reader.GetString(reader.GetOrdinal("email"));
                    String cellnumber = reader.GetString(reader.GetOrdinal("cellnumber"));
                    String profile_pic = reader.GetString(reader.GetOrdinal("profile_pic"));
                    String type = reader.GetString(reader.GetOrdinal("type"));

                    var columns = new JObject();
                    columns["id"] = id.ToString();
                    columns["name"] = name;
                    columns["email"] = email;
                    columns["cellnumber"] = cellnumber;
                    columns["profile_pic"] = profile_pic;
                    columns["type"] = type;


                    this.rows.Add(columns);
                }
            }
        }
        public JArray getUsers()
        {
            return rows;
        }
    }
}
