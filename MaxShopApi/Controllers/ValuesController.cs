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
            tables.tableName = tableName;
            tables.setTable();
            return tables.getTable();
        }

        //the following method is for logging in
        // POST api/values
        [HttpPost]
        public JArray Post([FromHeader] string tableName, [FromHeader] string password, [FromHeader] string email)
        {
            tables.setCredentials(password, email);
            tables.tableName = tableName;
            tables.setTable();
            return tables.getTable();
        }
        [HttpPost("book")]
        public JArray Post([FromHeader] string tableName, [FromHeader] string date, [FromHeader] string time,[FromHeader] string style_id, [FromHeader] string user_id)
        {
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
