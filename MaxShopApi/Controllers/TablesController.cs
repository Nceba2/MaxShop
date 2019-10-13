using System;
using MaxShopApi.models;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace MaxShopApi.Controllers
{
    public class TablesController: ITablesController
    {
        public string tableName { get; set; }

        private userModel users;
        private StyleModel styles;
        private BookingModel booking;

        private string email;
        private string password;
        private JArray _tableData;

        public string date { get; set; }
        public string time { get; set; }
        public string userid { get; set; }
        public string styleid { get; set; }

        public TablesController()
        {
            users = new userModel();
            styles = new StyleModel();
            booking = new BookingModel();
        }
        public void setCredentials(string userpassword, string emailaddress)
        {
            this.email = emailaddress;
            this.password = userpassword;
        }

        public void setTable()
        {
            switch (tableName)
            {
                case "users":
                    users.setUsers("SELECT * FROM user");
                    this._tableData = users.getUsers();
                    break;
                case "login":
                    users.setUsers("SELECT * FROM `user` WHERE password='"+password+"' AND email='"+email+"'");
                    this._tableData = users.getUsers();
                    break;

                case "styles":
                    styles.setStyles("SELECT * FROM styles");
                    this._tableData = styles.getStyles();
                    break;

                case "order":
                    booking.setBooking("SELECT * FROM booking");
                    this._tableData = booking.getBooking();
                    break;

                case "bookings":
                    //booking.setBooking("SELECT * FROM booking");
                    this._tableData =JArray.Parse("[{\"id\":\"5\",\"text\":\"Germen Cut\",\"start\":\"2019-10-18T10:30:00\",\"end\":\"2019-10-18T11:30:00\"}]"); 
                    break;

                case "book":
                    //insert values to database table
                    //booking.setBooking("SELECT * FROM booking");
                    this._tableData = JArray.Parse("[{\"response\":\"booked\"}]");
                    break;
                default:
                    this._tableData = null;
                    break;
            }
        }

        public JArray getTable()
        {
            return _tableData;
        }
    }
}
