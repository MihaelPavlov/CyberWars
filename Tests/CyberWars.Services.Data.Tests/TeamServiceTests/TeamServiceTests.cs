namespace CyberWars.Services.Data.Tests.TeamServiceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Services.Data.Tests.Helpers;
    using CyberWars.Services.Data.Tests.Helpers.TestViewModel.TeamViewModel;
    using CyberWars.Web.ViewModels.Team;
    using Xunit;

    public class TeamServiceTests
    {
        [Fact]
        public async Task TestCreateTeamShouldReturnTrue()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var registerInputModel = new RegisterTeamInputModel
            {
                Name = "GroupNameTest",
                Description = "Description Test",
                MotivationalMotto = "Welcome To our Test",
            };
            var result = await teamService.CreateTeam("Pesho", registerInputModel, "ImageTest");
            Assert.True(result);
        }

        [Fact]
        public async Task TestApplyToTeam()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var registerInputModel = new RegisterTeamInputModel
            {
                Name = "GroupNameTest",
                Description = "Description Test",
                MotivationalMotto = "Welcome To our Test",
            };
            var result = await teamService.CreateTeam("Pesho", registerInputModel, "ImageTest");
            Assert.True(result);

            var teamId = await teamService.GetTeamIdByUserId("Pesho");

            await teamService.ApplyToTeam("Test", teamId);

            var team = await teamService.GetTeamPageById(teamId);

            Assert.Single(team.TeamPlayers);
        }

        [Fact]
        public async Task TestGet10RandomTeam()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var registerInputModel = new RegisterTeamInputModel
            {
                Name = "GroupNameTest",
                Description = "Description Test",
                MotivationalMotto = "Welcome To our Test",
            };
            var result = await teamService.CreateTeam("Pesho", registerInputModel, "ImageTest");

            Assert.True(result);

            var registerInputModel1 = new RegisterTeamInputModel
            {
                Name = "Test2",
                Description = "Description Test",
                MotivationalMotto = "Welcome To our Test",
            };

            var result1 = await teamService.CreateTeam("Test", registerInputModel1, "ImageTest");

            Assert.True(result1);

            var teams = await teamService.Get10RandomTeam<TestTeamViewModel>();
            Assert.Equal(2, teams.Count());
        }

        [Fact]
        public async Task TestGetTeamNameById()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var registerInputModel = new RegisterTeamInputModel
            {
                Name = "GroupNameTest",
                Description = "Description Test",
                MotivationalMotto = "Welcome To our Test",
            };
            var result = await teamService.CreateTeam("Pesho", registerInputModel, "ImageTest");

            Assert.True(result);

            var teamId = await teamService.GetTeamIdByUserId("Pesho");

            var team = await teamService.GetTeamNameById(teamId);

            Assert.Equal("GroupNameTest", team);
        }

        [Fact]
        public async Task TestIsUserHaveTeam()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var isUserHaveTeam = teamService.IsUserHaveTeam("Pesho");

            Assert.False(isUserHaveTeam);
        }

        [Fact]
        public async Task TestIsPlayerAlreadyApplyToTeam()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var isUserHaveTeam = await teamService.IsPlayerAlreadyApplyToTeam("Pesho");

            Assert.False(isUserHaveTeam);
        }

        [Fact]
        public async Task TestLeaveGroup()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var registerInputModel = new RegisterTeamInputModel
            {
                Name = "GroupNameTest",
                Description = "Description Test",
                MotivationalMotto = "Welcome To our Test",
            };
            var result = await teamService.CreateTeam("Pesho", registerInputModel, "ImageTest");
            Assert.True(result);

            var teamId = await teamService.GetTeamIdByUserId("Pesho");

            await teamService.ApplyToTeam("Test", teamId);

            var team = await teamService.GetTeamPageById(teamId);

            Assert.Single(team.TeamPlayers);

            await teamService.LeaveGroup("Test", teamId);

            var teamAfter = await teamService.GetTeamPageById(teamId);

            Assert.Empty(teamAfter.TeamPlayers);
        }

        [Fact]
        public async Task TestAbandon()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var registerInputModel = new RegisterTeamInputModel
            {
                Name = "GroupNameTest",
                Description = "Description Test",
                MotivationalMotto = "Welcome To our Test",
            };
            var result = await teamService.CreateTeam("Pesho", registerInputModel, "ImageTest");
            Assert.True(result);
            var teamId = await teamService.GetTeamIdByUserId("Pesho");

            await teamService.Abandon(teamId, "ImageTest");
            var teams = await teamService.Get10RandomTeam<TestTeamViewModel>();

            Assert.Empty(teams);
        }

        [Fact]
        public async Task TestGetTeamCount()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var registerInputModel = new RegisterTeamInputModel
            {
                Name = "GroupNameTest",
                Description = "Description Test",
                MotivationalMotto = "Welcome To our Test",
            };
            var result = await teamService.CreateTeam("Pesho", registerInputModel, "ImageTest");
            Assert.True(result);

            var teamCount = await teamService.GetTeamCount();

            Assert.Equal(1, teamCount);
        }

        [Fact]
        public async Task TestSearchTeamByName()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var registerInputModel = new RegisterTeamInputModel
            {
                Name = "GroupNameTest",
                Description = "Description Test",
                MotivationalMotto = "Welcome To our Test",
            };
            var result = await teamService.CreateTeam("Pesho", registerInputModel, "ImageTest");
            Assert.True(result);

            var team = await teamService.SearchTeamByName("GroupNameTest");

            Assert.Equal("GroupNameTest", team.Name);
        }

        [Fact]
        public async Task TestIsTeamUsernameAlreadyUse()
        {
            var teamService = await TestDataHelpers.GetTeamService();

            var registerInputModel = new RegisterTeamInputModel
            {
                Name = "GroupNameTest",
                Description = "Description Test",
                MotivationalMotto = "Welcome To our Test",
            };
            var result = await teamService.CreateTeam("Pesho", registerInputModel, "ImageTest");
            Assert.True(result);

            var isTeamUsernameAlreadyUse = await teamService.IsTeamUsernameAlreadyUse("GroupNameTest");

            Assert.True(isTeamUsernameAlreadyUse);
        }
    }
}
