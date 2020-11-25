namespace CyberWars.Data.Models.Pet_Food
{
    using System;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class PlayerPet : IDeletableEntity
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }

        public int Level { get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public int Mood { get; set; }

        public int MaxMood { get; set; }

        public string NameIt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
