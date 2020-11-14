namespace CyberWars.Services.Data.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Badge;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Services.Mapping;
    using CyberWars.Web.ViewModels.HomeViews;
    using CyberWars.Web.ViewModels.HomeViews.Pet;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<PlayerSkill> playerSkillRepository;
        private readonly IDeletableEntityRepository<PlayerAbility> playerAbilityRepository;
        private readonly IDeletableEntityRepository<Badge> badgeRepository;
        private readonly IDeletableEntityRepository<BadgeRequirement> badgeRequirementRepository;
        private readonly IDeletableEntityRepository<PlayerPet> playerPetRepository;
        private readonly IDeletableEntityRepository<Food> foodRepository;

        public HomeService(IDeletableEntityRepository<Player> playerRepository
            , IDeletableEntityRepository<PlayerSkill> playerSkillRepository
            , IDeletableEntityRepository<PlayerAbility> playerAbilityRepository
            , IDeletableEntityRepository<ApplicationUser> userRepository
            , IDeletableEntityRepository<Badge> badgeRepository
            , IDeletableEntityRepository<BadgeRequirement> badgeRequirementRepository
            , IDeletableEntityRepository<PlayerPet> playerPetRepository
            , IDeletableEntityRepository<Food> foodRepository)
        {
            this.playerRepository = playerRepository;
            this.playerSkillRepository = playerSkillRepository;
            this.playerAbilityRepository = playerAbilityRepository;
            this.userRepository = userRepository;
            this.badgeRepository = badgeRepository;
            this.badgeRequirementRepository = badgeRequirementRepository;
            this.playerPetRepository = playerPetRepository;
            this.foodRepository = foodRepository;
        }

        public async Task<T> GetPlayerData<T>(string userId)
        {
            // Get The Player with userId 
            return await this.playerRepository
                .All()
                .Where(x => x.UserId == userId)
                .To<T>()
                .FirstAsync();

            // return await this.playerRepository.All().FirstOrDefault(x => x.UserId == userId);
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<IEnumerable<T>> GetPlayerSkills<T>(string userId)
        {
            return await this.playerSkillRepository.All().Where(x => x.Player.UserId == userId).To<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetPlayerAbilitiesByType<T>(string playerId, string type)
        {
            return await this.playerAbilityRepository.All().Where(x => x.PlayerId == playerId && x.Ability.AbilityType.Type == type).OrderByDescending(x => x.Points).To<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllBadges<T>()
        {
            return await this.badgeRepository.All().To<T>().ToListAsync();
        }

        public async Task<T> GetAllRequirementForBadgeById<T>(int badgeId)
        {
            return await this.badgeRepository.All().Where(x => x.Id == badgeId).To<T>().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetPlayerPets<T>(string userId)
        {
            return await this.playerPetRepository.All().Where(x => x.Player.UserId == userId).To<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetPetRandomFood<T>()
        {
            var allFood = await this.foodRepository.All().To<T>().ToListAsync();
            int foodCountPetDay = 3;
            var randomFood = new List<T>();
            for (int i = 1; i <= foodCountPetDay; i++)
            {
                int index = new Random().Next(allFood.Count());
                randomFood.Add(allFood[index]);
            }

            return randomFood;
        }

        public async Task<T> GetPetById<T>(string userId, int petId)
        {
            return await this.playerPetRepository.All().Where(x => x.Player.UserId == userId && x.PetId == petId).To<T>().FirstOrDefaultAsync();
        }
    }
}
