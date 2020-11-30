namespace CyberWars.Data.Models.Job
{
    using System;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class PlayerJob : IDeletableEntity
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int JobId { get; set; }

        public Job Job { get; set; }

        public DateTime LastDatePlayed { get; set; }

        public int TimesComplete { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
