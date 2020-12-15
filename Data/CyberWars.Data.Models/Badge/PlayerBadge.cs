namespace CyberWars.Data.Models.Badge
{
    using System;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class PlayerBadge : IDeletableEntity
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int BadgeId { get; set; }

        public Badge Badge { get; set; }

        public DateTime AchievementDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
