namespace CyberWars.Web.Tests.AcademyControllerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Web.Controllers;
    using CyberWars.Web.Tests.Extensions;
    using CyberWars.Web.Tests.Helpers;
    using CyberWars.Web.ViewModels.Academy;
    using Microsoft.AspNetCore.Mvc;

    using Xunit;

    public class TestAcademyController
    {
        [Fact]
        public void TestIndexAction()
        {
            var acadedmyController = new AcademyController(new FakeAcademyService())
                .WithTestUser();

            var result = acadedmyController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void TestBasicAction()
        {
            var acadedmyController = new AcademyController(new FakeAcademyService())
                .WithTestUser();

            var result = acadedmyController.Basic();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestLecturesAction()
        {
            var acadedmyController = new AcademyController(new FakeAcademyService())
                .WithTestUser();

            var result = await acadedmyController.Lectures("Test");

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<LectureViewModel>>(viewResult.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async Task TestCompleteLectureAction()
        {
            var acadedmyController = new AcademyController(new FakeAcademyService())
                .WithTestUser();

            var result = await acadedmyController.CompleteLecture(1);

            var viewResult = Assert.IsType<RedirectResult>(result);
        }

        [Fact]
        public void TestLanguagesAction()
        {
            var acadedmyController = new AcademyController(new FakeAcademyService())
                .WithTestUser();

            var result = acadedmyController.Languages();

            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
