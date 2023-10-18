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
        public JsonResult GetTotalReactionsByRangeDate([FromBody] like_get_reaction_percentage_by_daterange_param_sp _Get_Reaction_Percentage_By_Daterange_Param_Sp)
        {
            try
            {
                var begin_date = new SqlParameter("@PARAM_BEGIN_DATE", _Get_Reaction_Percentage_By_Daterange_Param_Sp.PARAM_BEGIN_DATE);
                var end_date = new SqlParameter("@PARAM_END_DATE", _Get_Reaction_Percentage_By_Daterange_Param_Sp.PARAM_END_DATE);

                List<like_get_reaction_percentage_by_service_sp> _response = _context.GetReactionPercentageSP.FromSqlRaw
                ("EXEC fbc.like_get_reaction_percentage_by_daterange @PARAM_BEGIN_DATE, @PARAM_END_DATE", begin_date, end_date).ToList();
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
                var question_log_id = new SqlParameter("@PARAM_QUESTION_LOG_ID", _Set_Reaction_Param_Sp.PARAM_QUESTION_LOG_ID);

                List<like_add_set_update_return_sp> _response = _context.AddUpdateSetReturnSP.FromSqlRaw
                ("EXEC fbc.like_set_reaction @PARAM_DEVICE_ID, @PARAM_REACTION_ID, @PARAM_QUESTION_LOG_ID", device_id, reaction_id, question_log_id).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        public JsonResult GetDevicesByAreaGraph([FromBody] like_get_graph_param_sp _Set_Graph_Param_Sp)
        {
            try
            {
                var begin_date = new SqlParameter("@PARAM_BEGIN_DATE", _Set_Graph_Param_Sp.PARAM_BEGIN_DATE);
                var end_date = new SqlParameter("@PARAM_END_DATE", _Set_Graph_Param_Sp.PARAM_END_DATE);
                var service_id = new SqlParameter("@PARAM_SERVICE_ID", _Set_Graph_Param_Sp.PARAM_SERVICE_ID);

                List<like_get_devices_by_area_graph_sp> _response = _context.GetGraphByDeviceSP.FromSqlRaw
                ("EXEC [fbc].[like_get_devices_by_area_graph] @PARAM_BEGIN_DATE, @PARAM_END_DATE, @PARAM_SERVICE_ID", begin_date, end_date, service_id).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        public JsonResult GetQuestionsByAreaGraph([FromBody] like_get_graph_param_sp _Set_Graph_Param_Sp)
        {
            try
            {
                var begin_date = new SqlParameter("@PARAM_BEGIN_DATE", _Set_Graph_Param_Sp.PARAM_BEGIN_DATE);
                var end_date = new SqlParameter("@PARAM_END_DATE", _Set_Graph_Param_Sp.PARAM_END_DATE);
                var service_id = new SqlParameter("@PARAM_SERVICE_ID", _Set_Graph_Param_Sp.PARAM_SERVICE_ID);

                List<like_get_questions_by_area_graph_sp> _response = _context.GetGraphByQuestionAreaSP.FromSqlRaw
                ("EXEC [fbc].[like_get_questions_by_area_graph] @PARAM_BEGIN_DATE, @PARAM_END_DATE, @PARAM_SERVICE_ID", begin_date, end_date, service_id).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        public JsonResult GetQuestionsByDeviceGraph([FromBody] like_get_graph_param_sp _Set_Graph_Param_Sp)
        {
            try
            {
                var begin_date = new SqlParameter("@PARAM_BEGIN_DATE", _Set_Graph_Param_Sp.PARAM_BEGIN_DATE);
                var end_date = new SqlParameter("@PARAM_END_DATE", _Set_Graph_Param_Sp.PARAM_END_DATE);
                var device_id = new SqlParameter("@PARAM_DEVICE_ID", _Set_Graph_Param_Sp.PARAM_DEVICE_ID);

                List<like_get_questions_by_device_graph_sp> _response = _context.GetGraphByQuestionDeviceSP.FromSqlRaw
                ("EXEC [fbc].[like_get_questions_by_device_graph] @PARAM_BEGIN_DATE, @PARAM_END_DATE, @PARAM_DEVICE_ID", begin_date, end_date, device_id).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        public JsonResult GetReactionRecordByArea([FromBody] like_get_graph_param_sp _Set_Graph_Param_Sp)
        {
            try
            {
                var begin_date = new SqlParameter("@PARAM_BEGIN_DATE", _Set_Graph_Param_Sp.PARAM_BEGIN_DATE);
                var end_date = new SqlParameter("@PARAM_END_DATE", _Set_Graph_Param_Sp.PARAM_END_DATE);
                var service_id = new SqlParameter("@PARAM_SERVICE_ID", _Set_Graph_Param_Sp.PARAM_SERVICE_ID);

                List<like_get_reaction_records_by_service_id_sp> _response = _context.GetReactionRecordsByServiceIdSP.FromSqlRaw
                ("EXEC [fbc].[like_get_reaction_records_by_service_id] @PARAM_BEGIN_DATE, @PARAM_END_DATE, @PARAM_SERVICE_ID", begin_date, end_date, service_id).ToList();
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
