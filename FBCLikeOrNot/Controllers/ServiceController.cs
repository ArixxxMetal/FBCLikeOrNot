using FBCLikeOrNot.Models.DB;
using FBCLikeOrNot.Models.Sp_Parameters;
using FBCLikeOrNot.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Controllers
{
    public class ServiceController : Controller
    {
        private Models.DB.db_a87bdd_fbcContext _context;
        public ServiceController(Models.DB.db_a87bdd_fbcContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetServices()
        {
            try
            {
                List<like_get_services_sp> _response = _context.GetServicesSP.FromSqlRaw
                ("EXEC fbc.like_get_services").ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        [HttpPost]
        public JsonResult GetAllQuestions()
        {
            try
            {

                List<LikeQuestion> _response = _context.LikeQuestions.FromSqlRaw
                    ("SELECT * FROM fbc.LikeQuestions ORDER BY Createdatequestion DESC").ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        [HttpPost]
        public JsonResult AddService([FromBody] like_add_new_service_param_sp _Add_New_Service_Param_Sp)
        {
            try
            {
                var service_name = new SqlParameter("@PARAM_SERVICE_NAME", _Add_New_Service_Param_Sp.PARAM_SERVICE_NAME);
                var service_question = new SqlParameter("@PARAM_SERVICE_QUESTION", _Add_New_Service_Param_Sp.PARAM_SERVICE_QUESTION);
                var create_by = new SqlParameter("@PARAM_CREATE_BY", _Add_New_Service_Param_Sp.PARAM_CREATE_BY);

                List<like_add_set_update_return_sp> _response = _context.AddUpdateSetReturnSP.FromSqlRaw
                ("EXEC fbc.like_add_new_service @PARAM_SERVICE_NAME, @PARAM_SERVICE_QUESTION, @PARAM_CREATE_BY", service_name, service_question, create_by).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        [HttpPost]
        public JsonResult UpdateService([FromBody] like_update_service_param_sp _Update_Service_Param_Sp)
        {
            try
            {
                var service_id = new SqlParameter("@PARAM_SERVICE_ID", _Update_Service_Param_Sp.PARAM_SERVICE_ID);
                var service_name = new SqlParameter("@PARAM_SERVICE_NAME", _Update_Service_Param_Sp.PARAM_SERVICE_NAME);
                var edit_by = new SqlParameter("@PARAM_EDIT_BY", _Update_Service_Param_Sp.PARAM_EDIT_BY);

                List<like_add_set_update_return_sp> _response = _context.AddUpdateSetReturnSP.FromSqlRaw
                ("EXEC fbc.like_update_service @PARAM_SERVICE_ID, @PARAM_SERVICE_NAME, @PARAM_EDIT_BY", service_id, service_name, edit_by).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        [HttpPost]
        public JsonResult SetQuestionService([FromBody] like_set_question_param_sp _Set_Question_Param_Sp)
        {
            try
            {
                var service_question = new SqlParameter("@PARAM_DESCRIPTION_QUESTION", _Set_Question_Param_Sp.PARAM_DESCRIPTION_QUESTION);
                var create_by = new SqlParameter("@PARAM_CREATE_BY", _Set_Question_Param_Sp.PARAM_CREATE_BY);

                List<like_add_set_update_return_sp> _response = _context.AddUpdateSetReturnSP.FromSqlRaw
                ("EXEC fbc.like_set_question @PARAM_DESCRIPTION_QUESTION, @PARAM_CREATE_BY", service_question, create_by).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }
    }
}
