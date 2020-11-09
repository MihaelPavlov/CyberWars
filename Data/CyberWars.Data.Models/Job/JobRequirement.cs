namespace CyberWars.Data.Models.Job
{
    using CyberWars.Data.Models.Badge;

    public class JobRequirement
    {
        public int JobId { get; set; }

        public Job Job { get; set; }

        public int RequirementId { get; set; }

        public Requirement Requirement { get; set; }
    }
}
