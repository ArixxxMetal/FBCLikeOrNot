using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Models.Sp_Parameters
{
    public class ParametersSP
    {
        public int PARAM_SERVICE_ID { get; set; }
        public int PARAM_DEVICE_ID { get; set; }
        public int PARAM_QUESTION_ID { get; set; }
        public string PARAM_DEVICE_NAME { get; set; }
        public string PARAM_SERVICE_NAME { get; set; }
        public string PARAM_DESCRIPTION_QUESTION { get; set; }
        public string PARAM_CREATE_BY { get; set; }
        public string PARAM_EDIT_BY { get; set; }
        public int PARAM_REACTION_ID { get; set; }
        public int PARAM_QUESTION_LOG_ID { get; set; }
    }
}
