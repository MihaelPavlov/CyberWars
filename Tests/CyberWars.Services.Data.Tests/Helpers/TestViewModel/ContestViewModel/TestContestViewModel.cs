namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel.ContestViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.CompetitiveCoding;
    using CyberWars.Services.Mapping;

    public class TestContestViewModel : IMapFrom<RandomHangfireContest>
    {
        public int ContestId { get; set; }

        public string ContestName { get; set; }

        public string ContestDescription { get; set; }

        public string ContestImageName { get; set; }

        public int ContestPercentage { get; set; }

        public int ContestRewardMoney { get; set; }

        public int ContestRewardExp { get; set; }

        public int ContestConsumeEnergy { get; set; }

    }
}
