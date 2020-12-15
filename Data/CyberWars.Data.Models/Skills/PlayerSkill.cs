namespace CyberWars.Data.Models.Skills
{
    using System;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class PlayerSkill : IDeletableEntity
    {
        public virtual string PlayerId { get; set; }

        public Player Player { get; set; }

        public virtual int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int Points { get; set; }

        public int Money { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
