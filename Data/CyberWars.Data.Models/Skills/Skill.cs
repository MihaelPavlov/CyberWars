namespace CyberWars.Data.Models.Skills
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Skill
    {
        public Skill()
        {
            this.PlayerSkills = new HashSet<PlayerSkill>();
        }

        [Key]
        public int SkillId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PlayerSkill> PlayerSkills { get; set; }
    }
}
