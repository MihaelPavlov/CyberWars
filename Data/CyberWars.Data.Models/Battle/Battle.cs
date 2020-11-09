namespace CyberWars.Data.Models.Battle
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CyberWars.Data.Models.Player;

    public class Battle
    {
        public Battle()
        {
            this.PlayerBattles = new HashSet<PlayerBattle>();
        }

        [Key]
        public int BattleId { get; set; }

        [ForeignKey("AttackPlayer")]
        public string AttackPlayerId { get; set; }

        public Player AttackPlayer { get; set; }

        [ForeignKey("DefencePlayer")]
        public string DefencePlayerId { get; set; }

        public Player DefencePlayer { get; set; }

        public DateTime BattleDate { get; set; }

        public virtual ICollection<PlayerBattle> PlayerBattles { get; set; }
    }
}
