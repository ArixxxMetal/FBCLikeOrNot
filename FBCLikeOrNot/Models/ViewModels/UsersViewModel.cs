using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Models.ViewModels
{
    public class GetUsersViewModel
    {
        public int Id { get; set; }
        public string Employeenumberuser { get; set; }
        public string Nameuser { get; set; }
        public string Lastnameuser { get; set; }
        public bool Isactiveuser { get; set; }
        public string Namerole { get; set; }
        public DateTime Createdateuser { get; set; }
        public DateTime? Editdateuser { get; set; }

    }
}
