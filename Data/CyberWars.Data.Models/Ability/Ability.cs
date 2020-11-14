namespace CyberWars.Data.Models.Ability
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Badge;

    public class Ability : BaseDeletableModel<int>
    {
        public Ability()
        {
            this.PlayerAbilities = new HashSet<PlayerAbility>(); 
            this.Requirements = new HashSet<Requirement>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public int AbilityTypeId { get; set; }

        public AbilityType AbilityType { get; set; }

        public virtual ICollection<PlayerAbility> PlayerAbilities { get; set; }

        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
