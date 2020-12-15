namespace CyberWars.Web.Tests.HomeControllerTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Web.Controllers;
    using CyberWars.Web.Tests.Extensions;
    using CyberWars.Web.Tests.Helpers;
    using CyberWars.Web.ViewModels.HomeViews;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using Xunit;

    public class TestHomeController
    {
        [Fact]
        public async Task TestIndexActionShouldReturnPlayerDataView()
        {
            var homeController = new HomeController(new FakeHomeService())
                .WithTestUser();

            var result = await homeController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PlayerDataView>(viewResult.Model);
        }

        [Fact]
        public async Task TestSkillActionShouldReutrnPlayerSkillViewModel()
        {
            var homeController = new HomeController(new FakeHomeService());
            homeController.WithTestUser();

            var result = await homeController.Skills();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<PlayerSkillViewModel>>(viewResult.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async Task TestTrainSkillAction()
        {
            var homeController = new HomeController(new FakeHomeService()).WithTestUser();


            var result = await homeController.TrainSkill("Health");

            var viewResult = Assert.IsType<RedirectResult>(result);
        }

        [Fact]
        public async Task TestAbilitiesAction()
        {
            var homeController = new HomeController(new FakeHomeService()).WithTestUser();


            var result = await homeController.Abilities("Language");

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<PlayerAbilitiesViewModel>>(viewResult.Model);
            Assert.Equal(4, model.Count());
        }
    }
}
