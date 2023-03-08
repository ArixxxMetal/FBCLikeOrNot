using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Models.ViewModels
{
    public class like_get_question_in_reaction_sp
    {

        public int Id { get; set; }
        public int Iddevice { get; set; }
        public string Namedevice { get; set; }
        public string Nameservice { get; set; }
        public int Id_service { get; set; }
        public string QuestionService { get; set; }
    }
}
