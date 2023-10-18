using System;

namespace FBCLikeOrNot.Models.ViewModels
{
    public class like_get_devices_by_area_graph_sp
    {
        public int Id { get; set; }
        public int Id_device { get; set; }
        public string DeviceName { get; set; }
        public int ReactionCount { get; set; }
        public DateTime LatestCreateDate { get; set; }
        public DateTime FirstCreateDate { get; set; }
        public int GoodReactions { get; set; }
        public int NeutralReactions { get; set; }
        public int BadReactions { get; set; }
    }
}
