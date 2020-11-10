namespace CyberWars.Data.Models.Badge
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BadgeType
    {
        public BadgeType()
        {
            this.Badges = new HashSet<Badge>();
            this.Requirements = new HashSet<Requirement>();
        }

        [Key]
        public int BadgeTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Badge> Badges { get; set; }

        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
