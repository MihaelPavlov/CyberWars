namespace CyberWars.Data.Models.Job
{
    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Badge;
    using System;

    public class JobRequirement : IDeletableEntity
    {
        public int JobId { get; set; }

        public Job Job { get; set; }

        public int RequirementId { get; set; }

        public Requirement Requirement { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
