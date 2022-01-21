namespace CyberWars.Data.Models.CompetitiveCoding
{
    using System;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class PlayerContest : IDeletableEntity
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int ContestId { get; set; }

        public Contest Contest { get; set; }

        public DateTime DateCompleteContext { get; set; }

        public bool IsWin { get; set; }

        public int TimePlayed { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
