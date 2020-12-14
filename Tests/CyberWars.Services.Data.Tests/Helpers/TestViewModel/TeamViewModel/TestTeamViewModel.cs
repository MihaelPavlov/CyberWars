namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel.TeamViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Teams;
    using CyberWars.Services.Mapping;

    public class TestTeamViewModel : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string MotivationalMotto { get; set; }

        public string Description { get; set; }
    }
}
