namespace CyberWars.Data.Models.Battle
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class Battle : BaseDeletableModel<string>
    {
        public Battle()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PlayerBattles = new HashSet<PlayerBattle>();
        }

        [ForeignKey("AttackPlayerId")]
        public string AttackPlayerId { get; set; }

        [ForeignKey("DefencePlayerId")]
        public string DefencePlayerId { get; set; }

        public virtual Player AttackPlayer { get; set; }

        public virtual Player DefencePlayer { get; set; }

        public DateTime BattleDate { get; set; }

        public virtual ICollection<PlayerBattle> PlayerBattles { get; set; }
    }
}
