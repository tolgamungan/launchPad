using System;
using launchPad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace launchPad {

    public class AdminController : Controller {

        private LinkManager linkManager;
        public AdminController(LinkManager myManager) { linkManager = myManager; }
        public IActionResult Index() {
            // check if the user is logged in - if not redirect to the public index
            if (HttpContext.Session.GetString("auth") != "true") return RedirectToAction("Index","Public");
            return View(linkManager);
        }
        public IActionResult AddLink(string categoryName, int categoryID) {
            if (HttpContext.Session.GetString("auth") != "true") return RedirectToAction("Index","Public");
            Link link = new Link();
            Category category = new Category();
            category.categoryID=categoryID;
            category.categoryName=categoryName;
            ViewBag.category = category; // To display category in view
            TempData["tempCategoryID"] = category.categoryID; // To pass categoryID between controllers
            return View(link);            
        }
        [HttpPost]
        public IActionResult AddSubmit(Link link) {
            if (HttpContext.Session.GetString("auth") != "true") return RedirectToAction("Index","Public");
            if (!ModelState.IsValid) {
            ViewData["feedback"] = "Incorrect input. Please try again...";}
            link.categoryID = Convert.ToInt32(TempData["tempCategoryID"]);
            linkManager.Add(link);
            linkManager.SaveChanges();
            return RedirectToAction("index");          
        }

        public IActionResult DeleteLink(Link link, int linkID) {
            if (HttpContext.Session.GetString("auth") != "true") return RedirectToAction("Index","Public");
            link = linkManager.getLinkByID(linkID);
            TempData["linkID"] = linkID;
            return View(link);            
        }
        [HttpPost]
         public IActionResult DeleteLinkSubmit(Link link) {
            if (HttpContext.Session.GetString("auth") != "true") return RedirectToAction("Index","Public");
            link.linkID = Convert.ToInt32(TempData["linkID"]);
            linkManager.Remove(link);
            linkManager.SaveChanges();
            return RedirectToAction("index"); 
        }

        public IActionResult EditCategory(Category category, int categoryID) {
            if (HttpContext.Session.GetString("auth") != "true") return RedirectToAction("Index","Public");
            category = linkManager.getCategoryByID(categoryID);
            ViewBag.category = category; // To display category in view
            TempData["categoryID"] = categoryID;
            return View();            
        }
        [HttpPost]
        public IActionResult EditCategorySubmit(Category category) {         
            if (HttpContext.Session.GetString("auth") != "true") return RedirectToAction("Index","Public");
            category.categoryID = Convert.ToInt32(TempData["categoryID"]);
            linkManager.Update(category);
            linkManager.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult EditLink(Category category, int categoryID, int linkID) {
            if (HttpContext.Session.GetString("auth") != "true") return RedirectToAction("Index","Public");
            Link link = new Link();
            link = linkManager.getLinkByID(linkID);
            category = linkManager.getCategoryByID(categoryID);
            ViewBag.category = category; // To display category in view
            ViewBag.categoryList = linkManager.getCategoryList();
            TempData["tempLinkID"] = link.linkID; // To pass linkID between controllers
            TempData["finalCategoryID"] = categoryID;
            return View(link);            
        }

        [HttpPost]
        // update the category of selected link by a dropdown
        public IActionResult EditLinkUpdateCategory( Category category, int linkID) {
            if (HttpContext.Session.GetString("auth") != "true") return RedirectToAction("Index","Public");
            Link link = new Link();
            link = linkManager.getLinkByID(linkID);
            TempData["tempLinkID"] = linkID; 
            Category selectedCategory = linkManager.getCategoryByID(category.categoryID);
            ViewBag.categoryList = linkManager.getCategoryList();
            TempData["finalCategoryID"] = selectedCategory.categoryID;
            return View("EditLink",link);            
        }
        
        [HttpPost]
         public IActionResult EditLinkSubmit(Link link) {
             if (HttpContext.Session.GetString("auth") != "true") return RedirectToAction("Index","Public");
            if (!ModelState.IsValid) {
            ViewData["feedback"] = "Incorrect input. Please try again...";}
            link.linkID = Convert.ToInt32(TempData["tempLinkID"]);
            link.categoryID = Convert.ToInt32(TempData["finalCategoryID"]);
            linkManager.Update(link);
            linkManager.SaveChanges();
            return RedirectToAction("index");          
        }




    }
}
