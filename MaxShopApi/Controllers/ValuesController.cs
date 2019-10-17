using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaxShopApi.models;

namespace MaxShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ITablesController tables = new TablesController();

        // GET api/values
        [HttpGet]
        public JArray Get()
        {
            tables.tableName = "styles";
            tables.setTable();
            return tables.getTable();
        }

        // GET api/values/table/styles
        [HttpGet("table/{tablename}")]
        public JArray Get(string tableName)
        {
            /*
             * the method requests information to required models
             * the model then retrive the require information from the database and return feedback
             * tableName is then used be the switch satement to call specific processes done by models
             * tableName = styles would get a model that will retrive styles from the database
             * setTable would set the information, prepare it as JArray for retreval.
             * getTable() would provide the information as a JAarray
             */
            tables.tableName = tableName;
            tables.setTable();
            return tables.getTable();
        }

        //the following method is for logging in
        // POST api/values
        [HttpPost]
        public JArray Post([FromHeader] string tableName, [FromHeader] string password, [FromHeader] string email)
        {
            /*
             * the method posts credentials to required models
             * the models then checks for the existance of the user on database and return feedback
             */
            tables.setCredentials(password, email);
            tables.tableName = tableName;
            tables.setTable();
            return tables.getTable();
        }

        //for regitering a user
        [HttpPost("Register")]
        public JArray Post([FromHeader] string tableName,[FromHeader] string name, [FromHeader] string password, [FromHeader] string email,[FromHeader] string phonenumber)
        {
            tables.name = name;
            tables.email = email;
            tables.password = password;
            tables.phonenumber = phonenumber;

            tables.tableName = tableName;
            tables.setTable();
            return tables.getTable();
        }

        //for booking a haircut
        [HttpPost("book")]
        public JArray Post([FromHeader] string tableName, [FromHeader] string date, [FromHeader] string time,[FromHeader] string style_id, [FromHeader] string user_id)
        {
            /*
             * the method posts information to required models
             * the models then insert to the database and return feedback
             */
            tables.date = date;
            tables.time = time;
            tables.userid = user_id;
            tables.styleid = style_id;

            tables.tableName = tableName;
            tables.setTable();
            return tables.getTable();
        }

    }
}
