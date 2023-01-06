using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class LikeUserRole
    {
        public LikeUserRole()
        {
            LikeUserRolesServiceAccesses = new HashSet<LikeUserRolesServiceAccess>();
            LikeUsers = new HashSet<LikeUser>();
        }

        public int IdUserrole { get; set; }
        public string Namerole { get; set; }
        public DateTime? Createdaterole { get; set; }
        public DateTime? Editdaterole { get; set; }
        public string Createbyrole { get; set; }
        public string Editbyrole { get; set; }

        public virtual ICollection<LikeUserRolesServiceAccess> LikeUserRolesServiceAccesses { get; set; }
        public virtual ICollection<LikeUser> LikeUsers { get; set; }
    }
}
