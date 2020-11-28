namespace CyberWars.Web.ViewModels.WebViews.Job
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Job;
    using CyberWars.Services.Mapping;

    public class JobViewModel : IMapFrom<RandomHangfireJob>
    {
        public JobViewModel()
        {
            this.JobJobRequirements = new HashSet<JobRequirementViewModel>();
        }

        public string JobName { get; set; }

        public int JobJobTypeId { get; set; }

        public JobType JobJobType { get; set; }

        public int JobLevelRequirement { get; set; }

        public virtual ICollection<JobRequirementViewModel> JobJobRequirements { get; set; }
    }
}
