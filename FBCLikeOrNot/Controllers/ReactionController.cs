using FBCLikeOrNot.Models;
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
    public class ReactionController : Controller
    {
        private Models.DB.db_a87bdd_fbcContext _context;

        public ReactionController(Models.DB.db_a87bdd_fbcContext db)
        {
            _context = db;
        }
        public IActionResult Index(String area, String device)
        {

            ReactionParameterView parameterView = new ReactionParameterView();

            parameterView.area = area.Replace("_", " ");
            parameterView.device = device.Replace("_", " ");

            var device_name = new SqlParameter("@PARAM_DEVICE_NAME", device.Replace("_", " "));
            var service_name = new SqlParameter("@PARAM_SERVICE_NAME", area.Replace("_", " "));
            
            List<like_get_question_in_reaction_sp> _response = _context.GetQuestionReactionSP.FromSqlRaw
            ("EXEC fbc.like_get_question_in_reaction @PARAM_DEVICE_NAME, @PARAM_SERVICE_NAME", device_name, service_name).ToList();

            return View(_response);
        }

        [HttpPost]
        public JsonResult GetAllReactions()
        {
            try
            {
                List<LikeReaction> _response = _context.LikeReactions.FromSqlRaw
                ("SELECT * FROM fbc.LikeReactions").ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        [HttpPost]
        public JsonResult GetTotalReactions()
        {
            try
            {
                List<like_get_reaction_percentage_by_service_sp> _response = _context.GetReactionPercentageSP.FromSqlRaw
                ("EXEC fbc.like_get_reaction_percentage_by_service").ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        [HttpPost]
        public JsonResult GetQuestioninReaction([FromBody] like_get_question_in_reaction_param_sp _Get_Question_In_Reaction_Sp)
        {
            try
            {
                var device_name = new SqlParameter("@PARAM_DEVICE_NAME", _Get_Question_In_Reaction_Sp.PARAM_DEVICE_NAME);
                var service_name = new SqlParameter("@PARAM_SERVICE_NAME", _Get_Question_In_Reaction_Sp.PARAM_SERVICE_NAME);

                List<like_get_question_in_reaction_sp> _response = _context.GetQuestionReactionSP.FromSqlRaw
                ("EXEC fbc.like_get_question_in_reaction @PARAM_DEVICE_NAME, @PARAM_SERVICE_NAME", device_name, service_name).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        public JsonResult SetReaction([FromBody] like_set_reaction_param_sp _Set_Reaction_Param_Sp)
        {
            try
            {
                var device_id = new SqlParameter("@PARAM_DEVICE_ID", _Set_Reaction_Param_Sp.PARAM_DEVICE_ID);
                var reaction_id = new SqlParameter("@PARAM_REACTION_ID", _Set_Reaction_Param_Sp.PARAM_REACTION_ID);

                List<like_add_set_update_return_sp> _response = _context.AddUpdateSetReturnSP.FromSqlRaw
                ("EXEC fbc.like_set_reaction @PARAM_DEVICE_ID, @PARAM_REACTION_ID", device_id, reaction_id).ToList();
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
