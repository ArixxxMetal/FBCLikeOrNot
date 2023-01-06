using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class GrievanceMail
    {
        public int Id { get; set; }
        public string UserType { get; set; }
        public string GrievanceType { get; set; }
        public string Description { get; set; }
        public string FactoryName { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FactoryLocation { get; set; }
        public bool? IsAnonymous { get; set; }
        public DateTime? Creadate { get; set; }
    }
}
