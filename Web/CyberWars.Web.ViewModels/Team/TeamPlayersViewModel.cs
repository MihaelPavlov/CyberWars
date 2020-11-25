namespace CyberWars.Web.ViewModels.Team
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Team;
    using CyberWars.Services.Mapping;

    public class TeamPlayersViewModel : IMapFrom<TeamPlayer>
    {
        public string PlayerName { get; set; }

        public string PlayerId { get; set; }

        public string TeamName { get; set; }

        public int TeamId { get; set; }
    }
}
