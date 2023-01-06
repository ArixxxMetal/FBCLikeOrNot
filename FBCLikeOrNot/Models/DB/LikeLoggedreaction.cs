using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class LikeLoggedreaction
    {
        public int Idlog { get; set; }
        public int IdDevice { get; set; }
        public int IdReaction { get; set; }
        public DateTime? Createdate { get; set; }

        public virtual LikeDevice IdDeviceNavigation { get; set; }
        public virtual LikeReaction IdReactionNavigation { get; set; }
    }
}
