namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel.WebViewModel
{
    using System.Collections.Generic;

    using CyberWars.Data.Models.Job;
    using CyberWars.Services.Mapping;

    public class TestJobViewModel : IMapFrom<RandomHangfireJob>
    {
        public TestJobViewModel()
        {
            this.JobJobRequirements = new HashSet<TestJobRequirementViewModel>();
        }

        public int JobId { get; set; }

        public string JobName { get; set; }

        public int JobJobTypeId { get; set; }

        public JobType JobJobType { get; set; } 

        public int JobLevelRequirement { get; set; }

        public int JobRewardExp { get; set; }

        public int JobRewardMoney { get; set; }

        public string JobRewardAbilityNames { get; set; }

        public virtual ICollection<TestJobRequirementViewModel> JobJobRequirements { get; set; }
    }
}
