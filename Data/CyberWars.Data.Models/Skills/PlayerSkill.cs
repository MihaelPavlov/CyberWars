namespace CyberWars.Data.Models.Skills
{
    using System;

    using CyberWars.Data.Common.Models;

    using CyberWars.Data.Models.Player;

    public class PlayerSkill : IDeletableEntity
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int Points { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
