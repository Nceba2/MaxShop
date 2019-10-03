using System;
using Microsoft.AspNetCore.Mvc;

namespace MaShop.Controllers
{
    public class LoginController: Controller
    {
        public LoginController()
        {
        }

        public IActionResult Loging_in()
        {
            ViewData["Message"] = "loging in..";

            return View("Login");
        }
    }
}
