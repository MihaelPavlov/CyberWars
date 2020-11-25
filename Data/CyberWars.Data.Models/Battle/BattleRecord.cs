namespace CyberWars.Data.Models.Battle
{
    using System;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class BattleRecord : BaseDeletableModel<string>
    {
        public BattleRecord()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public string PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
