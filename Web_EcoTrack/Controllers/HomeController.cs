using Microsoft.AspNetCore.Mvc;
using Web_EcoTrack.Models;

namespace Web_EcoTrack.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Account()
        {
            return View();
        }
        public IActionResult testpage()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
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

        public IActionResult about()
        {
            ViewData["Title"] = "«·Œ’Ê’Ì…";
            return View();
        }

        public IActionResult Blog()
        {
            ViewData["Title"] = "«·„œÊ‰…";
            return View();
        }
    }
}