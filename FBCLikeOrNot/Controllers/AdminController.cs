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
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Devices()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }
    }
}
