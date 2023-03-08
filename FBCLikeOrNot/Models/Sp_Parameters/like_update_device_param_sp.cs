using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Models.Sp_Parameters
{
    public class like_update_device_param_sp
    {
        public int PARAM_DEVICE_ID { get; set; }
        public string PARAM_DEVICE_NAME { get; set; }
        public string PARAM_EDIT_BY { get; set; }
        public int PARAM_SERVICE_ID { get; set; }
    }
}
