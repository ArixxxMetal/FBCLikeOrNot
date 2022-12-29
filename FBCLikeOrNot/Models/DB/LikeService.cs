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
        }

        public int Idservice { get; set; }
        public string Nameservice { get; set; }
        public DateTime? Createdateservice { get; set; }
        public DateTime? Editdateservice { get; set; }
        public string Createbyservice { get; set; }
        public string Editbyservice { get; set; }
        public bool? Isactiveservice { get; set; }
        public int IdQuestion { get; set; }
        public int? Objetiveservice { get; set; }

        public virtual LikeQuestion IdQuestionNavigation { get; set; }
        public virtual ICollection<LikeDevice> LikeDevices { get; set; }
    }
}
