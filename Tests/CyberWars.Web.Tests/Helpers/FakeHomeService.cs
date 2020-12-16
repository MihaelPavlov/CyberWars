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
    using CyberWars.Web.ViewModels.HomeViews.Pet;

    public class FakeHomeService : IHomeService
    {
        public async Task ChangePetName(string newName, int petId, string userId)
        {

        }

        public Task CompleteBadge(int badgeId, string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task FeedPetById(int foodId, int petId, string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllBadges<T>()
        {
            var result = new List<BadgesViewModel>
            {
                new BadgesViewModel{ Id=1 },
                new BadgesViewModel{ Id=2 },
                new BadgesViewModel{ Id=3 },
                new BadgesViewModel{ Id=4 },
            };
            return (IEnumerable<T>)await Task.FromResult(result);
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

        public async Task<BadgesViewModel> GetAllRequirementForBadgeById(int badgeId)
        {
            var result = new BadgesViewModel
            {
                Id = 1,
                BadgeRequirements = new List<BadgeRequirementsViewModel>
                {
                        new BadgeRequirementsViewModel{ BadgeId = 1, RequirementId = 1,},
                        new BadgeRequirementsViewModel{ BadgeId = 1, RequirementId = 2,},
                        new BadgeRequirementsViewModel{ BadgeId = 1, RequirementId = 3,},
                },

            };
            BadgesViewModel badgesViewModel = await Task.FromResult(result);
            return badgesViewModel;
        }

        public async Task<PetViewModel> GetPetById(string userId, int petId)
        {
            var result = new PetViewModel
            {
                PetId = 1,
            };

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<T>> GetPetRandomFood<T>(int petId)
        {
            var result = new List<FoodViewModel>
            {
                new FoodViewModel{FoodId=1,},
                new FoodViewModel{FoodId=1,},
                new FoodViewModel{FoodId=1,},
                new FoodViewModel{FoodId=1,},
            };

            return (IEnumerable<T>)await Task.FromResult(result);
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


        public async Task<IEnumerable<T>> GetPlayerPets<T>(string userId)
        {
            var result = new List<PetViewModel>
            {
                new PetViewModel{PetId = 1},
                new PetViewModel{PetId = 2,},
                new PetViewModel{PetId = 3,},
                new PetViewModel{PetId = 4},
            };
            return (IEnumerable<T>)await Task.FromResult(result);
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

        public async Task<PlayerDataView> GetPlayerViewData(string playerName)
        {
            var result = new PlayerDataView
            {
                Id = "Test",
                UserId = "TestUser",
            };

            return await Task.FromResult(result);
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return new ApplicationUser { Id = "TestUser", PlayerId = "Test" };
        }

        public async Task ScratchPetBelly(int petId, string userId)
        {

        }

        public async Task SellPetById(int petId, string userId)
        {

        }

        public async Task TrainSkillByName(string userId, string skillName)
        {

        }
    }
}
