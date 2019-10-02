using System;
using MaxShopApi.models;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace MaxShopApi.Controllers
{
    public class TablesController
    {

        private userModel users;
        private StyleModel styles;
        private BookingModel booking;

        private JArray _tableData;

        public TablesController()
        {
            users = new userModel();
            styles = new StyleModel();
            booking = new BookingModel();
        }

        public void setTable(string tableName)
        {
            switch (tableName)
            {
                case "users":
                    users.setUsers("SELECT * FROM user");
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
