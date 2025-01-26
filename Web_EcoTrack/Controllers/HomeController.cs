using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_EcoTrack.Models;


namespace Web_EcoTrack.Controllers
{
    public class HomeController : Controller
    {
        // ��� ���� ����� ������
        public IActionResult Login()
        {
            ViewData["Title"] = "����� ������";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // ���� ���� (������� ����� ������ ����)
            if (username == "admin" && password == "12345")
            {
                TempData["SuccessMessage"] = "�� ����� ������ �����!";
                return RedirectToAction("Dashboard");
            }

            ViewBag.ErrorMessage = "��� �������� �� ���� ������ ��� �����.";
            return View();
        }

        // ��� ���� ����� ������
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                // ����� ����� ������ �������� ��� �� ����� ��������
                ViewBag.SuccessMessage = "�� ����� ������ �����! ����� ����� ������ ����.";
                return View();
            }

            ViewBag.ErrorMessage = "���� ������ �� �������� �������.";
            return View(model);
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

        public IActionResult Privacy()
        {
            ViewData["Title"] = "��������";
            return View();
        }

        public IActionResult Logout()
        {
            TempData["SuccessMessage"] = "�� ����� ������ �����.";
            return RedirectToAction("Login");
        }
    }
}
