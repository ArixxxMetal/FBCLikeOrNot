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
    public class DeviceController : Controller
    {
        private Models.DB.db_a87bdd_fbcContext _context;

        public DeviceController(Models.DB.db_a87bdd_fbcContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDevicesList()
        {
            try
            {
                List<like_get_devices_sp> _response = _context.GetDevicesSP.FromSqlRaw
                ("EXEC fbc.like_get_devices;").ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        [HttpPost]
        public JsonResult AddDevice([FromBody] like_add_new_device_param_sp _Add_New_Device_Param_Sp)
        {
            try
            {
                var device_name_param = new SqlParameter("@PARAM_DEVICE_NAME", _Add_New_Device_Param_Sp.PARAM_DEVICE_NAME);
                var service_id_param = new SqlParameter("@PARAM_SERVICE_ID", _Add_New_Device_Param_Sp.PARAM_SERVICE_ID);
                var create_by_param = new SqlParameter("@PARAM_CREATE_BY", _Add_New_Device_Param_Sp.PARAM_CREATE_BY);

                List<like_add_set_update_return_sp> _response = _context.AddUpdateSetReturnSP.FromSqlRaw
                ("EXEC fbc.like_add_new_device @PARAM_SERVICE_ID, @PARAM_DEVICE_NAME, @PARAM_CREATE_BY", service_id_param, device_name_param, create_by_param).ToList();
                return Json(_response);
            }
            catch (Exception ex)
            {
                var ExceptionResponse = ex.Message;
                return Json(ExceptionResponse);
            }
        }

        [HttpPost]
        public JsonResult UpdateDevice([FromBody] like_update_device_param_sp _Update_Device_Param_Sp)
        {
            try
            {
                var device_id_param = new SqlParameter("@PARAM_DEVICE_ID", _Update_Device_Param_Sp.PARAM_DEVICE_ID);
                var device_name_param = new SqlParameter("@PARAM_DEVICE_NAME", _Update_Device_Param_Sp.PARAM_DEVICE_NAME);
                var service_id_param = new SqlParameter("@PARAM_SERVICE_ID", _Update_Device_Param_Sp.PARAM_SERVICE_ID);
                var edit_by_param = new SqlParameter("@PARAM_EDIT_BY", _Update_Device_Param_Sp.PARAM_EDIT_BY);

                List<like_add_set_update_return_sp> _response = _context.AddUpdateSetReturnSP.FromSqlRaw
                ("EXEC fbc.like_update_device @PARAM_DEVICE_ID, @PARAM_DEVICE_NAME, @PARAM_EDIT_BY, @PARAM_SERVICE_ID", 
                device_id_param, device_name_param, edit_by_param, service_id_param).ToList();

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
