namespace CyberWars.Web.ViewModels.WebViews.CompetitiveCoding
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CyberWars.Data.Models.CompetitiveCoding;
    using CyberWars.Services.Mapping;

    public class ResultContestViewModel : IMapFrom<PlayerContest>
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

        public string PlayerName { get; set; }

        public bool IsWin { get; set; }

        public DateTime DateCompleteContext { get; set; }
    }
}
