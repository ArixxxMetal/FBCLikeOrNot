using FBCLikeOrNot.Models.Sp_Parameters;
using FBCLikeOrNot.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;

namespace FBCLikeOrNot.Controllers
{
    public class QuestionController : Controller
    {
        private Models.DB.db_a87bdd_fbcContext _context;

        public QuestionController(Models.DB.db_a87bdd_fbcContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetQuestionsById([FromBody] ParametersSP Questions_Parameter)
        {
            try
            {
                var service_id = new SqlParameter("@PARAM_SERVICE_ID", Questions_Parameter.PARAM_SERVICE_ID);

                List<like_get_multiple_questions_sp> _response = _context.GetMultipleQuestionSP.FromSqlRaw
                ("EXEC fbc.test_get_multiple_questions_ @PARAM_SERVICE_ID", service_id).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        public JsonResult SetQuestionById([FromBody] ParametersSP Questions_Parameter)
        {
            try
            {
                var service_id = new SqlParameter("@PARAM_SERVICE_ID", Questions_Parameter.PARAM_SERVICE_ID);
                var question_id = new SqlParameter("@PARAM_QUESTION_ID", Questions_Parameter.PARAM_QUESTION_ID);

                List<Sp_Return> _response = _context.AddUpdateReturnSP.FromSqlRaw
                ("EXEC fbc.test_set_multiple_questions_ @PARAM_QUESTION_ID, @PARAM_SERVICE_ID", question_id, service_id).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        public JsonResult DisableQuestionById([FromBody] ParametersSP Questions_Parameter)
        {
            try
            {
                var question_log_id = new SqlParameter("@PARAM_LOG_QUESTION_ID", Questions_Parameter.PARAM_QUESTION_LOG_ID);

                List<Sp_Return> _response = _context.AddUpdateReturnSP.FromSqlRaw
                ("EXEC fbc.test_disable_multiple_questions_ @PARAM_LOG_QUESTION_ID", question_log_id).ToList();
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
