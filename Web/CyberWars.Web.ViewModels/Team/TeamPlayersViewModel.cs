﻿namespace CyberWars.Web.ViewModels.Team
{
    using CyberWars.Data.Models.Teams;
    using CyberWars.Services.Mapping;

    public class TeamPlayersViewModel : IMapFrom<TeamPlayer>
    {
        public string PlayerName { get; set; }

        public string PlayerId { get; set; }

        public string TeamName { get; set; }

        public int TeamId { get; set; }
    }
}
