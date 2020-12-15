namespace CyberWars.Data.Models.Teams
{
    using System.Collections.Generic;

    using CyberWars.Data.Common.Models;

    public class Team : BaseDeletableModel<int>
    {
        public Team()
        {
            this.TeamPlayers = new HashSet<TeamPlayer>();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Name { get; set; }

        public string MotivationalMotto { get; set; }

        public string Description { get; set; }

        public int Rank { get; set; }

        public string Image { get; set; }

        public ICollection<TeamPlayer> TeamPlayers { get; set; }
    }
}
