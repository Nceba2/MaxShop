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
        TablesController tables = new TablesController();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/table/styles
        [HttpGet("table/{tablename}")]
        public JArray Get(string tableName)
        {
            tables.setTable(tableName);
            return tables.getTable();
        }

        //the following get method is for logging in
        // GET api/values/table/styles
        [HttpGet("table/{tableName}/{password}/{email}")]
        public JArray Get(string tableName,string password,string email)
        {
            tables.setCredentials(password,email);
            tables.setTable(tableName);
            return tables.getTable();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
