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
            ViewData["Title"] = "������ ��������";
            return View();
        }

        

        public IActionResult Dashboard()
        {
            ViewData["Title"] = "���� ������";
            return View();
        }

        public IActionResult Map()
        {
            ViewData["Title"] = "����� ������";
            return View();
        }

        public IActionResult about()
        {
            ViewData["Title"] = "��������";
            return View();
        }

        public IActionResult Blog()
        {
            ViewData["Title"] = "�������";
            return View();
        }
    }
}