namespace CyberWars.Web.Tests.WebControllerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Web.Controllers;
    using CyberWars.Web.Tests.Extensions;
    using CyberWars.Web.Tests.Helpers;
    using CyberWars.Web.ViewModels.WebViews.Job;
    using Microsoft.AspNetCore.Mvc;

    using Xunit;

    public class TestWebController
    {
        [Fact]
        public void TestIndexAction()
        {
            var webController = new WebController(new FakeWebService())
                .WithTestUser();

            var result = webController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestJobAction()
        {
            var webController = new WebController(new FakeWebService())
                .WithTestUser();

            var result = await webController.Job();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<JobViewModel>>(viewResult.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async Task TestGetRewardFromJobAction()
        {
            var webController = new WebController(new FakeWebService())
                .WithTestUser();

            var result = await webController.GetRewardFromJob(1);

            var viewResult = Assert.IsType<RedirectResult>(result);
        }
    }
}
