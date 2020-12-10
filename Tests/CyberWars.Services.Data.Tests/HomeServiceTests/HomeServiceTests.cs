namespace CyberWars.Services.Data.Tests.HomeServiceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Badge;
    using CyberWars.Data.Models.Battle;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Data.Models.Team;
    using CyberWars.Services.Data.Home;
    using CyberWars.Web.ViewModels.HomeViews;
    using CyberWars.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using CyberWars.Data;
    using AutoMapper;
    using CyberWars.Services.Mapping;
    using CyberWars.Services.Data.Tests.Helpers;
    using Moq;
    using Xunit;

    public class HomeServiceTests
    {
        private Mock<IDeletableEntityRepository<ApplicationUser>> userRepository;
        private Mock<IDeletableEntityRepository<Player>> playerRepository;
        private Mock<IDeletableEntityRepository<PlayerSkill>> playerSkillRepository;
        private Mock<IDeletableEntityRepository<Skill>> skillRepository;
        private Mock<IDeletableEntityRepository<PlayerAbility>> playerAbilityRepository;
        private Mock<IDeletableEntityRepository<Badge>> badgeRepository;
        private Mock<IDeletableEntityRepository<BadgeRequirement>> badgeRequirementRepository;
        private Mock<IDeletableEntityRepository<PlayerPet>> playerPetRepository;
        private Mock<IDeletableEntityRepository<Food>> foodRepository;
        private Mock<IDeletableEntityRepository<Pet>> petRepository;
        private Mock<IDeletableEntityRepository<PlayerFood>> playerFoodRepository;
        private Mock<IDeletableEntityRepository<BattleRecord>> battleRecordRepository;
        private Mock<IDeletableEntityRepository<RandomHangfireFood>> randomHangfireFoodRepository;
        private Mock<IDeletableEntityRepository<PlayerBadge>> playerBadgeRepository;
        private Mock<IDeletableEntityRepository<TeamPlayer>> teamPlayerRepository;
        private Mock<IDeletableEntityRepository<Team>> teamRepository;

        public HomeServiceTests()
        {
            this.playerRepository = new Mock<IDeletableEntityRepository<Player>>();
            this.playerSkillRepository = new Mock<IDeletableEntityRepository<PlayerSkill>>();
            this.playerAbilityRepository = new Mock<IDeletableEntityRepository<PlayerAbility>>();
            this.userRepository = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            this.badgeRepository = new Mock<IDeletableEntityRepository<Badge>>();
            this.badgeRequirementRepository = new Mock<IDeletableEntityRepository<BadgeRequirement>>();
            this.playerPetRepository = new Mock<IDeletableEntityRepository<PlayerPet>>();
            this.foodRepository = new Mock<IDeletableEntityRepository<Food>>();
            this.petRepository = new Mock<IDeletableEntityRepository<Pet>>();
            this.playerFoodRepository = new Mock<IDeletableEntityRepository<PlayerFood>>();
            this.battleRecordRepository = new Mock<IDeletableEntityRepository<BattleRecord>>();
            this.skillRepository = new Mock<IDeletableEntityRepository<Skill>>();
            this.randomHangfireFoodRepository = new Mock<IDeletableEntityRepository<RandomHangfireFood>>();
            this.playerBadgeRepository = new Mock<IDeletableEntityRepository<PlayerBadge>>();
            this.teamPlayerRepository = new Mock<IDeletableEntityRepository<TeamPlayer>>();
            this.teamRepository = new Mock<IDeletableEntityRepository<Team>>();
        }

        //public async Task<HomeService> GetHomeService()
        //{
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //                    .UseInMemoryDatabase("CyberWars").Options;

        //    var new ApplicationDbContext(options.Options) = new ApplicationDbContext(options);

        //    var playerRepositoryInMemory = new EfDeletableEntityRepository<Player>(new ApplicationDbContext(options.Options));
        //    var playerSkillRepositoryInMemory = new EfDeletableEntityRepository<PlayerSkill>(new ApplicationDbContext(options.Options));
        //    var playerAbilitiesRepositoryInMemory = new EfDeletableEntityRepository<PlayerAbility>(new ApplicationDbContext(options.Options));
        //    var userRepositoryInMemory = new EfDeletableEntityRepository<ApplicationUser>(new ApplicationDbContext(options.Options));
        //    var badgeRepositoryInMemory = new EfDeletableEntityRepository<Badge>(new ApplicationDbContext(options.Options));
        //    var badgeRequirementsRepositoryInMemory = new EfDeletableEntityRepository<BadgeRequirement>(new ApplicationDbContext(options.Options));
        //    var playerPetRepositoryInMemory = new EfDeletableEntityRepository<PlayerPet>(new ApplicationDbContext(options.Options));
        //    var foodRepositoryInMemory = new EfDeletableEntityRepository<Food>(new ApplicationDbContext(options.Options));
        //    var petRepositoryInMemory = new EfDeletableEntityRepository<Pet>(new ApplicationDbContext(options.Options));
        //    var playerFoodRepositoryInMemory = new EfDeletableEntityRepository<PlayerFood>(new ApplicationDbContext(options.Options));
        //    var battleRecordRepositoryInMemory = new EfDeletableEntityRepository<BattleRecord>(new ApplicationDbContext(options.Options));
        //    var skillRepositoryInMemory = new EfDeletableEntityRepository<Skill>(new ApplicationDbContext(options.Options));
        //    var randomHangfireFoodRepositoryInMemory = new EfDeletableEntityRepository<RandomHangfireFood>(new ApplicationDbContext(options.Options));
        //    var playerBadgeRepositoryInMemory = new EfDeletableEntityRepository<PlayerBadge>(new ApplicationDbContext(options.Options));
        //    var teamPlayerRepositoryInMemory = new EfDeletableEntityRepository<TeamPlayer>(new ApplicationDbContext(options.Options));
        //    var teamRepositoryInMemory = new EfDeletableEntityRepository<Team>(new ApplicationDbContext(options.Options));

        //    var service = new HomeService(playerRepositoryInMemory, playerSkillRepositoryInMemory, playerAbilitiesRepositoryInMemory,
        //                                    userRepositoryInMemory, badgeRepositoryInMemory, badgeRequirementsRepositoryInMemory,
        //                                    playerPetRepositoryInMemory, foodRepositoryInMemory, petRepositoryInMemory,
        //                                    playerFoodRepositoryInMemory, battleRecordRepositoryInMemory, skillRepositoryInMemory,
        //                                    randomHangfireFoodRepositoryInMemory, playerBadgeRepositoryInMemory, teamPlayerRepositoryInMemory, teamRepositoryInMemory);

        //    var user = new ApplicationUser
        //    {
        //        Email = "Test",
        //        Id = "Test",
        //        PlayerId = "Test",
        //        UserName = "Test",
        //    };

        //    await userRepositoryInMemory.AddAsync(user);
        //    await userRepositoryInMemory.SaveChangesAsync();


        //    var player = new Player
        //    {
        //        Id = "Test",
        //        Name = "Test",
        //        UserId = "Test",
        //        User = user,
        //        Experience = 0,
        //        Class = "Test",
        //        ImageName = "Test",
        //        Health = 1000,
        //        MaxHealth = 1000,
        //        Energy = 100,
        //        MaxEnergy = 100,
        //        Money = 1000,
        //        LearnPoint = 0,
        //        Level = 1,
        //        IsStatsResetStart = false,
        //    };

        //    await playerRepositoryInMemory.AddAsync(player);
        //    await playerRepositoryInMemory.SaveChangesAsync();

        //    var battleRecord = new BattleRecord
        //    {
        //        Player = player,
        //        PlayerId = player.Id,
        //        Id = "TestBattleRecord",
        //        StealPerBattle = 50,
        //    };
        //    player.BattleRecord = battleRecord;
        //    playerRepositoryInMemory.Update(player);
        //    await battleRecordRepositoryInMemory.AddAsync(battleRecord);
        //    await battleRecordRepositoryInMemory.SaveChangesAsync();


        //    await skillRepositoryInMemory.AddAsync(new Skill
        //    {
        //        Name = "Firewall Defence",
        //        Description = "Increase the chanse to defence from attacks",
        //        StartMoney = 120,
        //    });

        //    await skillRepositoryInMemory.AddAsync(new Skill
        //    {
        //        Name = "Motivation",
        //        Description = "Motivation is the reason for people's action",
        //        StartMoney = 120,
        //    });

        //    await skillRepositoryInMemory.AddAsync(new Skill
        //    {
        //        Name = "Knowledge",
        //        Description = "Enhances the money of perBattle + 5",
        //        StartMoney = 120,
        //    });

        //    await skillRepositoryInMemory.AddAsync(new Skill
        //    {
        //        Name = "Staying Power",
        //        Description = "Increase the energy + 5",
        //        StartMoney = 120,
        //    });

        //    await skillRepositoryInMemory.AddAsync(new Skill
        //    {
        //        Name = "Health",
        //        Description = "Affects the amount of life + 10",
        //        StartMoney = 120,
        //    });
        //    await skillRepositoryInMemory.SaveChangesAsync();



        //    //foreach (var skill in await skillRepositoryInMemory.All().ToListAsync())
        //    //{
        //    //    var newSkill = new PlayerSkill
        //    //    {
        //    //        SkillId = skill.Id,
        //    //        Skill = skill,
        //    //        PlayerId = "Test",
        //    //        Player = player,
        //    //        Points = 0,
        //    //        Money = skill.StartMoney,
        //    //    };
        //    //    player.PlayerSkills.Add(newSkill);
        //    //    await playerSkillRepositoryInMemory.AddAsync(newSkill);
        //    //}

        //    //playerRepositoryInMemory.Update(player);
        //    //await playerRepositoryInMemory.SaveChangesAsync();
        //    //await playerSkillRepositoryInMemory.SaveChangesAsync();

        //    return service;
        //}


        [Fact]
        public async Task TestTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());

            var playerRepositoryInMemory = new EfDeletableEntityRepository<Player>(new ApplicationDbContext(options.Options));
            var playerSkillRepositoryInMemory = new EfDeletableEntityRepository<PlayerSkill>(new ApplicationDbContext(options.Options));
            var playerAbilitiesRepositoryInMemory = new EfDeletableEntityRepository<PlayerAbility>(new ApplicationDbContext(options.Options));
            var userRepositoryInMemory = new EfDeletableEntityRepository<ApplicationUser>(new ApplicationDbContext(options.Options));
            var badgeRepositoryInMemory = new EfDeletableEntityRepository<Badge>(new ApplicationDbContext(options.Options));
            var badgeRequirementsRepositoryInMemory = new EfDeletableEntityRepository<BadgeRequirement>(new ApplicationDbContext(options.Options));
            var playerPetRepositoryInMemory = new EfDeletableEntityRepository<PlayerPet>(new ApplicationDbContext(options.Options));
            var foodRepositoryInMemory = new EfDeletableEntityRepository<Food>(new ApplicationDbContext(options.Options));
            var petRepositoryInMemory = new EfDeletableEntityRepository<Pet>(new ApplicationDbContext(options.Options));
            var playerFoodRepositoryInMemory = new EfDeletableEntityRepository<PlayerFood>(new ApplicationDbContext(options.Options));
            var battleRecordRepositoryInMemory = new EfDeletableEntityRepository<BattleRecord>(new ApplicationDbContext(options.Options));
            var skillRepositoryInMemory = new EfDeletableEntityRepository<Skill>(new ApplicationDbContext(options.Options));
            var randomHangfireFoodRepositoryInMemory = new EfDeletableEntityRepository<RandomHangfireFood>(new ApplicationDbContext(options.Options));
            var playerBadgeRepositoryInMemory = new EfDeletableEntityRepository<PlayerBadge>(new ApplicationDbContext(options.Options));
            var teamPlayerRepositoryInMemory = new EfDeletableEntityRepository<TeamPlayer>(new ApplicationDbContext(options.Options));
            var teamRepositoryInMemory = new EfDeletableEntityRepository<Team>(new ApplicationDbContext(options.Options));
            for (int i = 0; i < 3; i++)
            {
                await playerRepositoryInMemory.AddAsync(new Player
                {
                    Id = $"TestPlayer{i}",
                    Money = 1000,
                    UserId = $"Test{i}",
                    Class = "Programmer",
                });
            }
            await playerRepositoryInMemory.SaveChangesAsync();

            var homeService = new HomeService(playerRepositoryInMemory, playerSkillRepositoryInMemory, playerAbilitiesRepositoryInMemory,
                                             userRepositoryInMemory, badgeRepositoryInMemory, badgeRequirementsRepositoryInMemory,
                                             playerPetRepositoryInMemory, foodRepositoryInMemory, petRepositoryInMemory,
                                             playerFoodRepositoryInMemory, battleRecordRepositoryInMemory, skillRepositoryInMemory,
                                             randomHangfireFoodRepositoryInMemory, playerBadgeRepositoryInMemory, teamPlayerRepositoryInMemory, teamRepositoryInMemory);

            var result = await homeService.GetPlayerData("Test1");
            Assert.Equal("Test1", result.UserId);

        }


        [Fact]
        public async Task TestIsSkillTrainUpWith1()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());

            var playerRepositoryInMemory = new EfDeletableEntityRepository<Player>(new ApplicationDbContext(options.Options));
            var playerSkillRepositoryInMemory = new EfDeletableEntityRepository<PlayerSkill>(new ApplicationDbContext(options.Options));
            var playerAbilitiesRepositoryInMemory = new EfDeletableEntityRepository<PlayerAbility>(new ApplicationDbContext(options.Options));
            var userRepositoryInMemory = new EfDeletableEntityRepository<ApplicationUser>(new ApplicationDbContext(options.Options));
            var badgeRepositoryInMemory = new EfDeletableEntityRepository<Badge>(new ApplicationDbContext(options.Options));
            var badgeRequirementsRepositoryInMemory = new EfDeletableEntityRepository<BadgeRequirement>(new ApplicationDbContext(options.Options));
            var playerPetRepositoryInMemory = new EfDeletableEntityRepository<PlayerPet>(new ApplicationDbContext(options.Options));
            var foodRepositoryInMemory = new EfDeletableEntityRepository<Food>(new ApplicationDbContext(options.Options));
            var petRepositoryInMemory = new EfDeletableEntityRepository<Pet>(new ApplicationDbContext(options.Options));
            var playerFoodRepositoryInMemory = new EfDeletableEntityRepository<PlayerFood>(new ApplicationDbContext(options.Options));
            var battleRecordRepositoryInMemory = new EfDeletableEntityRepository<BattleRecord>(new ApplicationDbContext(options.Options));
            var skillRepositoryInMemory = new EfDeletableEntityRepository<Skill>(new ApplicationDbContext(options.Options));
            var randomHangfireFoodRepositoryInMemory = new EfDeletableEntityRepository<RandomHangfireFood>(new ApplicationDbContext(options.Options));
            var playerBadgeRepositoryInMemory = new EfDeletableEntityRepository<PlayerBadge>(new ApplicationDbContext(options.Options));
            var teamPlayerRepositoryInMemory = new EfDeletableEntityRepository<TeamPlayer>(new ApplicationDbContext(options.Options));
            var teamRepositoryInMemory = new EfDeletableEntityRepository<Team>(new ApplicationDbContext(options.Options));



            var player = new Player
            {
                Money = 1000,
                UserId = "Pesho",
                Class = "Programmer",
            };

            await playerRepositoryInMemory.AddAsync(player);

            await playerRepositoryInMemory.SaveChangesAsync();

            var user = new ApplicationUser
            {
                UserName = "Test",
                Id = "Pesho",
                PlayerId = player.Id,
                Email = "Test@abv.bg",
            };

            await userRepositoryInMemory.AddAsync(user);

            await userRepositoryInMemory.SaveChangesAsync();

            await skillRepositoryInMemory.AddAsync(new Skill
            {
                Name = "Firewall Defence",
                Description = "Increase the chanse to defence from attacks",
                StartMoney = 120,
            });

            await skillRepositoryInMemory.AddAsync(new Skill
            {
                Name = "Motivation",
                Description = "Motivation is the reason for people's action",
                StartMoney = 120,
            });
            await skillRepositoryInMemory.AddAsync(new Skill
            {
                Name = "Knowledge",
                Description = "Enhances the money of perBattle + 5",
                StartMoney = 120,
            });
            await skillRepositoryInMemory.AddAsync(new Skill
            {
                Name = "Staying Power",
                Description = "Increase the energy + 5",
                StartMoney = 120,
            });
            var skill = new Skill
            {
                Name = "Health",
                Description = "Affects the amount of life + 10",
                StartMoney = 120,
            };
            await skillRepositoryInMemory.AddAsync(skill);
            await skillRepositoryInMemory.SaveChangesAsync();

            var battleRecord = new BattleRecord
            {
                Losses = 0,
                Wins = 0,
                PlayerId = player.Id,
                StealPerBattle = 50,
                StolenMoney = 0,
            };

            await battleRecordRepositoryInMemory.AddAsync(battleRecord);
            await battleRecordRepositoryInMemory.SaveChangesAsync();

            var homeService = new HomeService(playerRepositoryInMemory, playerSkillRepositoryInMemory, playerAbilitiesRepositoryInMemory,
                                             userRepositoryInMemory, badgeRepositoryInMemory, badgeRequirementsRepositoryInMemory,
                                             playerPetRepositoryInMemory, foodRepositoryInMemory, petRepositoryInMemory,
                                             playerFoodRepositoryInMemory, battleRecordRepositoryInMemory, skillRepositoryInMemory,
                                             randomHangfireFoodRepositoryInMemory, playerBadgeRepositoryInMemory, teamPlayerRepositoryInMemory, teamRepositoryInMemory);
            var playerSkill = new PlayerSkill
            {
                PlayerId=player.Id,
                SkillId=skill.Id,
                Points = 1,
                Money = 0,
            };
            await playerSkillRepositoryInMemory.AddAsync(playerSkill);

            await playerSkillRepositoryInMemory.SaveChangesAsync();

            await homeService.TrainSkillByName("Pesho", "Health");

            var resultPlayerSkill = await playerSkillRepositoryInMemory.All().FirstOrDefaultAsync(x => x.Skill.Name == "Health");
            Assert.Equal(2, resultPlayerSkill.Points);
        }
    }
}
