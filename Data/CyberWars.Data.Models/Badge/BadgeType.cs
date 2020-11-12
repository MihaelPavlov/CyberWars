namespace CyberWars.Data.Models.Badge
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CyberWars.Data.Common.Models;

    public class BadgeType : BaseDeletableModel<int>
    {
        public BadgeType()
        {
            this.Badges = new HashSet<Badge>();
            this.Requirements = new HashSet<Requirement>();
        }

        public string Name { get; set; }

        public virtual ICollection<Badge> Badges { get; set; }

        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
