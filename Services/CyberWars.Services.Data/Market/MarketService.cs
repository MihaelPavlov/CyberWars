namespace CyberWars.Services.Data.Market
{
    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using CyberWars.Data.Models.Player;

    public class MarketService : IMarketService
    {
        private readonly IDeletableEntityRepository<Pet> petRepository;

        private readonly IDeletableEntityRepository<Food> foodRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;

        public MarketService(IDeletableEntityRepository<Pet> petRepository, IDeletableEntityRepository<Food> foodRepository, IDeletableEntityRepository<Player> playerRepository)
        {
            this.petRepository = petRepository;
            this.foodRepository = foodRepository;
            this.playerRepository = playerRepository;
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
                Mood = 100,
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
    }
}
