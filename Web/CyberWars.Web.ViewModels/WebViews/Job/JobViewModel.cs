namespace CyberWars.Web.ViewModels.WebViews.Job
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Job;
    using CyberWars.Services.Mapping;

    public class JobViewModel : IMapFrom<Job>
    {
        public JobViewModel()
        {
            this.JobRequirements = new HashSet<JobRequirementViewModel>();
        }

        public string Name { get; set; }

        public int JobTypeId { get; set; }

        public JobType JobType { get; set; }

        public int LevelRequirement { get; set; }

        public virtual ICollection<JobRequirementViewModel> JobRequirements { get; set; }
    }
}
