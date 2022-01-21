namespace CyberWars.Data.Models.Badge
{
    using System.Collections.Generic;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Job;

    public class Requirement : BaseDeletableModel<int>
    {
        public Requirement()
        {
            this.BadgeRequirements = new HashSet<BadgeRequirement>();
            this.JobRequirements = new HashSet<JobRequirement>();
        }

        public string Name { get; set; }

        public int AbilityId { get; set; }

        public Ability Ability { get; set; }

        public int Points { get; set; }

        public virtual ICollection<BadgeRequirement> BadgeRequirements { get; set; }

        public virtual ICollection<JobRequirement> JobRequirements { get; set; }
    }
}
