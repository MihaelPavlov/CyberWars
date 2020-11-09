namespace CyberWars.Data.Models.Skills
{
    using CyberWars.Data.Models.Player;

    public class PlayerSkill
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int Points { get; set; }
    }
}
