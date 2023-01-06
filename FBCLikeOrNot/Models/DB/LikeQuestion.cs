using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class LikeQuestion
    {
        public LikeQuestion()
        {
            LikeQuestionServicesLogs = new HashSet<LikeQuestionServicesLog>();
        }

        public int Idquestion { get; set; }
        public string Descriptionquestion { get; set; }
        public DateTime? Createdatequestion { get; set; }
        public DateTime? Editdatequestion { get; set; }
        public string Createbyquestion { get; set; }
        public string Editbyquestion { get; set; }

        public virtual ICollection<LikeQuestionServicesLog> LikeQuestionServicesLogs { get; set; }
    }
}
