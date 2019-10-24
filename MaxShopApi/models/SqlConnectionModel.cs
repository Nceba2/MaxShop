using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MaxShopApi.models
{
    public class SqlConnectionModel
    {
        private MySqlConnection con;
        private MySqlDataReader reader;

        public SqlConnectionModel()
        {
            var configuration = GetConfiguration();
            this.con = new MySqlConnection(configuration.GetSection("ConnectionStrings").GetSection("DefualtConnection").Value);
        }

        public void setData(String query)
        {
            if(con.State != ConnectionState.Open)
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                this.reader = command.ExecuteReader();
            }
            else
            {
                ConCloseAndDespose(query);
            }
        }

        public void insertData(string query)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                using (con)
                {
                    var comm = con.CreateCommand();
                    comm.CommandText = query;
                    comm.ExecuteNonQuery();
                }
            }
            else
            {
                ConCloseAndDespose(query);
            }
        }

        public MySqlDataReader getData()
        {
            return reader;
        }
        public void ConCloseAndDespose(string query)
        {
            MySqlCommand command = new MySqlCommand(query, con);
            command.Dispose();
            con.Close();
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

    }

}