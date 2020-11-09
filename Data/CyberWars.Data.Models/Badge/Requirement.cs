namespace CyberWars.Data.Models.Badge
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CyberWars.Data.Models.Job;

    public class Requirement
    {
        public Requirement()
        {
            this.BadgeRequirements = new HashSet<BadgeRequirement>();
            this.JobRequirements = new HashSet<JobRequirement>();
        }

        [Key]
        public int RequirementId { get; set; }

        public string Name { get; set; }

        public int BadgeTypeId { get; set; }

        public BadgeType BadgeType { get; set; }

        public int Points { get; set; }

        public virtual ICollection<BadgeRequirement> BadgeRequirements { get; set; }

        public virtual ICollection<JobRequirement> JobRequirements { get; set; }
    }
}
