using System;

namespace FBCLikeOrNot.Models.ViewModels
{
    public class like_get_reaction_records_by_service_id_sp
    {
        public int Id { get; set; }
        public int Idservice { get; set; }
        public int Iddevice { get; set; }
        public string Namedevice { get; set; }
        public DateTime CreateDate { get; set; }
        public int Id_reaction { get; set; }
        public string Namereaction { get; set; }
        public int? Id_question_log { get; set; }
        public string? Descriptionquestion { get; set; }          

    }
}
