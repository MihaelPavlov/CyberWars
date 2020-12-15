namespace CyberWars.Web.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Battle;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Services.Data.Home;
    using CyberWars.Web.ViewModels.HomeViews;

    public class FakeHomeService : IHomeService
    {
        public Task ChangePetName(string newName, int petId, string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task CompleteBadge(int badgeId, string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task FeedPetById(int foodId, int petId, string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllBadges<T>()
        {
            throw new System.NotImplementedException();
        }

        public async Task<PlayerDataView> GetPlayerData(string userId)
            => await Task.FromResult(new PlayerDataView
            {
                Id = "Test",
                UserId = "TestUser",
                Name = "Kilerabg",
                Level = 1,
                Class = "Programmer",
                Energy = 100,
                MaxEnergy = 100,
                Health = 1000,
                MaxHealth = 1000,
            });

        public Task<T> GetAllRequirementForBadgeById<T>(int badgeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetPetById<T>(string userId, int petId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetPetRandomFood<T>(int petId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetPlayerAbilitiesByType<T>(string playerId, string type)
        {
            var result = new List<PlayerAbilitiesViewModel>
            {
                new PlayerAbilitiesViewModel{PlayerId="Test" , AbilityId=1 },
                new PlayerAbilitiesViewModel{PlayerId="Test" , AbilityId=2 },
                new PlayerAbilitiesViewModel{PlayerId="Test" , AbilityId=3 },
                new PlayerAbilitiesViewModel{PlayerId="Test" , AbilityId=4 },
            };
            return (IEnumerable<T>)await Task.FromResult(result);

        }

        public Task<BattleRecord> GetPlayerBattleRecordByPlayerName(string name)
        {
            throw new System.NotImplementedException();
        }


        public Task<IEnumerable<T>> GetPlayerPets<T>(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<PlayerSkill> GetPlayerSkillByName(string name, string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetPlayerSkills<T>(string userId)
        {

            var result = new List<PlayerSkillViewModel>
                {
                    new PlayerSkillViewModel{PlayerId="Test",SkillId=1,},
                    new PlayerSkillViewModel{PlayerId="Test",SkillId=2,},
                    new PlayerSkillViewModel{PlayerId="Test",SkillId=3,},
                };

            return (IEnumerable<T>)await Task.FromResult(result);
        }

        public Task<PlayerDataView> GetPlayerViewData(string playerName)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return new ApplicationUser { Id = "TestUser", PlayerId = "Test" };
        }

        public Task ScratchPetBelly(int petId, string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task SellPetById(int petId, string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task TrainSkillByName(string userId, string skillName)
        {

        }
    }
}
