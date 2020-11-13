namespace CyberWars.Services.Data.Market
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMarketService
    {
        public Task<IEnumerable<T>> GetAllPets<T>();

        public Task<IEnumerable<T>> GetAllFood<T>();

        public Task BuyPet(int petId, string userId,string nameIt);
    }
}
