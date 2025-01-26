using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_EcoTrack.Models;


namespace Web_EcoTrack.Controllers
{
    public class HomeController : Controller
    {
        // ⁄—÷ ’›Õ…  ”ÃÌ· «·œŒÊ·
        public IActionResult Login()
        {
            ViewData["Title"] = " ”ÃÌ· «·œŒÊ·";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            //  Õﬁﬁ »”Ìÿ («” »œ·Â »„’œ— »Ì«‰«  ›⁄·Ì)
            if (username == "admin" && password == "12345")
            {
                TempData["SuccessMessage"] = " „  ”ÃÌ· «·œŒÊ· »‰Ã«Õ!";
                return RedirectToAction("Dashboard");
            }

            ViewBag.ErrorMessage = "«”„ «·„” Œœ„ √Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ….";
            return View();
        }

        // ⁄—÷ ’›Õ… ≈‰‘«¡ «·Õ”«»
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                // Ì„ﬂ‰ﬂ  Œ“Ì‰ »Ì«‰«  «·„” Œœ„ Â‰« ›Ì ﬁ«⁄œ… «·»Ì«‰« 
                ViewBag.SuccessMessage = " „ ≈‰‘«¡ «·Õ”«» »‰Ã«Õ! Ì„ﬂ‰ﬂ  ”ÃÌ· «·œŒÊ· «·¬‰.";
                return View();
            }

            ViewBag.ErrorMessage = "Ì—ÃÏ «· Õﬁﬁ „‰ «·»Ì«‰«  «·„œŒ·….";
            return View(model);
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "«·’›Õ… «·—∆Ì”Ì…";
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewData["Title"] = "·ÊÕ… «· Õﬂ„";
            return View();
        }

        public IActionResult Map()
        {
            ViewData["Title"] = "Œ—Ìÿ… «· ’Õ—";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "«·Œ’Ê’Ì…";
            return View();
        }

        public IActionResult Logout()
        {
            TempData["SuccessMessage"] = " „  ”ÃÌ· «·Œ—ÊÃ »‰Ã«Õ.";
            return RedirectToAction("Login");
        }
    }
}
