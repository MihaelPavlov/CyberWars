namespace CyberWars.Web.ViewModels.WebViews.CompetitiveCoding
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CyberWars.Data.Models.CompetitiveCoding;
    using CyberWars.Services.Mapping;

    public class ContestViewModel : IMapFrom<Contest>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        [Range(1, 100)]
        public int Percentage { get; set; }

        public int RewardMoney { get; set; }

        public int RewardExp { get; set; }

        public int ConsumeEnergy { get; set; }

    }
}
