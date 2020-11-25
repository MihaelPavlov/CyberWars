namespace CyberWars.Web.ViewModels.HomeViews.Pet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Services.Mapping;

    public class PetViewModel : IMapFrom<PlayerPet>
    {
        public PetViewModel()
        {
            this.Foods = new HashSet<FoodViewModel>();
        }

        public int PetId { get; set; }

        public string PetName { get; set; }

        public string PetImageName { get; set; }

        public string PetDescription { get; set; }

        public int Level { get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public int Mood { get; set; }

        public int MaxMood { get; set; }

        public string NameIt { get; set; }

        public decimal PetPrice { get; set; }

        public int PetLevelRequirement { get; set; }

        public IEnumerable<FoodViewModel> Foods { get; set; }
    }
}
