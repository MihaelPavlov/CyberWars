namespace CyberWars.Data.Models.Job
{
    using System.Collections.Generic;

    public class JobType
    {
        public JobType()
        {
            this.Jobs = new HashSet<Job>();
        }

        public int JobTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
