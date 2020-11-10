namespace CyberWars.Data.Models.Pet_Food
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Pet
    {
        public Pet()
        {
            this.PlayerPets = new HashSet<PlayerPet>();

        }

        [Key]
        public int PetId { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int LevelRequirement { get; set; }

        public virtual ICollection<PlayerPet> PlayerPets { get; set; }
    }
}
