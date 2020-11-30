namespace CyberWars.Data.Models.Job
{
    using System.Collections.Generic;

    using CyberWars.Data.Common.Models;

    public class Job : BaseDeletableModel<int>
    {
        public Job()
        {
            this.JobRequirements = new HashSet<JobRequirement>();
            this.PlayerJobs = new HashSet<PlayerJob>();
        }

        public string Name { get; set; }

        public int JobTypeId { get; set; }

        public JobType JobType { get; set; }

        public int LevelRequirement { get; set; }

        public int RewardMoney { get; set; }

        public int RewardExp { get; set; }

        public string RewardAbilityNames { get; set; }

        public virtual ICollection<JobRequirement> JobRequirements { get; set; }

        public virtual ICollection<PlayerJob> PlayerJobs { get; set; }
    }
}
