namespace CyberWars.Services.Data.Market
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Pet_Food;

    public interface IMarketService
    {
        /// <summary>
        /// Use this method to get all pets.
        /// </summary>
        /// <returns>A collection of T.</returns>
        public Task<IEnumerable<T>> GetAllPets<T>();

        /// <summary>
        /// Use this method to get all foods.
        /// </summary>
        /// <returns>A collection of T.</returns>
        public Task<IEnumerable<T>> GetAllFood<T>();

        /// <summary>
        /// Use this method to get all pets that player has.
        /// </summary>
        /// <param name="playerId">A string representing the Id of the player.</param>
        /// <returns>A collection of models <see cref="PlayerPet"/>.</returns>
        public Task<IEnumerable<PlayerPet>> GetAllPlayerPets(string playerId);

        /// <summary>
        /// Use this method to get all foods that player has.
        /// </summary>
        /// <param name="playerId">A string representing the Id of the player.</param>
        /// <returns>A collection of models <see cref="PlayerPet"/>.</returns>
        public Task<IEnumerable<PlayerFood>> GetAllPlayerFood(string playerId);

        /// <summary>
        /// Use this method to buy pet.
        /// </summary>
        /// <param name="petId">A integer representing the Id of the pet that we want to buy.</param>
        /// <param name="userId">A string representing the Id of the user.</param>
        /// <param name="nameIt">A string representing the name of the pet.</param>
        public Task BuyPet(int petId, string userId, string nameIt);

        /// <summary>
        /// Use this method to buy food.
        /// </summary>
        /// <param name="foodId">A integer representing the Id of the food that we want to buy.</param>
        /// <param name="userId">A string representing the Id of the user.</param>
        public Task BuyFood(int foodId, string userId);
    }
}
