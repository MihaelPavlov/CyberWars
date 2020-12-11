namespace CyberWars.Web.ViewModels.Team
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Teams;
    using CyberWars.Services.Mapping;

    public class TeamPageViewModel : IMapFrom<Team>
    {
        public TeamPageViewModel()
        {
            this.TeamPlayers = new HashSet<TeamPlayersViewModel>();
        }

        public string LeaderName { get; set; }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string MotivationalMotto { get; set; }

        public string Description { get; set; }

        public int Rank { get; set; }

        public string Image { get; set; }

        public virtual ICollection<TeamPlayersViewModel> TeamPlayers { get; set; }
    }
}
