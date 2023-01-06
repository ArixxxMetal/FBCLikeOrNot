using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class LikeDevice
    {
        public LikeDevice()
        {
            LikeLoggedreactions = new HashSet<LikeLoggedreaction>();
        }

        public int Iddevice { get; set; }
        public string Namedevice { get; set; }
        public DateTime? Createdatedevice { get; set; }
        public DateTime? Editdatedevice { get; set; }
        public string Createbydevice { get; set; }
        public string Editbydevice { get; set; }
        public bool? Isactivedevice { get; set; }
        public int IdService { get; set; }

        public virtual LikeService IdServiceNavigation { get; set; }
        public virtual ICollection<LikeLoggedreaction> LikeLoggedreactions { get; set; }
    }
}
