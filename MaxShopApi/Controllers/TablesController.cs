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

        //for login regidtration
        public string email { get; set; }
        public string password { get; set; }
        private JArray _tableData;
        public string phonenumber { get; set; }
        public string name { get; set; }

        //for booking
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

                    /*
                     * if user exist session contoller check if session already created
                     * if session does not contain user append user to a session using sessionModel
                     * else do nothing
                     */
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
                    //fix values to mach required JSON format:
                    //"[{\"id\":\"5\",\"text\":\"Germen Cut\",\"start\":\"2019-10-18T10:30:00\",\"end\":\"2019-10-18T11:30:00\"}]"
                    this._tableData =JArray.Parse("[{\"id\":\"5\",\"text\":\"Germen Cut\",\"start\":\"2019-10-18T10:30:00\",\"end\":\"2019-10-18T11:30:00\"}]"); 
                    break;

                case "book":
                    //insert values to database table
                    string response = booking.insertBooking("INSERT(user_id,style_id,date,time) VALUE(\""+userid+",\""+styleid+ ",\"" + date + ",\"" + time + ") INTO booking");
                    this._tableData = JArray.Parse("[{\"response\":\"booked "+response+"\"}]");
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
