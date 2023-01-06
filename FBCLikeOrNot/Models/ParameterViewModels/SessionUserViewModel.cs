using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Models.ParameterViewModels
{
    public class SessionUserViewModel
    {
        public int id { get; set; }
        public string emp_num { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string role { get; set; }
        public bool isallowed { get; set; }
        public string area { get; set; }
    }
}
