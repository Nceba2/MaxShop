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
                    //string[] columns;

                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                    String name = reader.GetString(reader.GetOrdinal("name"));
                    String email = reader.GetString(reader.GetOrdinal("email"));
                    String password = reader.GetString(reader.GetOrdinal("password"));

                    //columns = new string[] { id.ToString(), name, email, password };

                    var columns = new JObject();
                    columns["id"] = id.ToString();
                    columns["name"] = name;
                    columns["email"] = email;
                    columns["password"] = password;

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
