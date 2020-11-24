namespace CyberWars.Web.ViewModels.Team
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Team;
    using CyberWars.Services.Mapping;

    public class TeamViewModel : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string MotivationalMotto { get; set; }

        public string Description { get; set; }
    }
}
