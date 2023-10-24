using FBCLikeOrNot.Models;
//using FBCLikeOrNot.Models.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Controllers
{
    [Authorize]
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

        public IActionResult DevicesGraph()
        {
            return View();
        }

        public IActionResult QuestionsGraph()
        {
            return View();
        }

        public IActionResult QuestionDevicesGraph()
        {
            return View();
        }

        public IActionResult ReactionRecords()
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

        public IActionResult Questions()
        {
            return View();
        }

        public IActionResult QuestionSettings()
        {
            return View();
        }
    }
}
