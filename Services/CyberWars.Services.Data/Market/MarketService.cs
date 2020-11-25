namespace CyberWars.Services.Data.Market
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Services.Mapping;
    using CyberWars.Data.Models.Player;

    public class MarketService : IMarketService
    {
        private readonly IDeletableEntityRepository<Pet> petRepository;

        private readonly IDeletableEntityRepository<Food> foodRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<PlayerFood> playerFoodRepository;

        public MarketService(IDeletableEntityRepository<Pet> petRepository, IDeletableEntityRepository<Food> foodRepository
            , IDeletableEntityRepository<Player> playerRepository
           , IDeletableEntityRepository<PlayerFood> playerFoodRepository)
        {
            this.petRepository = petRepository;
            this.foodRepository = foodRepository;
            this.playerRepository = playerRepository;
            this.playerFoodRepository = playerFoodRepository;
        }

        public async Task<IEnumerable<T>> GetAllFood<T>()
        {
            return await this.foodRepository.All().To<T>().ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAllPets<T>()
        {
            return await this.petRepository.All().To<T>().ToListAsync();
        }

        public async Task BuyPet(int petId, string userId, string nameIt)
        {
            var pet = await this.petRepository.All().FirstOrDefaultAsync(x => x.Id == petId);

            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            // Create PlayerPet
            var playerPet = new PlayerPet
            {
                PetId = pet.Id,
                PlayerId = player.Id,
                Health = 100,
                MaxHealth=100,
                Mood = 100,
                MaxMood=100,
                Level = 1,
                NameIt = nameIt,
            };

            var petPrice = pet.Price;
            var playerMoney = player.Money;

            // If player doesn't have enoughmoney ot buy it error
            if (playerMoney < petPrice)
            {
                return;
            }

            // Check if the player already have that pet
            if (player.PlayerPets.Any(x => x.PetId == petId))
            {
                return;
            }

            player.Money -= petPrice;
            player.PlayerPets.Add(playerPet);

            this.playerRepository.Update(player);
            await this.playerRepository.SaveChangesAsync();

        }

        public async Task BuyFood(int foodId, string userId)
        {
            var food = await this.foodRepository.All().FirstOrDefaultAsync(x => x.Id == foodId);

            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            var foodPrice = food.Price;
            var playerMoney = player.Money;

            if (playerMoney < foodPrice)
            {
                return;
            }

            player.Money -= food.Price;

            if (this.playerFoodRepository.All().Any(x => x.PlayerId == player.Id && x.FoodId == food.Id))
            {
                var getPlayerFood = await this.playerFoodRepository.All().FirstOrDefaultAsync(x => x.PlayerId == player.Id && x.FoodId == food.Id);

                getPlayerFood.Quantity++;
                this.playerFoodRepository.Update(getPlayerFood);
            }
            else
            {
                var playerFood = new PlayerFood
                {
                    Player = player,
                    Food = food,
                    PlayerId = player.Id,
                    FoodId = food.Id,
                    Quantity = 1,
                };
                await this.playerFoodRepository.AddAsync(playerFood);
            }

            await this.playerFoodRepository.SaveChangesAsync();

            await this.playerRepository.SaveChangesAsync();
        }
    }
}
