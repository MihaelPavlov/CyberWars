using System;
using System.Collections.Generic;
using System.Text;

namespace CyberWars.Services.Data.Tests.HomeServiceTests
{

    class Test
    {

    }
    //public class HomeServiceTests
    //{
    //    private Mock<IDeletableEntityRepository<ApplicationUser>> userRepository;
    //    private Mock<IDeletableEntityRepository<Player>> playerRepository;
    //    private Mock<IDeletableEntityRepository<PlayerSkill>> playerSkillRepository;
    //    private Mock<IDeletableEntityRepository<Skill>> skillRepository;
    //    private Mock<IDeletableEntityRepository<PlayerAbility>> playerAbilityRepository;
    //    private Mock<IDeletableEntityRepository<Badge>> badgeRepository;
    //    private Mock<IDeletableEntityRepository<BadgeRequirement>> badgeRequirementRepository;
    //    private Mock<IDeletableEntityRepository<PlayerPet>> playerPetRepository;
    //    private Mock<IDeletableEntityRepository<Food>> foodRepository;
    //    private Mock<IDeletableEntityRepository<Pet>> petRepository;
    //    private Mock<IDeletableEntityRepository<PlayerFood>> playerFoodRepository;
    //    private Mock<IDeletableEntityRepository<BattleRecord>> battleRecordRepository;
    //    private Mock<IDeletableEntityRepository<RandomHangfireFood>> randomHangfireFoodRepository;
    //    private Mock<IDeletableEntityRepository<PlayerBadge>> playerBadgeRepository;
    //    private Mock<IDeletableEntityRepository<TeamPlayer>> teamPlayerRepository;
    //    private Mock<IDeletableEntityRepository<Team>> teamRepository;

    //    public HomeServiceTests()
    //    {
    //        this.playerRepository = new Mock<IDeletableEntityRepository<Player>>();
    //        this.playerSkillRepository = new Mock<IDeletableEntityRepository<PlayerSkill>>();
    //        this.playerAbilityRepository = new Mock<IDeletableEntityRepository<PlayerAbility>>();
    //        this.userRepository = new Mock<IDeletableEntityRepository<ApplicationUser>>();
    //        this.badgeRepository = new Mock<IDeletableEntityRepository<Badge>>();
    //        this.badgeRequirementRepository = new Mock<IDeletableEntityRepository<BadgeRequirement>>();
    //        this.playerPetRepository = new Mock<IDeletableEntityRepository<PlayerPet>>();
    //        this.foodRepository = new Mock<IDeletableEntityRepository<Food>>();
    //        this.petRepository = new Mock<IDeletableEntityRepository<Pet>>();
    //        this.playerFoodRepository = new Mock<IDeletableEntityRepository<PlayerFood>>();
    //        this.battleRecordRepository = new Mock<IDeletableEntityRepository<BattleRecord>>();
    //        this.skillRepository = new Mock<IDeletableEntityRepository<Skill>>();
    //        this.randomHangfireFoodRepository = new Mock<IDeletableEntityRepository<RandomHangfireFood>>();
    //        this.playerBadgeRepository = new Mock<IDeletableEntityRepository<PlayerBadge>>();
    //        this.teamPlayerRepository = new Mock<IDeletableEntityRepository<TeamPlayer>>();
    //        this.teamRepository = new Mock<IDeletableEntityRepository<Team>>();
    //    }

    //    public async Task<HomeService> GetHomeService()
    //    {
    //        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    //                        .UseInMemoryDatabase("CyberWars").Options;

    //        var db = new ApplicationDbContext(options);

    //        var playerRepositoryInMemory = new EfDeletableEntityRepository<Player>(db);
    //        var playerSkillRepositoryInMemory = new EfDeletableEntityRepository<PlayerSkill>(db);
    //        var playerAbilitiesRepositoryInMemory = new EfDeletableEntityRepository<PlayerAbility>(db);
    //        var userRepositoryInMemory = new EfDeletableEntityRepository<ApplicationUser>(db);
    //        var badgeRepositoryInMemory = new EfDeletableEntityRepository<Badge>(db);
    //        var badgeRequirementsRepositoryInMemory = new EfDeletableEntityRepository<BadgeRequirement>(db);
    //        var playerPetRepositoryInMemory = new EfDeletableEntityRepository<PlayerPet>(db);
    //        var foodRepositoryInMemory = new EfDeletableEntityRepository<Food>(db);
    //        var petRepositoryInMemory = new EfDeletableEntityRepository<Pet>(db);
    //        var playerFoodRepositoryInMemory = new EfDeletableEntityRepository<PlayerFood>(db);
    //        var battleRecordRepositoryInMemory = new EfDeletableEntityRepository<BattleRecord>(db);
    //        var skillRepositoryInMemory = new EfDeletableEntityRepository<Skill>(db);
    //        var randomHangfireFoodRepositoryInMemory = new EfDeletableEntityRepository<RandomHangfireFood>(db);
    //        var playerBadgeRepositoryInMemory = new EfDeletableEntityRepository<PlayerBadge>(db);
    //        var teamPlayerRepositoryInMemory = new EfDeletableEntityRepository<TeamPlayer>(db);
    //        var teamRepositoryInMemory = new EfDeletableEntityRepository<Team>(db);

    //        var service = new HomeService(playerRepositoryInMemory, playerSkillRepositoryInMemory, playerAbilitiesRepositoryInMemory,
    //                                        userRepositoryInMemory, badgeRepositoryInMemory, badgeRequirementsRepositoryInMemory,
    //                                        playerPetRepositoryInMemory, foodRepositoryInMemory, petRepositoryInMemory,
    //                                        playerFoodRepositoryInMemory, battleRecordRepositoryInMemory, skillRepositoryInMemory,
    //                                        randomHangfireFoodRepositoryInMemory, playerBadgeRepositoryInMemory, teamPlayerRepositoryInMemory, teamRepositoryInMemory);

    //        var user = new ApplicationUser
    //        {
    //            Email = "Test",
    //            Id = "Test",
    //            PlayerId = "Test",
    //            UserName = "Test",
    //        };

    //        await userRepositoryInMemory.AddAsync(user);
    //        await userRepositoryInMemory.SaveChangesAsync();


    //        var player = new Player
    //        {
    //            Id = "Test",
    //            Name = "Test",
    //            UserId = "Test",
    //            User = user,
    //            Experience = 0,
    //            Class = "Test",
    //            ImageName = "Test",
    //            Health = 1000,
    //            MaxHealth = 1000,
    //            Energy = 100,
    //            MaxEnergy = 100,
    //            Money = 1000,
    //            LearnPoint = 0,
    //            Level = 1,
    //            IsStatsResetStart = false,
    //        };

    //        await playerRepositoryInMemory.AddAsync(player);
    //        await playerRepositoryInMemory.SaveChangesAsync();

    //        var battleRecord = new BattleRecord
    //        {
    //            Player = player,
    //            PlayerId = player.Id,
    //            Id = "TestBattleRecord",
    //            StealPerBattle = 50,
    //        };
    //        player.BattleRecord = battleRecord;
    //        playerRepositoryInMemory.Update(player);
    //        await battleRecordRepositoryInMemory.AddAsync(battleRecord);
    //        await battleRecordRepositoryInMemory.SaveChangesAsync();


    //        await skillRepositoryInMemory.AddAsync(new Skill
    //        {
    //            Name = "Firewall Defence",
    //            Description = "Increase the chanse to defence from attacks",
    //            StartMoney = 120,
    //        });

    //        await skillRepositoryInMemory.AddAsync(new Skill
    //        {
    //            Name = "Motivation",
    //            Description = "Motivation is the reason for people's action",
    //            StartMoney = 120,
    //        });

    //        await skillRepositoryInMemory.AddAsync(new Skill
    //        {
    //            Name = "Knowledge",
    //            Description = "Enhances the money of perBattle + 5",
    //            StartMoney = 120,
    //        });

    //        await skillRepositoryInMemory.AddAsync(new Skill
    //        {
    //            Name = "Staying Power",
    //            Description = "Increase the energy + 5",
    //            StartMoney = 120,
    //        });

    //        await skillRepositoryInMemory.AddAsync(new Skill
    //        {
    //            Name = "Health",
    //            Description = "Affects the amount of life + 10",
    //            StartMoney = 120,
    //        });
    //        await skillRepositoryInMemory.SaveChangesAsync();


    //        foreach (var skill in await skillRepositoryInMemory.All().ToListAsync())
    //        {
    //            var newSkill = new PlayerSkill
    //            {
    //                SkillId = skill.Id,
    //                Skill = skill,
    //                PlayerId = "Test",
    //                Player = player,
    //                Points = 0,
    //                Money = skill.StartMoney,
    //            };
    //            player.PlayerSkills.Add(newSkill);
    //            await playerSkillRepositoryInMemory.AddAsync(newSkill);
    //        }

    //        playerRepositoryInMemory.Update(player);
    //        await playerRepositoryInMemory.SaveChangesAsync();
    //        await playerSkillRepositoryInMemory.SaveChangesAsync();

    //        return service;
    //    }

    //    [Fact]
    //    public async Task GetPlayerDataTest()
    //    {
    //        var service = await this.GetHomeService();

    //        var player = await service.GetPlayerData("Test");

    //        Assert.Equal("Test", player.UserId);
    //        Assert.Equal("Test", player.Id);
    //        Assert.Equal("Test", player.Name);
    //        Assert.Equal("Test", player.ImageName);
    //        Assert.Equal("Test", player.UserId);
    //        Assert.Equal(0, player.Experience);
    //        Assert.Equal("Test", player.Class);
    //        Assert.Equal(1000, player.Health);
    //        Assert.Equal(1000, player.MaxHealth);
    //        Assert.Equal(100, player.Energy);
    //        Assert.Equal(100, player.MaxEnergy);
    //        Assert.Equal(1000, player.Money);
    //        Assert.Equal(0, player.LearnPoint);
    //        Assert.Equal(1, player.Level);
    //        Assert.Equal(1, player.Level);
    //        Assert.False(player.IsStatsResetStart, "Its need to be false");
    //    }

    //    //[Fact]
    //    //public async Task CheckIsPlayerSkillsCountEqualTo5()
    //    //{
    //    //    var service = await this.GetHomeService();

    //    //    var playerSkills = await service.GetPlayerSkills<PlayerSkillViewModel>("Test");

    //    //    Assert.Equal(5, playerSkills.Count());
    //    //}

    //    [Fact]
    //    public async Task TestIsSkillTrainUpWith1()
    //    {
    //        var service = await this.GetHomeService();

    //        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    //        .UseInMemoryDatabase("CyberWars").Options;
    //        var db = new ApplicationDbContext(options);

    //        var playerSkillRepositoryInMemory = new EfDeletableEntityRepository<PlayerSkill>(db);
    //        var skillRepositoryInMemory = new EfDeletableEntityRepository<Skill>(db);

    //        var playerSkill = await playerSkillRepositoryInMemory.All().FirstOrDefaultAsync(x => x.PlayerId == "Test" && x.Skill.Name == "Health");
    //        var skill = await skillRepositoryInMemory.All().FirstOrDefaultAsync(x => x.Name == "Health");
    //        await service.TrainSkillByName(playerSkill.PlayerId, skill.Name);

    //        Assert.Equal(1, playerSkillNew.Points);
    //    }
    //}
}
