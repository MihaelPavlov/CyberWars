﻿namespace CyberWars.Web.ViewModels.WebViews.CompetitiveCoding
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CyberWars.Data.Models.CompetitiveCoding;
    using CyberWars.Services.Mapping;

    public class ContestViewModel : IMapFrom<RandomHangfireContest>
    {
        public int ContestId { get; set; }

        public string ContestName { get; set; }

        public string ContestDescription { get; set; }

        public string ContestImageName { get; set; }

        [Range(1, 100)]
        public int ContestPercentage { get; set; }

        public int ContestRewardMoney { get; set; }

        public int ContestRewardExp { get; set; }

        public int ContestConsumeEnergy { get; set; }

    }
}
