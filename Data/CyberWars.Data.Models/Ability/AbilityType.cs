namespace CyberWars.Data.Models.Ability
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Common.Models;

    public class AbilityType : BaseDeletableModel<int>
    {
        public AbilityType()
        {
            this.Abilities = new HashSet<Ability>();
        }

        public string Type { get; set; }

        public virtual ICollection<Ability> Abilities { get; set; }
    }
}
