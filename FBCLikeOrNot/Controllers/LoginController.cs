using FBCLikeOrNot.Models;
//using FBCLikeOrNot.Models.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginAccessViewModel _User)
        //{

        //    using (var _context = new db_a87bdd_fbcContext())
        //    {
        //        //string query = "SELECT * FROM adm.Users";
        //        //var _UserLogged = _context.LikeUsers.Where(UserSelect => UserSelect.Employeenumberuser == _User.user && UserSelect.Lastnameuser == _User.password).FirstOrDefault();

        //        if ((_User.Username == "101673" && _User.Password == "08091996"))
        //        {
        //            var claims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, _User.Username)
        //            };

        //            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

        //            return RedirectToAction("Dashboard", "Admin");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "Login");
        //        }
        //    }
        //}

        public async Task<IActionResult> CloseSession()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
