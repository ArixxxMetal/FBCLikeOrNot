using System;

namespace FBCLikeOrNot.Models.ViewModels
{
    public class like_get_multiple_questions_sp
    {
        public int Id { get; set; }
        public int Id_question { get; set; }
        public int Id_service { get; set; }
        public bool IsActive { get; set; }
        public DateTime Createdate { get; set; }
        public string Descriptionquestion { get; set; }
    }
}
