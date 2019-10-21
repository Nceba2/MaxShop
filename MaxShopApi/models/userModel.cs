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
        private bool existance;

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

        public string RegisterUser(string sql_query)
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
        public void CheckUserExist(string email)
        {
            string sql_query = "SELECT * FROM user WHERE email='" + email + "'";
            SqlConnModel.setData(sql_query);
            MySqlDataReader reader = SqlConnModel.getData();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (email == reader.GetString(reader.GetOrdinal("email")))
                    {
                        this.existance = true;//user already exists
                    }
                    else
                    {
                        this.existance = false;
                    }
                }
            }
        }

        public bool getExistance()
        {
            return existance;
        }

        public JArray getUsers()
        {
            return rows;
        }
    }
}
