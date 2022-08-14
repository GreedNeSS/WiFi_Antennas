using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WiFi_Antennas_Win.BLL.DTO;
using WiFi_Antennas_Win.BLL.Interfaces;

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
        public IActionResult Login(UserDTO? user, [FromServices] IAccessUserService accessUserService,
            [FromServices] ITokenCreator tokenCreator)
        {
            if (user != null)
            {
                if (!accessUserService.IsAllowed(user))
                {
                    return View(user);
                }
                else
                {
                    
                    Response.Redirect("/home/index");
                    return SignIn(tokenCreator.GetClaimsPrincipal(user));
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
