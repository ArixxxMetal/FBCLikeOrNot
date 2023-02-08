using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Models.ViewModels
{
    public class GetDeviceViewModels
    {
        public int Iddevice { get; set; }
        public string Namedevice { get; set; }
        public string Nameservice { get; set; }
        public bool Isactivedevice { get; set; }
        public string Createbydevice { get; set; }
        public DateTime Createdatedevice { get; set; }
        public string Editbydevice { get; set; }
        public DateTime? Editdatedevice { get; set; }
    }
}
