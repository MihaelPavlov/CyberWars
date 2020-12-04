namespace CyberWars.Services.Data.Hangfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Common.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class UpdatePetFavouriteFoodService
    {
        private readonly IDeletableEntityRepository<Food> foodRepository;
        private readonly IDeletableEntityRepository<Pet> petRepository;
        private readonly IDeletableEntityRepository<RandomHangfireFood> randomHangfireFoodRepository;

        public UpdatePetFavouriteFoodService(IDeletableEntityRepository<Food> foodRepository, IDeletableEntityRepository<Pet> petRepository
          , IDeletableEntityRepository<RandomHangfireFood> randomHangfireFoodRepository)
        {
            this.foodRepository = foodRepository;
            this.petRepository = petRepository;
            this.randomHangfireFoodRepository = randomHangfireFoodRepository;
        }

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
