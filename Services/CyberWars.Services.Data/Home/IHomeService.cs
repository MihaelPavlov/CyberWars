namespace CyberWars.Services.Data.Home
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Battle;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Web.ViewModels.HomeViews;
    using CyberWars.Web.ViewModels.HomeViews.Pet;

    public interface IHomeService
    {
        public Task<ApplicationUser> GetUserById(string userId);

        public Task<PlayerDataView> GetPlayerData(string userId);

        public Task<PlayerSkill> GetPlayerSkillByName(string name, string userId);

        public Task<IEnumerable<T>> GetPlayerSkills<T>(string userId);

        public Task TrainSkillByName(string userId, string skillName);

        public Task<BattleRecord> GetPlayerBattleRecordByPlayerName(string name);

        public Task<IEnumerable<T>> GetPlayerAbilitiesByType<T>(string playerId, string type);

        public Task<IEnumerable<T>> GetAllBadges<T>();

        public Task<BadgesViewModel> GetAllRequirementForBadgeById(int badgeId);

        public Task<IEnumerable<T>> GetPlayerPets<T>(string userId);

        public Task<IEnumerable<T>> GetPetRandomFood<T>(int petId);

        public Task<PetViewModel> GetPetById(string userId, int petId);

        public Task FeedPetById(int foodId, int petId, string userId);

        public Task ChangePetName(string newName, int petId, string userId);

        public Task ScratchPetBelly(int petId, string userId);

        public Task SellPetById(int petId, string userId);

        public Task<PlayerDataView> GetPlayerViewData(string playerName);

        public Task CompleteBadge(int badgeId, string userId);
    }
}
