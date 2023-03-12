using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBCLikeOrNot.Models.ViewModels
{
    public class like_get_reaction_percentage_by_service_sp
    {
        public int Id { get; set; }
        public int Idservice { get; set; }
        public string Nameservice { get; set; }
        public int GoodTotalReactions { get; set; }
        public int NeutralTotalReactions { get; set; }
        public int BadTotalReactions { get; set; }
        public int TotalReactions { get; set; }
        public double GoodPercentage { get; set; }
        public double NeutralPercentage { get; set; }
        public double BadPercentage { get; set; }
    }
}
