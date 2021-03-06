﻿namespace CyberWars.Services.Data.Tests.HomeServiceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Services.Data.Tests.Helpers;
    using CyberWars.Services.Data.Tests.Helpers.TestViewModel;
    using Xunit;

    public class HomeServiceTests
    {
        [Fact]
        public async Task TestGetPlayerDataAsync()
        {
            var homeService = await TestDataHelpers.GetHomeService();
            var result = await homeService.GetPlayerData("Test");
            Assert.Equal("Test", result.UserId);
        }

        [Fact]
        public async Task TestTrainSkillByNameAsync()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            await homeService.TrainSkillByName("Pesho", "Health");

            var resultPlayerSkill = await homeService.GetPlayerSkillByName("Health", "Pesho");
            Assert.Equal(2, resultPlayerSkill.Points);
        }

        [Fact]
        public async Task TestTrainSkillByNameIsHealthScaleRight()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            await homeService.TrainSkillByName("Pesho", "Health");

            var resultPlayer = await homeService.GetPlayerData("Pesho");
            Assert.Equal(1010, resultPlayer.MaxHealth);
        }

        [Fact]
        public async Task TestTrainSkillByNameIsEnergyScaleRight()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            await homeService.TrainSkillByName("Pesho", "Staying Power");

            var resultPlayer = await homeService.GetPlayerData("Pesho");
            Assert.Equal(105, resultPlayer.MaxEnergy);
        }

        [Fact]
        public async Task TestTrainSkillByNameIsMoneyPerBatlleScaleRight()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            await homeService.TrainSkillByName("Pesho", "Cunning");

            var resultBattleRecord = await homeService.GetPlayerBattleRecordByPlayerName("PlayerPesho");
            Assert.Equal(55, resultBattleRecord.StealPerBattle);
        }

        [Fact]
        public async Task TestGetPlayerSkillsByUserId()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var result = await homeService.GetPlayerSkills<TestPlayerSkillViewModel>("Pesho");

            Assert.Equal(5, result.Count());
        }

        [Fact]
        public async Task TestGetUserById()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var result = await homeService.GetUserById("Pesho");

            Assert.Equal("Pesho", result.Id);
        }

        [Fact]
        public async Task TestGetPlayerAbilitiesByTypeLanguages()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var abilityType = "Languages";

            var player = await homeService.GetPlayerData("Pesho");

            var result = await homeService.GetPlayerAbilitiesByType<TestPlayerAbilityViewModel>(player.Id, abilityType);

            Assert.Equal(6, result.Count());
        }

        [Fact]
        public async Task TestGetPlayerAbilitiesByTypeDatabase()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var abilityType = "Database";

            var player = await homeService.GetPlayerData("Pesho");

            var result = await homeService.GetPlayerAbilitiesByType<TestPlayerAbilityViewModel>(player.Id, abilityType);

            Assert.Equal(6, result.Count());
        }

        [Fact]
        public async Task TestGetPlayerAbilitiesByTypeFrameworks()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var abilityType = "Frameworks";

            var player = await homeService.GetPlayerData("Pesho");

            var result = await homeService.GetPlayerAbilitiesByType<TestPlayerAbilityViewModel>(player.Id, abilityType);

            Assert.Equal(7, result.Count());
        }

        [Fact]
        public async Task TestGetAllBagdes()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var result = await homeService.GetAllBadges<TestBadgeViewModel>();

            Assert.Equal(3, result.Count());
        }

        //[Fact]
        //public async Task TestGetAllRequirementForBadgeById()
        //{
        //    var homeService = await TestDataHelpers.GetHomeService();

        //    var resultAllBadges = await homeService.GetAllBadges<TestBadgeViewModel>();

        //    var result = await homeService.GetAllRequirementForBadgeById(resultAllBadges.FirstOrDefault(x => x.Name == "Student Developer").Id);

        //    Assert.Equal(4, result.BadgeRequirements.Count());
        //}

        [Fact]
        public async Task TestGetPlayerPets()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var result = await homeService.GetPlayerPets<TestPlayerPetViewModel>("Pesho");
            Assert.Single(result);
        }

        [Fact]
        public async Task TestGetPlayerRandomFood()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var result = await homeService.GetPetRandomFood<TestFoodViewModel>(1);
            Assert.Equal(2, result.Count());
        }

        //[Fact]
        //public async Task TestGetPetById()
        //{
        //    var homeService = await TestDataHelpers.GetHomeService();
        //    var player = await homeService.GetPlayerData("Pesho");

        //    var result = await homeService.GetPetById("Pesho", 1);
        //    Assert.Equal(1, result.PetId);
        //    Assert.Equal(player.Id, result.PlayerId);
        //}

        //[Fact]
        //public async Task TestFeedPetById()
        //{
        //    var homeService = await TestDataHelpers.GetHomeService();

        //    await homeService.FeedPetById(3, 1, "Pesho");

        //    var result = await homeService.GetPetById("Pesho", 1);

        //    Assert.Equal(100, result.Health);
        //}

        //[Fact]
        //public async Task TestFeedPetByIdWithFavouriteFood()
        //{
        //    var homeService = await TestDataHelpers.GetHomeService();

        //    await homeService.FeedPetById(1, 1, "Pesho");

        //    var result = await homeService.GetPetById("Pesho", 1);

        //    Assert.Equal(95, result.Health);
        //    Assert.Equal(60, result.Mood);
        //}

        //[Fact]
        //public async Task TestChangePetName()
        //{
        //    var homeService = await TestDataHelpers.GetHomeService();

        //    await homeService.ChangePetName("TestCat", 1, "Pesho");
        //    var result = await homeService.GetPetById("Pesho", 1);

        //    Assert.Equal("TestCat", result.NameIt);
        //}

        //[Fact]
        //public async Task TestScratchPetBelly()
        //{
        //    var homeService = await TestDataHelpers.GetHomeService();

        //    await homeService.ScratchPetBelly(1, "Pesho");
        //    var result = await homeService.GetPetById("Pesho", 1);

        //    Assert.Equal(90, result.Mood);
        //}

        [Fact]
        public async Task TestSellPetById()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            await homeService.SellPetById(1, "Pesho");
            var result = await homeService.GetPlayerPets<TestPlayerPetViewModel>("Pesho");

            Assert.Empty(result);
        }

        [Fact]
        public async Task TestSellPetByIdAndGetMoneyBack()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var player = await homeService.GetPlayerData("Pesho");

            Assert.Equal(1000, player.Money);

            await homeService.SellPetById(1, "Pesho");
            var result = await homeService.GetPlayerPets<TestPlayerPetViewModel>("Pesho");

            var playerAfterSellPet = await homeService.GetPlayerData("Pesho");

            Assert.Empty(result);
            Assert.Equal(1200, playerAfterSellPet.Money);
        }

        [Fact]
        public async Task TestGetPlayerViewData()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var player = await homeService.GetPlayerViewData("PlayerPesho");

            Assert.NotNull(player.BattleRecord);
            Assert.NotNull(player.PlayerSkills);
            Assert.Equal(5, player.PlayerSkills.Count());
            Assert.Equal("PlayerPesho", player.Name);
        }

        [Fact]
        public async Task TestCompleteBadge()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var playerBadge = await homeService.GetPlayerBadgeById(1);

            Assert.Null(playerBadge);

            await homeService.CompleteBadge(1, "Pesho");

            var playerBadgeCompletes = await homeService.GetPlayerBadgeById(1);

            Assert.NotNull(playerBadgeCompletes);
            Assert.Equal(1, playerBadgeCompletes.BadgeId);
        }

        [Fact]
        public async Task TestIsPlayerApplyInGroup()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var player = await homeService.GetPlayerData("Pesho");

            var isPlayerInGroup = await homeService.IsPlayerApplyInGroup(player.Id);

            Assert.False(isPlayerInGroup);
        }

        [Fact]
        public async Task TestIsUserHaveGroup()
        {
            var homeService = await TestDataHelpers.GetHomeService();

            var isPlayerInGroup = await homeService.IsUserHaveGroup("Pesho");

            Assert.False(isPlayerInGroup);
        }
    }
}
