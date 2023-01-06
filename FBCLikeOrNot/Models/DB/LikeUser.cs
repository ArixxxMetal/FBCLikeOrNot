using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class LikeUser
    {
        public int Iduser { get; set; }
        public string Nameuser { get; set; }
        public string Lastnameuser { get; set; }
        public string Employeenumberuser { get; set; }
        public string Passworduser { get; set; }
        public DateTime? Createdateuser { get; set; }
        public DateTime? Editdateuser { get; set; }
        public string Createbyuser { get; set; }
        public string Editbyuser { get; set; }
        public bool? Isactiveuser { get; set; }
        public int IdRole { get; set; }

        public virtual LikeUserRole IdRoleNavigation { get; set; }
    }
}
