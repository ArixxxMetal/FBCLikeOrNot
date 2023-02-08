using FBCLikeOrNot.Models;
using FBCLikeOrNot.Models.DB;
using FBCLikeOrNot.Models.ParameterViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FBCLikeOrNot.Controllers
{
    public class LoginController : Controller
    {
        private Models.DB.db_a87bdd_fbcContext _context;

        public LoginController(Models.DB.db_a87bdd_fbcContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAccessViewModel _User)
        {
            try
            {
                var employeenumberParam = new SqlParameter("@PARAM_EMP_NUM", _User.Username);
                var employeepasswordParam = new SqlParameter("@PARAM_PASS", _User.Password);

                List<SessionUserViewModel> lst = new List<SessionUserViewModel>();
                List<SessionUserViewModel> _LoggedUser = _context.GetLoginUserSP.FromSqlRaw("EXEC fbc.like_get_loginuservalues @PARAM_EMP_NUM, @PARAM_PASS", employeenumberParam, employeepasswordParam).ToList();

                if (_LoggedUser[0].isallowed == true)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, _User.Username)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return RedirectToAction("Index", "Login");
            }


        }

        public async Task<IActionResult> CloseSession()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }


    }

