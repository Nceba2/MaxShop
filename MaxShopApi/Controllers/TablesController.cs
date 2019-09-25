using System;
using MaxShopApi.models;
using System.Collections.Generic;

namespace MaxShopApi.Controllers
{
    public class TablesController
    {

        private userModel users;
        private StyleModel styles;
        private BookingModel booking;
        List<string[]> _tableData;

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
            }
        }

        public List<string[]> getTable()
        {
            return _tableData;
        }
    }
}
