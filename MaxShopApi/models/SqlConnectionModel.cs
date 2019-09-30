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
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            this.reader = command.ExecuteReader();
            //command.Dispose();
        }

        public MySqlDataReader getData()
        {
            //con.Close();
            return reader;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

    }

}