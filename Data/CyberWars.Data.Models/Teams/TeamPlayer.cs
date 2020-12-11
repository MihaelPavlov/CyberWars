namespace CyberWars.Data.Models.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class TeamPlayer : IDeletableEntity
    {
        public Player Player { get; set; }

        public string PlayerId { get; set; }

        public Team Team { get; set; }

        public int TeamId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
