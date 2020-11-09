namespace CyberWars.Data.Models.Team
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class Team : BaseDeletableModel<int>
    {
        public Team()
        {
            this.TeamId = Guid.NewGuid().ToString();
            this.TeamMembers = new HashSet<Player>();
        }

        public string TeamId { get; set; }

        public string Name { get; set; }

        public string MotivationalMotto { get; set; }

        public string Description { get; set; }

        [ForeignKey("LeaderOfTeam")]
        public string LeaderOfTeamId { get; set; }

        public Player LeaderOfTeam { get; set; }

        public virtual ICollection<Player> TeamMembers { get; set; }
    }
}
