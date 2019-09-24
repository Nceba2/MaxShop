using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShopApi.models
{
    public class userModel
    {
        private SqlConnectionModel SqlConnModel;
        List<string[]> rows;

        public userModel()
        {
            SqlConnModel = new SqlConnectionModel();
            this.rows = new List<string[]>();
        }
        public void setUsers(string sql_query)
        {
            SqlConnModel.setData(sql_query);
            MySqlDataReader reader = SqlConnModel.getData();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string[] columns;

                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                    String name = reader.GetString(reader.GetOrdinal("name"));
                    String email = reader.GetString(reader.GetOrdinal("email"));
                    String password = reader.GetString(reader.GetOrdinal("password"));

                    columns = new string[] { id.ToString(), name, email, password };

                    this.rows.Add(columns);
                }
            }
        }
        public List<string[]> getUsers()
        {
            return rows;
        }
    }
}
