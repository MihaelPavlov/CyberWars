namespace CyberWars.Data.Models.Job
{
    using System.Collections.Generic;

    public class Job
    {
        public Job()
        {
            this.JobRequirements = new HashSet<JobRequirement>();
            this.PlayerJobs = new HashSet<PlayerJob>();
        }

        public int JobId { get; set; }

        public string Name { get; set; }

        public int JobTypeId { get; set; }

        public JobType JobType { get; set; }

        public int LevelRequirement { get; set; }

        public virtual ICollection<JobRequirement> JobRequirements { get; set; }

        public virtual ICollection<PlayerJob> PlayerJobs { get; set; }
    }
}
