namespace CyberWars.Web.Tests.CompetitiveCodingControllerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Web.Controllers;
    using CyberWars.Web.Tests.Extensions;
    using CyberWars.Web.Tests.Helpers;
    using CyberWars.Web.ViewModels.WebViews.CompetitiveCoding;
    using Microsoft.AspNetCore.Mvc;

    using Xunit;

    public class TestCompetitiveCodingController
    {
        [Fact]
        public async Task TestIndexAction()
        {
            var contestController = new CompetitiveCodingController(new FakeContestService())
                .WithTestUser();

            var result = await contestController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ContestViewModel>>(viewResult.Model);
        }

        [Fact]
        public async Task TestResultAction()
        {
            var contestController = new CompetitiveCodingController(new FakeContestService())
                .WithTestUser();

            var result = await contestController.Result(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ResultContestViewModel>(viewResult.Model);
        }
    }
}
