﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaShop.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Text;
//using MaxShopApi;

namespace MaShop.Controllers
{
    public class HomeController : Controller
    {
        IDataController RestCtr = new DataController();

        public IActionResult Index()
        {
            /*
             * these values would be from interface
             * the interface would be getting values
             * from the class requesting information from the api
            */
            
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
        public IActionResult Loging_in([FromForm] string email,[FromForm] string password)
        {
            RestCtr.email = email;
            RestCtr.password = password;

            if (RestCtr.DoLogin() == true)
            {
                ViewData["Message"] = "logged";
                return View("Booker");
            }
            else
            {
                ViewData["Message"] = "password or email address invalid";
                return View("Login");
            }

        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Booker()
        {
            //restructure booking table as id|text|start|end|userid|styleid
            //add insert delete view from api

            //ViewData["Message"] += "[{\"id\":\"5\",\"text\":\"Germen Cut\",\"start\":\"2019-10-10T10:30:00\",\"end\":\"2019-10-10T11:30:00\"}]";
            ViewData["Message"] = RestCtr.GetBookings();
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
