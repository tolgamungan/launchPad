using System;
using Microsoft.AspNetCore.Mvc;
using launchPad.Models;
using Microsoft.AspNetCore.Http;


namespace launchPad.Controllers {

    public class LoginController : Controller {

        public IActionResult Login() {
            return View();
        }

        public IActionResult Submit(string myUsername, string myPassword) {
            // construct WebLogin object and set properties
            WebLogin webLogin = new WebLogin(Connection.CONNECTION_STRING, HttpContext);
            webLogin.username = myUsername;
            webLogin.password = myPassword;
            // attempt to login!
            if (webLogin.unlock()) {
                return RedirectToAction("Index", "Admin");
            } else {
                ViewData["feedback"] = "Incorrect login. Please try again...";
            }
            return View("Login");
        }

    }
}
