using System;
using System.Collections.Generic;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class EmpleadosPosadum
    {
        public int Id { get; set; }
        public string Idrh { get; set; }
        public string Nombre { get; set; }
        public string NumeroPuesto { get; set; }
        public string NombrePuesto { get; set; }
        public string NumeroDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public string Area { get; set; }
        public string Bum { get; set; }
        public string Ischecked { get; set; }
        public DateTime? CheckDate { get; set; }
    }
}
