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
        IProccessController process = new ProccessController();

        // GET api/values
        [HttpGet]
        public JArray Get()
        {
            process.processName = "styles";
            process.setProccess();
            return process.getFeedback();
        }

        // GET api/values/table/styles
        [HttpGet("table/{tablename}")]
        public JArray Get(string _processName)
        {
            /*
             * the method requests information to required models
             * the model then retrive the require information from the database and return feedback
             * tableName is then used be the switch satement to call specific processes done by models
             * tableName = styles would get a model that will retrive styles from the database
             * setTable would set the information, prepare it as JArray for retreval.
             * getTable() would provide the information as a JAarray
             */
            process.processName = _processName;
            process.setProccess();
            return process.getFeedback();
        }

        //the following method is for logging in
        // POST api/values
        [HttpPost]
        public JArray Post([FromHeader] string _processName, [FromHeader] string password, [FromHeader] string email)
        {
            /*
             * the method posts credentials to required models
             * the models then checks for the existance of the user on database and return feedback
             */
            process.setCredentials(password, email);
            process.processName = _processName;
            process.setProccess();
            return process.getFeedback();
        }

        //for regitering a user
        [HttpPost("register")]
        public JArray Register([FromHeader] string _processName, [FromHeader] string name, [FromHeader] string password, [FromHeader] string email,[FromHeader] string phonenumber)
        {
            process._Name = name;
            process.email = email;
            process.password = password;
            process.phonenumber = phonenumber;

            process.processName = _processName;
            process.setProccess();
            return process.getFeedback();
        }

        //for booking a haircut
        [HttpPost("book")]
        public JArray Post([FromHeader] string _processName, [FromHeader] string date, [FromHeader] string time,[FromHeader] string style_id, [FromHeader] string user_id)
        {
            /*
             * the method posts information to required models
             * the models then insert to the database and return feedback
             */
            process.date = date;
            process.time = time;
            process.userid = user_id;
            process.styleid = style_id;

            process.processName = _processName;
            process.setProccess();
            return process.getFeedback();
        }

        [HttpGet("pulse")]
        public string pulse([FromHeader] string check)
        {
            return "pusle says check= " + check;
        }
    }
}
