using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaShop.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
//using MaxShopApi;

namespace MaShop.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            /*
             * these values would be from interface
             * the interface would be getting values
             * from the class requesting information from the api
            */
            IRestController RestCtr = new RestController();

            ViewData["items"] = RestCtr.GetStyles().OfType <JObject> ().ToList();

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Loging_in()
        {
            ViewData["Message"] = "loging in..";

            return View("Login");
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Booker()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
