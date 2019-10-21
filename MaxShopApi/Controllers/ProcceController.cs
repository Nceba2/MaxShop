using System;
using MaxShopApi.models;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace MaxShopApi.Controllers
{
    public class ProccessController : IProccessController
    {
        public string processName { get; set; }

        private userModel users;
        private StyleModel styles;
        private BookingModel booking;
        private string response {get; set;}

        //for login regidtration
        //public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        private JArray feedback_JArray;
        public string phonenumber { get; set; }
        public string _Name { get; set; }

        //for booking
        public string date { get; set; }
        public string time { get; set; }
        public string userid { get; set; }
        public string styleid { get; set; }


        public ProccessController()
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

        public void setProccess()
        {
            switch (processName)
            {
                case "users":
                    users.setUsers("SELECT * FROM user");
                    this.feedback_JArray = users.getUsers();
                    break;

                case "check_users_existance":
                    /*
                     * the 
                     */
                    users.CheckUserExist(email);
                    this.feedback_JArray = JArray.Parse("[{\"exist\":\""+users.getExistance()+"\"}]");
                    break;

                case "login":
                    users.setUsers("SELECT * FROM `user` WHERE password='"+password+"' AND email='"+email+"'");
                    this.feedback_JArray = users.getUsers();

                    /*
                     * if user exist session contoller check if session already created
                     * if session does not contain user append user to a session using sessionModel
                     * else do nothing
                     */
                    break;

                case "register":
                    if (users.getExistance() == false)
                        response = users.RegisterUser("SELECT * FROM booking");//refactor to be insert statement
                    this.feedback_JArray = JArray.Parse("[{\"response\":\"registered " + response + "\"}]");
                    else
                        this.feedback_JArray = JArray.Parse("[{\"response\":\"user already exists\"}]");
                    break;

                case "styles":
                    styles.setStyles("SELECT * FROM styles");
                    this.feedback_JArray = styles.getStyles();
                    break;

                case "bookings":
                    //booking.setBooking("SELECT * FROM booking");
                    //fix values to mach required JSON format:
                    //"[{\"id\":\"5\",\"text\":\"Germen Cut\",\"start\":\"2019-10-18T10:30:00\",\"end\":\"2019-10-18T11:30:00\"}]"
                    this.feedback_JArray = JArray.Parse("[{\"id\":\"5\",\"text\":\"Germen Cut\",\"start\":\"2019-10-18T10:30:00\",\"end\":\"2019-10-18T11:30:00\"}]"); 
                    break;

                case "book":
                    //insert values to database table
                    users.CheckUserExist(email);

                    if (users.getExistance() == false)
                        response = booking.insertBooking(userid, styleid, date, time);
                    else
                        response = "user already exists";
                    this.feedback_JArray = JArray.Parse("[{\"response\":\"booked "+response+"\"}]");
                    break;

                default:
                    this.feedback_JArray = null;
                    break;
            }
        }

        public JArray getFeedback()
        {
            return feedback_JArray;
        }
    }
}
