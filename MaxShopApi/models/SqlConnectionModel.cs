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
            con = new MySqlConnection(configuration.GetSection("ConnectionStrings").GetSection("DefualtConnection").Value);
            con.Open();
        }

        public void setData(String query)
        {
            MySqlCommand command = new MySqlCommand(query, con);
            this.reader = command.ExecuteReader();
        }

        public MySqlDataReader getData()
        {
            return reader;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

    }

}