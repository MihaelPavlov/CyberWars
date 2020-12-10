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
    using NUnit.Framework;

    //[TestFixture]
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

    //    private Mock<IHomeService> homeService;

    //    private Mock<IQueryable<Player>> mockPlayers;
    //    [SetUp]
    //    //public void Setup()
    //    //{
    //    //    this.mockPlayers = TestDataHelpers.GetTestPlayers().AsQueryable<Player>();
    //    //    this.userRepository = new Mock<IDeletableEntityRepository<ApplicationUser>>();
    //    //    this.userRepository.Setup(x => x.All()).Returns(this.mockPlayers)
    //    //}
    //}
}
