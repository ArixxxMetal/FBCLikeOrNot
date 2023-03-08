using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Models.ViewModels
{
    public class like_get_services_sp
    {
        public int Id { get; set; }
        public int Idservice { get; set; }
        public string Nameservice { get; set; }
        public bool Isactiveservice { get; set; }
        public string Questionservice { get; set; }
        //public string Descriptionquestion { get; set; }
        public string Createbyservice { get; set; }
        public DateTime Createdateservice { get; set; }
        //public int Idquestion { get; set; }
    }
}
