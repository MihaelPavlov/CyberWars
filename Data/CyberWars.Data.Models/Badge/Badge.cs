namespace CyberWars.Data.Models.Badge
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CyberWars.Data.Common.Models;

    public class Badge : BaseDeletableModel<int>
    {
        public Badge()
        {
            this.BadgeRequirements = new HashSet<BadgeRequirement>();
            this.PlayersBadges = new HashSet<PlayerBadge>();
        }

        public string Name { get; set; }

        public int BadgeTypeId { get; set; }

        public BadgeType BadgeType { get; set; }

        public string ImageName { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public virtual ICollection<BadgeRequirement> BadgeRequirements { get; set; }

        public virtual ICollection<PlayerBadge> PlayersBadges { get; set; }
    }
}
