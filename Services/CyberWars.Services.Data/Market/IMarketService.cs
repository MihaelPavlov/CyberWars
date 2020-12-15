namespace CyberWars.Services.Data.Market
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Pet_Food;

    public interface IMarketService
    {
        public Task<IEnumerable<T>> GetAllPets<T>();

        public Task<IEnumerable<T>> GetAllFood<T>();

        public Task<IEnumerable<PlayerPet>> GetAllPlayerPets(string playerId);

        public Task<IEnumerable<PlayerFood>> GetAllPlayerFood(string playerId);

        public Task BuyPet(int petId, string userId, string nameIt);

        public Task BuyFood(int foodId, string userId);
    }
}
