namespace CyberWars.Data.Models.Ability
{
    using CyberWars.Data.Models.Player;

    public class PlayerAbility
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int AbilityId { get; set; }

        public Ability Ability { get; set; }

        public int Points { get; set; }
    }
}
