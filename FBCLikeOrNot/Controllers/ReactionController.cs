using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Controllers
{
    public class ReactionController : Controller
    {
        private Models.DB.db_a87bdd_fbcContext _context;

        public ReactionController(Models.DB.db_a87bdd_fbcContext db)
        {
            _context = db;
        }
        public IActionResult Index(String area, String device)
        {
            ///Reaction/Index?area=comedor&device=test
            var test = _context.LikeReactions.ToList();
            return View();
        }
    }
}
