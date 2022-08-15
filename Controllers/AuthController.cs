using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WiFi_Antennas_Win.BLL.DTO;
using WiFi_Antennas_Win.BLL.Interfaces;
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
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserViewModel userViewModel, [FromServices] IAccessUserService accessUserService,
            [FromServices] ITokenCreator tokenCreator)
        {
            if (userViewModel != null)
            {
                UserDTO user = new UserDTO { Login = userViewModel.Login, Password = userViewModel.Password };

                if (accessUserService.IsAllowed(user))
                {
                    Response.Redirect("/home/index");
                    return SignIn(tokenCreator.GetClaimsPrincipal(user));
                }
                
            }

            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            Response.Redirect("/auth/login");
            return SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
