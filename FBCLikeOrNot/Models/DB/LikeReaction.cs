using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class LikeReaction
    {
        public LikeReaction()
        {
            LikeLoggedreactions = new HashSet<LikeLoggedreaction>();
        }

        public int Idreaction { get; set; }
        public string Namereaction { get; set; }
        public DateTime? Createdatereaction { get; set; }

        public virtual ICollection<LikeLoggedreaction> LikeLoggedreactions { get; set; }
    }
}
