namespace CyberWars.Data.Models.Skills
{
    using CyberWars.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Skill : BaseDeletableModel<int>
    {
        public Skill()
        {
            this.PlayerSkills = new HashSet<PlayerSkill>();
        }

        public string Name { get; set; }

        public virtual ICollection<PlayerSkill> PlayerSkills { get; set; }
    }
}
