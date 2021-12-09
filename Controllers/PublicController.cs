using System;
using launchPad.Models;
using Microsoft.AspNetCore.Mvc;

namespace launchPad {

    public class PublicController : Controller {

        private LinkManager linkManager;
        public PublicController(LinkManager myManager) {
            linkManager = myManager;
        }

        public IActionResult Index() {
            return View(linkManager);            
        }

        public IActionResult Login() {
            return View(linkManager);            
        }


    }
}
