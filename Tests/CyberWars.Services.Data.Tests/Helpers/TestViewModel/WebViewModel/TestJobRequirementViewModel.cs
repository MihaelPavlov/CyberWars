namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel.WebViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Badge;
    using CyberWars.Data.Models.Job;
    using CyberWars.Services.Mapping;

    public class TestJobRequirementViewModel : IMapFrom<JobRequirement>
    {
        public int JobId { get; set; }

        public Job Job { get; set; }

        public int RequirementId { get; set; }

        public Requirement Requirement { get; set; }
    }
}
