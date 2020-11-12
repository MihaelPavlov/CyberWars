namespace CyberWars.Data.Models.Job
{
    using System.Collections.Generic;

    using CyberWars.Data.Common.Models;

    public class JobType : BaseDeletableModel<int>
    {
        public JobType()
        {
            this.Jobs = new HashSet<Job>();
        }

        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
