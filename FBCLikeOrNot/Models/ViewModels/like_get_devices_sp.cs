using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Models.ViewModels
{
    public class like_get_devices_sp
    {
        
        public int Id { get; set; }
        public int Iddevice { get; set; }
        public string Namedevice { get; set; }
        public string Nameservice { get; set; }
        public DateTime Createdatedevice { get; set; }
        public string Createbydevice { get; set; }
        public bool Isactivedevice { get; set; }
        public DateTime? Editdatedevice { get; set; }
        public string? Editbydevice { get; set; }
        public int Id_service { get; set; }
        public string Url_reaction { get; set; }
    }
}
