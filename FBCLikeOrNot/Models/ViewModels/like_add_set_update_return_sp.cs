using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Models.ViewModels
{
    public class like_add_set_update_return_sp
    {
        public int id { get; set; }
        public bool was_done { get; set; }
        public string return_message { get; set; }
    }
}
