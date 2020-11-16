namespace CyberWars.Services.Data.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Web.ViewModels.HomeViews;

    public interface IHomeService
    {
        public Task<ApplicationUser> GetUserById(string userId);

        public Task<T> GetPlayerData<T>(string userId);

        public Task<IEnumerable<T>> GetPlayerSkills<T>(string userId);

        public Task<IEnumerable<T>> GetPlayerAbilitiesByType<T>(string playerId, string type);

        public Task<IEnumerable<T>> GetAllBadges<T>();

        public Task<T> GetAllRequirementForBadgeById<T>(int badgeId);

        public Task<IEnumerable<T>> GetPlayerPets<T>(string userId);

        public Task<IEnumerable<T>> GetPetRandomFood<T>();

        public Task<T> GetPetById<T>(string userId, int petId);

        public Task FeedPetById(int foodId, int petId, string userId);
    }
}
