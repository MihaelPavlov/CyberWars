namespace CyberWars.Data.Models.Battle
{
    using System;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class PlayerBattle : IDeletableEntity
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public string BattleId { get; set; }

        public Battle Battle { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
