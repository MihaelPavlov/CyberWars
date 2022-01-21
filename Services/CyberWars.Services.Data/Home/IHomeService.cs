namespace CyberWars.Services.Data.Home
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Battle;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Web.ViewModels.HomeViews;
    using CyberWars.Web.ViewModels.HomeViews.Pet;

    /// <summary>
    /// Defines an interface for a service that will handle operations related to home.
    /// </summary>
    public interface IHomeService
    {
        /// <summary>
        /// Use this method to get application user by Id.
        /// </summary>
        /// <param name="userId">A string that contains user Id.</param>
        /// <returns>A view model <see cref="ApplicationUser"/>.</returns>
        public Task<ApplicationUser> GetUserById(string userId);

        /// <summary>
        /// Use this method to get data for the player by user Id.
        /// </summary>
        /// <param name="userId">A string that contains user Id.</param>
        /// <returns>A view model <see cref="PlayerDataView"/>.</returns>
        public Task<PlayerDataView> GetPlayerData(string userId);

        /// <summary>
        /// Use this method to get player skill by name.
        /// </summary>
        /// <param name="name">A string that contains the skill name.</param>
        /// <param name="userId">A string that contains the user Id.</param>
        /// <returns>A view model <see cref="PlayerSkill"/>.</returns>
        public Task<PlayerSkill> GetPlayerSkillByName(string name, string userId);

        /// <summary>
        /// Use this method to get all player skills by user Id.
        /// </summary>
        /// <param name="userId">A string representing the user Id.</param>
        /// <returns>A collection of T.</returns>
        public Task<IEnumerable<T>> GetPlayerSkills<T>(string userId);

        /// <summary>
        /// Use this method to train selected skill by name.
        /// </summary>
        /// <param name="userId">A string representing the user Id.</param>
        /// <param name="skillName">A string representing the skill name.</param>
        public Task TrainSkillByName(string userId, string skillName);


        /// <summary>
        /// Use this method to get battle record by player name.
        /// </summary>
        /// <param name="name">A string representing the player name.</param>
        /// <returns>A model <see cref="BattleRecord"/>.</returns>
        public Task<BattleRecord> GetPlayerBattleRecordByPlayerName(string name);

        /// <summary>
        /// Use this method to get collection of abilities by type.
        /// </summary>
        /// <param name="playerId">A string representing the player Id.</param>
        /// <param name="type">A string representing the ability type.</param>
        /// <returns>A collection of T.</returns>
        public Task<IEnumerable<T>> GetPlayerAbilitiesByType<T>(string playerId, string type);

        /// <summary>
        /// Use this method to get all badges.
        /// </summary>
        /// <returns>A collection of T.</returns>
        public Task<IEnumerable<T>> GetAllBadges<T>();

        /// <summary>
        /// Use this method to get all badges requirements by badge Id.
        /// </summary>
        /// <param name="badgeId">A integer representing the badge Id.</param>
        /// <returns>A view model <see cref="BadgesViewModel"/>.</returns>
        public Task<BadgesViewModel> GetAllRequirementForBadgeById(int badgeId);

        /// <summary>
        /// Use this method to complete badge.
        /// Badge is complete when you have all requirements.
        /// </summary>
        /// <param name="badgeId">A integer representing the badge Id.</param>
        /// <param name="userId">A string representing the user Id.</param>
        public Task CompleteBadge(int badgeId, string userId);

        /// <summary>
        /// Use this method to get player pets by user Id.
        /// </summary>
        /// <param name="userId">A string representing the user Id.</param>
        /// <returns>A collection of T.</returns>
        public Task<IEnumerable<T>> GetPlayerPets<T>(string userId);

        /// <summary>
        /// Use this method to get pet random food.That change automatcly from hangfire.
        /// </summary>
        /// <param name="petId">A integer representing the pet Id.</param>
        /// <returns>A collection of T.</returns>
        public Task<IEnumerable<T>> GetPetRandomFood<T>(int petId);

        /// <summary>
        /// Use this method to get pet by Id.
        /// </summary>
        /// <param name="userId">A string representing the user Id.</param>
        /// <param name="petId">A integer representing the pet Id that we want to get.</param>
        /// <returns>A view model <see cref="PetViewModel"/>.</returns>
        public Task<PetViewModel> GetPetById(string userId, int petId);

        /// <summary>
        /// Use this method to feed pet by Id.
        /// </summary>
        /// <param name="foodId">A integer representing the identifier of the food we want to give to the pet.</param>
        /// <param name="petId">A integer representing the identifier of the pet we want to give food.</param>
        /// <param name="userId">A string representing currently login user Id.</param>
        public Task FeedPetById(int foodId, int petId, string userId);

        /// <summary>
        /// Use this method to rename pet.
        /// </summary>
        /// <param name="newName">A string respresenting the new name of the pet.</param>
        /// <param name="petId">A integer representing the ID of the pet we want to rename.</param>
        /// <param name="userId">A string representing currently login user Id.</param>
        public Task ChangePetName(string newName, int petId, string userId);

        /// <summary>
        /// Use this method to scratch pet belly.
        /// </summary>
        /// <param name="petId">A integer representing the ID of the pet we want to scratch on the belly.</param>
        /// <param name="userId">A string representing currently login user Id.</param>
        public Task ScratchPetBelly(int petId, string userId);

        /// <summary>
        /// Use this method to sell pet.
        /// </summary>
        /// <param name="petId">A integer representing the ID of the pet we want to sell/remove.</param>
        /// <param name="userId">A string representing currently login user Id.</param>
        public Task SellPetById(int petId, string userId);

        /// <summary>
        /// Use this method to get full information about player.
        /// </summary>
        /// <param name="playerName">A string representing the player name that we want to see.</param>
        /// <returns>A view model <see cref="PlayerDataView"/>.</returns>
        public Task<PlayerDataView> GetPlayerViewData(string playerName);
    }
}
