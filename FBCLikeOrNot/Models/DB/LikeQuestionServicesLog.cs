using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class LikeQuestionServicesLog
    {
        public int Id { get; set; }
        public int IdQuestion { get; set; }
        public int IdService { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Createdate { get; set; }

        public virtual LikeQuestion IdQuestionNavigation { get; set; }
        public virtual LikeService IdServiceNavigation { get; set; }
    }
}
