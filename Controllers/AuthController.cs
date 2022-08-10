using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using WiFi_Antennas_Win.Models;

namespace WiFi_Antennas_Win.Controllers
{
    public class AuthController : Controller
    {
        private ApplicationContext db;

        public AuthController(ApplicationContext context)
        {
            db = context;

            if (!db.Users.Any())
            {
                List<User> users = new List<User>
                {
                    new User(){Id = 1, Login = "GreeD", Password = "123456tl"},
                    new User(){Id = 2, Login = "Roman", Password = "123456tl"},
                    new User(){Id = 3, Login = "Leha", Password = "123456tl"},
                };

                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User? user)
        {
            if (user != null)
            {
                User? userDb = db.Users.FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password);
                if (userDb is null)
                {
                    return View(user);
                }
                else
                {
                    var claims = new List<Claim> { new(ClaimTypes.Name, userDb.Login!) };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    Response.Redirect("/home/index");
                    return SignIn(claimsPrincipal);
                }
                
            }
            return View(user);
        }

        public IActionResult Logout()
        {
            Response.Redirect("/auth/login");
            return SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
