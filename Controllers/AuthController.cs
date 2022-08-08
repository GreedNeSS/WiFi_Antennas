using Microsoft.AspNetCore.Mvc;
using System;
using WiFi_Antennas_Win.Models;

namespace WiFi_Antennas_Win.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            return View();
        }

        public IActionResult Logout()
        {

            throw new NotImplementedException();
        }
    }
}
