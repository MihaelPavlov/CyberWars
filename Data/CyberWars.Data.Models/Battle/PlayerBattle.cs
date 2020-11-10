namespace CyberWars.Data.Models.Battle
{
    using CyberWars.Data.Models.Player;

    public class PlayerBattle
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int BattleId { get; set; }

        public Battle Battle { get; set; }
    }
}
