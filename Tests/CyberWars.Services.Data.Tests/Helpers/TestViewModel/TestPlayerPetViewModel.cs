using CyberWars.Data.Models.Pet_Food;
using CyberWars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel
{
    public class TestPlayerPetViewModel : IMapFrom<PlayerPet>
    {
        public TestPlayerPetViewModel()
        {
            this.Foods = new HashSet<TestFoodViewModel>();
        }

        public int PetId { get; set; }

        public string PlayerId { get; set; }

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

        public IEnumerable<TestFoodViewModel> Foods { get; set; }
    }
}
