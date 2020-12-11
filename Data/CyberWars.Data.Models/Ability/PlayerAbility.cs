namespace CyberWars.Data.Models.Ability
{
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Common.Models;
    using System;

    public class PlayerAbility : IDeletableEntity

    {
        public virtual string PlayerId { get; set; }

        public virtual Player Player { get; set; }

        public virtual int AbilityId { get; set; }

        public virtual Ability Ability { get; set; }

        public int Points { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
