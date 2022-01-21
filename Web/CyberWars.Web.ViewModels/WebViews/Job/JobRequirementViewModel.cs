namespace CyberWars.Web.ViewModels.WebViews.Job
{
    using CyberWars.Data.Models.Badge;
    using CyberWars.Data.Models.Job;
    using CyberWars.Services.Mapping;

    public class JobRequirementViewModel : IMapFrom<JobRequirement>
    {
        public int JobId { get; set; }

        public Job Job { get; set; }

        public int RequirementId { get; set; }

        public Requirement Requirement { get; set; }
    }
}
