namespace CyberWars.Data.Models.Badge
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Badge
    {
        public Badge()
        {
            this.BadgeRequirements = new HashSet<BadgeRequirement>();
            this.PlayersBadges = new HashSet<PlayerBadge>();
        }

        [Key]
        public int BadgeId { get; set; }

        public string Name { get; set; }

        public int BadgeTypeId { get; set; }

        public BadgeType BadgeType { get; set; }

        public string ImageName { get; set; }

        public virtual ICollection<BadgeRequirement> BadgeRequirements { get; set; }

        public virtual ICollection<PlayerBadge> PlayersBadges { get; set; }
    }
}
