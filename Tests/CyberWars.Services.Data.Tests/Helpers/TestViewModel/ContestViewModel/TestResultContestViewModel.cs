﻿namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel.ContestViewModel
{
    using System;

    using CyberWars.Data.Models.CompetitiveCoding;
    using CyberWars.Services.Mapping;

    public class TestResultContestViewModel : IMapFrom<PlayerContest>
    {
        public int ContestId { get; set; }

        public string ContestName { get; set; }

        public string ContestDescription { get; set; }

        public string ContestImageName { get; set; }

        public int ContestPercentage { get; set; }

        public int ContestRewardMoney { get; set; }

        public int ContestRewardExp { get; set; }

        public int ContestConsumeEnergy { get; set; }

        public string PlayerName { get; set; }

        public bool IsWin { get; set; }

        public DateTime DateCompleteContext { get; set; }
    }
}
