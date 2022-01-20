namespace CyberWars.Services.Data.Hangfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Pet_Food;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Use this class to update pet favourite food on every n hour.
    /// </summary>
    public class UpdatePetFavouriteFoodService
    {
        private readonly IDeletableEntityRepository<Food> foodRepository;
        private readonly IDeletableEntityRepository<Pet> petRepository;
        private readonly IDeletableEntityRepository<RandomHangfireFood> randomHangfireFoodRepository;

        /// <summary>
        /// Constructor that instantiates UpdatePetFavouriteFoodService.
        /// </summary>
        public UpdatePetFavouriteFoodService(
            IDeletableEntityRepository<Food> foodRepository,
            IDeletableEntityRepository<Pet> petRepository,
            IDeletableEntityRepository<RandomHangfireFood> randomHangfireFoodRepository)
        {
            this.foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
            this.petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
            this.randomHangfireFoodRepository = randomHangfireFoodRepository ?? throw new ArgumentNullException(nameof(randomHangfireFoodRepository));
        }

        /// <summary>
        /// Use this method to change every n hours the pet favourite food.
        /// </summary>
        public async Task ChangePetFavouriteFoodEveryDay()
        {
            var allPets = await this.petRepository.All().ToListAsync();

            foreach (var pet in allPets)
            {
                var randomFoodForPet = await this.randomHangfireFoodRepository.All().Where(x => x.PetId == pet.Id).ToListAsync();

                foreach (var food in randomFoodForPet)
                {
                    this.randomHangfireFoodRepository.Delete(food);
                }

                var randomFoods = await this.GetRandomFood();

                foreach (var randomFood in randomFoods)
                {
                    var randomHangfireFood = new RandomHangfireFood
                    {
                        Pet = pet,
                        PetId = pet.Id,
                        Food = randomFood,
                        FoodId = randomFood.Id,
                    };
                    await this.randomHangfireFoodRepository.AddAsync(randomHangfireFood);
                }
            }

            await this.randomHangfireFoodRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Helper method.
        /// </summary>
        /// <returns>A collection of food.</returns>
        public async Task<IEnumerable<Food>> GetRandomFood()
        {
            var allFood = await this.foodRepository.All().ToListAsync();
            int foodCountPetDay = 3;
            var randomFood = new List<Food>();
            for (int i = 1; i <= foodCountPetDay; i++)
            {
                int index = new Random().Next(allFood.Count());
                randomFood.Add(allFood[index]);
            }

            return randomFood;
        }
    }
}
