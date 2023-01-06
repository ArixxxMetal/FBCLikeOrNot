using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class LikeService
    {
        public LikeService()
        {
            LikeDevices = new HashSet<LikeDevice>();
            LikeQuestionServicesLogs = new HashSet<LikeQuestionServicesLog>();
        }

        public int Idservice { get; set; }
        public string Nameservice { get; set; }
        public DateTime? Createdateservice { get; set; }
        public DateTime? Editdateservice { get; set; }
        public string Createbyservice { get; set; }
        public string Editbyservice { get; set; }
        public bool? Isactiveservice { get; set; }

        public virtual ICollection<LikeDevice> LikeDevices { get; set; }
        public virtual ICollection<LikeQuestionServicesLog> LikeQuestionServicesLogs { get; set; }
    }
}
