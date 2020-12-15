namespace CyberWars.Data.Models.Player
{
    using CyberWars.Data.Common.Models;

    public class Level : BaseDeletableModel<int>
    {
        public int LevelName { get; set; }

        public int Exp { get; set; }

        public int ExpDifference { get; set; }
    }
}
