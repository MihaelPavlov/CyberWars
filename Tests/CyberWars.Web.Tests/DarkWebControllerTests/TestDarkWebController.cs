namespace CyberWars.Web.Tests.DarkWebControllerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Web.Controllers;
    using CyberWars.Web.Tests.Extensions;
    using CyberWars.Web.Tests.Helpers;
    using CyberWars.Web.ViewModels.DarkWeb;
    using Microsoft.AspNetCore.Mvc;

    using Xunit;

    public class TestDarkWebController
    {
        [Fact]
        public void TestAttackAction()
        {
            var webController = new DarkWebController(new FakeDarkWebService())
                .WithTestUser();

            var result = webController.Attack();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestSearchAction()
        {
            var webController = new DarkWebController(new FakeDarkWebService())
                .WithTestUser();

            var input = new TypeOfAttackInputModel
            {
                SearchName = "Test",
                Type = "Test",
            };

            var result = await webController.Search(input);

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestSearchFailAction()
        {
            var webController = new DarkWebController(new FakeDarkWebService())
                .WithTestUser();

            var input = new TypeOfAttackInputModel
            {
                Type = "Search",
            };

            var result = await webController.Search(input);

            var viewResult = Assert.IsType<RedirectResult>(result);
        }

        [Fact]
        public async Task TestResultAction()
        {
            var webController = new DarkWebController(new FakeDarkWebService())
                .WithTestUser();

            var input = new TypeOfAttackInputModel
            {
                Type = "Search",
            };

            var result = await webController.Result("Test");

            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
