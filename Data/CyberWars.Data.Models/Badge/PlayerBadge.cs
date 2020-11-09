namespace CyberWars.Data.Models.Badge
{
    using System;

    using CyberWars.Data.Models.Player;

    public class PlayerBadge
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int BadgeId { get; set; }

        public Badge Badge { get; set; }

        public DateTime AchievementDate { get; set; }
    }
}
