using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class LikeUserRolesServiceAccess
    {
        public int IdUserroleaccess { get; set; }
        public DateTime? Createdate { get; set; }
        public int? IdService { get; set; }
        public int IdRole { get; set; }

        public virtual LikeUserRole IdRoleNavigation { get; set; }
    }
}
