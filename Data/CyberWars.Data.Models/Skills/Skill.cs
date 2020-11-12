namespace CyberWars.Data.Models.Skills
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CyberWars.Data.Common.Models;

    public class Skill : BaseDeletableModel<int>
    {
        public Skill()
        {
            this.PlayerSkills = new HashSet<PlayerSkill>();
        }

        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public int StartMoney { get; set; }

        public virtual ICollection<PlayerSkill> PlayerSkills { get; set; }
    }
}
