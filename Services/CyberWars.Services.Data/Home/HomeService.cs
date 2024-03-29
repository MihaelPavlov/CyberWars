﻿namespace CyberWars.Services.Data.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Badge;
    using CyberWars.Data.Models.Battle;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Data.Models.Teams;
    using CyberWars.Services.Mapping;
    using CyberWars.Web.ViewModels.Battle;
    using CyberWars.Web.ViewModels.HomeViews;
    using CyberWars.Web.ViewModels.HomeViews.Pet;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// A custom implementation of <see cref="IHomeService"/>.
    /// </summary>
    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<PlayerSkill> playerSkillRepository;
        private readonly IDeletableEntityRepository<Skill> skillRepository;
        private readonly IDeletableEntityRepository<PlayerAbility> playerAbilityRepository;
        private readonly IDeletableEntityRepository<Badge> badgeRepository;
        private readonly IDeletableEntityRepository<BadgeRequirement> badgeRequirementRepository;
        private readonly IDeletableEntityRepository<PlayerPet> playerPetRepository;
        private readonly IDeletableEntityRepository<Food> foodRepository;
        private readonly IDeletableEntityRepository<Pet> petRepository;
        private readonly IDeletableEntityRepository<PlayerFood> playerFoodRepository;
        private readonly IDeletableEntityRepository<BattleRecord> battleRecordRepository;
        private readonly IDeletableEntityRepository<RandomHangfireFood> randomHangfireFoodRepository;
        private readonly IDeletableEntityRepository<PlayerBadge> playerBadgeRepository;
        private readonly IDeletableEntityRepository<TeamPlayer> teamPlayerRepository;
        private readonly IDeletableEntityRepository<Team> teamRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeService"/> class.
        /// </summary>
        public HomeService(
            IDeletableEntityRepository<Player> playerRepository,
            IDeletableEntityRepository<PlayerSkill> playerSkillRepository,
            IDeletableEntityRepository<PlayerAbility> playerAbilityRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Badge> badgeRepository,
            IDeletableEntityRepository<BadgeRequirement> badgeRequirementRepository,
            IDeletableEntityRepository<PlayerPet> playerPetRepository,
            IDeletableEntityRepository<Food> foodRepository,
            IDeletableEntityRepository<Pet> petRepository,
            IDeletableEntityRepository<PlayerFood> playerFoodRepository,
            IDeletableEntityRepository<BattleRecord> battleRecordRepository,
            IDeletableEntityRepository<Skill> skillRepository,
            IDeletableEntityRepository<RandomHangfireFood> randomHangfireFoodRepository,
            IDeletableEntityRepository<PlayerBadge> playerBadgeRepository,
            IDeletableEntityRepository<TeamPlayer> teamPlayerRepository,
            IDeletableEntityRepository<Team> teamRepository)
        {
            this.playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            this.playerSkillRepository = playerSkillRepository ?? throw new ArgumentNullException(nameof(playerSkillRepository));
            this.playerAbilityRepository = playerAbilityRepository ?? throw new ArgumentNullException(nameof(playerAbilityRepository));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.badgeRepository = badgeRepository ?? throw new ArgumentNullException(nameof(badgeRepository));
            this.badgeRequirementRepository = badgeRequirementRepository ?? throw new ArgumentNullException(nameof(badgeRequirementRepository));
            this.playerPetRepository = playerPetRepository ?? throw new ArgumentNullException(nameof(playerPetRepository));
            this.foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
            this.petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
            this.playerFoodRepository = playerFoodRepository ?? throw new ArgumentNullException(nameof(playerFoodRepository));
            this.battleRecordRepository = battleRecordRepository ?? throw new ArgumentNullException(nameof(battleRecordRepository));
            this.skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
            this.randomHangfireFoodRepository = randomHangfireFoodRepository ?? throw new ArgumentNullException(nameof(randomHangfireFoodRepository));
            this.playerBadgeRepository = playerBadgeRepository ?? throw new ArgumentNullException(nameof(playerBadgeRepository));
            this.teamPlayerRepository = teamPlayerRepository ?? throw new ArgumentNullException(nameof(teamPlayerRepository));
            this.teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        /// <inheritdoc />
        public async Task<PlayerDataView> GetPlayerData(string userId)
        {
            var player = await this.playerRepository
                .All()
                .FirstOrDefaultAsync(x => x.UserId == userId);

            var playerData = new PlayerDataView
            {
                Id = player.Id,
                Name = player.Name,
                UserId = player.UserId,
                Experience = player.Experience,
                Class = player.Class,
                ImageName = player.ImageName,
                Health = player.Health,
                MaxHealth = player.MaxHealth,
                Energy = player.Energy,
                MaxEnergy = player.MaxEnergy,
                Money = player.Money,
                LearnPoint = player.LearnPoint,
                Level = player.Level,
                IsStatsResetStart = player.IsStatsResetStart,
            };

            return playerData;
        }

        /// <inheritdoc />
        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == userId);
        }

        /// <inheritdoc />
        public async Task<PlayerSkill> GetPlayerSkillByName(string name, string userId)
        {
            return await this.playerSkillRepository.All().FirstOrDefaultAsync(x => x.Skill.Name == name && x.Player.UserId == userId);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetPlayerSkills<T>(string userId)
        {
            return await this.playerSkillRepository.All().Where(x => x.Player.UserId == userId).To<T>().ToListAsync();
        }

        /// <inheritdoc />
        public async Task TrainSkillByName(string userId, string skillName)
        {
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);
            var playerSkill = await this.playerSkillRepository.All().FirstOrDefaultAsync(x => x.Player.UserId == userId && x.Skill.Name == skillName);
            var playerBattleRecord = await this.battleRecordRepository.All().FirstOrDefaultAsync(x => x.PlayerId == player.Id);

            var multipleNumber = 0.20M;

            var newAddMoneyToPlayerSkill = (decimal)playerSkill.Money * multipleNumber;
            if (player.Money < playerSkill.Money)
            {
                return;
            }

            player.Money -= playerSkill.Money;

            playerSkill.Money += (int)newAddMoneyToPlayerSkill;
            playerSkill.Points++;

            // Add Stats To player

            // Health
            if (skillName == "Health")
            {
                var addHealth = 10;

                player.MaxHealth += addHealth;
            }
            else if (skillName == "Staying Power")
            {
                var addEnergy = 5;

                player.MaxEnergy += addEnergy;
            }
            else if (skillName == "Cunning")
            {
                var addStealPetBattleMoney = 5;
                playerBattleRecord.StealPerBattle += addStealPetBattleMoney;
            }

            this.playerSkillRepository.Update(playerSkill);
            this.playerRepository.Update(player);
            this.battleRecordRepository.Update(playerBattleRecord);

            await this.battleRecordRepository.SaveChangesAsync();
            await this.playerSkillRepository.SaveChangesAsync();
            await this.playerRepository.SaveChangesAsync();

            // Update Team Rank if Player up skills
            if (await this.IsPlayerApplyInGroup(player.Id))
            {
                var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.TeamPlayers.Any(x => x.PlayerId == player.Id));
                team.Rank++;
                this.teamRepository.Update(team);
            }

            if (await this.IsUserHaveGroup(userId))
            {
                var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);
                team.Rank++;
                this.teamRepository.Update(team);
            }

            await this.teamRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<BattleRecord> GetPlayerBattleRecordByPlayerName(string name)
        {
            return await this.battleRecordRepository.All().FirstOrDefaultAsync(x => x.Player.Name == name);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetPlayerAbilitiesByType<T>(string playerId, string type)
        {
            return await this.playerAbilityRepository.All().Where(x => x.PlayerId == playerId && x.Ability.AbilityType.Type == type).OrderByDescending(x => x.Points).To<T>().ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetAllBadges<T>()
        {
            return await this.badgeRepository.All().To<T>().ToListAsync();
        }

        /// <inheritdoc />
        public async Task<BadgesViewModel> GetAllRequirementForBadgeById(int badgeId)
        {
            return await this.badgeRepository.All().Where(x => x.Id == badgeId).To<BadgesViewModel>().FirstOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task CompleteBadge(int badgeId, string userId)
        {
            var badge = await this.badgeRepository.All().FirstOrDefaultAsync(x => x.Id == badgeId);

            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            var playerBadges = await this.playerBadgeRepository.All().Where(x => x.Player.UserId == userId).ToListAsync();

            if (playerBadges.Any(x => x.BadgeId == badgeId))
            {
                return;
            }
            else
            {
                var playerBadge = new PlayerBadge
                {
                    PlayerId = player.Id,
                    BadgeId = badge.Id,
                    AchievementDate = DateTime.UtcNow,
                };

                await this.playerBadgeRepository.AddAsync(playerBadge);
                await this.playerBadgeRepository.SaveChangesAsync();
            }
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetPlayerPets<T>(string userId)
        {
            return await this.playerPetRepository.All().Where(x => x.Player.UserId == userId).To<T>().ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetPetRandomFood<T>(int petId)
        {
            return await this.randomHangfireFoodRepository.All().Where(x => x.PetId == petId).To<T>().ToListAsync();
        }

        /// <inheritdoc />
        public async Task<PetViewModel> GetPetById(string userId, int petId)
        {
            return await this.playerPetRepository.All().Where(x => x.Player.UserId == userId && x.PetId == petId).To<PetViewModel>().FirstOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task FeedPetById(int foodId, int petId, string userId)
        {
            var food = await this.foodRepository.All().FirstOrDefaultAsync(x => x.Id == foodId);
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            var playerPet = await this.playerPetRepository.All().FirstOrDefaultAsync(x => x.PetId == petId && x.PlayerId == player.Id);
            var playerFood = await this.playerFoodRepository.All().FirstOrDefaultAsync(x => x.PlayerId == player.Id && x.FoodId == foodId);

            var petFavouriteFood = await this.randomHangfireFoodRepository.All().Where(x => x.PetId == playerPet.PetId).ToListAsync();

            playerFood.Food = food;

            // If you feed your pet with his favourite food you will give him +10 mood
            if (petFavouriteFood.Any(x => x.FoodId == food.Id))
            {
                var bonusMood = 10;
                playerPet.Mood += bonusMood;

                if (playerPet.Mood > playerPet.MaxMood)
                {
                    playerPet.Mood = playerPet.MaxMood;
                }
            }

            playerPet.Health += playerFood.Food.GainHealth;

            if (playerPet.Health > playerPet.MaxHealth)
            {
                playerPet.Health = playerPet.MaxHealth;
            }

            this.playerPetRepository.Update(playerPet);

            // Delete PlayerFood and Save
            playerFood.Quantity--;
            this.playerFoodRepository.Update(playerFood);

            await this.playerFoodRepository.SaveChangesAsync();
            await this.playerPetRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task ChangePetName(string newName, int petId, string userId)
        {
            var playerPet = await this.playerPetRepository.All().FirstOrDefaultAsync(x => x.Player.UserId == userId && x.PetId == petId);

            playerPet.NameIt = newName;

            this.playerPetRepository.Update(playerPet);
            await this.playerPetRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task ScratchPetBelly(int petId, string userId)
        {
            var playerPet = await this.playerPetRepository.All().FirstOrDefaultAsync(x => x.Player.UserId == userId && x.PetId == petId);

            playerPet.Mood += 40;

            if (playerPet.Mood > playerPet.MaxMood)
            {
                playerPet.Mood = playerPet.MaxMood;
            }

            this.playerPetRepository.Update(playerPet);
            await this.playerPetRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task SellPetById(int petId, string userId)
        {
            var playerPet = await this.playerPetRepository.All().FirstOrDefaultAsync(x => x.Player.UserId == userId && x.PetId == petId);

            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);
            var pet = await this.petRepository.All().FirstOrDefaultAsync(x => x.Id == petId);

            player.Money += pet.Price;
            this.playerPetRepository.HardDelete(playerPet);

            await this.playerPetRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<PlayerDataView> GetPlayerViewData(string playerName)
        {
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.Name == playerName);
            if (player == null)
            {
                return null;
            }

            // PlayerSkills
            var playerSkills = await this.playerSkillRepository.All().Where(x => x.PlayerId == player.Id).ToListAsync();

            var playerSkillViewData = new List<PlayerSkillViewModel>();

            foreach (var skill in playerSkills)
            {
                playerSkillViewData.Add(new PlayerSkillViewModel
                {
                    PlayerId = skill.PlayerId,
                    SkillId = skill.SkillId,
                    Money = skill.Money,
                    Points = skill.Points,
                    SkillName = this.skillRepository.All().FirstOrDefault(x => x.Id == skill.SkillId).Name,
                });
            }

            // PlayerBattleRecord
            var playerBattleRecord = await this.battleRecordRepository.All().FirstOrDefaultAsync(x => x.PlayerId == player.Id);

            var viewPlayerBattleRecord = new BattleRecordViewModel
            {
                Wins = playerBattleRecord.Wins,
                Losses = playerBattleRecord.Losses,
                StolenMoney = playerBattleRecord.StolenMoney,
                PlayerId = playerBattleRecord.PlayerId,
                StealPerBattle = playerBattleRecord.StealPerBattle,
            };

            var playerData = new PlayerDataView
            {
                Id = player.Id,
                Name = player.Name,
                UserId = player.UserId,
                Experience = player.Experience,
                Class = player.Class,
                ImageName = player.ImageName,
                Health = player.Health,
                MaxHealth = player.MaxHealth,
                Energy = player.Energy,
                MaxEnergy = player.MaxEnergy,
                Money = player.Money,
                LearnPoint = player.LearnPoint,
                Level = player.Level,
                PlayerSkills = playerSkillViewData,
                BattleRecord = viewPlayerBattleRecord,
                IsStatsResetStart = player.IsStatsResetStart,
            };

            return playerData;
        }

        // Helpful method for tests.

        /// <summary>
        /// Use this method to get playerBadge model.
        /// </summary>
        /// <param name="badgeId">A integer representing the Id of the badge.</param>
        /// <returns>A model <see cref="PlayerBadge"/>.</returns>
        public async Task<PlayerBadge> GetPlayerBadgeById(int badgeId)
        {
            return await this.playerBadgeRepository.All().FirstOrDefaultAsync(x => x.BadgeId == badgeId);
        }

        /// <summary>
        /// Use this method check is player already in group.
        /// </summary>
        /// <param name="playerId">A string representing the Id of the player.</param>
        /// <returns>A bool.</returns>
        public async Task<bool> IsPlayerApplyInGroup(string playerId)
        {
            return await this.teamPlayerRepository.All().AnyAsync(x => x.PlayerId == playerId);
        }

        /// <summary>
        /// Use this method to check is user have already created a group.
        /// </summary>
        /// <param name="userId">A string representing the Id of the user.</param>
        /// <returns>A bool.</returns>
        public async Task<bool> IsUserHaveGroup(string userId)
        {
            return await this.teamRepository.All().AnyAsync(x => x.UserId == userId);
        }
    }
}
