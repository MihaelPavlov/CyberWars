namespace CyberWars.Data.Models.Battle
{
    using CyberWars.Data.Models.Player;

    public class BattleRecord
    {
        public int BattleRecordId { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public string PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
