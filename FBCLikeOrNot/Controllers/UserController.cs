using FBCLikeOrNot.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FBCLikeOrNot.Controllers
{
    public class UserController : Controller
    {
        private Models.DB.db_a87bdd_fbcContext _context;

        public UserController(Models.DB.db_a87bdd_fbcContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetAllEmployees()
        {
            try
            {
                List<GetUsersViewModel> lst = new List<GetUsersViewModel>();
                List<GetUsersViewModel> _UserList = _context.GetUserListSP.FromSqlRaw
                    ("SELECT LU.Iduser AS Id, LU.Employeenumberuser, LU.Nameuser, LU.Lastnameuser, LU.Isactiveuser, LUR.Namerole, LU.Createdateuser, LU.Editdateuser FROM fbc.LikeUsers LU INNER JOIN fbc.LikeUserRoles LUR ON LUR.IdUserrole = LU.Id_Role;")
                    .ToList();
                return Json(_UserList);
            }
            catch(Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }

        }
    }
}
