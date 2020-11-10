using CyberWars.Data.Common.Models;

namespace CyberWars.Data.Models.Player
{
    public class Level : BaseDeletableModel<int>
    {
        public int Exp { get; set; }

        public int ExpDifference { get; set; }
    }
}
