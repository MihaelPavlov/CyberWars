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
    using CyberWars.Web.ViewModels.HomeViews.Pet;
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

        [Fact]
        public async Task TestBadgesAction()
        {
            var homeController = new HomeController(new FakeHomeService()).WithTestUser();

            var result = await homeController.Badges();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BadgesViewModel>>(viewResult.Model);
            Assert.Equal(4, model.Count());
        }

        [Fact]
        public async Task TestBadgeRequirementsAction()
        {
            var homeController = new HomeController(new FakeHomeService()).WithTestUser();

            var result = await homeController.BadgeRequirements(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BadgesViewModel>(viewResult.Model);
            Assert.Equal(3, model.BadgeRequirements.Count());
        }

        [Fact]
        public async Task TestPetsAction()
        {
            var homeController = new HomeController(new FakeHomeService()).WithTestUser();

            var result = await homeController.Pets();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<PetViewModel>>(viewResult.Model);
            Assert.Equal(4, model.Count());
        }

        [Fact]
        public async Task TestPetCardAction()
        {
            var homeController = new HomeController(new FakeHomeService()).WithTestUser();

            var result = await homeController.PetCard(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PetViewModel>(viewResult.Model);
        }

        [Fact]
        public async Task TestChangeNameAction()
        {
            var homeController = new HomeController(new FakeHomeService()).WithTestUser();

            var result = await homeController.ChangeName("Test", 1);

            var viewResult = Assert.IsType<RedirectResult>(result);
        }

        [Fact]
        public async Task TestScratchPetBellyAction()
        {
            var homeController = new HomeController(new FakeHomeService()).WithTestUser();

            var result = await homeController.ScratchPetBelly(1);

            var viewResult = Assert.IsType<RedirectResult>(result);
        }

        [Fact]
        public async Task TestSellPetAction()
        {
            var homeController = new HomeController(new FakeHomeService()).WithTestUser();

            var result = await homeController.SellPet(1);

            var viewResult = Assert.IsType<RedirectResult>(result);
        }

        [Fact]
        public async Task TestPlayerViewAction()
        {
            var homeController = new HomeController(new FakeHomeService()).WithTestUser();

            var result = await homeController.PlayerView("Test");

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PlayerDataView>(viewResult.Model);
        }
    }
}
